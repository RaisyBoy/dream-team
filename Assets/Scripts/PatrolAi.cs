using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAi : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    GameObject firstPoint;

    [SerializeField]
    GameObject secondPoint;

    bool x = false;

    [SerializeField]
    float speed = 1.0f;

    float firstDistance;

    float rotation = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPoint.transform.parent = null;
        secondPoint.transform.parent = null;
        firstDistance = Vector3.Distance(this.transform.position, firstPoint.transform.position);
    }

    void FixedUpdate()
    {
        if (!x)
        {
            rb.MovePosition(Vector3.MoveTowards(this.transform.position, firstPoint.transform.position, speed));
            Debug.Log(Vector3.Distance(this.transform.position, firstPoint.transform.position));
            this.transform.Rotate(0, 0, rotation);
            rotation = (firstDistance - Vector3.Distance(this.transform.position, firstPoint.transform.position)) * 5;
            if (Vector3.Distance(this.transform.position, firstPoint.transform.position) <= 0.2f)
            {
                x = true;
                Debug.Log(x);
                firstDistance = Vector3.Distance(this.transform.position, secondPoint.transform.position);
            }
        }
        if (x)
        {
            rb.MovePosition(Vector3.MoveTowards(this.transform.position, secondPoint.transform.position, speed));
            this.transform.Rotate(0, 0, -rotation);
            rotation = (firstDistance - Vector3.Distance(this.transform.position, secondPoint.transform.position)) * 5;
            if (Vector3.Distance(this.transform.position, secondPoint.transform.position) <= 0.2f)
            {
                x = false;
                firstDistance = Vector3.Distance(this.transform.position, firstPoint.transform.position);
            }
        }
    }
}
