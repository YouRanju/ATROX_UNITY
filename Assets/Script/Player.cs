using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PolygonCollider2D UpColi;
    public PolygonCollider2D DownColi;
    public PolygonCollider2D[] groudColi;
    public Sprite[] runImg;
    static float rdt = 0;
    static float jdt = 0;

    private Rigidbody2D Rigid;
    private int cnt = 0;

    
    float m_OrHeight;
    float m_PrHeight;
    float m_JumpPower;
    float m_JumpTime;
    int m_life;
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

        Rigid.velocity = (Vector2.right * 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;
        jdt += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow)) Jump();

        Render();

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
        }

        if (!m_Jump)
        {
            m_Jump = true;
            m_2ndJump = false;
            m_JumpPower = 8.0f;
            m_PrHeight = this.transform.position.y;

            Rigid.velocity = (Vector2.up * m_JumpPower);

            isFalling = (this.transform.position.y - m_PrHeight) < 0 ? false : true;

            if (isFalling)
            {
                GetComponent<SpriteRenderer>().sprite = runImg[1];
            }
            else GetComponent<SpriteRenderer>().sprite = runImg[0];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(m_Jump)
            m_Jump = false;
    }
}
