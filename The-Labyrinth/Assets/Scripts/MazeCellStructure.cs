using System;
using System.Collections.Generic;

namespace MazeStructure
{
    public class Cell2D
    {
        Maze2D m_maze = null;

        int m_position_x = 0;
        public int PositionX
        {
            get { return m_position_x; }
        }

        int m_position_z = 0;
        public int PositionZ
        {
            get { return m_position_z; }
        }

        public enum CellWallEnum { kRight = 0, kLeft, kFront, kBack, kSize};
        List<bool> m_walls = null;
        public List<bool> Walls
        {
            get { return m_walls; }
        }

        List<Cell2D> m_adjacent_cells = null;
        public List<Cell2D> AdjacentCells
        {
            get
            {
                if(m_adjacent_cells.Count == 0)
                {
                    // Find Adjacent Cells
                    if (!m_maze.GetCell(PositionX - 1, PositionZ).IsNull()) { m_adjacent_cells.Add(m_maze.GetCell(PositionX - 1, PositionZ)); }
                    if (!m_maze.GetCell(PositionX + 1, PositionZ).IsNull()) { m_adjacent_cells.Add(m_maze.GetCell(PositionX + 1, PositionZ)); }
                    if (!m_maze.GetCell(PositionX, PositionZ - 1).IsNull()) { m_adjacent_cells.Add(m_maze.GetCell(PositionX, PositionZ - 1)); }
                    if (!m_maze.GetCell(PositionX, PositionZ + 1).IsNull()) { m_adjacent_cells.Add(m_maze.GetCell(PositionX, PositionZ + 1)); }
                }

                return m_adjacent_cells;
            }
        }

        public enum CellTypeEnum { kStandardCell = 0, kStartCell, kEndCell };
        private CellTypeEnum m_cell_type;
        public CellTypeEnum CellType
        {
            get { return m_cell_type; }
            set { m_cell_type = value; }
        }

        protected Cell2D()
        {
            m_walls = new List<bool>((int)CellWallEnum.kSize);
            m_walls.Insert((int)CellWallEnum.kRight, true);
            m_walls.Insert((int)CellWallEnum.kLeft, true);
            m_walls.Insert((int)CellWallEnum.kFront, true);
            m_walls.Insert((int)CellWallEnum.kBack, true);

            m_adjacent_cells = new List<Cell2D>();

            m_cell_type = CellTypeEnum.kStandardCell;
        }

        public static bool CellCompare(Cell2D cell_a, Cell2D cell_b)
        {
            bool result = false;

            if(
                !cell_a.IsNull() && 
                !cell_b.IsNull() &&
                cell_a.PositionX == cell_b.PositionX &&
                cell_a.PositionZ == cell_b.PositionZ
               )
            {
                result = true;
            } 

            return result;
        }

        public static Cell2D GetInstance(Maze2D maze, int x, int z)
        {
            Cell2D cell = new Cell2D();

            // Set Cell Parent Maze Reference
            cell.m_maze = maze;

            // Set Cell Position within Parent Maze
            cell.m_position_x = x;
            cell.m_position_z = z;

            return cell;
        }

        public virtual bool IsNull() { return false; }

        public virtual bool HasAllWalls()
        {
            bool result = true;

            foreach(bool wall in m_walls)
            {
                if(!wall)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public virtual bool IsAdjacentCell(Cell2D cell)
        {
            bool result = false;

            foreach(Cell2D adjacent_cell in AdjacentCells)
            {
                if(Cell2D.CellCompare(cell, adjacent_cell))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public virtual void RemoveWall(CellWallEnum wall)
        {
            m_walls[(int)wall] = false;
        }

        public virtual void RemoveWall(Cell2D cell)
        {
            if(
                !cell.IsNull() && 
                IsAdjacentCell(cell)
               )
            {
                // Determine Cell Wall to Remove
                int delta_x = PositionX - cell.PositionX;
                int delta_z = PositionZ - cell.PositionZ;

                if (delta_z == -1)
                {
                    RemoveWall(CellWallEnum.kFront);
                    cell.RemoveWall(CellWallEnum.kBack);                    
                }
                else if (delta_z == 1)
                {
                    RemoveWall(CellWallEnum.kBack);
                    cell.RemoveWall(CellWallEnum.kFront);
                }
                else if (delta_x == -1)
                {
                    RemoveWall(CellWallEnum.kRight);
                    cell.RemoveWall(CellWallEnum.kLeft);
                }
                else if(delta_x == 1)
                {
                    RemoveWall(CellWallEnum.kLeft);
                    cell.RemoveWall(CellWallEnum.kRight);
                }
                else
                {
                    // TODO: Throw Exception
                }
            }
            else
            {
                // No Op
            }
        }
    }

    public class NullCell : Cell2D
    {
        public override bool IsNull() { return true; }
    }
}
