
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMeteorMove : MonoBehaviour
{
    private Vector2 vec;

    // Start is called before the first frame update
    void Start()
    {
        vec = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -0.2f)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.up * 0.3f);

        }
        if (transform.position.y >= 0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0.03f;
        }
    }
}
