using UnityEngine;
using System.Collections;

public class CellWall : MonoBehaviour
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

    void Awake()
    {
        // Initialize Member Variables

        // Initialize the Cell Floor Material
        m_initialMaterial = GetComponent<Renderer>().material;
        m_updatedMaterial = m_initialMaterial;
    }

    void Update()
    {
        if (m_hasMaterialChanged)
        {
            GetComponent<Renderer>().material = m_updatedMaterial;
            m_hasMaterialChanged = false;
        }
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
