using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using Assets.Scripts.DifficultySettings;

public class GameManager : MonoBehaviour
{
    // Public GameObject References
    public Text textCurrentMazeName;
    public Text textCurrentMazeDifficultyLevel;

    /// <summary>
    /// The maze timer for the maze
    /// </summary>
    public Text textMazeTimer;

    // Public Prefab References
    public UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter tp;

    // Private Members
    private UnityAction m_handleEventRenderMazeCompleted;
    private UnityAction m_handleEventCompletedMaze;

    private Camera playerCam;

    public float xCameraRotate = 45;

    // Unity Methods
    void Awake()
    {
        // Initialize Member Variables
        //

        // Initialize Event Handlers
        m_handleEventRenderMazeCompleted = new UnityAction(RenderMazeCompleted);
        m_handleEventCompletedMaze = new UnityAction(CompletedMaze);

        // Initialize GameContext Elements
        GameContext.m_context.m_currentMaze = new MazeStructure.NullMaze();
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
                GameContext.m_context.m_currentMaze = GameContext.m_context.difficulty.GetRandomMaze();

                // Modify the default maze structure with the maze generation algorithm
                MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, GameContext.m_context.m_currentMaze);

                // Solve the generated maze with the maze solving algorithm
                MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse, GameContext.m_context.m_currentMaze);

                // Set Maze Properties:
                GameContext.m_context.m_currentMaze.Name = "Auto Generated";
            }

            // Publish Event: RenderMaze
            EventManager.TriggerEvent("RenderMaze");
            textCurrentMazeName.text = GameContext.m_context.m_currentMaze.Name;

            // Set the difficulty mode string
            textCurrentMazeDifficultyLevel.text = GameContext.m_context.difficulty.DifficultyString;
        }


        // *************************************************************************
        // *************************************************************************
        // TEST CODE: Shows the Maze Solution
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("GameManager: Showing Maze Solution");

            EventManager.TriggerEvent("ShowMazeSolution");
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
        playerCam.transform.position = new Vector3(x, y + 1, z - 0.2f);
        playerCam.gameObject.transform.Rotate(new Vector3(xCameraRotate, 0, 0));

        //Destroy origional camera
        GameObject.DestroyObject(original);

        //Enable the new camera
        playerCam.enabled = true;
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

        // *************************************************************************
        // *************************************************************************
        // TEMP CODE: 
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        // *************************************************************************
        // *************************************************************************
    }
}
