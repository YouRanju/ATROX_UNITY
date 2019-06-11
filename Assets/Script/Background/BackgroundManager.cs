using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private float eTime;
    private Vector2 startPos;

    public GameObject m_Spr;
    public GameObject player;

    public Vector3 m_Scroll;
    public float m_Screen;
    public float m_dirX;
    public float m_Speed;

    bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Spr.transform.position = m_Scroll;
        startPos = m_Scroll;
      
        m_dirX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        eTime = Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow)) {
            m_dirX = -0.7f;
            left = false;
        }
        //else if(Input.GetKey(KeyCode.LeftArrow) && m_Scroll.x - startPos.x < 4f)
        //{
        //    if(left)
        //    {
        //        m_dirX = 0.7f;
        //    } else
        //    {
        //        startPos = m_Scroll;
        //        left = true;
        //    }
        //}
        else
        {
            m_dirX = 0;
        }

        m_Scroll.x += m_dirX * m_Speed * eTime;
        Move();
       
    }

    private void Move()
    {
        if (m_Scroll.x < m_Screen)
        {
            m_Scroll.x += 40f;
        }

        Vector2 pos1 = new Vector2(m_Scroll.x, m_Scroll.y);

        m_Spr.transform.position = pos1;
    }
}
