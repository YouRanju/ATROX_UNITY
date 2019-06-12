using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemcollision : MonoBehaviour
{
    float m_dirX = 0;
    float m_Scroll;

    // Start is called before the first frame update
    void Start()
    {
        m_Scroll = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_dirX = -0.3f;
        }

        else
        {
            m_dirX = 0;
        }

        m_Scroll += m_dirX;

        Vector2 pos1 = new Vector2(m_Scroll, transform.position.y);
        transform.position = pos1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            //collision.gameObject.GetComponent<Player>().DecHP();
        }

        if (collision.transform.tag == "Back")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
