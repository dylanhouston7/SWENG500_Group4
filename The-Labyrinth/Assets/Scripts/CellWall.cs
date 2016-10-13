using UnityEngine;
using System.Collections;

public class CellWall : MonoBehaviour
{
    public void RemoveWall()
    {
        Destroy(GetComponent<GameObject>());
    }
}
