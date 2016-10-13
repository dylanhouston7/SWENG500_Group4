using System;
using System.Collections.Generic;

namespace MazeStructure
{
    public class MazeSolver
    {
        public enum MazeSolverAlgorithmEnum
        {
            kRandomMouse
        };

        public static void Solve(
            MazeSolverAlgorithmEnum mazeSolverAlgorithm,
            Maze2D maze
            )
        {
            switch(mazeSolverAlgorithm)
            {
                case MazeSolverAlgorithmEnum.kRandomMouse:
                    {
                        RandomMouseMazeSolver.Solve(maze);
                        break;
                    }
                default:
                    {
                        maze.MazeSolutionPath = new List<Cell2D>();
                        break;
                    }
            };
        }

        class RandomMouseMazeSolver
        {
            public static void Solve(Maze2D maze)
            {
                if(!maze.IsNull())
                {
                    // Setup:
                    Random rand = new Random();
                    Stack<Cell2D> cellStack = new Stack<Cell2D>();                    
                    List<Cell2D> previousCells = new List<Cell2D>();
                    int numCells = maze.SizeX * maze.SizeZ;

                    Cell2D currentCell = maze.GetStartCell();
                    previousCells.Add(currentCell);

                    // Step 1: Apply Algorithm until end cell is found OR all cells have been visited
                    while (previousCells.Count <= numCells)
                    {
                        // Check for End Cell Condition
                        if(currentCell.CellType == Cell2D.CellTypeEnum.kEndCell)
                        {
                            // Push Current Cell to Cell Stack
                            cellStack.Push(currentCell);

                            break;
                        }


                        // Find Current Cell's adjacent cells with a path to them (no wall between them)
                        List<int> cellIndices = new List<int>();
                        List<Cell2D> adjacentCells = currentCell.AdjacentCells;
                        for (int index = 0; index < adjacentCells.Count; ++index)
                        {
                            // Store index of each adjacent cell with no walls to the current cell
                            if (!isPreviousCell(adjacentCells[index], previousCells) &&
                                currentCell.HasPathToCell(adjacentCells[index]))
                            {
                                cellIndices.Add(index);
                            }
                        }

                        if (cellIndices.Count > 0)
                        {
                            // Randomly select the next cell
                            Cell2D nextCell = adjacentCells[cellIndices[rand.Next() % cellIndices.Count]];

                            // Push Current Cell to Cell Stack
                            cellStack.Push(currentCell);

                            // Move Cell References
                            currentCell = nextCell;
                            previousCells.Add(currentCell);
                        }
                        else
                        {
                            currentCell = cellStack.Pop();
                        }
                    }
                    

                    // Store the Maze Solution Path
                    maze.MazeSolutionPath = new List<Cell2D>(cellStack.ToArray());

                    // Flag each solution cell
                    foreach(Cell2D cell in maze.MazeSolutionPath)
                    {
                        cell.IsSolutionCell = true;
                    }
                }
                else
                {
                    // No Op
                }
            }

            private static bool isPreviousCell(Cell2D cell, List<Cell2D> previousCells)
            {
                bool result = false;

                foreach(Cell2D previousCell in previousCells)
                {
                    if(Cell2D.CellCompare(previousCell, cell))
                    {
                        result = true;
                        break;
                    }
                }

                return result;
            }
        }
    }
}