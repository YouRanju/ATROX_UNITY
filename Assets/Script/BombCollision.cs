using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollision : MonoBehaviour
{

    public GameObject clear;
    GameObject[] obj = new GameObject[7];

    float dt;

    bool arrive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;

        if (dt > 3.2f)
        {
            for (int i = 0; i < 7; i++)
            {
                if (obj[i] != null && arrive)
                {
                    Destroy(obj[i].gameObject);
                }

                if (i == 6)
                {
                    arrive = false;
                    dt = 0;
                    gameObject.SetActive(false);
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                }
            }          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "floor" && arrive == false)
        {
            obj[0] = (GameObject)Instantiate(clear, new Vector3(0, 0), Quaternion.identity);
            obj[1] = (GameObject)Instantiate(clear, new Vector3(Random.Range(-5, 10), Random.Range(-3, 6)), Quaternion.identity);
            obj[2] = (GameObject)Instantiate(clear, new Vector3(Random.Range(-10, 3), Random.Range(-3, 2)), Quaternion.identity);
            obj[3] = (GameObject)Instantiate(clear, new Vector3(Random.Range(-3, 6), Random.Range(0, 6)), Quaternion.identity);
            obj[4] = (GameObject)Instantiate(clear, new Vector3(Random.Range(-5, 2), Random.Range(-2, 5)), Quaternion.identity);
            obj[5] = (GameObject)Instantiate(clear, new Vector3(Random.Range(0, 7), Random.Range(1, 4)), Quaternion.identity);
            obj[6] = (GameObject)Instantiate(clear, new Vector3(Random.Range(3, 10), Random.Range(1, 6)), Quaternion.identity);
            arrive = true;

            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }
    }
}
