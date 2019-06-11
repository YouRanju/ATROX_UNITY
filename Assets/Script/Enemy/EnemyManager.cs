using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public float delayTime;

    private float sdt;
    private int cnt = 0;

    GameObject[] obj;
    private int objcnt = 0;

    void Start()
    {
        obj = new GameObject[4];
        
    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;

        if (sdt > delayTime)
        {
            for (int i = 0; i < 4; i++) { 

                if (obj[i] == null)
                {
                    cnt = Random.Range(0, Enemys.Length);

                    obj[i] = (GameObject)Instantiate(Enemys[cnt], new Vector3(20+Random.Range(2, 10), Enemys[cnt].transform.position.y, 0), Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }

            for(int i = 0; i < 4; i++)
            {
                if (obj[i].transform.position.x < -10)
                {
                    Destroy(obj[i].gameObject);
                }
            }

            

            sdt = 0;
        }


    }
}
