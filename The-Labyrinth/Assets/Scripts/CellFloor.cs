using UnityEngine;
using System.Collections;

public class CellFloor : MonoBehaviour
{      
    private MazeCell m_parentCell;
    public MazeCell ParentCell
    {
        set
        {
            m_parentCell = value;
            m_hasCellParentChanged = true;
        }
    }
    private bool m_hasCellParentChanged;

    bool m_hasShowSolutionChanged;
    bool m_showSolution;

    void Awake()
    {
        // Initialize Member Variables
        m_parentCell = null;
        m_hasCellParentChanged = false;

        m_hasShowSolutionChanged = false;
        m_showSolution = false;
    }

    void Update()
    {
        if(m_hasCellParentChanged)
        {
            if (m_parentCell != null && 
                m_parentCell.CellType == MazeCell.CellTypeEnum.kStart)
            {
                this.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (m_parentCell != null &&
                     m_parentCell.CellType == MazeCell.CellTypeEnum.kEnd)
            {
                this.GetComponent<Renderer>().material.color = Color.green;
            }

            m_hasCellParentChanged = false;
        }

        if (m_hasShowSolutionChanged)
        {
            if (m_showSolution)
            {
                this.GetComponent<Renderer>().material.color = Color.magenta;
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.black;
            }

            m_hasShowSolutionChanged = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameContext.m_context.m_currentPlayerMazePositionX = (int)this.transform.position.x;
        GameContext.m_context.m_currentPlayerMazePositionZ = (int)this.transform.position.z;

        if (m_parentCell != null &&
            m_parentCell.CellType == MazeCell.CellTypeEnum.kEnd)
        {
            Debug.Log("Published Event: CompletedMaze");

            EventManager.TriggerEvent("CompletedMaze");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (m_parentCell != null &&
            m_parentCell.CellType == MazeCell.CellTypeEnum.kStart)
        {
            Debug.Log("Published Event: StartedMaze");

            EventManager.TriggerEvent("StartedMaze");
        }
    }

    public void ShowSolution(bool showSolution)
    {
        if(m_parentCell != null &&
           m_parentCell.CellType != MazeCell.CellTypeEnum.kStart &&
           m_parentCell.CellType != MazeCell.CellTypeEnum.kEnd)
        {
            m_showSolution = showSolution;
            m_hasShowSolutionChanged = true;
        }
    }
}
