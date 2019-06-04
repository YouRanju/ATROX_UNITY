using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    private Rigidbody2D ShotRigid;

    public Sprite ExplosionImg;
    public GameObject Explosion;
    public AudioSource ShootAudio;

    public Vector3 dir;

    void Start()
    {
        ShotRigid = GetComponent<Rigidbody2D>();

        Invoke("explo", 0.7f);
        Destroy(gameObject, 0.7f);
    }

    void explo()
    { 
        Instantiate(Explosion, transform.position, transform.rotation);
    }

    void Update()
    {
        if (enabled)
        {
            ShotRigid.velocity = (dir * 5.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            explo();
            GetComponent<AudioSource>().Play();
            Destroy(gameObject,0.3f);
        }
    }
}
