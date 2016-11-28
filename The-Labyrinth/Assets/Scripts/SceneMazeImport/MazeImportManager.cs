using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

using Assets.Scripts.DifficultySettings;
using Plugins;

public class MazeImportManager : MonoBehaviour
{
    // Public References
    public Button m_buttonImportMaze;
    public Button m_buttonSaveMaze;
    public Text m_mazeImportStatus;
    public Text m_mazeNameProperty;
    public Text m_mazeSizeProperty;
    public Text m_mazeDifficultyProperty;
    public Text m_mazeTimeToCompleteProperty;
    public Text m_mazeSaveStatus;


    private string m_mazeFilePath;
    private MazeStructure.Maze2D m_importedMazeData;

    public void ImportMaze()
    {
        // Reset Save Status
        m_mazeSaveStatus.text = "";

        // Import Maze
        FileDialogs.OpenFile(out m_mazeFilePath);
        if (m_mazeFilePath != null &&
            File.Exists(m_mazeFilePath))
        {
            MazeDataSaveLoad.LoadMazeData(m_mazeFilePath, ref m_importedMazeData);

            if(m_importedMazeData != null)
            {
                m_mazeImportStatus.text = "Import Successful";
                m_mazeNameProperty.text = "Name: " + m_importedMazeData.Name;
                m_mazeSizeProperty.text = "Size (X, Z): " + "(" + m_importedMazeData.SizeX + ", " + m_importedMazeData.SizeZ + ")";
                m_mazeDifficultyProperty.text = "Difficulty: " + MazeDifficultyToString(m_importedMazeData.Difficulty);
                m_mazeTimeToCompleteProperty.text = "Time To Complete: " + MazeTimeToCompleteToString(m_importedMazeData.TimeToCompleteMaze);
            }
            else
            {
                m_mazeImportStatus.text = "Import Failed";
                m_mazeNameProperty.text = "";
                m_mazeSizeProperty.text = "";
                m_mazeDifficultyProperty.text = "";
                m_mazeTimeToCompleteProperty.text = "";
            }
        }
    }

    /// <summary>
    /// Saves an imported maze to the set of imported mazes stored by the GameContext
    /// </summary>
    public void SaveMaze()
    {
        if (m_importedMazeData != null)
        {
            // Step 1: Check that imported maze does not already exist in the set of installed imported mazes
            bool mazeExists = false;
            foreach (MazeStructure.Maze2D maze in GameContext.m_context.m_mazeChallengeMazes)
            {
                if (maze.GUID == m_importedMazeData.GUID)
                {
                    mazeExists = true;
                    break;
                }
            }

            // Step 2: If imported mazes does not exist add it to the set of imported mazes
            if (!mazeExists)
            {
                GameContext.m_context.m_mazeChallengeMazes.Add(m_importedMazeData);
                GameContext.m_context.m_mazeChallengeMazesChanged = true;

                m_mazeSaveStatus.text = "Save Completed";

                // Reset
                m_importedMazeData = null;
                m_mazeImportStatus.text = "";
                m_mazeNameProperty.text = "";
                m_mazeSizeProperty.text = "";
                m_mazeDifficultyProperty.text = "";
                m_mazeTimeToCompleteProperty.text = "";
            }   
            else
            {
                m_mazeSaveStatus.text = "Save Aborted: Duplicate Maze";
            }                
        }
        else
        {
            m_mazeSaveStatus.text = "Save Failed: Import a Maze";
        }
    }

    public void CloseMazeImportMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    private string MazeDifficultyToString(DifficultyEnum difficulty)
    {
        string result = "";
        switch (difficulty)
        {
            case DifficultyEnum.EASY: result = "EASY"; break;
            case DifficultyEnum.MEDIUM: result = "MEDIUM"; break;
            case DifficultyEnum.HARD: result = "HARD"; break;
            case DifficultyEnum.EPIC: result = "EPIC"; break;
        };

        return result;
    }

    private string MazeTimeToCompleteToString(int time_to_complete)
    {
        string result = "";
        if(time_to_complete < 0)
        {
            result = "Infinite";
        }
        else
        {
            result = time_to_complete.ToString();
        }

        return result;
    }
}
