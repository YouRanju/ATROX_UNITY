using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTime : MonoBehaviour
{
    // Start is called before the first frame update

    private float runTime;
    private GameObject[] obj;
    private int cnt;

    public GameObject[] Enemys;
    public GameObject[] Items;
    public GameObject[] Traps;
    public GameObject Boss;

    private Vector3[] EnemyPosition;
    private bool created;

    void Start()
    {
        runTime = 0;
        obj = new GameObject[4];
        EnemyPosition = new Vector3[4]; 
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            runTime += Time.deltaTime;
        }

        if (runTime > 5f && runTime < 6.3f)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].GetComponent<AlienShoot>().delayTime = Random.Range(2, 5);
                    obj[i].SetActive(true);
                    created = true;
                }
            }
        }

        if(runTime > 7.7f && runTime < 7.9f)
        {
            for (int i = 0; i < 4; i++)
            {
                if(obj[i] != null)
                {
                    Vector2 vec = obj[i].transform.position;
                    vec.x -= 0.6f;

                    obj[i].transform.position = vec;
                }
            }
        }

        if (runTime > 8f && runTime < 8.2f)
        {
            delete();
        }

        if (runTime > 10f && runTime < 11f)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                    created = true;
                }
            }
        }

        if (runTime > 13f && runTime < 13.2f)
        {
            for (int i = 0; i < 4; i++)
            {
                obj[i].GetComponent<DashEnemy>().AttDec(1);
            }
        }

        if (created)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Items[Random.Range(0, 5)], EnemyPosition[i], Quaternion.identity);
                    obj[i].SetActive(true);
                    continue;
                }

                EnemyPosition[i] = obj[i].transform.position;
            }
        }
    }

    private void delete()
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(obj[i].gameObject);
            obj[i] = null;
            created = false;
        }
    }
}
