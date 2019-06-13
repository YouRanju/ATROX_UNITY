﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AlienShotCollision : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 vec = transform.position;
            vec.x -= 0.2f;
            transform.position = vec;
        }

        if(player.GetComponent<Player>().isStart == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.GetComponent<Player>().DecHP();
            Destroy(gameObject);
        }

        if(collision.transform.tag == "Back")
        {
            Destroy(gameObject);
        }

        if(collision.transform.tag == "PlayerMissile")
        {
            player.GetComponent<Player>().scoring += 50;
            Destroy(gameObject);
        }
    }
}