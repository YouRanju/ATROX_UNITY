using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunTime : MonoBehaviour
{
    //거리-시간
    float runTime;
    float checkpointtime;
    public GameObject fullTime;

    //소환용 변수
    public GameObject[] obj;
    GameObject[] itemObj;
    GameObject trapObj;
    GameObject BossObj;
    int cnt = 0;

    //패턴적용용
    public GameObject player;
    public GameObject[] Enemys;
    public GameObject[] Items;
    public GameObject[] Traps;
    public GameObject Boss;
    public GameObject CheckPoint;
    public Slider slider;


    //아이템 생성용
    Vector3[] EnemyPosition; //죽은 적 위치 정보
    bool created;

    //플레이어 피격 시
    private int playerLife;

    float dt;
    bool bossdeath;

    void Start()
    {
        runTime = 0;
        checkpointtime = 0;

        obj = new GameObject[8];
        itemObj = new GameObject[2];

        EnemyPosition = new Vector3[8];

        playerLife = player.GetComponent<Player>().m_life;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            runTime += Time.deltaTime;
        }

        //스피드 아이템 획득시
        if (player.GetComponent<Player>().canSpeed)
        {
            runTime += Time.deltaTime * 2;
        }

        //핵폭탄
        if (player.GetComponent<Player>().isBomb)
        {
            dt += Time.deltaTime;

            if (dt > 2f)
            {
                delete();
                dt = 0;
            }
        }

        PlayerLifeCheck(); //피격체크
        EnemyAppear();  //외계인 소환 패턴
        TrapAppear();   //함정 소환 패턴

        //아이템
        if (created)
        {
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (Random.Range(0, 7) % 2 == 0 && itemObj[j] == null)
                        {
                            itemObj[j] = (GameObject)Instantiate(Items[Random.Range(0, 5)], EnemyPosition[i], Quaternion.identity);
                            itemObj[j].SetActive(true);
                        }
                    }

                    created = false;
                }

                if (obj[i] != null)
                {
                    EnemyPosition[i] = obj[i].transform.position;
                }
                else
                {
                    EnemyPosition[i] = new Vector3(0, 0, 3);
                }
            }
        }

        //체크포인트
        if (runTime < 13f) CheckPoint.SetActive(false);
        if (runTime > 13f)
        {
            CheckPoint.transform.position = new Vector3(30, CheckPoint.transform.position.y, 0);
            CheckPoint.SetActive(true);
        }

        if (CheckPoint.GetComponent<CheckpointColiision>().check)
        {
            checkpointtime = 15f;
        }

        //남은거리
        slider.value = runTime / 1000 * 32;

        //클리어
        if (runTime > 31.5f && BossObj == null)
        {
            dt += Time.deltaTime;

            player.GetComponent<Player>().scoring += 1200;
            fullTime.GetComponent<FullTime>().timeadd();

            if (dt > 5)
            {

                SceneManager.LoadScene("StageClear");
            }
        }
    }

    private void PlayerLifeCheck()
    {
        if (playerLife != player.GetComponent<Player>().m_life)
        {
            runTime = checkpointtime;
            created = false;
            delete();
            playerLife = player.GetComponent<Player>().m_life;
        }
    }

    private void delete()
    {
        for (int i = 0; i < 8; i++)
        {
            if (obj[i] != null)
            {
                Destroy(obj[i].gameObject);
            }

            if (i > 1) continue;

            if (itemObj[i] != null)
            {
                Destroy(itemObj[i].gameObject);
            }
        }

        if (trapObj != null)
        {
            Destroy(trapObj.gameObject);
        }
    }

    private void TrapAppear()
    {
        if (runTime > 0.6f && runTime < 0.7f)
        {
            if (trapObj == null)
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

            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 4.1 && runTime < 4.11)
        {
            cnt = 0;
        }

        if (runTime > 6.9f && runTime < 7f)
        {
            for (int i = 0; i < 6; i++)
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
            for (int i = 0; i < 6; i++)
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


        if (runTime > 30f && runTime < 30.1f)
        {
            delete();
        }

        if (runTime > 31f && runTime < 31.1f)
        {
            if (BossObj == null)
            {
                BossObj = (GameObject)Instantiate(Boss, new Vector3(20, Boss.transform.position.y, 0), Quaternion.identity);
                BossObj.SetActive(true);
            }

        }
    }
}
