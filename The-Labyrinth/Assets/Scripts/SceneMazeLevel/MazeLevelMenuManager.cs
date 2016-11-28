using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

using Assets;

public class MazeLevelMenuManager : MonoBehaviour
{
    // GameObject References
    public Text m_textMenuTitleRef;
    public Button m_buttonViewInstalledMazesRef;
    public Button m_buttonViewChallengeMazesRef;
    public MazeLevelGrid m_mazeLevelGridRef;
    public Scrollbar m_scrollbarMazeListRef;



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
        m_textMenuTitleRef.text = GameContext.m_context.difficulty.DifficultyString + " MAZE LEVELS";

        // Set Maze Level List Entries
        List<MazeStructure.Maze2D> installedMazes;
        GetInstalledMazes(out installedMazes);
        for (int index = 0; index < installedMazes.Count; ++index)
        {
            m_mazeLevelGridRef.AddMazeLevelRowElement(index, installedMazes[index]);
        }

        // Set the Maze Challenge List Entries
        for(int index = 0; index < GameContext.m_context.m_mazeChallengeMazes.Count; ++index)
        {
            if(GameContext.m_context.m_mazeChallengeMazes[index].Difficulty == GameContext.m_context.difficulty.Difficulty)
            {
                m_mazeLevelGridRef.AddMazeChallengeRowElement(index, GameContext.m_context.m_mazeChallengeMazes[index]);
            }            
        }

        // Default to only Viewing Installed Mazes
        ViewInstalledMazes();
    }

    void OnDisable()
    {

    }

    void Update()
    {
        // Mute Music
        if (Input.GetKeyDown(KeyCode.F10))
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }

    // ********************************************
    // Public EventSystem Handler Methods
    // ********************************************

    public void ViewInstalledMazes()
    {
        m_buttonViewInstalledMazesRef.interactable = false;
        m_buttonViewChallengeMazesRef.interactable = true;
        m_scrollbarMazeListRef.value = 1;


        m_mazeLevelGridRef.HideMazeChallengeRows();
        m_mazeLevelGridRef.ShowMazeLevelRows();
    }

    public void ViewChallengeMazes()
    {
        m_buttonViewInstalledMazesRef.interactable = true;
        m_buttonViewChallengeMazesRef.interactable = false;
        m_scrollbarMazeListRef.value = 1;

        m_mazeLevelGridRef.HideMazeLevelRows();
        m_mazeLevelGridRef.ShowMazeChallengeRows();
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartNewMazeChallenge()
    {
        // Generate a New Maze Challenge Maze
        MazeStructure.Maze2D mazeChallenge = GameContext.m_context.difficulty.GetRandomMaze();

        // Get list of available materials and select two random materials
        IList<MaterialResources.MaterialResource> materials = MaterialResources.GetMaterialResources();
        System.Random rand = new System.Random();
        int floor_material = rand.Next(0, materials.Count);
        int wall_material = rand.Next(0, materials.Count);

        // Set a Random Maze Cell Floor Material
        mazeChallenge.CellFloorMaterialKey = materials[floor_material].name;

        // Set a Random Maze Cell Wall Material
        mazeChallenge.CellWallMaterialKey = materials[wall_material].name;

        // Store the New Maze Challenge Maze
        GameContext.m_context.m_mazeChallengeMazes.Add(mazeChallenge);
        GameContext.m_context.m_mazeChallengeMazesChanged = true;

        // Set Maze Properties
        mazeChallenge.Name = "Challenge " + GameContext.m_context.m_mazeChallengeMazes.Count.ToString();

        // Set the GameContext Active Maze Index to the new maze challenge maze
        GameContext.m_context.m_activeMazeIndex = GameContext.m_context.m_mazeChallengeMazes.Count - 1;

        GameContext.m_context.m_isActiveMazeChallenge = true;

        // Load the Main Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainScene);
    }

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
    void GetInstalledMazes(out List<MazeStructure.Maze2D> mazes)
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
