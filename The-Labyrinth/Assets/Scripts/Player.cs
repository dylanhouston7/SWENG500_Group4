using UnityEngine;
using System.Collections;
using System;



    
    public class Player : MonoBehaviour
    {
        private Camera playerCam;

        public float xCameraRotate = 45;

        public Vector3 startingPos;

        void Start()
        {
            this.gameObject.AddComponent<PlayerController>();
            this.createPlayerCamera();
            this.setPlayerPosition(startingPos);
        }

        // Update is called once per frame
        void Update()
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
            float x = this.startingPos.x;
            float y = this.startingPos.y;
            float z = this.startingPos.y;

            //Create player camera
            playerCam = (Camera)Camera.Instantiate(original.GetComponent<Camera>(), new Vector3(x, y, z), Quaternion.FromToRotation(new Vector3(0, 0, 0), new Vector3(0, 0, 0)));

            //Attach Camera Controller to player camera object
            playerCam.gameObject.AddComponent<CameraController>().player = this.gameObject;

            //Set initial Position
            playerCam.transform.position = new Vector3(x, y + 2, z - 2);
            playerCam.gameObject.transform.Rotate(new Vector3(xCameraRotate, 0, 0));

            //Destroy origional camera
            GameObject.DestroyObject(original);

            //Enable the new camera
            playerCam.enabled = true;
        }
    }
