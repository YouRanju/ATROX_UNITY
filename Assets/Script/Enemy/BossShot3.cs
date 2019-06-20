using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot3 : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject[] Alien;
    public GameObject[] Stars;
    public GameObject dark;
    public GameObject Shot;
    public float delayTime;

    private float sdt;
    private float adt;
    private float stdt;
    private float ddt;
    bool isdark;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = player;
        sdt += Time.deltaTime;
        adt += Time.deltaTime;
        stdt += Time.deltaTime;
        ddt += Time.deltaTime;

        if (sdt > delayTime)
        {
            GameObject obj;
            obj = (GameObject)Instantiate(Shot, transform.position+new Vector3(-2, -1.7f), Quaternion.identity);
            obj.SetActive(true);
            obj.transform.Rotate(new Vector3(0f, 0f, (-90)));
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-7, Mathf.Sin((Mathf.PI * 1.6f * ddt)));
            obj.GetComponent<AlienShotCollision>().isBoss = true;

            sdt = 0;
        }

        if (adt > 8f)
        {
            GameObject[] obj = new GameObject[2];
            for (int i = 0; i < 2; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Alien[Random.Range(0, 2)], transform.position, Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }

            adt = 0;
        }

        if(stdt > 2f && stdt < 5.9)
        {
            dark.SetActive(false);
        }

        if (stdt > 6f)
        {
            dark.SetActive(true);
            dark.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, stdt * 0.08f);
        }

        if (stdt > 7f)
        {
            GameObject[] obj = new GameObject[20];
            for (int i = 0; i < 20; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Stars[Random.Range(0, 4)], new Vector3(Random.Range(-10, 15), 6), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }

            stdt = 0;
        }
    }
}
