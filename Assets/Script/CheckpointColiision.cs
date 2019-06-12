using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointColiision : MonoBehaviour
{
    public bool check = false;

    float m_dirX = 0;
    float m_Scroll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_dirX = -0.2f;
        }

        else
        {
            m_dirX = 0;
        }

        m_Scroll += m_dirX;

        Vector2 pos1 = new Vector2(m_Scroll, transform.position.y);
        transform.position = pos1;

        if(check)
        {
           // gameObject.GetComponent<SpriteRenderer>().color = new Color()
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            check = true;
        }
    }
}
