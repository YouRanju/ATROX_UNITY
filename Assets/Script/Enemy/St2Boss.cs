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

    public PolygonCollider2D portalCol;

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

        portalCol.enabled = false;
    }

    private void Update()
    {
        if (transform.position.x < 8f)
        {
            portalCol.enabled = true;
            transform.position = new Vector3(8, transform.position.y);
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player.GetComponent<Player>().DecHP();
        }

        if(collision.gameObject.name == "upperfloor")
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
        } else
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerMissile")
        {
            DecHP(player.GetComponent<Player>().level);
        }
    }
}
