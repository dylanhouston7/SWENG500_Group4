using UnityEngine;
using System.Collections;
using System;

public class CamObject : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        this.gameObject.AddComponent<CameraController>().player = player;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCameraPosistion(Vector3 position)
    {
        this.gameObject.transform.position = position;
    }

    public void setCameraRotation(Vector3 rotation)
    {
        this.gameObject.transform.rotation = Quaternion.Euler(rotation);
    }

}

