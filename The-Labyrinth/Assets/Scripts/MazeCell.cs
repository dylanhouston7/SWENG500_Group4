using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour
{
    // Public Prefab References
    public CellFloor cellFloorPrefab;
    public CellWall cellWallPrefab;
    public MazeHint mazeHintPrefab;

    // Public Members
    public enum CellTypeEnum { kStandard = 0, kStart, kEnd }

    // Private Members
    private CellTypeEnum cellType = CellTypeEnum.kStandard;
    public CellTypeEnum CellType
    {
        set
        {
            cellType = value;
            if (CellType == CellTypeEnum.kStart)
            {
                cellFloorInstance.SetColor(Color.red);
                cellFloorInstance.ActivateParticleSystemForStartOrEndCell(true);
            }
            else if (CellType == CellTypeEnum.kEnd)
            {
                cellFloorInstance.SetColor(Color.green);
                cellFloorInstance.ActivateParticleSystemForStartOrEndCell(false);
            }
            else
            {
                cellFloorInstance.ResetColor();
            }
        }
        get { return cellType; }
    }

    /// <summary>
    /// Retrieves the cell floor instance
    /// </summary>
    /// <returns>The cell floor instance of the Maze cell</returns>
    public CellFloor GetCellFloorInstance()
    {
        return cellFloorInstance;
    }

    // Private Prefab Instances
    private CellFloor cellFloorInstance = null;

    private CellWall cellLeftWallInstance = null;
    private CellWall cellRightWallInstance = null;
    private CellWall cellFrontWallInstance = null;
    private CellWall cellBackWallInstance = null;
    private CellWall cellCeilingInstance = null;

    private MazeHint cellMazeHintInstance = null;

    // ********************************************
    // Unity Methods
    // ********************************************

    /// <summary>
    /// Unity Method for initialization of GameObject called first
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Awake()
    {
        // Instantiate the Cell Floor
        cellFloorInstance = Instantiate(cellFloorPrefab, transform) as CellFloor;
        cellFloorInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        cellFloorInstance.ParentCell = this;
    }


    // ********************************************
    // Public Methods
    // ********************************************

    public void BuildCellWall(
        MazeStructure.Cell2D.CellDirectionEnum wall
        )
    {
        switch (wall)
        {
            case MazeStructure.Cell2D.CellDirectionEnum.kLeft:
                {
                    ResetCellWallInstance(ref cellLeftWallInstance);
                    cellLeftWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellLeftWallInstance.transform.localPosition = new Vector3(-0.5f, 0.5f, 0.0f);
                    cellLeftWallInstance.ParentCell = this;
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kRight:
                {
                    ResetCellWallInstance(ref cellRightWallInstance);
                    cellRightWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellRightWallInstance.transform.localPosition = new Vector3(0.5f, 0.5f, 0.0f);
                    cellRightWallInstance.ParentCell = this;
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kFront:
                {
                    ResetCellWallInstance(ref cellFrontWallInstance);
                    cellFrontWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellFrontWallInstance.transform.Rotate(0.0f, 90.0f, 0.0f);
                    cellFrontWallInstance.transform.localPosition = new Vector3(0.0f, 0.5f, 0.5f);
                    cellFrontWallInstance.ParentCell = this;
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kBack:
                {
                    ResetCellWallInstance(ref cellBackWallInstance);
                    cellBackWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellBackWallInstance.transform.Rotate(0.0f, 90.0f, 0.0f);
                    cellBackWallInstance.transform.localPosition = new Vector3(0.0f, 0.5f, -0.5f);
                    cellBackWallInstance.ParentCell = this;
                    break;
                }
            default:
                {
                    // No Op
                    break;
                }
        };
    }

    private void ResetCellWallInstance(ref CellWall cellwall)
    {
        if (cellwall != null)
        {
            DestroyImmediate(cellwall.gameObject);
            cellwall = null;
        }
    }

    public void BuildCellCeiling()
    {
        if(cellCeilingInstance != null)
        {
            DestroyImmediate(cellCeilingInstance.gameObject);
            cellCeilingInstance = null;
        }

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
                    if(cellLeftWallInstance != null) { Destroy(cellLeftWallInstance.gameObject, timeDelay); cellLeftWallInstance = null; }
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kRight:
                {
                    if (cellRightWallInstance != null) { Destroy(cellRightWallInstance.gameObject, timeDelay); cellRightWallInstance = null; }
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kFront:
                {
                    if (cellFrontWallInstance != null) { Destroy(cellFrontWallInstance.gameObject, timeDelay); cellFrontWallInstance = null; }
                    break;
                }
            case MazeStructure.Cell2D.CellDirectionEnum.kBack:
                {
                    if (cellBackWallInstance != null) { Destroy(cellBackWallInstance.gameObject, timeDelay); cellBackWallInstance = null; }
                    break;
                }
            default:
                {
                    // No Op
                    break;
                }
        };
    }

    public void RemoveCellCeiling(
        float timeDelay = 0.0f
        )
    {
        if (cellCeilingInstance != null) { Destroy(cellCeilingInstance.gameObject, timeDelay); cellCeilingInstance = null; }
    }


    public void ShowSolutionCell()
    {
        if (CellType != CellTypeEnum.kStart || CellType != CellTypeEnum.kEnd)
        {
            cellFloorInstance.SetColor(Color.magenta);
        }
    }

    public void HideSolutionCell()
    {
        cellFloorInstance.ResetColor();
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
                    // No Op
                    break;
                }
        };
    }


    public void SetFloorMaterial(Material floorMaterial)
    {
        if(cellFloorInstance != null)
        {
            cellFloorInstance.SetMaterial(floorMaterial);
        }        
    }

    public void SetWallMaterial(Material wallMaterial)
    {
        if(cellLeftWallInstance != null)
        {
            cellLeftWallInstance.SetMaterial(wallMaterial);
        }

        if (cellRightWallInstance != null)
        {
            cellRightWallInstance.SetMaterial(wallMaterial);
        }

        if (cellFrontWallInstance != null)
        {
            cellFrontWallInstance.SetMaterial(wallMaterial);
        }

        if (cellBackWallInstance != null)
        {
            cellBackWallInstance.SetMaterial(wallMaterial);
        }

        if (cellCeilingInstance != null)
        {
            cellCeilingInstance.SetMaterial(wallMaterial);
        }
    }
}
