using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    bool touch;
    // Start is called before the first frame update
    void Start()
    {
        touch = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if(!touch)
            {
                collision.GetComponent<Player>().DecHP();
                touch = true;
            }
        }
    }
}
