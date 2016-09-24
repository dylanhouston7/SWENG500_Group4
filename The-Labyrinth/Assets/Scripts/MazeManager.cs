using UnityEngine;
using System.Collections;

public class MazeManager : MonoBehaviour
{
    // References
    public GameManager refGameManager = null;

    // Prefabs
    public MazeCell cellPrefab;
    public Player playerPrefab;

    // Public Members
    // 

    // Private Members
    private MazeCell[,] mazeInstance = null;
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

    private Player playerInstance = null;

    void Update()
    {        
        // TODO: Temp Code Until Event Messaging is Implemented
        if(mazeInstance == null && refGameManager.mazeStructure != null)
        {            
            RenderMaze();
        }
    }


    // Other Methods
    public void RenderMaze()
    {
        Debug.Log("Rendering Maze");

        // Render Maze Structure
        mazeInstance = new MazeCell[refGameManager.mazeStructure.SizeX, refGameManager.mazeStructure.SizeZ];
        for (int x = 0; x < refGameManager.mazeStructure.SizeX; ++x)
        {
            for (int z = 0; z < refGameManager.mazeStructure.SizeZ; ++z)
            {
                // Get the Cell Structure Blueprint for the Cell
                MazeStructure.Cell2D cell = refGameManager.mazeStructure.GetCell(x, z);

                // Build Maze Cell from the CellStructure Blueprint
                mazeInstance[x, z] = Instantiate(cellPrefab, transform) as MazeCell;
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kLeft]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kLeft); };
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kRight]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kRight); };
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kFront]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kFront); };
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kBack]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kBack); };
                if (cell.HasAllWalls()) { mazeInstance[x, z].BuildCellCeiling(); }

                // Position the Maze Cell
                mazeInstance[x, z].transform.localPosition = new Vector3(x, 0, z);

                // Cell Type
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

                            InstantiatePlayerGameObject(new Vector3(cell.PositionX, 0.5f, cell.PositionZ));

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

    public void RestMaze()
    {
        for (int x = 0; x < MazeSizeX; ++x)
        {
            for (int z = 0; z < MazeSizeZ; ++z)
            {
                Destroy(mazeInstance[x, z]);
            }
        }
    }

    void InstantiatePlayerGameObject(
    Vector3 startPosition
    )
    {
        // Ensure there is only ever one Player GameObject            
        if (playerInstance != null)
        {
            Destroy(playerInstance.gameObject);
        }

        // Position Player GameObject
        playerInstance = Instantiate(playerPrefab, transform) as Player;
        playerInstance.transform.localPosition = startPosition;
    }
}
