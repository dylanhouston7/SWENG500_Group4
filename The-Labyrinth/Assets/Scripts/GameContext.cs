using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.DifficultySettings;
using Assets.Scripts.Scoring;

public class GameContext : MonoBehaviour
{
    // Public Members
    public static GameContext m_context;

    /// <summary>
    /// Flag indicating that the installed mazes have been installed or not
    /// </summary>
    /// <remarks>
    /// This includes both pre-installed mazes and user installed imported mazes
    /// </remarks>
    public bool m_installedMazesLoaded;

    /// <summary>
    /// Index of the next maze structure to load from the selected set of mazes
    /// </summary>
    public int m_nextMazeIndex;

    /// <summary>
    /// Reference to the active maze
    /// </summary>
    public MazeStructure.Maze2D m_activeMaze;

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
    /// Flag indicating that the set of imported mazes has changed
    /// </summary>
    /// <remarks>
    /// A change to the set of imported mazes should result in the set of mazes being saved
    /// to the imported maze data file
    /// </remarks>
    bool m_importMazesChanged;

    /// <summary>
    /// Set of user imported mazes
    /// </summary>
    public List<MazeStructure.Maze2D> m_importedMazes;

    /// <summary>
    /// Specifies the difficulty level of the game
    /// </summary>
    public IDifficulty difficulty;

    /// <summary>
    /// Specifies the score of the last maze completed
    /// Set by GameManager
    /// TODO: Better way to do this??
    /// </summary>
    public Score score;

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
        m_installedMazesLoaded = false;

        m_nextMazeIndex = 0;
        m_activeMaze = new MazeStructure.NullMaze();
        m_easyMazes = new List<MazeStructure.Maze2D>();
        m_mediumMazes = new List<MazeStructure.Maze2D>();
        m_hardMazes = new List<MazeStructure.Maze2D>();
        m_epicMazes = new List<MazeStructure.Maze2D>();

        m_importMazesChanged = false;
        m_importedMazes = new List<MazeStructure.Maze2D>();
    }

    void OnEnable()
    {
        if(!m_installedMazesLoaded)
        {
            MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/EasyMazes.dat", ref m_easyMazes);
            MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/MediumMazes.dat", ref m_mediumMazes);
            MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/HardMazes.dat", ref m_hardMazes);
            MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/EpicMazes.dat", ref m_epicMazes);
            MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/ImportedMazes.dat", ref m_importedMazes);

            m_installedMazesLoaded = true;
        }
    }

    void OnDisable()
    {        
        if(m_importMazesChanged)
        {
            MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/ImportedMazes.dat", m_importedMazes);

            m_importMazesChanged = false;
        }
    }
}
