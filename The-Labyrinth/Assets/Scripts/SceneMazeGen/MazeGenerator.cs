using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MazeGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Slider sliderMazeSizeX;
    public Slider sliderMazeSizeZ;

    public InputField inputFieldMazeName;

    public Text countStoredMazes;

    void Start()
    {
        // Update Displayed Count of Stored Mazes
        countStoredMazes.text = GameContext.m_context.m_installedMazes.Count.ToString();
    }

    public void GenerateMaze()
    {
        EventManager.TriggerEvent("ResetMaze");

        // Create a Default Maze of defined size
        GameContext.m_context.m_currentMaze = MazeStructure.Maze2D.GetInstance((int)sliderMazeSizeX.value, (int)sliderMazeSizeZ.value);

        // Run Maze Generation Algorithm on Default Maze instance
        MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, GameContext.m_context.m_currentMaze);

        // Run Maze Solver Algorithm on Generated Maze
        MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse, GameContext.m_context.m_currentMaze);

        EventManager.TriggerEvent("RenderMaze");

        // Position Camera over maze
        mainCamera.transform.position = new Vector3(sliderMazeSizeX.value / 2.0f, 30, sliderMazeSizeZ.value / 2.0f);
    }

    public void ViewMazeSolution()
    {
        EventManager.TriggerEvent("ShowMazeSolution");
    }

    public void StoreMaze()
    {
        if (GameContext.m_context.m_currentMaze != null &&
           !GameContext.m_context.m_currentMaze.IsNull())
        {
            // Set Maze Properties:
            // - Name
            // - Difficulty Level
            // - TBD
            // TODO: Implement
            GameContext.m_context.m_currentMaze.Name = inputFieldMazeName.text;

            // Add Maze to list of stored mazes
            GameContext.m_context.m_installedMazes.Add(GameContext.m_context.m_currentMaze);

            // Update Displayed Count of Stored Mazes
            countStoredMazes.text = GameContext.m_context.m_installedMazes.Count.ToString();
        }
    }
    
    public void ClearStoredMazes()
    {
        // Clear list of stored mazes
        GameContext.m_context.m_installedMazes.Clear();

        // Update Displayed Count of Stored Mazes
        countStoredMazes.text = GameContext.m_context.m_installedMazes.Count.ToString();
    }    
}