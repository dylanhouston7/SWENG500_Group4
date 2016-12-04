#define BUILD_RELEASE
//#undef BUILD_RELEASE

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets;
using Assets.Scripts.DifficultySettings;
using Assets.Scripts.Scoring;
using Assets.Scripts.MaterialsRegistry;

public class GameContext : MonoBehaviour
{
    // Public Members
    public static GameContext m_context;

    /// <summary>
    /// Flag indicating that the installed mazes have been installed or not
    /// </summary>
    /// <remarks>
    /// This includes both pre-installed mazes and user installed maze challenge mazes
    /// </remarks>
    public bool m_installedMazesLoaded;

    /// <summary>
    /// Index of the next maze structure to load from the selected set of mazes
    /// </summary>
    public int m_activeMazeIndex;


    public bool m_isActiveMazeChallenge;

    /// <summary>
    /// Reference to the active maze
    /// </summary>
    public MazeStructure.Maze2D m_activeMaze;

    /// <summary>
    /// Reference to the active maze last hint solution path
    /// </summary>
    public List<MazeStructure.Cell2D> m_activeMazeHintSolutionPath;

    /// <summary>
    /// Current Player position in the maze
    /// </summary>
    public int m_currentPlayerMazePositionX;
    public int m_currentPlayerMazePositionZ;

    /// <summary>
    /// Reference to the active user
    /// </summary>
    public Account.AccountData m_activeUser;

    /// <summary>
    /// Flag indicating that the user is loaded
    /// </summary>
    public bool m_accountloaded;

    /// <summary>
    /// Flag indicating that the user is registered
    /// </summary>
    public bool m_registered;    

    /// <summary>
    /// Set of pre-installed mazes for each of the defined difficulty levels
    /// </summary>
    /// <remarks>
    /// Maze expansion packages should add to the below set of pre-installed mazes
    /// </remarks>
    public List<MazeStructure.Maze2D> m_easyMazes;
    public List<MazeStructure.Maze2D> m_mediumMazes;
    public List<MazeStructure.Maze2D> m_hardMazes;
    public List<MazeStructure.Maze2D> m_epicMazes;

    /// <summary>
    /// Flag indicating that the set of maze challenge mazes has changed
    /// </summary>
    /// <remarks>
    /// A change to the set of maze challenge mazes should result in the set of mazes being saved
    /// to the maze challenge maze data file
    /// </remarks>
    public bool m_mazeChallengeMazesChanged;

    /// <summary>
    /// Set of maze challenge mazes
    /// </summary>
    public List<MazeStructure.Maze2D> m_mazeChallengeMazes;

    /// <summary>
    /// Specifies the difficulty level of the game
    /// </summary>
    public IDifficulty difficulty;

    /// <summary>
    /// Specifies the score of the last maze completed
    /// Set by GameManager
    /// TODO: Better way to do this??
    /// </summary>
    public ScoreContainer score;

    /// <summary>
    /// Defines a reference to the materials registry Singleton
    /// </summary>
    /// <remarks>
    /// Provided for convenience
    /// </remarks>
    public MaterialsRegistry m_materialRegistry;

    // Unity Methods
    void Awake()
    {
        if (m_context == null)
        {
            DontDestroyOnLoad(gameObject);
            m_context = this;

            // Initialize Context Variables Only Once
            Initialize();
        }
        else if (m_context != this)
        {
            // Ensure that only the first GameContext persists between scenes
            Destroy(gameObject);
        }
    }

    void Initialize()
    {
        Debug.Log("GameContext Initialize Called");

        m_installedMazesLoaded = false;

        m_activeMazeIndex = 0;
        m_isActiveMazeChallenge = false;
        m_activeMaze = new MazeStructure.NullMaze();

        m_easyMazes = new List<MazeStructure.Maze2D>();
        m_mediumMazes = new List<MazeStructure.Maze2D>();
        m_hardMazes = new List<MazeStructure.Maze2D>();
        m_epicMazes = new List<MazeStructure.Maze2D>();

        m_mazeChallengeMazesChanged = false;
        m_mazeChallengeMazes = new List<MazeStructure.Maze2D>();

        m_activeUser = Account.AccountData.GetInstance();
        m_accountloaded = false;

        // Initializes the Materials Registry
        InitializeMaterialsRegistry();
    }

    /// <summary>
    /// Initialization Method for initialization of the Materials Registry
    /// </summary>
    /// <remarks>
    /// Method will load all material resources defined in the SceneConstants source file into the
    /// Materials Registry
    /// </remarks>
    void InitializeMaterialsRegistry()
    {
        // Sets the reference to the Materials Registry Singleton
        m_materialRegistry = MaterialsRegistry.GetInstance();

        // Load all defined Materials into the Materials Registry
        IList<MaterialResources.MaterialResource> mat_resources = MaterialResources.GetMaterialResources();
        for (int index = 0; index < mat_resources.Count; ++index)
        {
            // Reference to the indexed resource
            MaterialResources.MaterialResource resource = mat_resources[index];

            // Try to load the material resource
            Material material = Resources.Load(resource.path) as Material;

            // If material was loaded successfully add it to the registry
            if (material != null)
            {
                m_materialRegistry.AddMaterialEntry(new MaterialsRegistry.MaterialEntry(resource.name, material));
            }
            else
            {
                Debug.LogError("GameContext: Failed to Load Material Resource <" + resource.name + "> at path <" + resource.path + ">");
            }
        }
    }

    void OnEnable()
    {
        Debug.Log("GameContext: OnEnable method Called");


        String path = Application.persistentDataPath;

#if (BUILD_RELEASE)        
        path = Application.dataPath;
#endif

        Debug.Log("Path: " + path);

        if (!m_installedMazesLoaded)
        {            
            // Loads the Installed Mazes that come with the Game
            MazeDataSaveLoad.LoadMazeData(path + "/EasyMazes.dat", ref m_easyMazes);
            MazeDataSaveLoad.LoadMazeData(path + "/MediumMazes.dat", ref m_mediumMazes);
            MazeDataSaveLoad.LoadMazeData(path + "/HardMazes.dat", ref m_hardMazes);
            MazeDataSaveLoad.LoadMazeData(path + "/EpicMazes.dat", ref m_epicMazes);

            // Loads the Maze Challenge Mazes that can be either generated by the game, maze challenge, or imported
            MazeDataSaveLoad.LoadMazeData(path + "/ChallengeMazes.dat", ref m_mazeChallengeMazes);

            m_installedMazesLoaded = true;
        }

        if(!m_accountloaded)
        {
            m_accountloaded = Account.AccountDataSaveLoad.LoadAccountData(path + "/Account.dat", ref m_activeUser);
        }
    }

    void OnDisable()
    {
        Debug.Log("GameContext: OnDisable method Called");


        String path = Application.persistentDataPath;

#if (BUILD_RELEASE)
        path = Application.dataPath;
#endif

        // Save the Maze Challenge Mazes if they have been changed
        if (m_mazeChallengeMazesChanged)
        {
            MazeDataSaveLoad.SaveMazeData(path + "/ChallengeMazes.dat", m_mazeChallengeMazes);

            m_mazeChallengeMazesChanged = false;
        }

        // Save the Player History if the Player account is not a NullAccount meaning the user has registered an account
        if (m_accountloaded)
        {
            Account.AccountDataSaveLoad.SaveAccountData(path + "/Account.dat", m_activeUser);
        }
    }
}