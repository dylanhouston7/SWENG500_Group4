using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    private Camera playerCam;

    void Start ()
    {
        this.gameObject.AddComponent<PlayerController>();

        this.createPlayerCamera();
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    public void setPlayerPosition(Vector3 position)
    {
        this.transform.localPosition = position;
    }

    private void createPlayerCamera()
    {
        // Find the 'main' camera object.
        var original = GameObject.FindWithTag("MainCamera");

        // Create a new camera to use, copying from the main camera
        // Notice how we provide a position and a rotation for it.  
        playerCam = (Camera)Camera.Instantiate(original.GetComponent<Camera>(), this.gameObject.transform.position, Quaternion.FromToRotation(new Vector3(0, 15, 0), new Vector3(0, 0, 0)));

        //Attach Camera Controller to player camera object
        playerCam.gameObject.AddComponent<CameraController>().player = this.gameObject;

        //Destroy origional camera
        GameObject.DestroyObject(original);

        //Enable the new camera
        playerCam.enabled = true;
    }
}
