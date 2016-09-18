using UnityEngine;
using System.Collections;

public class MazeCell : MonoBehaviour {    

    public CellFloor cellFloorPrefab;
    public CellWall cellWallPrefab;

    private CellFloor cellFloorInstance;
    private CellWall cellLeftWallInstance;
    private CellWall cellRightWallInstance;
    private CellWall cellFrontWallInstance;
    private CellWall cellBackWallInstance;
    private CellWall cellCeilingInstance;

    // Use this for initialization
    void Start () {

        // Create Cell Floor
        cellFloorInstance = Instantiate(cellFloorPrefab) as CellFloor;
        cellFloorInstance.transform.parent = transform;
        cellFloorInstance.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void BuildCellWall(MazeStructure.Cell2D.CellWallEnum wall)
    {
        switch(wall)
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
        cellCeilingInstance = Instantiate(cellWallPrefab) as CellWall;
        cellCeilingInstance.transform.parent = transform;
        cellCeilingInstance.transform.Rotate(0.0f, 0.0f, 90.0f);
        cellCeilingInstance.transform.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
    }

    public void RemoveCellWall(MazeStructure.Cell2D.CellWallEnum wall, float timeDelay = 0.0f)
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

    public void RemoveCellCeiling(float timeDelay = 0.0f)
    {
        Destroy(cellCeilingInstance, timeDelay);
    }
}
