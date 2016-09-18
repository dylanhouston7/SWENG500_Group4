using System;
using System.Collections.Generic;

namespace MazeStructure
{
    public class Maze2D
    {
        private Cell2D[/*SizeX*/,/*SizeZ*/] m_cells = null;
        public int SizeX
        {
            get
            {
                int result = 0;
                if (m_cells != null)
                {
                    result = m_cells.GetLength(0);
                }

                return result;
            }
        }
        public int SizeZ
        {
            get
            {
                int result = 0;
                if(m_cells != null)
                {
                    result = m_cells.GetLength(1);
                }

                return result;
            }
        }

        protected Maze2D() { }

        public static Maze2D GetInstance(int sizeX, int sizeZ)
        {
            Maze2D maze = null;

            if(sizeX >= 1 && sizeZ >= 1)
            {
                maze = new Maze2D();

                // Initialize the Maze Cells
                maze.m_cells = new Cell2D[sizeX, sizeZ];
                for (int x = 0; x < sizeX; ++x)                    
                {
                    for (int z = 0; z < sizeZ; ++z)
                    {
                        maze.m_cells[x, z] = Cell2D.GetInstance(maze, x, z);
                    }
                }
            }
            else
            {
                maze = new NullMaze();
            }

            return maze;
        }

        public virtual bool IsNull() { return false; }

        public virtual Cell2D GetCell(int x, int z)
        {
            Cell2D cell = null;

            if (
                x >= 0 &&
                x < m_cells.GetLength(0) &&             
                z >= 0 &&
                z < m_cells.GetLength(1)
                )
            {
                cell = m_cells[x, z];
            }
            else
            {
                cell = new NullCell();
            }

            return cell;
        }
    }

    public class NullMaze : Maze2D
    {
        public override bool IsNull() { return true; }
    }
}
