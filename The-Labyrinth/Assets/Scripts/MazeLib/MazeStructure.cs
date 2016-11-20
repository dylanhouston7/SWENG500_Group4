using Assets.Scripts.DifficultySettings;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MazeStructure
{
    [Serializable]
    public class Maze2D
    {
        private Guid m_guid;
        public Guid GUID
        {
            get { return m_guid; }
        }

        private String m_name;
        public String Name
        {
            set { m_name = value; }
            get { return m_name; }
        }

        private DifficultyEnum m_difficulty_level = DifficultyEnum.MEDIUM;

        public DifficultyEnum Difficulty
        {
            set { m_difficulty_level = value; }
            get { return m_difficulty_level; }
        }

        private int m_time_to_complete_maze;
        public int TimeToCompleteMaze
        {
            set { m_time_to_complete_maze = value; }
            get { return m_time_to_complete_maze; }
        }

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

        private String m_cellWallMaterialKey = null;
        public String CellWallMaterialKey
        {
            set { m_cellWallMaterialKey = value; }
            get { return m_cellWallMaterialKey; }
        }

        private String m_cellFloorMaterialKey = null;
        public String CellFloorMaterialKey
        {
            set { m_cellFloorMaterialKey = value; }
            get { return m_cellFloorMaterialKey; }
        }

        private List<Cell2D> m_maze_solution_path = null;
        public List<Cell2D> MazeSolutionPath
        {
            set { m_maze_solution_path = value; }
            get { return m_maze_solution_path; }
        }

        protected Maze2D()
        {
            m_guid = Guid.NewGuid();

            m_maze_solution_path = new List<Cell2D>();
        }

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
                x < SizeX &&             
                z >= 0 &&
                z < SizeZ
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

        public Cell2D GetStartCell()
        {
            Cell2D startCell = new MazeStructure.NullCell();

            foreach(Cell2D cell in m_cells)
            {
                if(cell.CellType == Cell2D.CellTypeEnum.kStartCell)
                {
                    startCell = cell;
                    break;
                }
            }

            return startCell;
        }

        public Cell2D GetEndCell()
        {
            Cell2D endCell = new MazeStructure.NullCell();

            foreach (Cell2D cell in m_cells)
            {
                if (cell.CellType == Cell2D.CellTypeEnum.kEndCell)
                {
                    endCell = cell;
                    break;
                }
            }

            return endCell;
        }
    }

    public class NullMaze : Maze2D
    {
        public override bool IsNull() { return true; }
    }
}
