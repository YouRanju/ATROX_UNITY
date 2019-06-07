using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLight : MonoBehaviour
{
    public GameObject planet;

    private float time = 1;
    private bool isAl = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        if(transform.position.x > 3 && !isAl)
        {
            GetComponent<Rigidbody2D>().gravityScale = 3f;
            if (transform.position.y < -1.5)
            {
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }

        if (transform.position.x > 9)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            time -= Time.deltaTime;
            planet.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, time);

            if (transform.position.y > 3.6)
            {
                time = 0;
                isAl = true;
                GetComponent<Rigidbody2D>().velocity = Vector2.left;
            }
        }
        
        if(transform.position.x < -0.5 && isAl)
        {
            isAl = false;
            
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0.02f;

            time = 1;
            planet.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, time);
        }

        if(transform.position.x < 1.2 && isAl)
        {
            time += Time.deltaTime;
            planet.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, time);
        }
    }
}
