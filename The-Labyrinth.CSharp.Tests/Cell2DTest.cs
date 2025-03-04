using System.Collections.Generic;
using System;
using MazeStructure;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeStructure.Tests
{
    /// <summary>This class contains parameterized unit tests for Cell2D</summary>
    [TestClass]
    [PexClass(typeof(Cell2D))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class Cell2DTest
    {

        /// <summary>Test stub for CellCompare(Cell2D, Cell2D)</summary>
        [PexMethod]
        public bool CellCompareTest(Cell2D cell_a, Cell2D cell_b)
        {
            bool result = Cell2D.CellCompare(cell_a, cell_b);
            return result;
            // TODO: add assertions to method Cell2DTest.CellCompareTest(Cell2D, Cell2D)
        }

        /// <summary>Test stub for DirectionToCell(Cell2D)</summary>
        [PexMethod]
        public Cell2D.CellDirectionEnum DirectionToCellTest([PexAssumeUnderTest]Cell2D target, Cell2D cell)
        {
            Cell2D.CellDirectionEnum result = target.DirectionToCell(cell);
            return result;
            // TODO: add assertions to method Cell2DTest.DirectionToCellTest(Cell2D, Cell2D)
        }

        /// <summary>Test stub for GetInstance(Maze2D, Int32, Int32)</summary>
        [PexMethod]
        public Cell2D GetInstanceTest(
            Maze2D maze,
            int x,
            int z
        )
        {
            Cell2D result = Cell2D.GetInstance(maze, x, z);
            return result;
            // TODO: add assertions to method Cell2DTest.GetInstanceTest(Maze2D, Int32, Int32)
        }

        /// <summary>Test stub for HasAllWalls()</summary>
        [PexMethod]
        public bool HasAllWallsTest([PexAssumeUnderTest]Cell2D target)
        {
            bool result = target.HasAllWalls();
            return result;
            // TODO: add assertions to method Cell2DTest.HasAllWallsTest(Cell2D)
        }

        /// <summary>Test stub for HasPathToCell(Cell2D)</summary>
        [PexMethod]
        public bool HasPathToCellTest([PexAssumeUnderTest]Cell2D target, Cell2D cell)
        {
            bool result = target.HasPathToCell(cell);
            return result;
            // TODO: add assertions to method Cell2DTest.HasPathToCellTest(Cell2D, Cell2D)
        }

        /// <summary>Test stub for IsAdjacentCell(Cell2D)</summary>
        [PexMethod]
        public bool IsAdjacentCellTest([PexAssumeUnderTest]Cell2D target, Cell2D cell)
        {
            bool result = target.IsAdjacentCell(cell);
            return result;
            // TODO: add assertions to method Cell2DTest.IsAdjacentCellTest(Cell2D, Cell2D)
        }

        /// <summary>Test stub for IsNull()</summary>
        [PexMethod]
        public bool IsNullTest([PexAssumeUnderTest]Cell2D target)
        {
            bool result = target.IsNull();
            return result;
            // TODO: add assertions to method Cell2DTest.IsNullTest(Cell2D)
        }

        /// <summary>Test stub for RemoveWall(CellDirectionEnum)</summary>
        [PexMethod]
        public void RemoveWallTest([PexAssumeUnderTest]Cell2D target, Cell2D.CellDirectionEnum wall)
        {
            target.RemoveWall(wall);
            // TODO: add assertions to method Cell2DTest.RemoveWallTest(Cell2D, CellDirectionEnum)
        }

        /// <summary>Test stub for RemoveWall(Cell2D)</summary>
        [PexMethod]
        public void RemoveWallTest01([PexAssumeUnderTest]Cell2D target, Cell2D cell)
        {
            target.RemoveWall(cell);
            // TODO: add assertions to method Cell2DTest.RemoveWallTest01(Cell2D, Cell2D)
        }

        /// <summary>Test stub for get_AdjacentCells()</summary>
        [PexMethod]
        public List<Cell2D> AdjacentCellsGetTest([PexAssumeUnderTest]Cell2D target)
        {
            List<Cell2D> result = target.AdjacentCells;
            return result;
            // TODO: add assertions to method Cell2DTest.AdjacentCellsGetTest(Cell2D)
        }

        /// <summary>Test stub for get_CellType()</summary>
        [PexMethod]
        public Cell2D.CellTypeEnum CellTypeGetTest([PexAssumeUnderTest]Cell2D target)
        {
            Cell2D.CellTypeEnum result = target.CellType;
            return result;
            // TODO: add assertions to method Cell2DTest.CellTypeGetTest(Cell2D)
        }

        /// <summary>Test stub for get_IsSolutionCell()</summary>
        [PexMethod]
        public bool IsSolutionCellGetTest([PexAssumeUnderTest]Cell2D target)
        {
            bool result = target.IsSolutionCell;
            return result;
            // TODO: add assertions to method Cell2DTest.IsSolutionCellGetTest(Cell2D)
        }

        /// <summary>Test stub for get_PositionX()</summary>
        [PexMethod]
        public int PositionXGetTest([PexAssumeUnderTest]Cell2D target)
        {
            int result = target.PositionX;
            return result;
            // TODO: add assertions to method Cell2DTest.PositionXGetTest(Cell2D)
        }

        /// <summary>Test stub for get_PositionZ()</summary>
        [PexMethod]
        public int PositionZGetTest([PexAssumeUnderTest]Cell2D target)
        {
            int result = target.PositionZ;
            return result;
            // TODO: add assertions to method Cell2DTest.PositionZGetTest(Cell2D)
        }

        /// <summary>Test stub for get_Walls()</summary>
        [PexMethod]
        public List<bool> WallsGetTest([PexAssumeUnderTest]Cell2D target)
        {
            List<bool> result = target.Walls;
            return result;
            // TODO: add assertions to method Cell2DTest.WallsGetTest(Cell2D)
        }

        /// <summary>Test stub for set_CellType(CellTypeEnum)</summary>
        [PexMethod]
        public void CellTypeSetTest([PexAssumeUnderTest]Cell2D target, Cell2D.CellTypeEnum value)
        {
            target.CellType = value;
            // TODO: add assertions to method Cell2DTest.CellTypeSetTest(Cell2D, CellTypeEnum)
        }

        /// <summary>Test stub for set_IsSolutionCell(Boolean)</summary>
        [PexMethod]
        public void IsSolutionCellSetTest([PexAssumeUnderTest]Cell2D target, bool value)
        {
            target.IsSolutionCell = value;
            // TODO: add assertions to method Cell2DTest.IsSolutionCellSetTest(Cell2D, Boolean)
        }
    }
}
