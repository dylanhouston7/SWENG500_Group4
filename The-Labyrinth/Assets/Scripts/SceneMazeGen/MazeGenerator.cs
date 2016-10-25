using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.DifficultySettings;

public class MazeGenerator : MonoBehaviour
{
    public MazeManager mazeManagerRef;

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

    private MazeStructure.Maze2D activeMaze;
    private List<MazeStructure.Maze2D> easyMazes;
    private List<MazeStructure.Maze2D> mediumMazes;
    private List<MazeStructure.Maze2D> hardMazes;
    private List<MazeStructure.Maze2D> epicMazes;

    public void Awake()
    {
        activeMaze = null;

        easyMazes = new List<MazeStructure.Maze2D>();
        mediumMazes = new List<MazeStructure.Maze2D>();
        hardMazes = new List<MazeStructure.Maze2D>();
        epicMazes = new List<MazeStructure.Maze2D>();
    }

    public void Start()
    {
        UpdateMazeCounts();
    }

    public void GenerateMaze()
    {
        // Reset Maze before Rendering the Generated Maze
        mazeManagerRef.ResetMaze();

        // Create a Default Maze of defined size
        activeMaze = MazeStructure.Maze2D.GetInstance((int)sliderMazeSizeX.value, (int)sliderMazeSizeZ.value);

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
        MazeStructure.MazeGenerator.Generate(mazeGenAlgorithm, activeMaze);

        // Run Maze Solver Algorithm on Generated Maze
        MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse, activeMaze);

        // Render the Generated Maze Structure
        mazeManagerRef.RenderMaze(activeMaze);

        // Position Camera over maze
        mainCamera.transform.position = new Vector3(sliderMazeSizeX.value / 2.0f, 30, sliderMazeSizeZ.value / 2.0f);
    }

    public void ViewMazeSolution()
    {
        textMazeSolutionPathLenValue.text = mazeManagerRef.MazeSolutionSize.ToString();

        mazeManagerRef.ShowMazeSolution();
    }

    public void StoreMaze()
    {
        if (activeMaze != null &&
           !activeMaze.IsNull())
        {
            // Set Maze Properties:
            // - Name
            // - Difficulty Level
            // - Time to Complete
            // TODO: Implement

            SetMazeNameProperty(activeMaze);
            SetMazeDifficultyProperty(activeMaze);
            SetMazeTimeToCompleteProperty(activeMaze);


            // Store the maze to the maze list of like difficulty
            switch(activeMaze.Difficulty)
            {
                case DifficultyEnum.EASY:
                    {
                        easyMazes.Add(activeMaze);
                        break;
                    }
                case DifficultyEnum.MEDIUM:
                    {
                        mediumMazes.Add(activeMaze);
                        break;
                    }
                case DifficultyEnum.HARD:
                    {
                        hardMazes.Add(activeMaze);
                        break;
                    }
                case DifficultyEnum.EPIC:
                    {
                        epicMazes.Add(activeMaze);
                        break;
                    }
                default:
                    {
                        break;
                    }
            };

            // Update Displayed Count of Stored Mazes
            UpdateMazeCounts();
        }
    }
    
    /// <summary>
    /// Exports the active maze to maze file
    /// </summary>
    public void ExportMaze()
    {
        if (activeMaze != null &&
            !activeMaze.IsNull())
        {
            MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/ExportedMaze.dat", activeMaze);
        }
    }

    public void SaveMazes()
    {
        MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/EasyMazes.dat", easyMazes);
        MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/MediumMazes.dat", mediumMazes);
        MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/HardMazes.dat", hardMazes);
        MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/EpicMazes.dat", epicMazes);
    }

    public void LoadMazes()
    {
        MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/EasyMazes.dat", ref easyMazes);
        MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/MediumMazes.dat", ref mediumMazes);
        MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/HardMazes.dat", ref hardMazes);
        MazeDataSaveLoad.LoadMazeData(Application.persistentDataPath + "/EpicMazes.dat", ref epicMazes);

        UpdateMazeCounts();
    }

    private void SetMazeNameProperty(MazeStructure.Maze2D maze)
    {
        if(maze != null)
        {
            // Set Maze Name Property
            activeMaze.Name = inputFieldMazeName.text;
        }
    }

    private void SetMazeDifficultyProperty(MazeStructure.Maze2D maze)
    {
        if(maze != null)
        {
            // Set Maze Difficulty Property
            DifficultyEnum mazeDifficultyLevel = DifficultyEnum.EASY;
            switch (dropDownMazeDifficultyLevel.value)
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
                        break;
                    }
            };
            maze.Difficulty = mazeDifficultyLevel;
        }        
    }

    private void SetMazeTimeToCompleteProperty(MazeStructure.Maze2D maze)
    {
        // Set Maze Time to Complete Property
        if (sliderTimeToCompleteMaze.value < 3600)
        {
            maze.TimeToCompleteMaze = (int)sliderTimeToCompleteMaze.value;
        }
        else
        {
            maze.TimeToCompleteMaze = -1;
        }
    }

    public void ResetActiveMaze()
    {
        mazeManagerRef.ResetMaze();

        textMazeSolutionPathLenValue.text = "";

        activeMaze = null;
    }

    public void ClearStoredMazes()
    {
        // Clear all Mazes
        easyMazes.Clear();
        mediumMazes.Clear();
        hardMazes.Clear();
        epicMazes.Clear();        

        // Update Displayed Count of Stored Mazes
        UpdateMazeCounts();
    }

    public void ClearStoredMazes(DifficultyEnum mazeList)
    {
        switch (mazeList)
        {
            case DifficultyEnum.EASY:
                {
                    easyMazes.Clear();
                    break;
                }
            case DifficultyEnum.MEDIUM:
                {
                    mediumMazes.Clear();
                    break;
                }
            case DifficultyEnum.HARD:
                {
                    hardMazes.Clear();
                    break;
                }
            case DifficultyEnum.EPIC:
                {
                    epicMazes.Clear();
                    break;
                }
            default:
                {
                    break;
                }
        };

        // Update Displayed Count of Stored Mazes
        UpdateMazeCounts();
    }

    void UpdateMazeCounts()
    {
        textCountStoredEasyMazes.text = easyMazes.Count.ToString();
        textCountStoredMediumMazes.text = mediumMazes.Count.ToString();
        textCountStoredHardMazes.text = hardMazes.Count.ToString();
        textCountStoredEpicMazes.text = epicMazes.Count.ToString();
    }
}