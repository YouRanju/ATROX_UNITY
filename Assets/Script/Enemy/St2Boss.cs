using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class St2Boss : MonoBehaviour
{
    public GameObject Explo;
    public GameObject player;

    public AudioSource EnemySound;
    public AudioSource DieSound;

    public bool death;
    public int hp;

    private Vector2 Dir;
    private Rigidbody2D Rigid;
    GameObject obj;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();

        Rigid.velocity = (Vector2.left * 30);
        player.GetComponent<Player>().isStartBoss2 = true;
    }

    private void Update()
    {
        if (transform.position.x < 9.27f)
        {
            Rigid.velocity = Vector2.zero;
        }
    }

    public void DecHP(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if(!death)
            {
                death = true;
                DieSound.Play();
                obj = (GameObject)Instantiate(Explo, transform.position, transform.rotation);
                Destroy(gameObject, 0.5f);
                Destroy(obj.gameObject, 5f);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerMissile")
        {
            DecHP(player.GetComponent<Player>().level);
        }

        if (collision.transform.tag == "Player")
        {
            player.GetComponent<Player>().DecHP();
        }
    }
}
