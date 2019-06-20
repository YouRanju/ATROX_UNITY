using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class St3Boss : MonoBehaviour
{
    public GameObject Explo;
    public GameObject player;

    public PolygonCollider2D Coli;

    public AudioSource EnemySound;
    public AudioSource DieSound;

    public int hp;

    private Vector2 Dir;
    private Rigidbody2D Rigid;
    private float rdt;
    private int cnt;

    private bool isright = true;

    public bool death;

    GameObject obj;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.velocity = Vector2.left * 30;
    }

    void Update()
    {
        if (transform.position.x < 5f)
        {
            if (transform.position.y <= 0)
            {
                GetComponent<Rigidbody2D>().velocity = (Vector2.up * 2.2f);

            }
            if (transform.position.y > 2.2f)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().gravityScale = 0.3f;
            }
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
    }
}
