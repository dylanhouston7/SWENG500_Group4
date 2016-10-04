using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Public Members
    public MazeStructure.Maze2D m_mazeStructure = null;

    // Private Memebers
    private UnityAction m_handleEventRenderMazeCompleted;
    private UnityAction m_handleEventCompletedMaze;
    private int m_sizeX, m_sizeZ;

    // Unity Methods
    void Awake()
    {
        // Initialize Member Variables        
        m_mazeStructure = new MazeStructure.NullMaze();

        // Initialize Event Handlers
        m_handleEventRenderMazeCompleted = new UnityAction(RenderMazeCompleted);
        m_handleEventCompletedMaze = new UnityAction(CompletedMaze);
        
        // Initialize the Difficulty Level
        switch (GameContext.m_context.m_difficultyLevel)
        {
            case 0: { m_sizeX = 10; m_sizeZ = 10; break; }
            case 1: { m_sizeX = 15; m_sizeZ = 15; break; }
            case 2: { m_sizeX = 20; m_sizeZ = 20; break; }
            default:
                {
                    m_sizeX = 10; m_sizeZ = 10; break;
                }
        };
    }

    void Update()
    {
        // Load/Generate a new Maze Level
        if (m_mazeStructure.IsNull())
        {
            if(GameContext.m_context.m_nextMazeIndex < GameContext.m_context.m_installedMazes.Count)
            {
                Debug.Log("GameManager: Loading Installed Maze Index " + GameContext.m_context.m_nextMazeIndex);

                m_mazeStructure = GameContext.m_context.m_installedMazes[GameContext.m_context.m_nextMazeIndex];

                ++GameContext.m_context.m_nextMazeIndex;
            }
            else
            {
                Debug.Log("GameManager: Generating Maze");

                // Get a default maze structure of defined size
                m_mazeStructure = MazeStructure.Maze2D.GetInstance(m_sizeX, m_sizeZ);

                // Modify the default maze structure with the maze generation algorithm
                MazeStructure.DepthFirstSearchMazeGenerator.Generate(m_mazeStructure);
            }

            // Publish Event: RenderMaze
            EventManager.TriggerEvent("RenderMaze");
        }


        // *************************************************************************
        // *************************************************************************
        // TEST CODE: Testing Save/Load Installed Mazes
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("GameManager: Adding Current Maze to Installed Mazes List");

            GameContext.m_context.m_installedMazes.Add(m_mazeStructure);
        }

        // TEMP CODE: For exiting maze level loop to return to main menu
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("GameManager: Exiting to Main Menu");

            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        // *************************************************************************
        // *************************************************************************
    }

    void OnEnable()
    {
        EventManager.StartListening("CompletedMaze", m_handleEventCompletedMaze);
        EventManager.StartListening("RenderMazeCompleted", m_handleEventRenderMazeCompleted);
    }

    void OnDisable()
    {
        EventManager.StopListening("CompletedMaze", m_handleEventCompletedMaze);
        EventManager.StopListening("RenderMazeCompleted", m_handleEventRenderMazeCompleted);
    }


    // Event Subscribers
    void RenderMazeCompleted()
    {
        Debug.Log("GameManager: RenderMazeCompleted Method Called!");

        // Post Maze Rendering:
        // - Position Player GameObject at Maze Starting Cell
        // - Enable the Player GameObject

        // Get the Maze StartCell
        MazeStructure.Cell2D startCell = m_mazeStructure.GetStartCell();
        if(!startCell.IsNull())
        {
            // TODO: Place Player GameObject at the start cell location
            // startCell.PositionX
            // startCell.PositionZ
            // 

            // TODO: Enable Player GameObject
            //
        }
    }

    void CompletedMaze()
    {
        Debug.Log("GameManager: CompletedMaze Method Called!");

        // TODO: Calculate Player Score
        //

        // TODO: Store Player Score to the GameContext
        //

        // Load Main Menu
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
