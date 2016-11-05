using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

using Assets;

public class MazeLevelMenuManager : MonoBehaviour
{
    // GameObject References
    public Text textMenuTitleRef;
    public MazeLevelGrid mazeLevelGridRef;


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

    }

    /// <summary>
    /// Unity Method for initialization of GameObject called after Awake()
    /// </summary>
    /// <remarks>
    /// Called each time the GameObject is enabled
    /// </remarks>
    void OnEnable()
    {

    }

    /// <summary>
    /// Unity Method for initialization of GameObject called after OnEnable()
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Start()
    {
        // Set Maze Level Menu Title
        textMenuTitleRef.text = GameContext.m_context.difficulty.DifficultyString + " MAZE LEVELS";

        // Set Maze Level List Entries
        List<MazeStructure.Maze2D> mazes;
        GetMazes(out mazes);
        for (int index = 0; index < mazes.Count; ++index)
        {
            mazeLevelGridRef.AddMazeLevelRowElement(index, mazes[index]);
        }
    }

    void OnDisable()
    {

    }

    void Update()
    {

    }

    // ********************************************
    // Public EventSystem Handler Methods
    // ********************************************

    /// <summary>
    /// Method for Navigating back to the Difficulty Scene
    /// </summary>
    public void LoadDifficultyScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.DifficultyScene);
    }

    /// <summary>
    /// Method for Navigating back to the Main Menu Scene
    /// </summary>
    public void LoadMainMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
    }

    // ********************************************
    // Private Helper Methods
    // ********************************************

    /// <summary>
    /// Method for retrieving the set of mazes of difficulty as selected on the Difficulty Menu
    /// </summary>
    /// <param name="mazes">Set of mazes of difficulty as set in the GameContext</param>
    void GetMazes(out List<MazeStructure.Maze2D> mazes)
    {
        mazes = new List<MazeStructure.Maze2D>();

        switch (GameContext.m_context.difficulty.Difficulty)
        {
            case Assets.Scripts.DifficultySettings.DifficultyEnum.EASY:
                {
                    mazes = GameContext.m_context.m_easyMazes;
                    break;
                }
            case Assets.Scripts.DifficultySettings.DifficultyEnum.MEDIUM:
                {
                    mazes = GameContext.m_context.m_mediumMazes;
                    break;
                }
            case Assets.Scripts.DifficultySettings.DifficultyEnum.HARD:
                {
                    mazes = GameContext.m_context.m_hardMazes;
                    break;
                }
            case Assets.Scripts.DifficultySettings.DifficultyEnum.EPIC:
                {
                    mazes = GameContext.m_context.m_epicMazes;
                    break;
                }
        }
    }
}
