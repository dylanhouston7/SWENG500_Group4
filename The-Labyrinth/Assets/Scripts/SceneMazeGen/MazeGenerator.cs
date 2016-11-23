#define BUILD_RELEASE
//#undef BUILD_RELEASE
//#define DEV_RELEASE
#undef DEV_RELEASE

using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.DifficultySettings;
using Assets.Scripts.MaterialsRegistry;

using Plugins;

public class MazeGenerator : MonoBehaviour
{
    public MazeManager mazeManagerRef;

    public Slider zoom;

    public GameObject panelMazeStorage;

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

    public Text textTextureMazeWalls;
    public Slider textureMazeWalls;
    public Text textTextureMazeFloors;
    public Slider textureMazeFloors;

    private List<MaterialsRegistry.MaterialEntry> materialEntries;

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

    public void OnEnable()
    {
        UpdateMazeCounts();
    }

    public void Start()
    {
        // Get the collection of Materials from the materials registry
        GameContext.m_context.m_materialRegistry.GetMaterialEntries(out materialEntries);

#if (BUILD_RELEASE)
        panelMazeStorage.SetActive(false);
#endif

        // Set the Slider max values
        textureMazeWalls.minValue = 0;
        textureMazeWalls.maxValue = materialEntries.Count - 1;
        textureMazeFloors.minValue = 0;
        textureMazeFloors.maxValue = materialEntries.Count - 1;
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
        List<MazeStructure.Cell2D> solutionPath = new List<MazeStructure.Cell2D>();
        MazeStructure.MazeSolver.Solve(MazeStructure.MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse,
                                       activeMaze,
                                       activeMaze.GetStartCell(),
                                       ref solutionPath);

        // Store Solution Path in the Maze
        activeMaze.MazeSolutionPath = solutionPath;

        // Store the Solution Path in the GameContext for Rendering
        GameContext.m_context.m_activeMazeHintSolutionPath = solutionPath;

        // Render the Generated Maze Structure
        mazeManagerRef.RenderMaze(activeMaze);

        // Update Textures
        ChangeCellWallTexture();
        ChangeCellFloorTexture();

        // Position Camera over maze
        mainCamera.transform.position = new Vector3(sliderMazeSizeX.value / 2.0f, 0.0f, sliderMazeSizeZ.value / 2.0f);
        this.Zoom();
    }

    public void ViewMazeSolution()
    {
        textMazeSolutionPathLenValue.text = activeMaze.MazeSolutionPath.Count.ToString();

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
            // - Maze Floor and Wall Materials

            SetMazeNameProperty(activeMaze);
            SetMazeDifficultyProperty(activeMaze);
            SetMazeTimeToCompleteProperty(activeMaze);
            SetMazeMaterials(activeMaze);


            // Store the maze to the maze list of like difficulty
            switch (activeMaze.Difficulty)
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
        StoreMaze();

        string export_path;
        FileDialogs.SaveFile(out export_path, "C:\\", "(*.dat)|*.dat");

        if (activeMaze != null &&
            !activeMaze.IsNull())
        {
            MazeDataSaveLoad.SaveMazeData(export_path, activeMaze);
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

    private void SetMazeMaterials(MazeStructure.Maze2D maze)
    {
        MaterialsRegistry.MaterialEntry matWallEntry = materialEntries[(int)textureMazeWalls.value];
        MaterialsRegistry.MaterialEntry matFloorEntry = materialEntries[(int)textureMazeFloors.value];

        maze.CellWallMaterialKey = matWallEntry.MaterialName;
        maze.CellFloorMaterialKey = matFloorEntry.MaterialName;
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

    public void Zoom()
    {
        mainCamera.transform.position =
            new Vector3(
                mainCamera.transform.position.x,
                zoom.value,
                mainCamera.transform.position.z
            );
    }

    public void ChangeCellWallTexture()
    {
        MaterialsRegistry.MaterialEntry matEntry = materialEntries[(int)textureMazeWalls.value];

        textTextureMazeWalls.text = "Walls: " + matEntry.MaterialName;
        mazeManagerRef.SetMazeWallMaterial(matEntry.MaterialData);
    }

    public void ChangeCellFloorTexture()
    {
        MaterialsRegistry.MaterialEntry matEntry = materialEntries[(int)textureMazeFloors.value];

        textTextureMazeFloors.text = "Floors: " + matEntry.MaterialName;
        mazeManagerRef.SetMazeFloorMaterial(matEntry.MaterialData);
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}