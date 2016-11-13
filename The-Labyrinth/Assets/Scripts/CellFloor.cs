using UnityEngine;
using System.Collections;

public class CellFloor : MonoBehaviour
{
    private MazeCell m_parentCell;
    public MazeCell ParentCell
    {
        set { m_parentCell = value; }
        get { return m_parentCell; }
    }

    private Material m_initialMaterial;
    private Material m_updatedMaterial;
    private bool m_hasMaterialChanged;

    private Color m_initialColor;
    private Color m_updatedColor;
    private bool m_hasColorChanged;

    void Awake()
    {
        // Initialize Member Variables

        m_parentCell = null;

        // Initialize the Cell Floor Material
        m_initialMaterial = GetComponent<Renderer>().material;
        m_updatedMaterial = m_initialMaterial;
        m_hasMaterialChanged = false;
        
        // Initialize the Cell Floor Color
        m_initialColor = GetComponent<Renderer>().material.color;
        m_updatedColor = m_initialColor;
        m_hasColorChanged = false;
    }

    void Update()
    {
        if(m_hasMaterialChanged)
        {
            GetComponent<Renderer>().material = m_updatedMaterial;
            m_hasMaterialChanged = false;
        }

        if (m_hasColorChanged)
        {
            GetComponent<Renderer>().material.color = m_updatedColor;
            m_hasColorChanged = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameContext.m_context.m_currentPlayerMazePositionX = (int)transform.position.x;
        GameContext.m_context.m_currentPlayerMazePositionZ = (int)transform.position.z;

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

    public void SetColor(Color floorColor)
    {
        m_updatedColor = floorColor;
        m_hasColorChanged = true;
    }

    public void ResetColor()
    {
        m_updatedColor = m_initialColor;
        m_hasColorChanged = true;
    }

    public void SetMaterial(Material floorMaterial)
    {
        m_updatedMaterial = floorMaterial;
        m_hasMaterialChanged = true;
    }

    public void ResetMaterial()
    {
        m_updatedMaterial = m_initialMaterial;
        m_hasMaterialChanged = true;
    }
}
