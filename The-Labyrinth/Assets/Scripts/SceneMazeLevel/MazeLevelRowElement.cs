using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Assets;

public class MazeLevelRowElement : MonoBehaviour
{   
    // Public GameObject References
    public GameObject m_parentRowElement;
    public Text m_textMazeName;
	public Text m_textDateCompleted;
	public Text m_textScore;
    public Button m_buttonStart;

    // Private Variables
    int m_mazeRefIndex;


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
        m_textMazeName.text = "";
		m_textDateCompleted.text = "";
		m_textScore.text = "";

        m_mazeRefIndex = -1;
    }

    // ********************************************
    // Public Methods
    // ********************************************

    /// <summary>
    /// Method used to initialize the maze level row element
    /// </summary>
    /// <param name="mazeRefIndex">Index in the GameContext maze set that the reference maze is stored</param>
    /// <param name="mazeRef">Reference maze that the maze level row element represents</param>
    public void Initialize(int mazeRefIndex, MazeStructure.Maze2D mazeRef)
    {
        // Set the Maze Reference Index
        m_mazeRefIndex = mazeRefIndex;

        // Set the Maze Name
        m_textMazeName.text = mazeRef.Name;

        //Get Completed Maze Data
        checkIfCompleted(mazeRef.GUID);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    // ********************************************
    // Public EventSystem Handler Methods
    // ********************************************

    /// <summary>
    /// Method used to start the referenced GameContext maze
    /// </summary>
    public void StartMaze()
    {
        if(m_mazeRefIndex >= 0)
        {
            // Set the GameContext Active Maze Index to the maze referenced by this maze level row element
            GameContext.m_context.m_activeMazeIndex = m_mazeRefIndex;

            GameContext.m_context.m_isActiveMazeChallenge = false;

            // Load the Main Scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainScene);
        }
    }

    private void checkIfCompleted(Guid guid)
    {
        if(GameContext.m_context.m_activeUser.completedMazes != null)
        {
            foreach(Account.AccountCompletedMaze maze in GameContext.m_context.m_activeUser.completedMazes)
            {
                if(maze.maze_guid == guid)
                {
                    // Set the Maze Date
                    m_textDateCompleted.text = "COMPLETED: " + maze.dateAchieved.ToShortDateString();

                    //Set Completed Maze Score
                    m_textScore.text = "SCORE: " + maze.points.ToString();

                    // Disable the Start Button
                    m_buttonStart.gameObject.SetActive(false);
                }
            }
        }
    }
}
