using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.DifficultySettings;

public class MazeGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Slider sliderMazeSizeX;
    public Slider sliderMazeSizeZ;
    public Dropdown dropDownMazeGenAlgorithm;
    public Text textMazeSolutionPathLenValue;

    public InputField inputFieldMazeName;
    public Dropdown dropDownMazeDifficultyLevel;
    public Slider sliderTimeToCompleteMaze;

    public Text textCountStoredEasyMazes;
    public Text textCountStoredMediumMazes;
    public Text textCountStoredHardMazes;
    public Text textCountStoredEpicMazes;

    void Start()
    {
        // Update Displayed Count of Stored Mazes
        UpdateMazeCounts();
    }

    void OnDisable()
    {
        GameContext.m_context.SaveMazes();
    }

    public void GenerateMaze()
    {
        EventManager.TriggerEvent("ResetMaze");

        // Create a Default Maze of defined size
        GameContext.m_context.m_currentMaze = MazeStructure.Maze2D.GetInstance((int)sliderMazeSizeX.value, (int)sliderMazeSizeZ.value);

        // Run the Selected Maze Generation Algorithm on Default Maze instance
        MazeStructure.MazeGenerator.MazeGenAlgorithmEnum mazeGenAlgorithm = MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch;
        switch(dropDownMazeGenAlgorithm.value)
        {
            case 0: // Straight Z
                {
                    mazeGenAlgorithm = MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kStraight;
                    break;
                }
            case 1: // Depth First Search
                {
                    mazeGenAlgorithm = MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch;
                    break;
                }
            default:
                {
                    break;
                }
        };
        MazeStructure.MazeGenerator.Generate(mazeGenAlgorithm, GameContext.m_context.m_currentMaze);

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
            // - Time to Complete
            // TODO: Implement

            // Set Maze Name Property
            GameContext.m_context.m_currentMaze.Name = inputFieldMazeName.text;

            // Set Maze Difficulty Property
            DifficultyEnum mazeDifficultyLevel;
            switch(dropDownMazeDifficultyLevel.value)
            {
                case 0: // Easy
                    {
                        mazeDifficultyLevel = DifficultyEnum.EASY;
                        break;
                    }
                case 1: // Medium
                    {
                        mazeDifficultyLevel = DifficultyEnum.MEDIUM;
                        break;
                    }
                case 2: // Hard
                    {
                        mazeDifficultyLevel = DifficultyEnum.HARD;
                        break;
                    }
                case 3: // Epic
                    {
                        mazeDifficultyLevel = DifficultyEnum.EPIC;
                        break;
                    }
                default:
                    {
                        mazeDifficultyLevel = DifficultyEnum.EASY;
                        break;
                    }
            };
            GameContext.m_context.m_currentMaze.Difficulty = mazeDifficultyLevel;

            // Set Maze Time to Complete Property
            if(sliderTimeToCompleteMaze.value < 3600)
            {
                GameContext.m_context.m_currentMaze.TimeToCompleteMaze = (int)sliderTimeToCompleteMaze.value;
            }
            else
            {
                GameContext.m_context.m_currentMaze.TimeToCompleteMaze = -1;
            }

            // Add Maze to list of stored mazes of same difficulty
            GameContext.m_context.m_installedMazes[(int)mazeDifficultyLevel].Add(GameContext.m_context.m_currentMaze);

            // Update Displayed Count of Stored Mazes
            UpdateMazeCounts();
        }
    }
    
    public void ClearStoredMazes()
    {
        // Clear list of stored mazes
        foreach(List<MazeStructure.Maze2D> mazes in GameContext.m_context.m_installedMazes)
        {
            mazes.Clear();
        }        

        // Update Displayed Count of Stored Mazes
        UpdateMazeCounts();
    }

    void UpdateMazeCounts()
    {
        textCountStoredEasyMazes.text = GameContext.m_context.m_installedMazes[(int)DifficultyEnum.EASY].Count.ToString();
        textCountStoredMediumMazes.text = GameContext.m_context.m_installedMazes[(int)DifficultyEnum.MEDIUM].Count.ToString();
        textCountStoredHardMazes.text = GameContext.m_context.m_installedMazes[(int)DifficultyEnum.HARD].Count.ToString();
        textCountStoredEpicMazes.text = GameContext.m_context.m_installedMazes[(int)DifficultyEnum.EPIC].Count.ToString();
    }
}