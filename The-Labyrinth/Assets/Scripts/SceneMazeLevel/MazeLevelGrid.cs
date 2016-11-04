using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MazeLevelGrid : MonoBehaviour
{
    // Prefab References
    public MazeLevelRowElement mazeLevelRowElementPrefab;


    // Private GameObject References
    private List<MazeLevelRowElement> mazeLevelRowElementInstances;

    void Awake()
    {
        mazeLevelRowElementInstances = new List<MazeLevelRowElement>();
    }

    void Start()
    {
        mazeLevelRowElementInstances.Clear();
    }

    public void AddMazeLevelRowElement(MazeStructure.Maze2D maze)
    {
        // Instantiate New Row Element
        MazeLevelRowElement rowElement = Instantiate(mazeLevelRowElementPrefab, transform) as MazeLevelRowElement;

        // Initialize New Row Element
        rowElement.Initialize(maze);

        // Add New Row Element to Managed List of Row Elements
        mazeLevelRowElementInstances.Add(rowElement);
    }
}
