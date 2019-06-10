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

    void Start()
    {
        ShotRigid = GetComponent<Rigidbody2D>();

        //Invoke("explo", 0.7f);
        Destroy(gameObject, 1.3f);
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

        if(collision.transform.tag == "EnemyMissile")
        {
            explo();
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.3f);
            Destroy(collision.gameObject);
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
