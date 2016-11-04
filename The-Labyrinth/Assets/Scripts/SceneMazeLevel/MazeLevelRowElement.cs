using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class MazeLevelRowElement : MonoBehaviour
{
    // GameObject References
    public Text textMazeName;

    public void Initialize(MazeStructure.Maze2D mazeRef)
    {
        textMazeName.text = mazeRef.Name;
    }
}
