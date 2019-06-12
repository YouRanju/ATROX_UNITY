using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PolygonCollider2D UpColi;
    public PolygonCollider2D DownColi;
    public PolygonCollider2D[] groudColi;
    public Sprite[] runImg;
    public AudioSource JumpAudio;
    public AudioSource DblJumpAudio;

    static float rdt = 0;
    static float jdt = 0;

    private Rigidbody2D Rigid;
    private int cnt = 0;
    private bool isStart = false;
    
    float m_OrHeight;
    float m_PrHeight;
    float m_JumpPower;
    float m_JumpTime;
    int m_life = 3;
    bool isFalling;
    bool m_Jump;
    bool m_2ndJump;
    bool JumpKey;
    bool Is2ndJumpKey;

    bool isGround = true;

    public Text Score;
    public int scoring;
    public Camera camera;

    public GameObject[] lifeUI;

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
        jdt += Time.deltaTime;

        if (transform.position.x > -3.2f && !isStart)
        {
            isStart = true;
        }
        
        if(isStart)
        {
            Rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Rigid.gravityScale = 1;

            if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();

            //if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -7f && isGround)
            //{
            //    Rigid.constraints = RigidbodyConstraints2D.None;
            //    Rigid.AddForce(Vector2.left * 10);
            //}

            //if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < -3.2f && isGround)
            //{
            //    Rigid.constraints = RigidbodyConstraints2D.None;
            //    Rigid.AddForce(Vector2.right * 10);
            //}

            if (transform.position.y < -1.6f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            Render();
        }
        Score.text = scoring.ToString();
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
        if (m_Jump && !m_2ndJump && isFalling)
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

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "double")
        {
            Debug.Log("dd");
        }
    }
}
