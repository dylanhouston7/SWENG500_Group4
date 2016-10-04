using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //Player Object
    public GameObject player;

    private Transform target;

    //Offset
    private Vector3 offset;

    private Rigidbody rigidbody;

    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = 0f;
    public float yMaxLimit = 45f;

    public float distanceMin = 15f;
    public float distanceMax = 90f;

    float sensitivity = 10f;

    float x = 0.1f;
    float y = 0.1f;

    void Start()
    {
        //Set Offset
        offset = transform.position - player.transform.position;

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }

        target = player.transform;

    }

    void Update()
    {
        this.cameraZoom();

        if(Input.GetMouseButton(1))
        {
            this.moveCamera();
        }

    }

    void LateUpdate()
    { 
        //Set Position
        transform.position = player.transform.position + offset;
    }

    void moveCamera()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * distance * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

        RaycastHit hit;
        if (Physics.Linecast(target.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }

        Vector3 negDistance = new Vector3(0.1f, 0.1f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }

    void cameraZoom()
    {
        //Zoom Field of View
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, distanceMin, distanceMax);
        Camera.main.fieldOfView = fov;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
