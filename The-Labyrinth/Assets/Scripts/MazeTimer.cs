using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Timer;

/// <summary>
/// A class that acts as a simple timer for a maze
/// </summary>
public class MazeTimer : MonoBehaviour
{
    /// <summary>
    /// The font for the timer label. Provided by the Unity Editor.
    /// </summary>
    public Font font;

    /// <summary>
    /// The color for the timer label. Provided by the Unity Editor.
    /// </summary>
    public Color color;

    /// <summary>
    /// The game manager object
    /// </summary>
    public GameManager gameManager;

    /// <summary>
    /// A reference to the timer object for storing and calculating time
    /// </summary>
    ITimer timer;

    /// <summary>
    /// Initialization method
    /// </summary>
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Get the timer for the difficulty level
        timer = GameContext.m_context.difficulty.Timer;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // For every single frame, subtract the amount of time it took to get to this frame from the time remaining.
        //timeRemaining -= Time.deltaTime;
        timer.Update(Time.deltaTime);


    }

    /// <summary>
    /// Updates the time label
    /// </summary>
    void OnGUI()
    {
        if (timer.GetTimeInSeconds() > 0)
        {
            ShowTimeLabel();
        }
        else
        {
            ShowTimeUpLabel();
            EventManager.TriggerEvent("GameOver");
        }
    }

    /// <summary>
    /// Show a label with the amount of seconds remaining in the maze
    /// </summary>
    void ShowTimeLabel()
    {
        // Convert the time remaining into seconds
        int seconds = timer.GetTimeInSeconds();

        // Create the label
        string timeRemainingLabel = string.Format("{0} seconds", seconds);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.textMazeTimer.text = timeRemainingLabel;
    }

    /// <summary>
    /// Show a label to the user, indicating that the time allotted for the maze has expired.
    /// </summary>
    void ShowTimeUpLabel()
    {
        // Create the label
        string timesUpLabel = "Time's Up!";

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        gameManager.textMazeTimer.text = timesUpLabel;
    }
}
