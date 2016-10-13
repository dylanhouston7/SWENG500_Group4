using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour
{
    // Public Members
    public float hSliderSizeX;
    public float hSliderSizeZ;

    void Awake()
    {
        // Initialize Member Variables
        hSliderSizeX = 5.0f;
        hSliderSizeZ = 5.0f;
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), "Maze Size X:" + (int)hSliderSizeX);
        hSliderSizeX = (int)GUI.HorizontalSlider(new Rect(110, 15, 300, 30), hSliderSizeX, 5, 50);

        GUI.TextArea(new Rect(10, 40, 100, 20), "Maze Size Z:" + (int)hSliderSizeZ);
        hSliderSizeZ = (int)GUI.HorizontalSlider(new Rect(110, 45, 300, 30), hSliderSizeZ, 5, 50);

        if (GUI.Button(new Rect(10, 75, 250, 30), "Generate Maze"))
        {
            EventManager.TriggerEvent("ResetMaze");

            // Create a Default Maze of defined size
            GameContext.m_context.m_currentMaze = MazeStructure.Maze2D.GetInstance((int)hSliderSizeX, (int)hSliderSizeZ);

            // Run Maze Generation Algorithm on Default Maze instance
            MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, GameContext.m_context.m_currentMaze);

            // Run Maze Solver Algorithm on Generated Maze
            MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse, GameContext.m_context.m_currentMaze);

            EventManager.TriggerEvent("RenderMaze");
        }

        if (GUI.Button(new Rect(10, 115, 250, 30), "Show Maze Solution"))
        {
            EventManager.TriggerEvent("ShowMazeSolution");
        }


        // **********************************************************
        // Store Maze
        // **********************************************************             

        if (GUI.Button(new Rect(10, 475, 100, 30), "Store Maze"))
        {
            if (GameContext.m_context.m_currentMaze != null &&
               !GameContext.m_context.m_currentMaze.IsNull())
            {
                // Set Maze Properties:
                // - Name
                // - Difficulty Level
                // - TBD
                // TODO: Implement

                // Add Maze to 
                GameContext.m_context.m_installedMazes.Add(GameContext.m_context.m_currentMaze);
            }
        }

        GUI.TextArea(new Rect(10, 510, 150, 25), "Num Mazes: " + GameContext.m_context.m_installedMazes.Count);

        // TODO: Display the Calculated Maze Difficulty Rating
    }
}