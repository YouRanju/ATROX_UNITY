using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class StarColiision : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.05f, 1.2f);
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.left * Random.Range(3, 16));

        if (player.GetComponent<Player>().isStart == false)
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

        if (collision.transform.tag == "Respawn")
        {
            Destroy(gameObject);
        }
    }
}