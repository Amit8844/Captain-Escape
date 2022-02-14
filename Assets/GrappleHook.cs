using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    LineRenderer line;

    [SerializeField] LayerMask grapplablMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 20f;

    bool isGrapplineg = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;

    void Start() 
    {
        line = GetComponent<LineRenderer>();
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0) && !isGrapplineg)
        {
            StartGrapple();
        }

        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);

            transform.position = grapplePos;

            line.SetPosition(0, transform.position);

            if(Vector2.Distance(transform.position,target) < 0.5f)
            {
                retracting = false;
                isGrapplineg = false;
                line.enabled = false;
            }
        }
    }

    private void StartGrapple()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplablMask);

        if(hit.collider != null)
        {
            isGrapplineg = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

        Vector2 newPos;

        for (; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
          newPos = Vector2.Lerp(transform.position, target, t / time);
          line.SetPosition(0, transform.position);
          line.SetPosition(1, newPos);
          yield return null;


        }
        line.SetPosition(1, target);
        retracting = true;
    }
}
