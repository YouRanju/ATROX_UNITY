using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private float eTime;
    private Vector2 startPos;

    public GameObject m_Spr;
    private GameObject m_SprClone;

    public Vector3 m_Scroll;
    public float m_Screen;
    public float m_dirX;
    public float m_Speed;

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

        if (Input.GetKey(KeyCode.LeftArrow)) {
            m_dirX = 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            m_dirX = -1;
        }
        else
        {
            m_dirX = 0;
        }

        m_Scroll.x += m_dirX * m_Speed * eTime;

        if (m_dirX < 0 && m_Scroll.x < -m_Screen)
        {
            m_Scroll.x += m_Screen+ 40;
        }
        else if (m_dirX > 0 && m_Scroll.x > m_Screen)
        {
            m_Scroll.x -= m_Screen+40;
        }
        else
        {
            Move();
        }
       
    }

    private void Move()
    {
        Vector2 pos1 = new Vector2(m_Scroll.x, 0);

        m_Spr.transform.position = pos1;
    }
}
