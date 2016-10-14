using System;
using System.Collections.Generic;

namespace MazeStructure
{
    public class MazeGenerator
    {
        public enum MazeGenAlgorithmEnum
        {
            kStraight,
            kDepthFirstSearch
        };

        public static void Generate(
            MazeGenAlgorithmEnum mazeGenAlgorithm,
            Maze2D maze
            )
        {
            switch(mazeGenAlgorithm)
            {
                case MazeGenAlgorithmEnum.kStraight:
                    {
                        StraightMazeGenerator.Generate(maze);
                        break;
                    }
                case MazeGenAlgorithmEnum.kDepthFirstSearch:
                    {
                        DepthFirstSearchMazeGenerator.Generate(maze);
                        break;
                    }
                default:
                    {
                        maze = new NullMaze();
                        break;
                    }
            };
        }

        class StraightMazeGenerator
        {
            public static void Generate(Maze2D maze)
            {
                if (!maze.IsNull())
                {
                    int maze_size = maze.SizeX;
                    int maze_center = maze_size / 2;
                    Cell2D cell = maze.GetCell(maze_center, 0);

                    // Set Start Cell
                    cell.CellType = Cell2D.CellTypeEnum.kStartCell;

                    // Remove cell walls between all cells down the Center of the Maze
                    while (true)
                    {
                        cell.RemoveWall(maze.GetCell(maze_center, cell.PositionZ + 1));

                        Cell2D nextCell = maze.GetCell(maze_center, cell.PositionZ + 1);
                        if (!nextCell.IsNull())
                        {
                            cell = nextCell;
                        }
                        else
                        {
                            // Set End Cell
                            cell.CellType = Cell2D.CellTypeEnum.kEndCell;

                            // End Maze Generation Algorithm
                            break;
                        }
                    }
                }
                else
                {
                    // No Op
                }
            }
        }

        class DepthFirstSearchMazeGenerator
        {
            public static void Generate(Maze2D maze)
            {
                if (!maze.IsNull())
                {
                    // Setup:
                    Random rand = new Random();
                    Stack<Cell2D> cellStack = new Stack<Cell2D>();
                    int numCells = maze.SizeX * maze.SizeZ;

                    // Step 1a: Random Selection of Starting Cell along X-axis
                    Cell2D startCell = maze.GetCell(rand.Next(0, maze.SizeX), 0);
                    startCell.CellType = Cell2D.CellTypeEnum.kStartCell;

                    // Step 1b: End Cell Determination setup
                    int mazePathLength = -1;
                    Cell2D endCell = new NullCell();

                    // Step 2: Apply Algorithm until all cells have been visited
                    Cell2D currentCell = startCell;

                    int numVisitedCells = 1;
                    while (numVisitedCells < numCells)
                    {
                        // Find Current Cell's adjancent cells with all walls
                        List<int> cellIndices = new List<int>();
                        List<Cell2D> adjacentCells = currentCell.AdjacentCells;
                        for (int index = 0; index < adjacentCells.Count; ++index)
                        {
                            // Store index of each adjacent cell with all walls
                            if (adjacentCells[index].HasAllWalls())
                            {
                                cellIndices.Add(index);
                            }
                        }

                        if (cellIndices.Count > 0)
                        {
                            // Randomly select the next cell
                            Cell2D nextCell = adjacentCells[cellIndices[rand.Next() % cellIndices.Count]];

                            // Remove walls beteen the Current and Next Cell
                            currentCell.RemoveWall(nextCell);

                            // Push Current Cell to Cell Stack
                            cellStack.Push(currentCell);

                            // Move Cell References
                            currentCell = nextCell;

                            // Increment Cells Visited
                            ++numVisitedCells;
                        }
                        else
                        {
                            // Define the End Cell
                            // Note: 
                            // - End Cell is the Cell with the longest length path to the Start Cell
                            if (cellStack.Count > mazePathLength)
                            {
                                endCell = currentCell;
                                mazePathLength = cellStack.Count;
                            }

                            currentCell = cellStack.Pop();
                        }
                    }

                    // Special Case:
                    // Summary: When the maze is generated that never backtracks but 
                    //          while generating visits every cell resulting in the 
                    //          maze generation loop to exit without setting an end cell
                    if(endCell.IsNull())
                    {
                        endCell = currentCell;
                    }

                    // Set End Cell
                    endCell.CellType = Cell2D.CellTypeEnum.kEndCell;
                }
                else
                {
                    // No Op
                }
            }
        }
    }
}
