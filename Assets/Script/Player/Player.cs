using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (transform.position.x > -5f && !isStart)
        {
            isStart = true;
        }
        
        if(isStart)
        {
            Rigid.constraints = RigidbodyConstraints2D.FreezePositionX;

            if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();

            //if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -7f)
            //{
            //    Rigid.constraints = RigidbodyConstraints2D.None;
            //    if (transform.rotation.z > 30)
            //    {
            //        transform.rotation = new Quaternion(0, 0, 0, 0);
            //    }
            //    Rigid.velocity = Vector2.down * 10;
            //    Rigid.velocity = Vector2.left * 4;
            //}

            //if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < -5f)
            //{
            //    Rigid.constraints = RigidbodyConstraints2D.None;
            //    Rigid.velocity = Vector2.down * 10;
            //    Rigid.velocity = Vector2.right * 4;
            //}

            if (transform.position.y < -1.6f)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            Render();
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
        m_life--;
        if (m_life <= 0)
        {
            Debug.Log("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(m_Jump)
        {
            m_Jump = false;
            Rigid.freezeRotation = false;
        }
            
    }
}
