using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Player Object Speed
    public float speed = 10;

    //Rigid Body
    private Rigidbody rb;

    void Start()
    {
        //Get Player Rigid Body
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Player Movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Force
        rb.AddForce(movement * speed);
    }
}