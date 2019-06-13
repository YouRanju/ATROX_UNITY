using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMoving : MonoBehaviour
{
    public float upmove;
    public float downmove;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            if (transform.position.y <= downmove)
            {
                GetComponent<Rigidbody2D>().velocity = (Vector2.up * upmove);

            }
            if (transform.position.y > upmove)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().gravityScale = gravity;
            }
    }
}
