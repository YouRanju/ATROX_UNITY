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

        Debug.Log(runTime);

        if (runTime > 5f && runTime < 6f)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                    created = true;
                }
            }
        }

        if(created)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Items[0], EnemyPosition[i], Quaternion.identity);
                    continue;
                }

                EnemyPosition[i] = obj[i].transform.position;

                Debug.Log(i + ": " + EnemyPosition[i]);
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
                }
            }
        }

        if (runTime > 13f && runTime < 13.2f)
        {
            delete();
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
