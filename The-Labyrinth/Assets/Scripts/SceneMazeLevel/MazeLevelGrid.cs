using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MazeLevelGrid : MonoBehaviour
{
    // Prefab References
    public MazeLevelRowElement m_mazeLevelRowElementPrefab;
    public MazeChallengeRowElement m_mazeChallengeRowElementPrefab;


    // Private GameObject References
    private List<MazeLevelRowElement> m_mazeLevelRowElementInstances;
    private List<MazeChallengeRowElement> m_mazeChallengeRowElementInstances;

    // ********************************************
    // Unity Methods
    // ********************************************

    /// <summary>
    /// Unity Method for initialization of GameObject called first
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Awake()
    {
        m_mazeLevelRowElementInstances = new List<MazeLevelRowElement>();
        m_mazeChallengeRowElementInstances = new List<MazeChallengeRowElement>();
    }

    // ********************************************
    // Public Methods
    // ********************************************

    public void AddMazeLevelRowElement(int mazeIndex, MazeStructure.Maze2D maze)
    {
        // Instantiate New Row Element
        MazeLevelRowElement rowElement = Instantiate(m_mazeLevelRowElementPrefab, transform) as MazeLevelRowElement;

        // Initialize New Row Element
        rowElement.Initialize(mazeIndex, maze);

        // Add New Row Element to Managed List of Row Elements
        m_mazeLevelRowElementInstances.Add(rowElement);
    }

    public void AddMazeChallengeRowElement(int mazeIndex, MazeStructure.Maze2D maze)
    {
        // Instantiate New Row Element
        MazeChallengeRowElement rowElement = Instantiate(m_mazeChallengeRowElementPrefab, transform) as MazeChallengeRowElement;

        // Initialize New Row Element
        rowElement.Initialize(mazeIndex, maze);

        // Add New Row Element to Managed List of Row Elements
        m_mazeChallengeRowElementInstances.Add(rowElement);
    }

    public void HideMazeLevelRows()
    {
        foreach(MazeLevelRowElement mazeRow in m_mazeLevelRowElementInstances)
        {
            mazeRow.Hide();
        }
    }

    public void ShowMazeLevelRows()
    {
        foreach (MazeLevelRowElement mazeRow in m_mazeLevelRowElementInstances)
        {
            mazeRow.Show();
        }
    }

    public void HideMazeChallengeRows()
    {
        foreach (MazeChallengeRowElement mazeRow in m_mazeChallengeRowElementInstances)
        {
            mazeRow.Hide();
        }
    }

    public void ShowMazeChallengeRows()
    {
        foreach (MazeChallengeRowElement mazeRow in m_mazeChallengeRowElementInstances)
        {
            mazeRow.Show();
        }
    }
}
