﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColiision : MonoBehaviour
{
    public bool check = false;
    public AudioSource checkin;

    float m_dirX = 0;
    float m_Scroll;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        m_Scroll = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Player>().canSpeed)
        {
            m_dirX = -1.2f;
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_dirX = -0.3f;
            }

            else
            {
                m_dirX = 0;
            }
        }
        

        m_Scroll += m_dirX;

        Vector2 pos1 = new Vector2(m_Scroll, transform.position.y);
        transform.position = pos1;

        if(check)
        {
            time += Time.deltaTime* 70;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(time, time, time);
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            checkin.Play();
            check = true;
        }
    }
}
