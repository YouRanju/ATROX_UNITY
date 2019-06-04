using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            Vector2 vec = transform.position;
            vec.x += 0.4f;
            transform.position = vec;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 vec = transform.position;
            vec.x -= 0.4f;
            transform.position = vec;
        }
    }
}
