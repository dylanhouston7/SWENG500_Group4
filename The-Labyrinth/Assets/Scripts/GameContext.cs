using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.DifficultySettings;

public class GameContext : MonoBehaviour
{
    // Public Members
    public static GameContext m_context;

    // Public Persistent Storage between Scenes
    public bool m_installedMazesLoaded;
    public int m_nextMazeIndex;
    public List<List<MazeStructure.Maze2D>> m_installedMazes;

    public MazeStructure.Maze2D m_currentMaze;

    /// <summary>
    /// Specifies the difficulty level of the game
    /// </summary>
    public IDifficulty difficulty;

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

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }


    void Initialize()
    {
        m_installedMazesLoaded = false;

        m_nextMazeIndex = 0;
        m_installedMazes = new List<List<MazeStructure.Maze2D>>(4);
        m_installedMazes.Add(new List<MazeStructure.Maze2D>()); // Easy Difficulty Mazes
        m_installedMazes.Add(new List<MazeStructure.Maze2D>()); // Medium Difficulty Mazes
        m_installedMazes.Add(new List<MazeStructure.Maze2D>()); // Hard Difficulty Mazes
        m_installedMazes.Add(new List<MazeStructure.Maze2D>()); // Epic Difficulty Mazes

        m_currentMaze = new MazeStructure.NullMaze();
    }

    public void LoadMazes()
    {
        // TODO: Have the installed mazes path be relative to the game executable
        //  - Note will require two build configurations one for developement and one for deployment

        LoadMazeData(Application.persistentDataPath + "/EasyMazes.dat", m_installedMazes[(int)DifficultyEnum.EASY]);
        LoadMazeData(Application.persistentDataPath + "/MediumMazes.dat", m_installedMazes[(int)DifficultyEnum.MEDIUM]);
        LoadMazeData(Application.persistentDataPath + "/HardMazes.dat", m_installedMazes[(int)DifficultyEnum.HARD]);
        LoadMazeData(Application.persistentDataPath + "/EpicMazes.dat", m_installedMazes[(int)DifficultyEnum.EPIC]);

        m_installedMazesLoaded = true;
    }

    void LoadMazeData(String maze_data_path, List<MazeStructure.Maze2D> maze_data)
    {
        if (File.Exists(maze_data_path))
        {
            Debug.Log("Loading Installed Mazes from " + maze_data_path);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(maze_data_path, FileMode.Open);

            maze_data = bf.Deserialize(file) as List<MazeStructure.Maze2D>;

            file.Close();
        }
        else
        {
            Debug.Log("Error: Missing Installed Maze File at " + maze_data_path);
        }       
    }

    public void SaveMazes()
    {
        SaveMazeData(Application.persistentDataPath + "/EasyMazes.dat", m_installedMazes[(int)DifficultyEnum.EASY]);
        SaveMazeData(Application.persistentDataPath + "/MediumMazes.dat", m_installedMazes[(int)DifficultyEnum.MEDIUM]);
        SaveMazeData(Application.persistentDataPath + "/HardMazes.dat", m_installedMazes[(int)DifficultyEnum.HARD]);
        SaveMazeData(Application.persistentDataPath + "/EpicMazes.dat", m_installedMazes[(int)DifficultyEnum.EPIC]);
    }

    void SaveMazeData(String maze_data_path, List<MazeStructure.Maze2D> maze_data)
    {
        if (maze_data != null)
        {
            Debug.Log("Saving Installed Mazes to " + maze_data_path);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(maze_data_path, FileMode.OpenOrCreate);

            bf.Serialize(file, m_installedMazes);

            file.Close();
        }
        else
        {
            Debug.Log("No Mazes to Save to " + maze_data_path);
        }
    }
}
