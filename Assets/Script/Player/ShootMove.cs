using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootMove : MonoBehaviour
{
    private Rigidbody2D ShotRigid;

    public Sprite ExplosionImg;
    public GameObject Explosion;
    public AudioSource ShootAudio;

    public Vector3 dir;

    public float deathTime = 0.8f;
    public bool canHo = false;

    void Start()
    {
        ShotRigid = GetComponent<Rigidbody2D>();

        Destroy(gameObject, deathTime);
    }

    void explo()
    { 
        Instantiate(Explosion, transform.position, transform.rotation);
    }

    void Update()
    {
        if (enabled)
        {
            ShotRigid.velocity = (Vector3.Normalize(dir) * 5.5f);
        }

        if (canHo)
        {
            float rotateAmount = Vector3.Cross(dir, transform.up).z;
            GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * 1200f;
            GetComponent<Rigidbody2D>().velocity = transform.up * 12f;
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

        if(collision.transform.tag == "EnemyMissile")
        {
            explo();
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.3f);
            
        }

        if (collision.transform.tag == "trap" &&  collision.GetComponent<TrapCollision>().isRock)
        {
            explo();
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.3f);
            collision.GetComponent<TrapCollision>().DecHP();
        }
    }
}
