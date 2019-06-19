using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
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

    private float adt;
    private bool col = false;

    bool die;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();

        Dir.x = (Player.transform.position.x < this.transform.position.x) ?
            -1 : 1;
        Dir.y = (Player.transform.position.y < this.transform.position.y) ?
            -1 : 1;

        die = false;
        Rigid.velocity = Dir * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;
        Render();

        Dir.x = (Player.transform.position.x < this.transform.position.x) ?
           -1 : 1;
        Dir.x = (Mathf.Abs(this.transform.position.x - Player.transform.position.x) < 1) ?
            0 : Dir.x;
        Dir.y = (Player.transform.position.y < this.transform.position.y) ?
            -0.5f : 0.5f;
        Dir.y = (transform.position.y < -1.9 && Player.transform.position.y < -0.4) ?
            0 : Dir.y;

        if (hp < 0)
        {
            Dir.x = 0; Dir.y = 0;
        }

        GetComponent<SpriteRenderer>().flipX = Dir.x < 0 ? false : true;

        Rigid.velocity = Dir * (Random.Range(3,12) * 0.7f);

        if(col)
        {
            Attack();
        }

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
                vec.x -= 0.3f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerMissile")
        {
            DecHP(Player.GetComponent<Player>().level); DecHP(1);
        }
        if(collision.transform.tag == "Player" && !col)
        {
            col = true;
        }
        if (collision.transform.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }

    public void DecHP(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            if(!die)
            {
                die = true;
                Player.GetComponent<Player>().scoring += 400;
                DieSound.Play();
                Instantiate(Explo, transform.position, transform.rotation);
                Destroy(gameObject, 0.5f);
            }
        }
    }

    public void AttDec(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            if (!die)
            {
                die = true;
                DieSound.Play();
                Instantiate(Explo, transform.position, transform.rotation);
                if (Mathf.Abs(Player.transform.position.x - this.transform.position.x) < 1.5f)
                {
                    Player.GetComponent<Player>().DecHP();
                }
                Destroy(gameObject, 0.5f);
            }
        }
    }

    public void bomb()
    {
        hp -= hp;
        if (hp <= 0)
        {
            if (!die)
            {
                die = true;
                DieSound.Play();
                Instantiate(Explo, transform.position, transform.rotation);
                Destroy(gameObject, 0.5f);
            }
        }
    }

    private void Attack()
    {
        
        adt += Time.deltaTime * 150;
        GetComponent<SpriteRenderer>().color = new Color(255 - adt, 0, 255 - adt);
 
        if(adt >= 255)
        {
            col = false;
            AttDec(1); 
        }
    }
}