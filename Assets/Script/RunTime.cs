using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTime : MonoBehaviour
{
    // Start is called before the first frame update

    private float runTime;
    public GameObject[] obj;
    private GameObject[] itemObj;
    private GameObject trapObj;

    public GameObject player;
    public GameObject[] Enemys;
    public GameObject[] Items;
    public GameObject[] Traps;
    public GameObject Boss;
    public GameObject CheckPoint;

    public Vector3[] EnemyPosition;
    private bool created;
    private float checkpointtime;
    private int cnt = 0;

    private int playerLife;

    void Start()
    {
        runTime = 0;

        obj = new GameObject[8];
        EnemyPosition = new Vector3[9];
        itemObj = new GameObject[8];

        playerLife = player.GetComponent<Player>().m_life;
        checkpointtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            runTime += Time.deltaTime;
        }

        EnemyAppear();
        TrapAppear();
        PlayerLifeCheck();

        //아이템
        if (created)
        {
            if(trapObj != null)
            {
                EnemyPosition[0] = trapObj.transform.position;
            } else
            {
                EnemyPosition[0] = new Vector3(0, 0, 3);
            }

            for (int i = 1; i < 9; i++)
            {
                if (EnemyPosition[i] == new Vector3(0, 0, 3))
                {
                    if (Random.Range(0, 7) == 7)
                    {
                        itemObj[i-1] = (GameObject)Instantiate(Items[Random.Range(0, 5)], EnemyPosition[i], Quaternion.identity);
                        itemObj[i-1].SetActive(true);
                        created = false;
                    }
                }

                if(obj[i-1] != null)
                {
                    EnemyPosition[i] = obj[i-1].transform.position;
                } else
                {
                    EnemyPosition[i] = new Vector3(0,0,3);
                }
            }
        }

        if (runTime > 17f)
        {
            CheckPoint.transform.position = new Vector3(30, CheckPoint.transform.position.y, 0);
            CheckPoint.SetActive(true);
        }

        if (CheckPoint.GetComponent<CheckpointColiision>().check)
        {
            checkpointtime = 17f;
        }
    }

    private void PlayerLifeCheck()
    {
        if (playerLife != player.GetComponent<Player>().m_life)
        {
            runTime = checkpointtime;
            created = false;
            for(int i = 0; i < 8; i++)
            {
                Destroy(obj[i].gameObject);
            }
            playerLife = player.GetComponent<Player>().m_life;
        }
    }

    private void TrapAppear()
    {
        if(runTime > 0.6f && runTime < 0.7f)
        {
            if(trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 2.2f && runTime < 2.3f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 5.7f && runTime < 5.8f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 9f && runTime < 9.1f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 11.6f && runTime < 11.7f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 13.4f && runTime < 13.5f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 17.2 && runTime < 17.3f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 22.4f && runTime < 22.5f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 25f && runTime < 25.1f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
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

            for(int i = 0; i < 8; i++)
            {
                if(obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if(runTime > 4.1 && runTime < 4.11)
        {
            cnt = 0;
        }

        if (runTime > 6.9f && runTime < 7f)
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

        if (runTime > 9.6f && runTime < 9.7f)
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

        if (runTime > 12.4f && runTime < 12.5f)
        {
            while (cnt < 4)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            while (cnt < 8)
            {
                obj[cnt] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[0].transform.position.y, 0), Quaternion.identity);
                obj[cnt].SetActive(true);
                cnt++;
            }
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 12.5 && runTime < 12.51)
        {
            cnt = 0;
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
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 17.1 && runTime < 17.11)
        {
            cnt = 0;
        }

        if (runTime > 21f && runTime < 21.1f)
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
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 21.1 && runTime < 21.11)
        {
            cnt = 0;
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
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 26.1 && runTime < 26.11)
        {
            cnt = 0;
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
