using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starlight : MonoBehaviour
{
    public GameObject logo;

    private float alpha;
    private float time;
    private bool isAl = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 1.6)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            time += Time.deltaTime;

            if (alpha < 8.0f && time >= 0.1f && !isAl)
            {
                alpha += time * 12;
                time = 0;
            } else if( time >= 0.1f)
            {
                isAl = true;
                alpha -= time * 12;
                if (alpha < 0)
                {
                    isAl = false;
                }

                time = 0;
            }
            GetComponent<Light>().intensity = alpha;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * 5;
        }
    }
}
