using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class MazeLevelMenuManager : MonoBehaviour
{
    // GameObject References
    public MazeLevelGrid mazeLevelGridRef;
   

    void Start()
    {
        List<MazeStructure.Maze2D> mazes;
        this.GetMazes(out mazes);
        foreach (MazeStructure.Maze2D maze in mazes)
        {
            mazeLevelGridRef.AddMazeLevelRowElement(maze);
        }
    }

    void GetMazes(out List<MazeStructure.Maze2D> mazes)
    {
        mazes = new List<MazeStructure.Maze2D>();

        switch (GameContext.m_context.difficulty.Difficulty)
        {
            case Assets.Scripts.DifficultySettings.DifficultyEnum.EASY:
                {
                    mazes = GameContext.m_context.m_easyMazes;
                    break;
                }
            case Assets.Scripts.DifficultySettings.DifficultyEnum.MEDIUM:
                {
                    mazes = GameContext.m_context.m_mediumMazes;
                    break;
                }
            case Assets.Scripts.DifficultySettings.DifficultyEnum.HARD:
                {
                    mazes = GameContext.m_context.m_hardMazes;
                    break;
                }
            case Assets.Scripts.DifficultySettings.DifficultyEnum.EPIC:
                {
                    mazes = GameContext.m_context.m_epicMazes;
                    break;
                }
        }
    }
}
