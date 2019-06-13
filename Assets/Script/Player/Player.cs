using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //이미지와 충돌처리, 이동
    public Sprite[] runImg;
    public PolygonCollider2D UpColi;
    public PolygonCollider2D DownColi;
    Rigidbody2D Rigid;
    int cnt = 0; //충돌처리용

    //사운드
    public AudioSource JumpAudio;
    public AudioSource DblJumpAudio;
    public AudioSource Falldown;

    //시간변수
    static float rdt = 0;

    //점프용 변수
    float m_PrHeight;
    float m_JumpPower;
    bool isFalling;
    bool m_Jump;
    bool m_2ndJump;

    //점수용
    public Text Score;
    public int scoring;

    //생명용
    public GameObject[] lifeUI;
    public Text Life;
    public int m_life = 3;
    float dieTime = 0;

    //item용 변수
    public GameObject[] ItemUI;
    public bool canDouble = false;
    public bool canThree = false;
    public bool canRange = false;
    public bool canSpeed = false;
    public bool canHom = false;
    float[] itemTime = new float[5];

    //핵폭탄
    public GameObject[] Bombs;
    public GameObject Bomb;
    int canBomb = 2;
    float keydelay = 0;

    // 임시변수
    public bool isStart = false; //시작용          
    bool isGround = true; //이동용


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(-11.79f, -1.31f);
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;

        if (m_life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (!isStart)
        {
            Vector2 vec = transform.position;
            vec.x += 0.4f;

            transform.position = vec;

            canDouble = false;
            canThree  = false;
            canRange  = false;
            canSpeed  = false;
            canHom = false;

            if (transform.position.x > -3.2f)
            {
                isStart = true;
            }

            if (m_life >= 1)
            {
                lifeUI[m_life - 1].SetActive(true);
            }
        }
        
        if(isStart)
        {
            keydelay += Time.deltaTime;

            Rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Rigid.gravityScale = 1;

            if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -7f)
            {
                Rigid.constraints = RigidbodyConstraints2D.None;
                Rigid.AddForce(Vector2.left * 20);
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < -3.2f)
            {
                Rigid.constraints = RigidbodyConstraints2D.None;
                Rigid.AddForce(Vector2.right * 10);
            }

            if (transform.position.y < -1.6f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Render();

            if(canBomb >= 0)
            {
                if (Input.GetKeyUp(KeyCode.LeftShift) && keydelay > 0.3f)
                {
                    Bombs[--canBomb].SetActive(false);
                    keydelay = 0;
                }
            }

            if(canRange)
            {
                GetComponent<Shoot>().time = 2f;
            } else
            {
                GetComponent<Shoot>().time = 1f;
            }
        }

        ItemCheck();

        Score.text = scoring.ToString();
        Life.text = m_life.ToString();
    }

    void ItemCheck()
    {
        if(canDouble)
        {
            itemTime[0] += Time.deltaTime;

            if(itemTime[0] > 7f)
            {
                canDouble = false;
                itemTime[0] = 0;
            }
        }
        if (canThree)
        {
            itemTime[1] += Time.deltaTime;

            if (itemTime[1] > 7f)
            {
                canThree = false;
                itemTime[1] = 0;
            }
        }
        if (canRange)
        {
            itemTime[2] += Time.deltaTime;

            if (itemTime[2] > 7f)
            {
                canRange = false;
                itemTime[2] = 0;
            }
        }
        if (canSpeed)
        {
            itemTime[3] += Time.deltaTime;

            if (itemTime[3] > 1f)
            {
                canSpeed = false;
                itemTime[3] = 0;
            }
        }
        if (canHom)
        {
            itemTime[4] += Time.deltaTime;

            if (itemTime[4] > 7f)
            {
                canHom = false;
                itemTime[4] = 0;
            }
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
            }
            else
            {
                UpColi.enabled = false;
                DownColi.enabled = true;
            }

            rdt = 0;
        }

        ItemUI[0].SetActive(canDouble);
        ItemUI[1].SetActive(canThree);
        ItemUI[2].SetActive(canRange);
        ItemUI[3].SetActive(canSpeed);
        ItemUI[4].SetActive(canHom);
    }

    void Jump()
    { 
        if (m_Jump && !m_2ndJump && isFalling && canDouble)
        {
            m_JumpPower = 8.0f;
            m_2ndJump = true;

            Rigid.velocity = (Vector2.up * m_JumpPower);
            DblJumpAudio.Play();
        }

        if (!m_Jump)
        {
            m_Jump = true;
            m_2ndJump = false;
            m_JumpPower = 8.0f;
            m_PrHeight = this.transform.position.y;
            isGround = false;

            Rigid.velocity = (Vector2.up * m_JumpPower);
            Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.rotation = new Quaternion(0, 0, 0, 0);

            JumpAudio.Play();

            isFalling = (this.transform.position.y - m_PrHeight) < 0 ? false : true;

            if (isFalling)
            {
                GetComponent<SpriteRenderer>().sprite = runImg[1];
            }
            else GetComponent<SpriteRenderer>().sprite = runImg[0];
        }
    }

    public void DecHP()
    {
        lifeUI[--m_life].SetActive(false);

        transform.position = new Vector2(-11.79f, -1.31f);

        isStart = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor" || collision.gameObject.name == "upperfloor")
        {
            if (m_Jump)
            {
                m_Jump = false;

                Rigid.freezeRotation = false;
            }

            isGround = true;
        }

        if (collision.transform.tag == "hole")
        {
            Falldown.Play();
            Vector2 vec = transform.position;

            vec.y -= 2f;
            transform.position = vec;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "double")
        {
            canDouble = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "three")
        {
            canThree = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "range")
        {
            canRange = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "speed")
        {
            canSpeed = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "homing")
        {
            canHom = true;
            Destroy(collision.gameObject);
        }
    }
}
