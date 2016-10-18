using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    //Public Members
    public GameObject player;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = 0f;
    public float yMaxLimit = 45f;
    public float distanceMin = 15f;
    public float distanceMax = 90f;

    //Private Members
    private new Rigidbody rigidbody;
    private Quaternion qOrg;

    private float sensitivity = 10f;
    private float x = 0.0f;
    private float y = 0.0f;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    void Start()
    {
        target = player.transform;

        //Set Offset
        offsetPosition = transform.position - target.position;

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void Update()
    {
        //Zoom in/out
        this.cameraZoom();

        if (Input.GetMouseButton(1))
        {
            //Get position of camera to snap back to
            if (qOrg.x == 0f)
            {
                qOrg = transform.rotation;
            }

            //Move camera with mouse
            this.moveCamera();
        }
        else
        {
            //Moves camera with target object
            Refresh();
        }
        
        //Release of Right mouse click returns camera to origional position
        if(Input.GetMouseButtonUp(1))
        {
            transform.rotation = qOrg;
        }
    }

    void LateUpdate()
    { 
        //Set Position
        transform.position = target.position + offsetPosition;
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

        Vector3 negDistance = new Vector3(0f, 0f, -distance);
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

    void Refresh()
    {
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        //Set rotation to rotation of target object
        transform.rotation = target.rotation;
    }
}
