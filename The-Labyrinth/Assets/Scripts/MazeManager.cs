using UnityEngine;
using UnityEngine.Events;

using System.Collections;
using System.Collections.Generic;

public class MazeManager : MonoBehaviour
{
    // References
    //

    // Prefabs
    public MazeCell cellPrefab;    

    // Public Members
    public int MazeSizeX
    {
        get
        {
            int result = 0;
            if (mazeInstance != null)
            {
                result = mazeInstance.GetLength(0);
            }
            return result;
        }
    }
    public int MazeSizeZ
    {
        get
        {
            int result = 0;
            if (mazeInstance != null)
            {
                result = mazeInstance.GetLength(1);
            }
            return result;
        }
    }

    // Private Members
    private UnityAction handleEventRenderMaze;
    private UnityAction handleEventShowMazeSolution;
    private UnityAction handleEventHideMazeSolution;
    private UnityAction handleEventShowMazeHint;
    private UnityAction handleEventResetMaze;

    private MazeCell[,] mazeInstance = null;

    void Awake()
    {
        // Initialize Event Handlers
        handleEventRenderMaze = new UnityAction(EventHandleRenderMaze);
        handleEventShowMazeSolution = new UnityAction(EventHandleShowMazeSolution);
        handleEventHideMazeSolution = new UnityAction(EventHandleHideMazeSolution);
        handleEventShowMazeHint = new UnityAction(EventHandlerShowMazeHint);
        handleEventResetMaze = new UnityAction(ResetMaze);
    }

    void OnEnable()
    {
        EventManager.StartListening("RenderMaze", handleEventRenderMaze);        
        EventManager.StartListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StartListening("HideMazeSolution", handleEventHideMazeSolution);
        EventManager.StartListening("ShowMazeHint", handleEventShowMazeHint);
        EventManager.StartListening("ResetMaze", handleEventResetMaze);
    }

    void OnDisable()
    {
        EventManager.StopListening("RenderMaze", handleEventRenderMaze);
        EventManager.StopListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StopListening("HideMazeSolution", handleEventHideMazeSolution);
        EventManager.StopListening("ShowMazeHint", handleEventShowMazeHint);
        EventManager.StopListening("ResetMaze", handleEventResetMaze);
    }

    public void EventHandleRenderMaze()
    {
        Debug.Log("MazeManager: Event Handler RenderMaze Method Called!");

        RenderMaze(GameContext.m_context.m_activeMaze);
    }

    public void EventHandleShowMazeSolution()
    {
        Debug.Log("MazeManager: Event Handler ShowMazeSolution Method Called!");

        ShowMazeSolution();
    }

    public void EventHandleHideMazeSolution()
    {
        Debug.Log("MazeManager: Event Handler HideMazeSolution Method Called!");

        HideMazeSolution();
    }

    public void EventHandlerShowMazeHint()
    {
        int posX = GameContext.m_context.m_currentPlayerMazePositionX;
        int posZ = GameContext.m_context.m_currentPlayerMazePositionZ;        
        
        // Determine the hint direction based on the first two hint solution path cells
        MazeStructure.Cell2D.CellDirectionEnum direction = GameContext.m_context.m_activeMazeSolutionPath[0].DirectionToCell(GameContext.m_context.m_activeMazeSolutionPath[1]);

        mazeInstance[posX, posZ].ShowCellHint(direction);
    }

    public void EventHandleResetMaze()
    {
        Debug.Log("MazeManager: Event Handler ResetMaze Method Called!");

        ResetMaze();
    }

    // Other Methods

    /// <summary>
    /// Renders the defined maze structure
    /// </summary>
    /// <param name="maze">The defined maze structure to render</param>
    public void RenderMaze(MazeStructure.Maze2D maze)
    {
        if (maze != null &&
           !maze.IsNull())
        {
            // Ensure only one maze instance is ever rendered at a time 
            if (mazeInstance != null)
            {
                ResetMaze();
            }


            // Initialize Maze Storage elements            
            mazeInstance = new MazeCell[maze.SizeX, maze.SizeZ];

            // Render Maze Structure
            for (int x = 0; x < maze.SizeX; ++x)
            {
                for (int z = 0; z < maze.SizeZ; ++z)
                {
                    // Get the Cell Structure Blueprint for the Cell
                    MazeStructure.Cell2D cell = maze.GetCell(x, z);

                    // Build Maze Cell from the CellStructure Blueprint
                    mazeInstance[x, z] = Instantiate(cellPrefab, transform) as MazeCell;
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kLeft]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kLeft); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kRight]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kRight); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kFront]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kFront); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kBack]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kBack); };
                    if (cell.HasAllWalls()) { mazeInstance[x, z].BuildCellCeiling(); }

                    // Position the Maze Cell
                    mazeInstance[x, z].transform.localPosition = new Vector3(x, 0, z);

                    // Set Cell Properties
                    // - Cell Type
                    // - Cell is part of the maze solution

                    // Set Cell Type property
                    switch (cell.CellType)
                    {
                        case MazeStructure.Cell2D.CellTypeEnum.kStandardCell:
                            {
                                mazeInstance[x, z].CellType = MazeCell.CellTypeEnum.kStandard;
                                break;
                            }
                        case MazeStructure.Cell2D.CellTypeEnum.kStartCell:
                            {
                                // Start Cell:
                                // - Add Start Cell Behavior to Cell
                                // - Instantiate Player GameObject and position in Maze

                                mazeInstance[x, z].CellType = MazeCell.CellTypeEnum.kStart;

                                break;
                            }
                        case MazeStructure.Cell2D.CellTypeEnum.kEndCell:
                            {
                                // End Cell:
                                // - Add End Cell Behavior to Cell

                                mazeInstance[x, z].CellType = MazeCell.CellTypeEnum.kEnd;

                                break;
                            }
                        default:
                            {
                                break;
                            }
                    };
                }
            }
        }

        // Publish Event: RenderMazeCompleted
        EventManager.TriggerEvent("RenderMazeCompleted");
    }

    /// <summary>
    /// Show the maze solution path defined in the GameContext
    /// </summary>
    public void ShowMazeSolution()
    {
        foreach(MazeStructure.Cell2D cell in GameContext.m_context.m_activeMazeSolutionPath)
        {
            mazeInstance[cell.PositionX, cell.PositionZ].ShowSolutionCell();
        }
    }

    /// <summary>
    /// Hide the entire maze solution path
    /// </summary>
    public void HideMazeSolution()
    {
        foreach (MazeStructure.Cell2D cell in GameContext.m_context.m_activeMazeSolutionPath)
        {
            mazeInstance[cell.PositionX, cell.PositionZ].HideSolutionCell();
        }
    }

    /// <summary>
    /// Resets the maze instance destroying all maze GameObjects
    /// </summary>
    public void ResetMaze()
    {
        // Reset Maze Instance
        if (mazeInstance != null)
        {
            for (int x = 0; x < MazeSizeX; ++x)
            {
                for (int z = 0; z < MazeSizeZ; ++z)
                {
                    DestroyImmediate(mazeInstance[x, z].gameObject);
                }
            }

            mazeInstance = null;
        }       
    }
}
