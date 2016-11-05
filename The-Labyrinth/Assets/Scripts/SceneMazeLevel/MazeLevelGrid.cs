using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MazeLevelGrid : MonoBehaviour
{
    // Prefab References
    public MazeLevelRowElement mazeLevelRowElementPrefab;


    // Private GameObject References
    private List<MazeLevelRowElement> mazeLevelRowElementInstances;

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
        mazeLevelRowElementInstances = new List<MazeLevelRowElement>();
    }

    // ********************************************
    // Public Methods
    // ********************************************

    public void AddMazeLevelRowElement(int mazeIndex, MazeStructure.Maze2D maze)
    {
        // Instantiate New Row Element
        MazeLevelRowElement rowElement = Instantiate(mazeLevelRowElementPrefab, transform) as MazeLevelRowElement;

        // Initialize New Row Element
        rowElement.Initialize(mazeIndex, maze);

        // Add New Row Element to Managed List of Row Elements
        mazeLevelRowElementInstances.Add(rowElement);
    }
}
