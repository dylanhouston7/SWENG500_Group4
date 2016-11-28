using System;
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

    public Text textMazeHintsCount;

    /// <summary>
    /// The maze timer for the maze
    /// </summary>
    public Text textMazeTimer;

    /// <summary>
    /// Stores the maze score
    /// </summary>
    public ScoreContainer currentMazeScore;

    /// <summary>
    /// Specifies whether the number of hints that the user requested
    /// </summary>
    public int hintCount = 0;

    // Public Prefab References
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter tp;

    // Private Members
    private UnityAction m_handleEventRenderMazeCompleted;
    private UnityAction m_handleEventCompletedMaze;

    private Camera playerCam;

    // ********************************************
    // Unity Methods
    // ********************************************

    /// <summary>
    /// Unity Method for initialization of GameObject called first
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Awake()
    {
        // Initialize Member Variables
        //

        // Initialize Event Handlers
        m_handleEventRenderMazeCompleted = new UnityAction(RenderMazeCompleted);
        m_handleEventCompletedMaze = new UnityAction(CompletedMaze);

        // Initialize GameContext Elements
        GameContext.m_context.m_activeMaze = new MazeStructure.NullMaze();
        //GameContext.m_context.m_activeUser = GameContext.m_context.m_activeUser;
    }

    /// <summary>
    /// Unity Method for initialization of GameObject called after Awake()
    /// </summary>
    /// <remarks>
    /// Called each time the GameObject is enabled
    /// </remarks>
    void OnEnable()
    {
        EventManager.StartListening("CompletedMaze", m_handleEventCompletedMaze);
        EventManager.StartListening("RenderMazeCompleted", m_handleEventRenderMazeCompleted);            
    }

    /// <summary>
    /// Unity Method for initialization of GameObject called after OnEnable()
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Start()
    {
        textMazeHintsCount.text = hintCount.ToString();

        // Set reference to the maze set
        List<MazeStructure.Maze2D> activeMazes = new List<MazeStructure.Maze2D>();
        if (!GameContext.m_context.m_isActiveMazeChallenge)
        {
            switch (GameContext.m_context.difficulty.Difficulty)
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
        }
        else
        {
            activeMazes = GameContext.m_context.m_mazeChallengeMazes;
        }


        // Load the Active Maze Index
        if (GameContext.m_context.m_activeMazeIndex >= 0 &&
            GameContext.m_context.m_activeMazeIndex < activeMazes.Count)
        {
            Debug.Log("GameManager: Loading Maze Index " + GameContext.m_context.m_activeMazeIndex);

            // Set the GameContext to the Active Maze Reference
            GameContext.m_context.m_activeMaze = activeMazes[GameContext.m_context.m_activeMazeIndex];

            // Display the Active Maze Properties
            textCurrentMazeName.text = GameContext.m_context.m_activeMaze.Name;
            textCurrentMazeDifficultyLevel.text = GameContext.m_context.difficulty.DifficultyString;

            // Reset Maze Timer
            GameContext.m_context.difficulty.ResetTimer();


            // Publish Event: RenderMaze
            EventManager.TriggerEvent("RenderMaze");
        }
        else
        {
            Debug.Log("GameManager: Invalid Maze Index " + GameContext.m_context.m_activeMazeIndex);

            // TODO: Display Error Message and Return to the Maze Level Scene
        }
    }

    /// <summary>
    /// Unity Method called each frame if the behavior is enabled
    /// </summary>
    /// <remarks>
    /// The rate this method is called is not deterministic. For deterministic updates
    /// use the Unity FixedUpdate Methode instead
    /// </remarks>
    void Update()
    {

        // Testing allows you to end game as if time ran out
        if (Input.GetKeyDown(KeyCode.G))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.GameOverScene);
        }

        // Mute Music
        if (Input.GetKeyDown(KeyCode.F10))
        {
            AudioListener.pause = !AudioListener.pause;
        }

        // Screen Shot
        if (Input.GetKeyDown(KeyCode.M))
        {
            var dayTime = DateTime.Now.ToString("M-d-y h-mm-ss tt");
            Debug.Log(dayTime);
            Debug.Log("saved screen shot");
            Application.CaptureScreenshot(dayTime + ".png");

        }        

        // Pause Button Logic    
        if (Input.GetKeyDown(KeyCode.P))
        {
            var currentTimeValue = Time.timeScale;
            if (currentTimeValue == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            Debug.Log("Game Paused");

        }


        // *************************************************************************
        // *************************************************************************
        //// TEST CODE: Shows the Maze Solution
        //if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        //{
        //    Debug.Log("GameManager: Showing Maze Solution");

        //    // Maze solution path based on the maze start cell
        //    GameContext.m_context.m_activeMazeHintSolutionPath = GameContext.m_context.m_activeMaze.MazeSolutionPath;

        //    EventManager.TriggerEvent("ShowMazeSolution");
        //}

        //// TEST CODE: Shows the Maze Solution
        //if (Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.S))
        //{
        //    Debug.Log("GameManager: Hiding Maze Solution");

        //    EventManager.TriggerEvent("HideMazeSolution");
        //}

        // TEMP CODE: For exiting maze level loop to return to main menu
        // Should replace this with an in game UI element; such as a button
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("GameManager: Exiting to Main Menu");

            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        // *************************************************************************
        // *************************************************************************

        //// TEST CODE: Allows rapid testing of the score screen
        //if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
        //{
        //    Debug.Log("GameManager: Skipping to Score Screen");

        //    EventManager.TriggerEvent("CompletedMaze");
        //}
    }

    /// <summary>
    /// Unity Method called when the behavior is disabled or inactive
    /// </summary>
    /// <remarks>
    /// Called each time the GameObject is disabled
    /// </remarks>
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
            Debug.Log("GameManager: Positioning Player GameObject at Maze Start Cell");

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

    void createPlayerCamera()
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

        //Destroy origional camera
        GameObject.DestroyObject(original);

        //Enable the new camera
        playerCam.enabled = true;
    }

    void CompletedMaze()
    {
        Debug.Log("GameManager: CompletedMaze Method Called!");

        int totalCompletionTimeInSeconds = GameContext.m_context.difficulty.Timer.GetTotalSecondsRecorded();
        GameContext.m_context.score = ScoreCalculator.CalculateScore(GameContext.m_context.difficulty, totalCompletionTimeInSeconds, hintCount);

        GameContext.m_context.difficulty.GetRandomMaze();

        // TODO: Store Player Score to the GameContext current Player account
        Account.AccountCompletedMaze mazeCompleted = new Account.AccountCompletedMaze();

        mazeCompleted.dateAchieved = DateTime.Now;
        mazeCompleted.points = GameContext.m_context.score.TotalScore;
        mazeCompleted.maze_guid = GameContext.m_context.m_activeMaze.GUID;

        if (GameContext.m_context.m_activeUser.completedMazes == null)
        {
            GameContext.m_context.m_activeUser.completedMazes = new List<Account.AccountCompletedMaze>();
        }

        GameContext.m_context.m_activeUser.completedMazes.Add(mazeCompleted);

        if (GameContext.m_context.m_registered)
        {
            Account.AccountDataSaveLoad.SaveAccountData(Application.persistentDataPath + "/Account.dat", GameContext.m_context.m_activeUser);
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MazeCompleteScene);
    }

    public void HandleMazeHintRequest()
    {
        Debug.Log("GameManager: Showing Maze Hint");

        // Determine the current maze solution path based on the player's current position in the maze
        MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse,
                                       GameContext.m_context.m_activeMaze,
                                       GameContext.m_context.m_activeMaze.GetCell(GameContext.m_context.m_currentPlayerMazePositionX, GameContext.m_context.m_currentPlayerMazePositionZ),
                                       ref GameContext.m_context.m_activeMazeHintSolutionPath);

        if (GameContext.m_context.m_activeMazeHintSolutionPath.Count >= 2)
        {
            EventManager.TriggerEvent("ShowMazeHint");

            // Increment hint counter
            ++hintCount;
        }

        textMazeHintsCount.text = hintCount.ToString();
    }
}
