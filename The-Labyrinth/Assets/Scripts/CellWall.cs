using UnityEngine;
using System.Collections;

public class CellWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RemoveWall()
    {
        Destroy(GetComponent<GameObject>());
    }
}
