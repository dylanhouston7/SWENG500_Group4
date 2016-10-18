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
    public MazeStructure.Maze2D m_activeMaze;
    public List<MazeStructure.Maze2D> m_easyMazes;
    public List<MazeStructure.Maze2D> m_mediumMazes;
    public List<MazeStructure.Maze2D> m_hardMazes;
    public List<MazeStructure.Maze2D> m_epicMazes;

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

    void Initialize()
    {
        m_installedMazesLoaded = false;

        m_nextMazeIndex = 0;
        m_activeMaze = new MazeStructure.NullMaze();
        m_easyMazes = new List<MazeStructure.Maze2D>();
        m_mediumMazes = new List<MazeStructure.Maze2D>();
        m_hardMazes = new List<MazeStructure.Maze2D>();
        m_epicMazes = new List<MazeStructure.Maze2D>();
    }
}
