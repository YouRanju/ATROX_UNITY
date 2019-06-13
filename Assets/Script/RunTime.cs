using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTime : MonoBehaviour
{
    // Start is called before the first frame update

    private float runTime;
    private GameObject[] obj;

    public GameObject Player;
    public GameObject[] Enemys;
    public GameObject[] Items;
    public GameObject[] Traps;
    public GameObject Boss;
    public GameObject CheckPoint;

    private Vector3[] EnemyPosition;
    private bool created;
    private float checkpointtime;
    private int cnt = 0;

    private int playerLife;

    void Start()
    {
        runTime = 0;
        obj = new GameObject[8];
        EnemyPosition = new Vector3[8];
        playerLife = Player.GetComponent<Player>().m_life;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            runTime += Time.deltaTime;
        }

        EnemyAppear();

        if (created)
        {
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    if(Random.Range(0,10) == 7)
                    {
                        obj[i] = (GameObject)Instantiate(Items[Random.Range(0, 5)], EnemyPosition[i], Quaternion.identity);
                        obj[i].SetActive(true);
                        created = false;
                    }
                }

                EnemyPosition[i] = obj[i].transform.position;
            }
        }

        if(CheckPoint.GetComponent<CheckpointColiision>().check)
        {
            checkpointtime = 30f;
        }
    }

    private void EnemyAppear()
    {
        if (runTime > 2f && runTime < 2.1f)
        {
            for (int i = 0; i < 8; i++)
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

        if (runTime > 4f && runTime < 4.1f)
        {
            while (cnt < 4)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            while (cnt < 8)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            created = true;
        }

        if (runTime > 5.7f && runTime < 5.8f)
        {
            for (int i = 0; i < 8; i++)
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

        if (runTime > 9f && runTime < 9.1f)
        {
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                    created = true;
                }
            }
        }

        if (runTime > 12f && runTime < 12.1f)
        {
            while (cnt < 4)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            while (cnt < 8)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            created = true;
        }

        if (runTime > 17f && runTime < 17.1f)
        {
            while (cnt < 4)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            while (cnt < 8)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            created = true;
        }

        if (runTime > 21f && runTime < 11.1f)
        {
            while (cnt < 6)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            while (cnt < 8)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            created = true;
        }

        if (runTime > 26f && runTime < 26.1f)
        {
            while (cnt < 2)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            while (cnt < 8)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            created = true;
        }

        if (runTime > 31f && runTime < 31.1f)
        {
            if (obj[0] == null)
            {
                obj[0] = (GameObject)Instantiate(Boss, new Vector3(20, Boss.transform.position.y, 0), Quaternion.identity);
                obj[0].SetActive(true);
                created = true;
            }
        }
    }

    private void delete(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            Destroy(obj[i].gameObject);
            obj[i] = null;
        }
        created = false;
    }
}
