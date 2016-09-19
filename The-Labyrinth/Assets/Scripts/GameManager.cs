using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Maze mazePrefab;

    public int sizeX, sizeY;

    private Maze mazeInstance = null;
  

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mazePrefab.sizeX = sizeX;
            mazePrefab.sizeZ = sizeY;

            if (mazeInstance != null)
            {
                Destroy(mazeInstance.gameObject);
            }
            else
            {
                mazeInstance = Instantiate(mazePrefab) as Maze;
            }
        }
    }
}
