using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class AlienShotCollision : MonoBehaviour
{
    public GameObject player;

    public bool isBoss;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(!isBoss)
            {
                Vector2 vec = transform.position;
                vec.x -= 0.2f;
                transform.position = vec;
            }
        }

        if(player.GetComponent<Player>().isStart == false)
        {
            Destroy(gameObject);
        }

        if (player.GetComponent<Player>().isBomb)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" && !collision.GetComponent<Player>().canSpeed)
        {
            Debug.Log("shot");
            player.GetComponent<Player>().DecHP();
            Destroy(gameObject);
        }

        if(collision.transform.tag == "Back")
        {
            Destroy(gameObject);
        }

        if(collision.transform.tag == "PlayerMissile")
        {
            player.GetComponent<Player>().scoring += 50;
            Destroy(gameObject);
        }
    }
}