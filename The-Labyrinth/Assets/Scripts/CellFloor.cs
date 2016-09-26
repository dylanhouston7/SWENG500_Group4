using UnityEngine;
using System.Collections;

public class CellFloor : MonoBehaviour
{
    private MazeCell.CellTypeEnum celltype = MazeCell.CellTypeEnum.kStandard;
    public MazeCell.CellTypeEnum CellType
    {
        set { celltype = value; }
        get { return celltype; }
    }

    void Start()
    {
        if (celltype == MazeCell.CellTypeEnum.kStart)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (celltype == MazeCell.CellTypeEnum.kEnd)
        {
            this.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (celltype == MazeCell.CellTypeEnum.kEnd)
        {
            Debug.Log("Published Event: CompletedMaze");

            EventManager.TriggerEvent("CompletedMaze");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (celltype == MazeCell.CellTypeEnum.kStart)
        {
            Debug.Log("Published Event: StartedMaze");

            EventManager.TriggerEvent("StartedMaze");
        }
    }
}
