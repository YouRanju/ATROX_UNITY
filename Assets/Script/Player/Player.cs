using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    //item용 변수
    public GameObject[] ItemUI;
    bool canDouble = false;
    bool canThree = false;
    bool canRange = false;
    bool canSpeed = false;
    bool canHom = false;

    // 임시변수
    bool isStart = false; //시작용          
    bool isGround = true; //이동용


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();

        Rigid.velocity = (Vector2.right * 13.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;

        if (transform.position.x > -3.2f && !isStart)
        {
            isStart = true;
        }
        
        if(isStart)
        {
            Rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Rigid.gravityScale = 1;

            if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -7f && isGround)
            {
                Rigid.constraints = RigidbodyConstraints2D.None;
                Rigid.AddForce(Vector2.left * 20);
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < -3.2f && isGround)
            {
                Rigid.constraints = RigidbodyConstraints2D.None;
                Rigid.AddForce(Vector2.right * 10);
            }

            if (transform.position.y < -1.6f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Render();
        }

        Score.text = scoring.ToString();
        Life.text = m_life.ToString();
    }

    void Render()
    {
        if(m_life >= 1)
        {
            lifeUI[m_life-1].SetActive(true);
        }

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
        
        if (m_life <= 0)
        {
            Debug.Log("GameOver");
        }
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
            ItemUI[0].SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "three")
        {
            canThree = true;
            ItemUI[1].SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "range")
        {
            canRange = true;
            ItemUI[2].SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "speed")
        {
            canSpeed = true;
            ItemUI[3].SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "homing")
        {
            canHom = true;
            ItemUI[4].SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
