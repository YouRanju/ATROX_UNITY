using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    private Rigidbody2D ShotRigid;

    public Sprite ExplosionImg;
    public GameObject Explosion;
    public AudioSource ShootAudio;

    // Start is called before the first frame update
    void Start()
    {
        ShotRigid = GetComponent<Rigidbody2D>();

        Invoke("explo", 1);
        Destroy(gameObject, 1);
    }

    void explo()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
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
            explo();
            Destroy(gameObject);
        }
    }
}
