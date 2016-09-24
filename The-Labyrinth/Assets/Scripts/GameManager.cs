using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Public Members
    public MazeStructure.Maze2D mazeStructure = null;

    // Private Memebers
    private UnityAction handleEventCompletedMaze;
    private int sizeX, sizeZ;    

    // Unity Methods
    void Awake()
    {
        // Initialize Event Handlers
        handleEventCompletedMaze = new UnityAction(CompletedMaze);
        
        // Initialize the Difficulty Level
        switch (GameContext.m_context.m_difficultyLevel)
        {
            case 0: { sizeX = 10; sizeZ = 10; break; }
            case 1: { sizeX = 15; sizeZ = 15; break; }
            case 2: { sizeX = 20; sizeZ = 20; break; }
            default:
                {
                    sizeX = 10; sizeZ = 10; break;
                }
        };
    }

    void Update()
    {
        // Load/Generate a new Maze Level
        if (mazeStructure == null)
        {
            Debug.Log("GameManager: Generating Maze");

            // Get a default maze structure of defined size
            mazeStructure = MazeStructure.Maze2D.GetInstance(sizeX, sizeZ);

            // Modify the default maze structure with the maze generation algorithm
            MazeStructure.DepthFirstSearchMazeGenerator.Generate(mazeStructure);

            // Publish Event: RenderMaze
            EventManager.TriggerEvent("RenderMaze");
        }

        // TODO: Remove :: Test Code Only
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.TriggerEvent("CompletedMaze");
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("CompletedMaze", handleEventCompletedMaze);
    }

    void OnDisable()
    {
        EventManager.StopListening("CompletedMaze", handleEventCompletedMaze);
    }

    // Event Subscribers
    void CompletedMaze()
    {
        Debug.Log("GameManager: CompletedMaze Method Called!");

        // TODO: Calculate Player Score
        //

        // TODO: Store Player Score to the GameContext
        //

        // Load Main Menu
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
