using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MazeStructure
{
    [Serializable]
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

        public enum CellDirectionEnum { kRight = 0, kLeft, kFront, kBack, kSize};
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

        private bool m_isSolutionCell;
        public bool IsSolutionCell
        {
            set { m_isSolutionCell = value; }
            get { return m_isSolutionCell; }
        }

        protected Cell2D()
        {
            m_walls = new List<bool>((int)CellDirectionEnum.kSize);
            m_walls.Insert((int)CellDirectionEnum.kRight, true);
            m_walls.Insert((int)CellDirectionEnum.kLeft, true);
            m_walls.Insert((int)CellDirectionEnum.kFront, true);
            m_walls.Insert((int)CellDirectionEnum.kBack, true);

            m_adjacent_cells = new List<Cell2D>();

            m_cell_type = CellTypeEnum.kStandardCell;

            m_isSolutionCell = false;
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

        public virtual bool HasPathToCell(Cell2D cell)
        {
            bool result = false;

            if(IsAdjacentCell(cell))
            {
                // Determine directional Vector to other Cell
                int delta_x = PositionX - cell.PositionX;
                int delta_z = PositionZ - cell.PositionZ;

                if (delta_z == -1)
                {
                    // Vector Direction = Front
                    if(!Walls[(int)CellDirectionEnum.kFront] && !cell.Walls[(int)CellDirectionEnum.kBack])
                    {
                        result = true;
                    }
                }
                else if (delta_z == 1)
                {
                    // Vector Direction = Back
                    if (!Walls[(int)CellDirectionEnum.kBack] && !cell.Walls[(int)CellDirectionEnum.kFront])
                    {
                        result = true;
                    }
                }
                else if (delta_x == -1)
                {
                    // Vector Direction = Right
                    if (!Walls[(int)CellDirectionEnum.kRight] && !cell.Walls[(int)CellDirectionEnum.kLeft])
                    {
                        result = true;
                    }
                }
                else if (delta_x == 1)
                {
                    // Vector Direction = Left
                    if (!Walls[(int)CellDirectionEnum.kLeft] && !cell.Walls[(int)CellDirectionEnum.kRight])
                    {
                        result = true;
                    }
                }
                else
                {
                    // TODO: Throw Exception
                }
            }

            return result;
        }

        public virtual CellDirectionEnum DirectionToCell(Cell2D cell)
        {
            CellDirectionEnum result = CellDirectionEnum.kSize;

            if (IsAdjacentCell(cell))
            {
                // Determine directional Vector to other Cell
                int delta_x = PositionX - cell.PositionX;
                int delta_z = PositionZ - cell.PositionZ;

                if (delta_z == -1)
                {
                    // Vector Direction = Front
                    result = CellDirectionEnum.kFront;
                }
                else if (delta_z == 1)
                {
                    // Vector Direction = Back
                    result = CellDirectionEnum.kBack;
                }
                else if (delta_x == -1)
                {
                    // Vector Direction = Right
                    result = CellDirectionEnum.kRight;
                }
                else if (delta_x == 1)
                {
                    // Vector Direction = Left
                    result = CellDirectionEnum.kLeft;
                }
                else
                {
                    // TODO: Throw Exception
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

        public virtual void RemoveWall(CellDirectionEnum wall)
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
                    RemoveWall(CellDirectionEnum.kFront);
                    cell.RemoveWall(CellDirectionEnum.kBack);
                }
                else if (delta_z == 1)
                {
                    RemoveWall(CellDirectionEnum.kBack);
                    cell.RemoveWall(CellDirectionEnum.kFront);
                }
                else if (delta_x == -1)
                {
                    RemoveWall(CellDirectionEnum.kRight);
                    cell.RemoveWall(CellDirectionEnum.kLeft);
                }
                else if(delta_x == 1)
                {
                    RemoveWall(CellDirectionEnum.kLeft);
                    cell.RemoveWall(CellDirectionEnum.kRight);
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
