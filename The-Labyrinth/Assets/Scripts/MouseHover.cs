using UnityEngine;
using System.Collections;

/// <summary>
/// Class to hold all of the mouse events for menus
/// </summary>
public class MouseHover : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	}

    /// <summary>
    /// Turns the text color to red upon mouse hover
    /// </summary>
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    /// <summary>
    /// Turns the text color to red on mouse click
    /// </summary>
    void OnMouseClick()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    /// <summary>
    /// Turns the text color to white upon mouse hover exit
    /// </summary>
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
