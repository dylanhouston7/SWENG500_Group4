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

    /// <summary>
    /// Activates a particle system for this cell floor
    /// </summary>
    /// <param name="start">Specifies whether or not it is a start cell. If not, it is assumed that the cell is an end cell.</param>
    public void ActivateParticleSystemForStartOrEndCell(bool start)
    {
        // Dynamically add a particle system to the floor of the cell
        ParentCell.GetCellFloorInstance().gameObject.AddComponent<ParticleSystem>();

        // Retrieve the particle system
        ParticleSystem particleSystem = ParentCell.GetCellFloorInstance().GetComponent<ParticleSystem>();

        // Set start color
        if (start)
        {
            particleSystem.startColor = Color.red;
        }
        // Set end color
        else
        {
            particleSystem.startColor = Color.green;
        }

        particleSystem.maxParticles = 2000;

        // We do this so the particles go upwards
        particleSystem.gravityModifier = -.4f;

        // Set size and speed of particles
        particleSystem.startSize = .1f;
        particleSystem.startLifetime = .6f;
        particleSystem.startSpeed = .01f;

        // How many particles to emit?
        particleSystem.emissionRate = 105;
        
        // Get the shape of the particle system so we can modify it
        ParticleSystem.ShapeModule shape = particleSystem.shape;

        // size of the baze
        shape.radius = .55f;

        // how wide do the particles disberse?
        shape.angle = 15;

        shape.shapeType = ParticleSystemShapeType.Cone;
        // Great reference Dylan found: https://www.raywenderlich.com/113049/introduction-unity-particle-systems
    }
}
