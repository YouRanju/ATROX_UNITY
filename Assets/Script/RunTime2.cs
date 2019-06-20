using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RunTime2 : MonoBehaviour
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
    public GameObject upperfloor;

    public AudioSource bossBgm;
    public AudioSource bossSE;
    public SpriteRenderer warning;
    bool wanr;
    float wdt;

    //아이템 생성용
    Vector3[] EnemyPosition; //죽은 적 위치 정보
    bool created;
    float idt;

    //플레이어 피격 시
    private int playerLife;

    float dt;

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
        if (runTime < 10.3f) CheckPoint.SetActive(false);
        if (runTime > 10.3f)
        {
            CheckPoint.transform.position = new Vector3(30, CheckPoint.transform.position.y, 0);
            CheckPoint.SetActive(true);
        }

        if (CheckPoint.GetComponent<CheckpointColiision>().check)
        {
            checkpointtime = 14f;
        }

        //남은거리
        slider.value = runTime / 1000 * 38;

        //클리어
        if (runTime > 26.6f && BossObj == null)
        {
            dt += Time.deltaTime;
            fullTime.GetComponent<FullTime>().checking = false;
            fullTime.GetComponent<Camera>().transform.localPosition = (Vector3)Random.insideUnitCircle * 0.1f + new Vector3(0, 0, -10);

            if (dt > 6)
            { 
                player.GetComponent<Player>().scoring += 3000;
                SceneManager.LoadScene("Stage2Clear");
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
            if (BossObj != null) Destroy(BossObj.gameObject);
            playerLife = player.GetComponent<Player>().m_life;
            player.GetComponent<Player>().isStartBoss2 = false;
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

        if (bossBgm.isPlaying)
        {
            fullTime.GetComponent<AudioSource>().Play();
            bossBgm.Pause();
        }
    }

    private void TrapAppear()
    {
        if (runTime > 0.3f && runTime < 0.31f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 4.4f && runTime < 4.41f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 7.7f && runTime < 7.8f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 9.4f && runTime < 9.41f)
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
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
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
        if (runTime > 16.2 && runTime < 16.3f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[0], new Vector3(20, -3.2f, 0), Quaternion.identity);
                trapObj.SetActive(true);
            }
        }
        if (runTime > 20.3f && runTime < 20.31f)
        {
            if (trapObj == null)
            {
                trapObj = (GameObject)Instantiate(Traps[1], new Vector3(20, -3.2f, 0), Quaternion.identity);
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
            for(int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }
            for(int i = 4; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].GetComponent<AlienShoot>().delayTime = Random.Range(2, 5);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
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

        if (runTime > 11.2f && runTime < 11.3f)
        {
            for (int i = 0; i < 6; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 6; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].GetComponent<AlienShoot>().delayTime = Random.Range(2, 5);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 14f && runTime < 14.1f)
        {
            for (int i = 0; i < 2; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 2; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].GetComponent<AlienShoot>().delayTime = Random.Range(2, 5);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 17f && runTime < 17.1f)
        {
            for (int i = 0; i < 5; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 5; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].GetComponent<AlienShoot>().delayTime = Random.Range(2, 5);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 20f && runTime < 20.1f)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 4; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[1], new Vector3(20 + Random.Range(5, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].GetComponent<AlienShoot>().delayTime = Random.Range(2, 5);
                    obj[i].SetActive(true);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] != null)
                {
                    created = true;
                }
            }
        }

        if (runTime > 23f && runTime < 23.1f)
        {
            for (int i = 0; i < 8; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Enemys[0], new Vector3(20 + Random.Range(2, 10), Enemys[1].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                    created = true;
                }
            }
        }

        if (runTime > 26f && runTime < 26.1f)
        {
            delete();
            bossSE.Play();
        }

        if(runTime > 26.2f && runTime < 26.3f)
        {
            wdt += Time.deltaTime * 2;

            if(wanr)
            {
                warning.color += new Color(0, 0, 0, wdt);
                wdt = 0;

                if (warning.color.a > 0.8f)
                {
                    wanr = false;
                }  
            }
            else
            {
                warning.color -= new Color(0, 0, 0, wdt);
                wdt = 0;

                if (warning.color.a <= 0f)
                {
                    wanr = true;
                }
            }

        }

        if (runTime < 26.2f)
        {
            upperfloor.SetActive(false);
        }

        if (runTime > 26.3f && runTime < 26.4f)
        {
            warning.color = new Color(255, 0, 0, 0);
            fullTime.GetComponent<AudioSource>().Pause();
            bossBgm.Play();

            if (BossObj == null)
            {
                BossObj = (GameObject)Instantiate(Boss, new Vector3(Boss.transform.position.x, Boss.transform.position.y, 0), Boss.transform.rotation);
                BossObj.SetActive(true);
            }
        }

        if (BossObj != null)
        {
            if (Mathf.CeilToInt(runTime) % 4 == 0)
            {
                upperfloor.SetActive(true);
            }
            if (upperfloor.transform.position.x < -20)
            {
                upperfloor.SetActive(false);
            }

            if(runTime > 26f)
            {
                idt += Time.deltaTime;

                if (Mathf.CeilToInt(idt * 100) % 5 == 0)
                {
                    created = true;
                }
            }
        }
    }

}
