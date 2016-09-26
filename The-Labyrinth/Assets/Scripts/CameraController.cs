using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //Player Object
    public GameObject player;

    //Offset
    private Vector3 offset;

    void Start()
    {
        //Set Offset
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    { 
        //Set Position
        transform.position = player.transform.position + offset;
    }

}
