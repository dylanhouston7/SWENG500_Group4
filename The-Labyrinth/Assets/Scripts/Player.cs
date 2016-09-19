using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    public CamObject cameraPrefab;

    private CamObject cameraInstance = null;

    void Start ()
    {
        this.gameObject.AddComponent<PlayerController>();

        //Temporary -- Still working on creating camera object that will be attached to player object
        Vector3 offset = new Vector3(0, 10, -10);
        Camera.main.gameObject.transform.position = offset;

        Vector3 rotation = new Vector3(45, 0, 0);
        Camera.main.gameObject.transform.rotation = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    public void setPlayerPosition(Vector3 position)
    {
        this.transform.localPosition = position;
    }
}
