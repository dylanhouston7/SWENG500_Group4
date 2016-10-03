using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //Player Object
    public GameObject player;

    //Offset
    private Vector3 offset;

    float minFov  = 15f;
    float maxFov = 90f;
    float sensitivity = 10f;

    void Start()
    {
        //Set Offset
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        //Zoom Field of View
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

    }

    void LateUpdate()
    { 
        //Set Position
        transform.position = player.transform.position + offset;
    }
}
