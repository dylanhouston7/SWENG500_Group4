using UnityEngine;
using Assets.Scripts;

/// <summary>
/// A class that acts as a simple timer for a maze
/// </summary>
public class MazeTimer : MonoBehaviour {

    /// <summary>
    /// The font for the timer label. Provided by the Unity Editor.
    /// </summary>
    public Font font;

    /// <summary>
    /// The color for the timer label. Provided by the Unity Editor.
    /// </summary>
    public Color color;

    /// <summary>
    /// Indicates how much time is allotted to complete a maze
    /// TODO: Make this more flexible so that the GameManager can provide a time to the class.
    /// </summary>
    float timeRemaining = 30;

	/// <summary>
    /// Initialization method
    /// </summary>
	void Start () {
	
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        // For every single frame, subtract the amount of time it took to get to this frame from the time remaining.
        timeRemaining -= Time.deltaTime;
	}

    /// <summary>
    /// Updates the time label
    /// </summary>
    void OnGUI()
    {
        if(timeRemaining > 0)
        {
            ShowTimeLabel();
        }
        else
        {

            ShowTimeUpLabel();
        }
    }

    /// <summary>
    /// Show a label with the amount of seconds remaining in the maze
    /// </summary>
    void ShowTimeLabel()
    {
        // Convert the time remaining into seconds
        int seconds = System.Convert.ToInt32(timeRemaining);

        // Create the label
        string timeRemainingLabel = string.Format("Time Remaining : {0} seconds", seconds);

        // Get the GUI elements
        int fontSize = 35;
        GUIStyle guiStyle = GuiHelper.CreateGuiStyle(fontSize, font);

        // Set the label
        GUILayout.Label(timeRemainingLabel, guiStyle);
    }

    /// <summary>
    /// Show a label to the user, indicating that the time allotted for the maze has expired.
    /// </summary>
    void ShowTimeUpLabel()
    {
        // Create the label
        string timesUpLabel = "Time's Up!";

        // Get the GUI elements
        int fontSize = 100;
        GUIStyle guiStyle = GuiHelper.CreateGuiStyle(fontSize, font);

        // Set the label
        GUILayout.Label(timesUpLabel, guiStyle);
    }
}
