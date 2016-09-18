using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

    public MazeCell cellPrefab;

    public int sizeX, sizeZ;
    public string mazeGenAlgorithm;    


    private MazeCell[,] cellInstances;
    private Player playerInstance;

	// Use this for initialization
	void Start () {

        // Get a default maze structure of defined size
        MazeStructure.Maze2D maze = MazeStructure.Maze2D.GetInstance(sizeZ, sizeX);

        // Modify the default maze structure with the chosen maze generation algorithm
        if(mazeGenAlgorithm == "Straight")
        {
            MazeStructure.StraightMazeGenerator.Generate(maze);
        }
        else if(mazeGenAlgorithm == "DepthFirstSearch")
        {
            MazeStructure.DepthFirstSearchMazeGenerator.Generate(maze);
        }
        else
        {            
            // Default Maze Generator
            MazeStructure.StraightMazeGenerator.Generate(maze);
        }
        

        // Render the resulting maze structure
        cellInstances = new MazeCell[maze.SizeX, maze.SizeZ];
        for(int x = 0; x < maze.SizeX; ++x)
        {
            for(int z = 0; z < maze.SizeZ; ++z)
            {
                // Get the Blueprint for the Cell
                MazeStructure.Cell2D cell = maze.GetCell(x, z);

                // Build Maze Cell from the Blueprint
                cellInstances[x, z] = Instantiate(cellPrefab, transform) as MazeCell;
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kLeft]) { cellInstances[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kLeft); };
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kRight]) { cellInstances[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kRight); };
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kFront]) { cellInstances[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kFront); };
                if (cell.Walls[(int)MazeStructure.Cell2D.CellWallEnum.kBack]) { cellInstances[x, z].BuildCellWall(MazeStructure.Cell2D.CellWallEnum.kBack); };
                if (cell.HasAllWalls()) { cellInstances[x, z].BuildCellCeiling(); }

                // Position the Maze Cell
                cellInstances[x, z].transform.localPosition = new Vector3(x, 0, z);

                // Handle Start Cell
                if(cell.CellType == MazeStructure.Cell2D.CellTypeEnum.kStartCell)
                {
                    // TODO: Change Cell Floor Material                    

                    // TODO: Instantiate Player GameObject and position at the Maze start cell
                }
            }
        }
	}
}
