using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Public Members
    public Player playerPrefab;

    // Private Memebers
    private UnityAction m_handleEventRenderMazeCompleted;
    private UnityAction m_handleEventCompletedMaze;
    private int m_sizeX, m_sizeZ;

    private Player playerInstance = null;

    // Unity Methods
    void Awake()
    {
        // Initialize Member Variables        
        //

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
        // Load/Generate a Maze Level
        if (GameContext.m_context.m_currentMaze.IsNull())
        {
            if(GameContext.m_context.m_nextMazeIndex < GameContext.m_context.m_installedMazes.Count)
            {
                Debug.Log("GameManager: Loading Installed Maze Index " + GameContext.m_context.m_nextMazeIndex);

                GameContext.m_context.m_currentMaze = GameContext.m_context.m_installedMazes[GameContext.m_context.m_nextMazeIndex];

                ++GameContext.m_context.m_nextMazeIndex;
            }
            else
            {
                Debug.Log("GameManager: Generating Maze");

                // Get a default maze structure of defined size
                GameContext.m_context.m_currentMaze = MazeStructure.Maze2D.GetInstance(m_sizeX, m_sizeZ);

                // Modify the default maze structure with the maze generation algorithm
                MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, GameContext.m_context.m_currentMaze);
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

            GameContext.m_context.m_installedMazes.Add(GameContext.m_context.m_currentMaze);
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
        MazeStructure.Cell2D startCell = GameContext.m_context.m_currentMaze.GetStartCell();
        if(!startCell.IsNull())
        {
            // TODO: Place Player GameObject at the start cell location
            // startCell.PositionX
            // startCell.PositionZ
            // 

            // TODO: Enable Player GameObject
            //
            GameObject obj;
            obj = Instantiate(Resources.Load("Player"), transform) as GameObject;
            obj.GetComponent<Player>().startingPos = new Vector3(startCell.PositionX, 0.5f, startCell.PositionZ);

        }
    }

    void CompletedMaze()
    {
        Debug.Log("GameManager: CompletedMaze Method Called!");

        // TODO: Calculate Player Score
        //

        // TODO: Store Player Score to the GameContext current Player account
        //

        // TODO: Load Maze Completion Summary Menu
        // - Should provide the user with:
        //  + Player's calculated score
        //  + Option to go to next installed maze level if one exists
        //  + Option to go to the main menu

        // Reset the currentMaze instance
        GameContext.m_context.m_currentMaze = new MazeStructure.NullMaze();

        // *************************************************************************
        // *************************************************************************
        // TEMP CODE: 
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        // *************************************************************************
        // *************************************************************************
    }
}
