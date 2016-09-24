using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool isStart;

    // Use this for initialization
    void Start () {
	
	}

    void OnMouseUp()
    {
        //Application.LoadLevel(1);
        if (isStart)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // TODO: Remove :: Test Code Only
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Diff 1"))
        {
            GameContext.m_context.m_difficultyLevel = 0;
        }

        if (GUI.Button(new Rect(10, 45, 100, 30), "Diff 2"))
        {
            GameContext.m_context.m_difficultyLevel = 1;
        }

        if (GUI.Button(new Rect(10, 80, 100, 30), "Diff 3"))
        {
            GameContext.m_context.m_difficultyLevel = 2;
        }
    }
}
