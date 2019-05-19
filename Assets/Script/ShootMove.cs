using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    private Rigidbody2D ShotRigid;

    // Start is called before the first frame update
    void Start()
    {
        ShotRigid = GetComponent<Rigidbody2D>();

        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(enabled)
        {
            ShotRigid.velocity = (Vector2.right * 7.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
