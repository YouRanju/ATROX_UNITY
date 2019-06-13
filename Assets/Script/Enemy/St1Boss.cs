using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St1Boss : MonoBehaviour
{
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
    private int cnt;

    private bool isright = true;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.velocity = Vector2.left * 30;
    }

    void Update()
    {
        rdt += Time.deltaTime;

        Render();
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
            DieSound.Play();
            Instantiate(Explo, transform.position, transform.rotation);
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerMissile")
        {
            DecHP(1);
        }
    }
}
