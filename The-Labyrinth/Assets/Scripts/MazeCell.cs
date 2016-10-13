﻿using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour
{
    // Prefabs
    public CellFloor cellFloorPrefab;
    public CellWall cellWallPrefab;

    // Public Members
    public enum CellTypeEnum { kStandard = 0, kStart, kEnd }

    // Private Members
    private CellTypeEnum cellType = CellTypeEnum.kStandard;
    public CellTypeEnum CellType
    {
        set { cellType = value; }
        get { return cellType; }
    }

    private bool isSolutionCell = false;
    public bool IsSolutionCell
    {
        set { isSolutionCell = value; }
        get { return isSolutionCell; }
    }

    private CellFloor cellFloorInstance;
    private CellWall cellLeftWallInstance;
    private CellWall cellRightWallInstance;
    private CellWall cellFrontWallInstance;
    private CellWall cellBackWallInstance;
    private CellWall cellCeilingInstance;

    // Unity Methods
    void Awake()
    {
        // Create Cell Floor
        cellFloorInstance = Instantiate(cellFloorPrefab, transform) as CellFloor;
        cellFloorInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        cellFloorInstance.ParentCell = this;
    }

    // Other Methods
    public void BuildCellWall(
        MazeStructure.Cell2D.CellWallEnum wall
        )
    {
        switch (wall)
        {
            case MazeStructure.Cell2D.CellWallEnum.kLeft:
                {
                    cellLeftWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellLeftWallInstance.transform.localPosition = new Vector3(-0.5f, 0.5f, 0.0f);
                    break;
                }
            case MazeStructure.Cell2D.CellWallEnum.kRight:
                {
                    cellRightWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellRightWallInstance.transform.localPosition = new Vector3(0.5f, 0.5f, 0.0f);
                    break;
                }
            case MazeStructure.Cell2D.CellWallEnum.kFront:
                {
                    cellFrontWallInstance = Instantiate(cellWallPrefab, transform) as CellWall;
                    cellFrontWallInstance.transform.Rotate(0.0f, 90.0f, 0.0f);
                    cellFrontWallInstance.transform.localPosition = new Vector3(0.0f, 0.5f, 0.5f);
                    break;
                }
            case MazeStructure.Cell2D.CellWallEnum.kBack:
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
        MazeStructure.Cell2D.CellWallEnum wall,
        float timeDelay = 0.0f
        )
    {
        switch (wall)
        {
            case MazeStructure.Cell2D.CellWallEnum.kLeft:
                {
                    Destroy(cellLeftWallInstance.gameObject, timeDelay);
                    break;
                }
            case MazeStructure.Cell2D.CellWallEnum.kRight:
                {
                    Destroy(cellRightWallInstance.gameObject, timeDelay);
                    break;
                }
            case MazeStructure.Cell2D.CellWallEnum.kFront:
                {
                    Destroy(cellFrontWallInstance.gameObject, timeDelay);
                    break;
                }
            case MazeStructure.Cell2D.CellWallEnum.kBack:
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
        if(isSolutionCell)
        {
            cellFloorInstance.ShowSolution(true);
        }        
    }

    public void HideSolutionCell()
    {
        if (isSolutionCell)
        {
            cellFloorInstance.ShowSolution(false);
        }
    }
}
