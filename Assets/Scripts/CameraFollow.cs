using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public GameObject player;
    

    Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        Vector3 destination = player.transform.position + offset;
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 0.2f);
        }
    }
}
