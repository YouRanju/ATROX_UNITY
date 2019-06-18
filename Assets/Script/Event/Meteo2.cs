using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo2 : MonoBehaviour
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
        if (transform.position.y < 1.2f)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0.6f);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(0.5f, 1f));
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(0.5f, 1f));
        }
        if (transform.position.y >= vec.y)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0.03f;
        }
    }
}
