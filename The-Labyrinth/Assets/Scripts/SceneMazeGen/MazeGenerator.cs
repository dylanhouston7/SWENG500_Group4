using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MazeGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Slider sliderMazeSizeX;
    public Slider sliderMazeSizeZ;
    public Text textMazeSolutionPathLenValue;

    public InputField inputFieldMazeName;
    public Dropdown dropDownMazeDifficultyLevel;

    public Text textCountStoredMazes;

    void Start()
    {
        // Update Displayed Count of Stored Mazes
        textCountStoredMazes.text = GameContext.m_context.m_installedMazes.Count.ToString();
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
        textMazeSolutionPathLenValue.text = GameContext.m_context.m_currentMaze.MazeSolutionPath.Count.ToString();

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

            // Set Maze Name Property
            GameContext.m_context.m_currentMaze.Name = inputFieldMazeName.text;

            // Set Maze Difficulty Property
            MazeStructure.Maze2D.DifficultyLevelEnum mazeDifficultyLevel = MazeStructure.Maze2D.DifficultyLevelEnum.kEasy;
            switch(dropDownMazeDifficultyLevel.value)
            {
                case 0: // Easy
                    {
                        mazeDifficultyLevel = MazeStructure.Maze2D.DifficultyLevelEnum.kEasy;
                        break;
                    }
                case 1: // Normal
                    {
                        mazeDifficultyLevel = MazeStructure.Maze2D.DifficultyLevelEnum.kNormal;
                        break;
                    }
                case 2: // Hard
                    {
                        mazeDifficultyLevel = MazeStructure.Maze2D.DifficultyLevelEnum.kHard;
                        break;
                    }
                case 3: // Epic
                    {
                        mazeDifficultyLevel = MazeStructure.Maze2D.DifficultyLevelEnum.kEpic;
                        break;
                    }
                default:
                    {
                        break;
                    }
            };
            GameContext.m_context.m_currentMaze.Difficulty = mazeDifficultyLevel;

            // Add Maze to list of stored mazes
            GameContext.m_context.m_installedMazes.Add(GameContext.m_context.m_currentMaze);

            // Update Displayed Count of Stored Mazes
            textCountStoredMazes.text = GameContext.m_context.m_installedMazes.Count.ToString();
        }
    }
    
    public void ClearStoredMazes()
    {
        // Clear list of stored mazes
        GameContext.m_context.m_installedMazes.Clear();

        // Update Displayed Count of Stored Mazes
        textCountStoredMazes.text = GameContext.m_context.m_installedMazes.Count.ToString();
    }    
}