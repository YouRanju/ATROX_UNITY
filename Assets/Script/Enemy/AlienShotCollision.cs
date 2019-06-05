﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AlienShotCollision : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 vec = transform.position;
            vec.x += 0.4f;
            transform.position = vec;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 vec = transform.position;
            vec.x -= 0.4f;
            transform.position = vec;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("아약");
            Destroy(gameObject);
        }
    }
}