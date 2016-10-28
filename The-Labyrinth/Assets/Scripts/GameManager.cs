using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.DifficultySettings;
using Assets;
using Assets.Scripts;
using Assets.Scripts.Scoring;

public class GameManager : MonoBehaviour
{
    // Public GameObject References
    public Text textCurrentMazeName;
    public Text textCurrentMazeDifficultyLevel;

    /// <summary>
    /// The maze timer for the maze
    /// </summary>
    public Text textMazeTimer;

    /// <summary>
    /// Stores the maze score
    /// </summary>
    public ScoreContainer currentMazeScore;

    /// <summary>
    /// Specifies whether or not the user has requested hint assistance
    /// </summary>
    public bool hintShown = false;

    // Public Prefab References
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter tp;

    // Private Members
    private UnityAction m_handleEventRenderMazeCompleted;
    private UnityAction m_handleEventCompletedMaze;

    private Camera playerCam;

    // Unity Methods
    void Awake()
    {
        // Initialize Member Variables
        //

        // Initialize Event Handlers
        m_handleEventRenderMazeCompleted = new UnityAction(RenderMazeCompleted);
        m_handleEventCompletedMaze = new UnityAction(CompletedMaze);

        // Initialize GameContext Elements
        GameContext.m_context.m_activeMaze = new MazeStructure.NullMaze();
    }

    void Update()
    {
        // *************************************************************************
        // *************************************************************************
        // TEST CODE: Shows the Maze Solution
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("GameManager: Showing Maze Solution");

            // Maze solution path based on the maze start cell
            GameContext.m_context.m_activeMazeSolutionPath = GameContext.m_context.m_activeMaze.MazeSolutionPath;

            EventManager.TriggerEvent("ShowMazeSolution");
        }

        if (Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("GameManager: Hiding Maze Solution");

            EventManager.TriggerEvent("HideMazeSolution");
        }

        // TEST CODE: Shows the Maze Solution Based on the current Player position in the maze
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("GameManager: Showing Maze Hint");

            // Determine the current maze solution path based on the player's current position in the maze
            MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse,
                                           GameContext.m_context.m_activeMaze,
                                           GameContext.m_context.m_activeMaze.GetCell(GameContext.m_context.m_currentPlayerMazePositionX, GameContext.m_context.m_currentPlayerMazePositionZ),
                                           ref GameContext.m_context.m_activeMazeSolutionPath);

            if (GameContext.m_context.m_activeMazeSolutionPath.Count >= 2)
            {
                EventManager.TriggerEvent("ShowMazeSolution");
                EventManager.TriggerEvent("ShowMazeHint");
            }
        }

        // TEMP CODE: For exiting maze level loop to return to main menu
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("GameManager: Exiting to Main Menu");

            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        // *************************************************************************
        // *************************************************************************

        // TEST CODE: Allows rapid testing of the score screen
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("GameManager: Skipping to Score Screen");

            EventManager.TriggerEvent("CompletedMaze");
        }
    }

    void OnEnable()
    {
        EventManager.StartListening("CompletedMaze", m_handleEventCompletedMaze);
        EventManager.StartListening("RenderMazeCompleted", m_handleEventRenderMazeCompleted);

        // Set reference to the mazes of selected difficulty
        List<MazeStructure.Maze2D> activeMazes = new List<MazeStructure.Maze2D>();
        switch(GameContext.m_context.difficulty.Difficulty)
        {
            case DifficultyEnum.EASY:
                {
                    activeMazes = GameContext.m_context.m_easyMazes;
                    break;
                }
            case DifficultyEnum.MEDIUM:
                {
                    activeMazes = GameContext.m_context.m_mediumMazes;
                    break;
                }
            case DifficultyEnum.HARD:
                {
                    activeMazes = GameContext.m_context.m_hardMazes;
                    break;
                }
            case DifficultyEnum.EPIC:
                {
                    activeMazes = GameContext.m_context.m_epicMazes;
                    break;
                }
            default:
                {
                    break;
                }
        };


        // Load/Generate a Maze Level
        if (GameContext.m_context.m_nextMazeIndex < activeMazes.Count)
        {
            Debug.Log("GameManager: Loading Installed Maze Index " + GameContext.m_context.m_nextMazeIndex);

            GameContext.m_context.m_activeMaze = activeMazes[GameContext.m_context.m_nextMazeIndex];

            ++GameContext.m_context.m_nextMazeIndex;
        }
        else
        {
            Debug.Log("GameManager: Generating Maze");

            // Get a default maze structure based on the defined difficulty level
            GameContext.m_context.m_activeMaze = GameContext.m_context.difficulty.GetRandomMaze();

            // Set Maze Properties:
            GameContext.m_context.m_activeMaze.Name = "Auto Generated";
            GameContext.m_context.m_activeMaze.Difficulty = GameContext.m_context.difficulty.Difficulty;

            // Modify the default maze structure with the maze generation algorithm
            MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, GameContext.m_context.m_activeMaze);

            // Solve the generated maze with the maze solving algorithm
            List<MazeStructure.Cell2D> solutionPath = new List<MazeStructure.Cell2D>();
            MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse, 
                                           GameContext.m_context.m_activeMaze,
                                           GameContext.m_context.m_activeMaze.GetStartCell(),
                                           ref solutionPath);

            // Store Solution Path
            GameContext.m_context.m_activeMaze.MazeSolutionPath = solutionPath;
        }

        // Display the Maze Properties
        textCurrentMazeName.text = GameContext.m_context.m_activeMaze.Name;
        textCurrentMazeDifficultyLevel.text = GameContext.m_context.difficulty.DifficultyString;

        // Reset the timer for the maze
        GameContext.m_context.difficulty.ResetTimer();

        // Publish Event: RenderMaze
        EventManager.TriggerEvent("RenderMaze");
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
        MazeStructure.Cell2D startCell = GameContext.m_context.m_activeMaze.GetStartCell();
        if(!startCell.IsNull())
        {
            // TODO: Place Player GameObject at the start cell location
            // startCell.PositionX
            // startCell.PositionZ
            // 

            // TODO: Enable Player GameObject
            //
            GameObject obj;
            obj = Instantiate(Resources.Load("ThirdPersonCharacter/Prefabs/ThirdPersonController"), transform) as GameObject;
            tp = obj.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
            tp.transform.position = new Vector3(startCell.PositionX, 0.5f, startCell.PositionZ);
            tp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            this.createPlayerCamera();
        }

    }

    private void createPlayerCamera()
    {
        // Find the 'main' camera object.
        var original = GameObject.FindWithTag("MainCamera");

        // Create a new camera to use, copying from the main camera
        // Notice how we provide a position and a rotation for it.  
        float x = tp.transform.position.x;
        float y = tp.transform.position.y;
        float z = tp.transform.position.z;

        //Create player camera
        playerCam = (Camera)Camera.Instantiate(original.GetComponent<Camera>(), new Vector3(x, y, z), Quaternion.FromToRotation(new Vector3(0, 0, 0), new Vector3(0, 0, 0)));

        //Attach Camera Controller to player camera object
        playerCam.gameObject.AddComponent<CameraController>().player = tp.gameObject;

        //Set initial Position
        playerCam.transform.position = new Vector3(x, y + .7f, z - 0.4f);
        playerCam.nearClipPlane = 0.1f;

        //Destroy origional camera
        GameObject.DestroyObject(original);

        //Enable the new camera
        playerCam.enabled = true;
    }

    void CompletedMaze()
    {
        Debug.Log("GameManager: CompletedMaze Method Called!");

        int totalCompletionTimeInSeconds = GameContext.m_context.difficulty.Timer.GetTotalSecondsRecorded();
        GameContext.m_context.score = ScoreCalculator.CalculateScore(GameContext.m_context.difficulty, totalCompletionTimeInSeconds, hintShown);

        GameContext.m_context.difficulty.GetRandomMaze();

        // TODO: Store Player Score to the GameContext current Player account

        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MazeCompleteScene);

    }
}
