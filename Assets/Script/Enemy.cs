using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public Sprite[] runImg;
    public PolygonCollider2D UpColi;
    public PolygonCollider2D DownColi;
    public AudioSource EnemySound;

    private Vector2 Dir;
    private Rigidbody2D Rigid;
    private float rdt;
    private int cnt;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = runImg[0];
        Rigid = GetComponent<Rigidbody2D>();

        Dir.x = (Player.transform.position.x < this.transform.position.x) ?
            -1 : 1;
        Dir.y = (Player.transform.position.y < this.transform.position.y) ?
            -1 : 1;

        Rigid.velocity = Dir * 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;
        Render();

        Dir.x = (Player.transform.position.x < this.transform.position.x) ?
           -1 : 1;
        Dir.y = (Player.transform.position.y < this.transform.position.y) ?
            -1 : 1;

        Rigid.velocity = Dir * 4.0f;
    }

    void Render()
    {
        if (rdt > 0.5f)
        {
            cnt++;
            if (cnt >= 2) cnt = 0;
            GetComponent<SpriteRenderer>().sprite = runImg[cnt];

            if (cnt == 0)
            {
                UpColi.enabled = true;
                DownColi.enabled = false;
                EnemySound.Play();
            }
            else
            {
                UpColi.enabled = false;
                DownColi.enabled = true;
            }

            rdt = 0;
        }
    }
}