﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpEnemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Explo;
    public Sprite[] runImg;
    public PolygonCollider2D UpColi;
    public PolygonCollider2D DownColi;
    public AudioSource EnemySound;
    public AudioSource DieSound;
    public int hp;

    private Vector2 Dir;
    private Rigidbody2D Rigid;
    private float rdt;
    private float dt;
    private int cnt;

    private bool isright = true;
    public bool die;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();

        Dir.x = 1;

        Rigid.velocity = Dir * 2.0f;

        die = false;

    }

    void Update()
    {
        rdt += Time.deltaTime;
        Render();

        Dir.x = (this.transform.position.x > 10 && isright) ? -Random.Range(1, 4) :
            (this.transform.position.x < -10 && !isright) ? Random.Range(1, 4) : Dir.x;

        isright = Dir.x < 0 ? false : true;

        GetComponent<SpriteRenderer>().flipX = isright;
        
        if (hp < 0)
        {
            Dir.x = 0;
        }

        Rigid.velocity = Dir * 5.0f;



        if (Player.GetComponent<Player>().canSpeed)
        {
            Vector2 vec = transform.position;
            vec.x -= 0.5f;
            transform.position = vec;
        }

        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector2 vec = transform.position;
                vec.x -= 0.2f;
                transform.position = vec;
            }
        }

        if (Player.GetComponent<Player>().isStart == false)
        {
            Destroy(gameObject);
        }

        if (Player.GetComponent<Player>().isBomb)
        {
            dt += Time.deltaTime;

            if (dt > 2.4f)
            {
                Player.GetComponent<Player>().scoring += 400;
                Destroy(gameObject);

                dt = 0;
            }
        }
    }

    void Render()
    {
        if (rdt > 0.1f)
        {
            cnt++;
            if (cnt >= 2) cnt = 0;
            GetComponent<SpriteRenderer>().sprite = runImg[cnt];

            if (cnt == 0)
            {
                UpColi.enabled = true;
                DownColi.enabled = false;
            }
            else
            {
                UpColi.enabled = false;
                DownColi.enabled = true;
            }

            rdt = 0;
        }
    }

    public void DecHP(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if (!die)
            {
                die = true;
                Player.GetComponent<Player>().scoring += 400;
                DieSound.Play();
                Instantiate(Explo, transform.position, transform.rotation);
                Destroy(gameObject, 0.5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerMissile")
        {
            DecHP(Player.GetComponent<Player>().level);
        }

        if(collision.transform.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}
