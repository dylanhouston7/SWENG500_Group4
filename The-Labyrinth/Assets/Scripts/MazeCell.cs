using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour
{
    // Prefabs
    public CellFloor cellFloorPrefab;
    public CellWall cellWallPrefab;
    public MazeHint mazeHintPrefab;

    // Public Members
    public enum CellTypeEnum { kStandard = 0, kStart, kEnd }

    // Private Members
    private CellTypeEnum cellType = CellTypeEnum.kStandard;
    public CellTypeEnum CellType
    {
        set { cellType = value; }
        get { return cellType; }
    }

    private CellFloor cellFloorInstance;
    private CellWall cellLeftWallInstance;
    private CellWall cellRightWallInstance;
    private CellWall cellFrontWallInstance;
    private CellWall cellBackWallInstance;
    private CellWall cellCeilingInstance;

    private MazeHint cellMazeHintInstance;

    // Unity Methods
    void Awake()
    {
        // Create Cell Floor
        cellFloorInstance = Instantiate(cellFloorPrefab, transform) as CellFloor;
        cellFloorInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        cellFloorInstance.ParentCell = this;

        cellMazeHintInstance = null;
    }

    // Other Methods
    public void BuildCellWall(
        MazeStructure.Cell2D.CellDirectionEnum wall
        )
    {
        switch (wall)
        {
            case MazeStructure.Cell2D.CellDirectionEnum.kLeft:
                {
                    cellLeftWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellLeftWallInstance.transform.localPosition = new Vector3(-0.5f, 0.5f, 0.0f);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kRight:
                {
                    cellRightWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellRightWallInstance.transform.localPosition = new Vector3(0.5f, 0.5f, 0.0f);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kFront:
                {
                    cellFrontWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellFrontWallInstance.transform.Rotate(0.0f, 90.0f, 0.0f);
                    cellFrontWallInstance.transform.localPosition = new Vector3(0.0f, 0.5f, 0.5f);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kBack:
                {
                    cellBackWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellBackWallInstance.transform.Rotate(0.0f, 90.0f, 0.0f);
                    cellBackWallInstance.transform.localPosition = new Vector3(0.0f, 0.5f, -0.5f);
                    break;
                }
        };
    }

    public void BuildCellCeiling()
    {
        cellCeilingInstance = Instantiate(cellWallPrefab, transform) as CellWall;
        cellCeilingInstance.transform.Rotate(0.0f, 0.0f, 90.0f);
        cellCeilingInstance.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
    }

    public void RemoveCellWall(
        MazeStructure.Cell2D.CellDirectionEnum wall,
        float timeDelay = 0.0f
        )
    {
        switch (wall)
        {
            case MazeStructure.Cell2D.CellDirectionEnum.kLeft:
                {
                    Destroy(cellLeftWallInstance.gameObject, timeDelay);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kRight:
                {
                    Destroy(cellRightWallInstance.gameObject, timeDelay);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kFront:
                {
                    Destroy(cellFrontWallInstance.gameObject, timeDelay);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kBack:
                {
                    Destroy(cellBackWallInstance.gameObject, timeDelay);
                    break;
                }
        };
    }

    public void RemoveCellCeiling(
        float timeDelay = 0.0f
        )
    {
        Destroy(cellCeilingInstance, timeDelay);
    }

    public void ShowSolutionCell()
    {
        cellFloorInstance.ShowSolution(true);
    }

    public void HideSolutionCell()
    {
        cellFloorInstance.ShowSolution(false);
    }

    public void ShowCellHint(MazeStructure.Cell2D.CellDirectionEnum direction)
    {
        // Ensure only one maze hint instance per cell
        if(cellMazeHintInstance != null)
        {
            DestroyImmediate(cellMazeHintInstance.gameObject);
            cellMazeHintInstance = null;
        }

        // Instantiate a new Maze Hint and position it over the cell with the defined direction
        cellMazeHintInstance = Instantiate(mazeHintPrefab, this.transform) as MazeHint;

        // TODO: Specify the Rendering Order to ensure the hint is rendered last so it is visible
        //       instead of elevating the hint slightly above the cell floor
        cellMazeHintInstance.transform.localPosition = new Vector3(0.0f, 0.01f, 0.0f);

        // Orient the Hint rotation based on the defined direction
        switch (direction)
        {
            case MazeStructure.Cell2D.CellDirectionEnum.kFront:
                {
                    cellMazeHintInstance.transform.Rotate(new Vector3(90.0f, 180.0f, 0.0f), Space.Self);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kBack:
                {
                    cellMazeHintInstance.transform.Rotate(new Vector3(90.0f, 0.0f, 0.0f), Space.Self);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kLeft:
                {
                    cellMazeHintInstance.transform.Rotate(new Vector3(90.0f, 90.0f, 0.0f), Space.Self);
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kRight:
                {
                    cellMazeHintInstance.transform.Rotate(new Vector3(90.0f, 270.0f, 0.0f), Space.Self);
                    break;
                }
            default:
                {
                    break;
                }
        };
    }
}
