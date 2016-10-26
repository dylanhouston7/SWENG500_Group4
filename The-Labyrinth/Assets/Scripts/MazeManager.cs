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
    public MazeHint mazeHintPrefab;

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

    public int MazeSolutionSize
    {
        get
        {
            int result = 0;
            if(mazeSolution != null)
            {
                result = mazeSolution.Count;
            }

            return result;
        }
    }        

    // Private Members
    private UnityAction handleEventRenderMaze;
    private UnityAction handleEventShowMazeSolution;
    private UnityAction handleEventMazeHintRequest;
    private UnityAction handleEventResetMaze;

    private MazeCell[,] mazeInstance = null;
    private List<MazeCell> mazeSolution = null;

    void Awake()
    {
        // Initialize Event Handlers
        handleEventRenderMaze = new UnityAction(EventHandleRenderMaze);
        handleEventShowMazeSolution = new UnityAction(EventHandleShowMazeSolution);
        handleEventMazeHintRequest = new UnityAction(EventHandlerMazeHintRequest);
        handleEventResetMaze = new UnityAction(ResetMaze);
    }

    void OnEnable()
    {
        EventManager.StartListening("RenderMaze", handleEventRenderMaze);        
        EventManager.StartListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StartListening("MazeHintRequest", handleEventMazeHintRequest);
        EventManager.StartListening("ResetMaze", handleEventResetMaze);
    }

    void OnDisable()
    {
        EventManager.StopListening("RenderMaze", handleEventRenderMaze);
        EventManager.StopListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StopListening("MazeHintRequest", handleEventMazeHintRequest);
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

    public void EventHandlerMazeHintRequest()
    {
        // Get the current maze cell the player is on
        int posX = GameContext.m_context.m_currentPlayerMazePositionX;
        int posZ = GameContext.m_context.m_currentPlayerMazePositionZ;

        // Instantiate a new Maze Hint and position it over the current maze cell
        MazeHint hint = Instantiate(mazeHintPrefab, mazeInstance[posX, posZ].transform) as MazeHint;
        hint.transform.localPosition = new Vector3(0.0f, 0.01f, 0.0f);
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
            mazeSolution = new List<MazeCell>();

            // Render Maze Structure
            for (int x = 0; x < maze.SizeX; ++x)
            {
                for (int z = 0; z < maze.SizeZ; ++z)
                {
                    // Get the Cell Structure Blueprint for the Cell
                    MazeStructure.Cell2D cell = maze.GetCell(x, z);

                    // Build Maze Cell from the CellStructure Blueprint
                    mazeInstance[x, z] = Instantiate(cellPrefab, transform) as MazeCell;
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kLeft]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kLeft); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kRight]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kRight); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kFront]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kFront); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kBack]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kBack); };
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

                    // Set Cell IsSolution property
                    mazeInstance[x, z].IsSolutionCell = cell.IsSolutionCell;


                    // Store References to the Maze Solution Cells
                    if (mazeInstance[x, z].IsSolutionCell)
                    {
                        mazeSolution.Add(mazeInstance[x, z]);
                    }
                }
            }
        }

        // Publish Event: RenderMazeCompleted
        EventManager.TriggerEvent("RenderMazeCompleted");
    }

    /// <summary>
    /// Show the entire maze solution
    /// </summary>
    public void ShowMazeSolution()
    {
        if(mazeSolution != null)
        {
            foreach (MazeCell cell in mazeSolution)
            {
                cell.ShowSolutionCell();
            }
        }
    }

    /// <summary>
    /// Show a specific portion of the maze solution
    /// </summary>
    /// <param name="startSolutionCellIndex">The start index of the maze solution to begin at inclusively</param>
    /// <param name="endSolutionCellIndex">The end index of the maze solution to end at inclusively</param>
    public void ShowMazeSolution(int startSolutionCellIndex, int endSolutionCellIndex)
    {
        if (mazeSolution != null &&
           startSolutionCellIndex >= 0 &&
           startSolutionCellIndex < MazeSolutionSize &&
           endSolutionCellIndex >= 0 &&
           endSolutionCellIndex < MazeSolutionSize)
        {
            for (int index = startSolutionCellIndex; index <= endSolutionCellIndex; ++index)
            {
                mazeSolution[index].ShowSolutionCell();
            }
        }
    }

    /// <summary>
    /// Resets the maze instance and solution destroying all maze GameObjects
    /// </summary>
    public void ResetMaze()
    {
        // Reset Maze Instance Solution
        if (mazeSolution != null)
        {
            mazeSolution.Clear();

            mazeSolution = null;
        }

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
