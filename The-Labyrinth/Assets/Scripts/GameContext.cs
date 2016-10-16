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
    public int m_nextMazeIndex;
    public List<MazeStructure.Maze2D> m_installedMazes;

    public MazeStructure.Maze2D m_currentMaze;

    public DifficultyEnum m_gameDifficulty;

    // Unity Methods
    void Awake()
    {
        if(m_context == null)
        {
            DontDestroyOnLoad(gameObject);
            m_context = this;

            // Initialize Context Variables Only Once
            Initialize();
        }
        else if(m_context != this)
        {
            // Ensure that only the first GameContext persists between scenes
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        if(m_context == this)
        {
            LoadInstalledMazes();
        }        
    }

    void OnDisable()
    {       
        if(m_context == this)
        {
            SaveInstalledMazes();
        }        
    }


    void Initialize()
    {
        m_nextMazeIndex = 0;
        m_installedMazes = new List<MazeStructure.Maze2D>();

        m_currentMaze = new MazeStructure.NullMaze();
    }

    void LoadInstalledMazes()
    {
        // TODO: Have the installed mazes path be relative to the game executable
        //  - Note will require two build configurations one for developement and one for deployment

        String installed_mazes_path = Application.persistentDataPath + "/installedMazes.dat";
        Debug.Log("Installed Mazes Path: " + installed_mazes_path);

        if (File.Exists(installed_mazes_path))
        {
            Debug.Log("Loading Installed Mazes");

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(installed_mazes_path, FileMode.Open);

            m_installedMazes = bf.Deserialize(file) as List<MazeStructure.Maze2D>;

            file.Close();
        }
        else
        {
            Debug.Log("Error: Missing Installed Maze File to Load");
        }        
    }

    void SaveInstalledMazes()
    {
        if(m_installedMazes != null)
        {
            Debug.Log("Saving Installed Mazes");

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/installedMazes.dat", FileMode.OpenOrCreate);

            bf.Serialize(file, m_installedMazes);

            file.Close();
        }
        else
        {
            Debug.Log("No Installed Mazes to Save");
        }
    }
}
