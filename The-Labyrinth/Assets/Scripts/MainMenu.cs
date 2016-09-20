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
            SceneManager.LoadScene(1);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
