using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Assets.Scripts.DifficultySettings;

public class MazeDataSaveLoad
{
    /// <summary>
    /// Provides a means of storing a single maze to a file
    /// </summary>
    /// <param name="maze_data_path"></param>
    /// <param name="maze_data"></param>
    public static void SaveMazeData(String maze_data_path, MazeStructure.Maze2D maze_data)
    {
        if (maze_data != null)
        {
            Debug.Log("Saving Installed Mazes to " + maze_data_path);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(maze_data_path, FileMode.OpenOrCreate);

            bf.Serialize(file, maze_data);

            file.Close();
        }
        else
        {
            Debug.Log("No Maze to Save to " + maze_data_path);
        }
    }

    /// <summary>
    /// POrovides a means for storing a set of mazes to a file
    /// </summary>
    /// <param name="maze_data_path"></param>
    /// <param name="maze_data"></param>
    public static void SaveMazeData(String maze_data_path, List<MazeStructure.Maze2D> maze_data)
    {
        if (maze_data != null)
        {
            Debug.Log("Saving Installed Mazes to " + maze_data_path);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(maze_data_path, FileMode.OpenOrCreate);

            bf.Serialize(file, maze_data);

            file.Close();
        }
        else
        {
            Debug.Log("No Mazes to Save to " + maze_data_path);
        }
    }

    /// <summary>
    /// Provides a means for loading a single maze from a maze file comprised of a single maze
    /// </summary>
    /// <param name="maze_data_path"></param>
    /// <param name="maze_data"></param>
    public static void LoadMazeData(String maze_data_path, ref MazeStructure.Maze2D maze_data)
    {
        if (File.Exists(maze_data_path))
        {
            Debug.Log("Loading Installed Mazes from " + maze_data_path);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(maze_data_path, FileMode.Open);

            maze_data = bf.Deserialize(file) as MazeStructure.Maze2D;

            file.Close();
        }
        else
        {
            Debug.Log("Error: Missing Installed Maze File at " + maze_data_path);
        }
    }

    /// <summary>
    /// Provides a means for loading a set of mazes from a maze file comprised of a set of mazes
    /// </summary>
    /// <param name="maze_data_path"></param>
    /// <param name="maze_data"></param>
    public static void LoadMazeData(String maze_data_path, ref List<MazeStructure.Maze2D> maze_data)
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
}
