﻿using System;
using UnityEngine;
using UnityEngine.Events;

using System.Collections;
using System.Collections.Generic;

using Assets;
using Assets.Scripts.MaterialsRegistry;

public class MazeManager : MonoBehaviour
{
    // References
    //

    // Prefabs
    public MazeCell cellPrefab;

    // Public Members
    public int MazeSizeX
    {
        get
        {
            int result = 0;
            if (mazeInstance != null)
            {
                result = mazeInstance.GetLength(0);
            }
            return result;
        }
    }
    public int MazeSizeZ
    {
        get
        {
            int result = 0;
            if (mazeInstance != null)
            {
                result = mazeInstance.GetLength(1);
            }
            return result;
        }
    }

    // Private Members
    private UnityAction handleEventRenderMaze = null;
    private UnityAction handleEventShowMazeSolution = null;
    private UnityAction handleEventHideMazeSolution = null;
    private UnityAction handleEventShowMazeHint = null;
    private UnityAction handleEventResetMaze = null;

    private MazeCell[,] mazeInstance = null;

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
        // Initialize Event Handlers
        handleEventRenderMaze = new UnityAction(EventHandleRenderMaze);
        handleEventShowMazeSolution = new UnityAction(EventHandleShowMazeSolution);
        handleEventHideMazeSolution = new UnityAction(EventHandleHideMazeSolution);
        handleEventShowMazeHint = new UnityAction(EventHandlerShowMazeHint);
        handleEventResetMaze = new UnityAction(ResetMaze);
    }

    /// <summary>
    /// Unity Method for initialization of GameObject called after Awake()
    /// </summary>
    /// <remarks>
    /// Called each time the GameObject is enabled
    /// </remarks>
    void OnEnable()
    {
        EventManager.StartListening("RenderMaze", handleEventRenderMaze);
        EventManager.StartListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StartListening("HideMazeSolution", handleEventHideMazeSolution);
        EventManager.StartListening("ShowMazeHint", handleEventShowMazeHint);
        EventManager.StartListening("ResetMaze", handleEventResetMaze);
    }

    /// <summary>
    /// Unity Method for initialization of GameObject called after OnEnable()
    /// </summary>
    /// <remarks>
    /// Called once
    /// </remarks>
    void Start()
    {

    }

    /// <summary>
    /// Unity Method called when the behavior is disabled or inactive
    /// </summary>
    /// <remarks>
    /// Called each time the GameObject is disabled
    /// </remarks>
    void OnDisable()
    {
        EventManager.StopListening("RenderMaze", handleEventRenderMaze);
        EventManager.StopListening("ShowMazeSolution", handleEventShowMazeSolution);
        EventManager.StopListening("HideMazeSolution", handleEventHideMazeSolution);
        EventManager.StopListening("ShowMazeHint", handleEventShowMazeHint);
        EventManager.StopListening("ResetMaze", handleEventResetMaze);
    }

    public void EventHandleRenderMaze()
    {
        Debug.Log("MazeManager: Event Handler RenderMaze Method Called!");

        RenderMaze(GameContext.m_context.m_activeMaze);
    }

    public void EventHandleShowMazeSolution()
    {
        Debug.Log("MazeManager: Event Handler ShowMazeSolution Method Called!");

        ShowMazeSolution();
    }

    public void EventHandleHideMazeSolution()
    {
        Debug.Log("MazeManager: Event Handler HideMazeSolution Method Called!");

        HideMazeSolution();
    }

    public void EventHandlerShowMazeHint()
    {
        int posX = GameContext.m_context.m_currentPlayerMazePositionX;
        int posZ = GameContext.m_context.m_currentPlayerMazePositionZ;

        // Determine the hint direction based on the first two hint solution path cells
        MazeStructure.Cell2D.CellDirectionEnum direction = GameContext.m_context.m_activeMazeHintSolutionPath[0].DirectionToCell(GameContext.m_context.m_activeMazeHintSolutionPath[1]);

        mazeInstance[posX, posZ].ShowCellHint(direction);
    }

    public void EventHandleResetMaze()
    {
        Debug.Log("MazeManager: Event Handler ResetMaze Method Called!");

        ResetMaze();
    }

    // Other Methods

    /// <summary>
    /// Renders the defined maze structure
    /// </summary>
    /// <param name="maze">The defined maze structure to render</param>
    public void RenderMaze(MazeStructure.Maze2D maze)
    {
        if (maze != null &&
           !maze.IsNull())
        {
            Debug.Log("MazeManager: Rendering Maze");

            // Ensure only one maze instance is ever rendered at a time 
            if (mazeInstance != null)
            {
                ResetMaze();
            }


            // Initialize Maze Storage elements            
            mazeInstance = new MazeCell[maze.SizeX, maze.SizeZ];


            // Get the Cell Floor Material
            MaterialsRegistry.MaterialEntry floor_material = new MaterialsRegistry.MaterialEntry();
            floor_material.MaterialName = maze.CellFloorMaterialKey;
            GameContext.m_context.m_materialRegistry.GetMaterialEntry(ref floor_material);

            // Get the Cell Wall Material
            MaterialsRegistry.MaterialEntry wall_material = new MaterialsRegistry.MaterialEntry();
            wall_material.MaterialName = maze.CellWallMaterialKey;
            GameContext.m_context.m_materialRegistry.GetMaterialEntry(ref wall_material);            


            // Render Maze Structure
            for (int x = 0; x < MazeSizeX; ++x)
            {
                for (int z = 0; z < MazeSizeZ; ++z)
                {
                    // Get the Cell Structure Blueprint for the Cell
                    MazeStructure.Cell2D cell = maze.GetCell(x, z);

                    // Build Maze Cell from the CellStructure Blueprint
                    mazeInstance[x, z] = Instantiate(cellPrefab, transform) as MazeCell;
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kLeft]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kLeft); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kRight]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kRight); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kFront]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kFront); };
                    if (cell.Walls[(int)MazeStructure.Cell2D.CellDirectionEnum.kBack]) { mazeInstance[x, z].BuildCellWall(MazeStructure.Cell2D.CellDirectionEnum.kBack); };
                    if (cell.HasAllWalls()) { mazeInstance[x, z].BuildCellCeiling(); }

                    // Position the Maze Cell
                    mazeInstance[x, z].transform.localPosition = new Vector3(x, 0, z);

                    // Set Cell Properties
                    // - Cell Type
                    // - Cell Floor Material
                    // - Cell Wall Material

                    // Set Cell Type property
                    switch (cell.CellType)
                    {
                        case MazeStructure.Cell2D.CellTypeEnum.kStandardCell:
                            {
                                mazeInstance[x, z].CellType = MazeCell.CellTypeEnum.kStandard;
                                break;
                            }
                        case MazeStructure.Cell2D.CellTypeEnum.kStartCell:
                            {
                                // Start Cell:
                                // - Add Start Cell Behavior to Cell
                                // - Instantiate Player GameObject and position in Maze

                                mazeInstance[x, z].CellType = MazeCell.CellTypeEnum.kStart;

                                break;
                            }
                        case MazeStructure.Cell2D.CellTypeEnum.kEndCell:
                            {
                                // End Cell:
                                // - Add End Cell Behavior to Cell

                                mazeInstance[x, z].CellType = MazeCell.CellTypeEnum.kEnd;

                                break;
                            }
                        default:
                            {
                                break;
                            }
                    };

                    // Set Cell Floor Material
                    // - Use default floor material if material not found
                    if(floor_material.MaterialData != null)
                    {
                        mazeInstance[x, z].SetFloorMaterial(floor_material.MaterialData);
                    }

                    // Set Cell Wall Material
                    // - Use default wall material if material not found
                    if (wall_material.MaterialData != null)
                    {
                        mazeInstance[x, z].SetWallMaterial(wall_material.MaterialData);
                    }
                }
            }
        }
        else
        {
            Debug.Log("MazeManager: Rendering Maze Aborted");
        }


        // Publish Event: RenderMazeCompleted
        EventManager.TriggerEvent("RenderMazeCompleted");
    }

    public void SetMazeFloorMaterial(Material floorMaterial)
    {
        for (int x = 0; x < MazeSizeX; ++x)
        {
            for (int z = 0; z < MazeSizeZ; ++z)
            {
                mazeInstance[x, z].SetFloorMaterial(floorMaterial);
            }
        }
    }

    public void SetMazeWallMaterial(Material wallMaterial)
    {
        for (int x = 0; x < MazeSizeX; ++x)
        {
            for (int z = 0; z < MazeSizeZ; ++z)
            {
                mazeInstance[x, z].SetWallMaterial(wallMaterial);
            }
        }
    }

    /// <summary>
    /// Show the maze solution path defined in the GameContext
    /// </summary>
    public void ShowMazeSolution()
    {
        foreach (MazeStructure.Cell2D cell in GameContext.m_context.m_activeMazeHintSolutionPath)
        {
            mazeInstance[cell.PositionX, cell.PositionZ].ShowSolutionCell();
        }
    }

    /// <summary>
    /// Hide the entire maze solution path
    /// </summary>
    public void HideMazeSolution()
    {
        if (mazeInstance != null)
        {
            for (int x = 0; x < MazeSizeX; ++x)
            {
                for (int z = 0; z < MazeSizeZ; ++z)
                {
                    mazeInstance[x, z].HideSolutionCell();
                }
            }
        }
    }

    /// <summary>
    /// Resets the maze instance destroying all maze GameObjects
    /// </summary>
    public void ResetMaze()
    {
        // Reset Maze Instance
        if (mazeInstance != null)
        {
            for (int x = 0; x < MazeSizeX; ++x)
            {
                for (int z = 0; z < MazeSizeZ; ++z)
                {
                    DestroyImmediate(mazeInstance[x, z].gameObject);
                }
            }

            mazeInstance = null;
        }
    }
}
