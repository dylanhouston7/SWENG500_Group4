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
    //public Player playerPrefab;

    // Public Members
    public int MazeSizeX
    {
        get
        {
            int result = -1;
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
            int result = -1;
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
    private UnityAction handleEventResetMaze;
    private MazeCell[,] mazeInstance = null;
    private Player playerInstance = null;

    void Awake()
    {
        // Initialize Event Handlers
        handleEventRenderMaze = new UnityAction(RenderMaze);
        handleEventShowMazeSolution = new UnityAction(ShowMazeSolution);
        handleEventResetMaze = new UnityAction(ResetMaze);
    }

    void OnEnable()
    {
        EventManager.StartListening("RenderMaze", handleEventRenderMaze);
        EventManager.StartListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StartListening("ResetMaze", handleEventResetMaze);
    }

    void OnDisable()
    {
        EventManager.StopListening("RenderMaze", handleEventRenderMaze);
        EventManager.StopListening("ResetMaze", handleEventResetMaze);
    }

    // Other Methods
    public void RenderMaze()
    {
        Debug.Log("MazeManager: RenderMaze Method Called!");

        // Render Maze Structure
        mazeInstance = new MazeCell[GameContext.m_context.m_currentMaze.SizeX, GameContext.m_context.m_currentMaze.SizeZ];
        for (int x = 0; x < GameContext.m_context.m_currentMaze.SizeX; ++x)
        {
            for (int z = 0; z < GameContext.m_context.m_currentMaze.SizeZ; ++z)
            {
                // Get the Cell Structure Blueprint for the Cell
                MazeStructure.Cell2D cell = GameContext.m_context.m_currentMaze.GetCell(x, z);

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

                            //InstantiatePlayerGameObject(new Vector3(cell.PositionX, 0.5f, cell.PositionZ));

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
            }
        }

        // Publish Event: RenderMazeCompleted
        EventManager.TriggerEvent("RenderMazeCompleted");
    }

    public void ShowMazeSolution()
    {
        Debug.Log("MazeManager: ShowMazeSolution Method Called!");

        foreach(MazeStructure.Cell2D cell in GameContext.m_context.m_currentMaze.MazeSolutionPath)
        {
            mazeInstance[cell.PositionX, cell.PositionZ].ShowSolutionCell();
        }
    }

    public void ResetMaze()
    {
        Debug.Log("MazeManager: ResetMaze Method Called!");

        if(mazeInstance != null)
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

    //void InstantiatePlayerGameObject(
    //Vector3 startPosition
    //)
    //{
    //    // Ensure there is only ever one Player GameObject            
    //    if (playerInstance != null)
    //    {
    //        Destroy(playerInstance.gameObject);
    //    }

    //    // Position Player GameObject
    //    playerInstance = Instantiate(playerPrefab, transform) as Player;
    //    playerInstance.transform.localPosition = startPosition;
    //}
}
