using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Public Members
    public MazeStructure.Maze2D mazeStructure = null;

    // Private Memebers
    private int sizeX, sizeZ;

    // Unity Methods
    void Start()
    {
        // TODO: 
        switch (GameContext.m_context.m_difficultyLevel)
        {
            case 0: { sizeX = 10; sizeZ = 10; break; }
            case 1: { sizeX = 15; sizeZ = 15; break; }
            case 2: { sizeX = 20; sizeZ = 20; break; }
        };
    }

    void Update()
    {
        // Generate a new Maze Level
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Generating Maze");

            // Get a default maze structure of defined size
            mazeStructure = MazeStructure.Maze2D.GetInstance(sizeX, sizeZ);

            // Modify the default maze structure with the maze generation algorithm
            MazeStructure.DepthFirstSearchMazeGenerator.Generate(mazeStructure);

            // Publish Event: RenderMaze
            // TODO:
        }
    }

    void OnEnable()
    {
        // TODO: Setup Event Pubs/Subs
    }

    void OnDisable()
    {
        // TODO: Cleanup Event Pubs/Subs
    }

    // Event Subscribers
    void CompletedMaze()
    {
        // TODO: 
    }
}
