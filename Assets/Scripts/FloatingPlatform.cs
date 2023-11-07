using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 curLoc;


    Vector3 upP;
    Vector3 downP;
    bool x = false;

    [SerializeField]
    float speed = 1.0f;

    [SerializeField]    
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curLoc = this.transform.position;
        upP = new Vector3(curLoc.x, curLoc.y+0.5f, curLoc.z);
        downP = new Vector3(curLoc.x, curLoc.y-0.5f, curLoc.z);
        timer = Random.Range(0.0f, timer);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer >= 0.0f) 
        {
            timer -= Time.deltaTime;
            return;
        }
        if(!x)
        {
            rb.MovePosition(Vector3.MoveTowards(this.transform.position, downP, speed));
            if (Vector3.Distance(this.transform.position, downP) <= 0.2f)
            {
                x = true;   
            }
        }
        if (x)
        {
            rb.MovePosition(Vector3.MoveTowards(this.transform.position, upP, speed));
            if (Vector3.Distance(this.transform.position, upP) <= 0.2f)
            {
                x = false;
            }
        }

    }
}
