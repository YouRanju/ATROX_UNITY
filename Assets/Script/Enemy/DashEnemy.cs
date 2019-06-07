using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    public GameObject Player;
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


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();

        Dir.x = (Player.transform.position.x < this.transform.position.x) ?
            -1 : 1;
        Dir.y = (Player.transform.position.y < this.transform.position.y) ?
            -1 : 1;

        Rigid.velocity = Dir * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;
        Render();

        Dir.x = (Player.transform.position.x < this.transform.position.x) ?
           -1 : 1;
        Dir.x = (this.transform.position.x - Player.transform.position.x < 5) ?
            0 : Dir.x;
        Dir.y = (Player.transform.position.y < this.transform.position.y) ?
            -0.5f : 0.5f;
        Dir.y = (transform.position.y < -1 && Player.transform.position.y < -1) ?
            0 : Dir.y;

        if (hp < 0)
        {
            Dir.x = 0; Dir.y = 0;
        }

        Rigid.velocity = Dir * 4.0f;

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

    void Render()
    {
        if (rdt > 0.5f)
        {
            cnt++;
            if (cnt >= 2) cnt = 0;
            GetComponent<SpriteRenderer>().sprite = runImg[cnt];

            if (cnt == 0)
            {
                UpColi.enabled = true;
                DownColi.enabled = false;
                //EnemySound.Play();
            }
            else
            {
                UpColi.enabled = false;
                DownColi.enabled = true;
            }

            rdt = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerMissile")
        {
            DecHP(1);
        }
    }

    public void DecHP(int damage)
    {
        hp -= damage;
        if(hp < 0)
        {
            DieSound.Play();
            Destroy(gameObject, 1);
        }
    }
}