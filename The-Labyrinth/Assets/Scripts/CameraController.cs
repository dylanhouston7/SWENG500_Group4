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
   
    }

    void LateUpdate()
    {
        //Set Offset
        offset = transform.position - player.transform.position;

        //Set Position
        transform.position = player.transform.position + offset;
    }

}
