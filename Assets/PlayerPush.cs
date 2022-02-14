using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x, distance, boxMask);

        if(hit.collider!=null && hit.collider.gameObject.tag == "Pushable" && Input.GetKey(KeyCode.Space))
        {
              box = hit.collider.gameObject;

              box.GetComponent<FixedJoint2D>().enabled = true;
              box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

        }else if(Input.GetKeyUp(KeyCode.Space))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
        }
    }

    void OnDrawGizmos()
     {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
