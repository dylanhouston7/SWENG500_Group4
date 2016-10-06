using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour
{
    public float hSliderSizeX = 0.0f;
    public float hSliderSizeZ = 0.0f;

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), "Maze Size X:" + (int)hSliderSizeX);
        hSliderSizeX = (int)GUI.HorizontalSlider(new Rect(110, 15, 300, 30), hSliderSizeX, 0, 50);

        GUI.TextArea(new Rect(10, 40, 100, 20), "Maze Size Z:" + (int)hSliderSizeZ);
        hSliderSizeZ = (int)GUI.HorizontalSlider(new Rect(110, 45, 300, 30), hSliderSizeZ, 0, 50);

        if (GUI.Button(new Rect(10, 75, 100, 30), "Gen Maze"))
        {
            EventManager.TriggerEvent("ResetMaze");

            GameContext.m_context.m_currentMaze = MazeStructure.Maze2D.GetInstance((int)hSliderSizeX, (int)hSliderSizeZ);
            MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, GameContext.m_context.m_currentMaze);

            // TODO: Solve Maze and Calculate Difficulty Rating

            EventManager.TriggerEvent("RenderMaze");
        }

        if(GUI.Button(new Rect(1000, 10, 100, 30), "Store Maze"))
        {
            if(GameContext.m_context.m_currentMaze != null &&
               !GameContext.m_context.m_currentMaze.IsNull())
            {
                GameContext.m_context.m_installedMazes.Add(GameContext.m_context.m_currentMaze);
            }            
        }

        GUI.Label(new Rect(1000, 45, 100, 30), "Num Mazes: " + GameContext.m_context.m_installedMazes.Count);

        // TODO: Display the Calculated Maze Difficulty Rating
    }
}