﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    float m_dirX = 0;
    float m_Scroll;
    public float m_y;
    public bool isRock;
    public GameObject player;
    public AudioSource dieSound;

    bool die;
    int m_life = 3;
    // Start is called before the first frame update
    void Start()
    {
        m_Scroll = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_dirX = -0.3f;
        }

        else
        {
            m_dirX = 0;
        }

        m_Scroll += m_dirX;

        Vector2 pos1 = new Vector2(m_Scroll, m_y);
        transform.position = pos1;

        if(player.GetComponent<Player>().isStart == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DecHP();
        }

        if (collision.transform.tag == "PlayerMissile" && isRock)
        {
            DecHP();
        }

        if(collision.transform.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }

    public void plzDes()
    {
        dieSound.Play();
        Destroy(gameObject, 1f);
    }

    public void DecHP()
    {
        m_life--;
        if (m_life <= 0)
        {
            if (!die)
            {
                die = true;
                player.GetComponent<Player>().scoring += 300;

                plzDes();
            }
        }
    }
}
