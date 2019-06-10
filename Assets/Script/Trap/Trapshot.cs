using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapshot : MonoBehaviour
{
    public GameObject[] Traps;
    public float delayTime;

    private float sdt;
    private float speed = 4;
    private int cnt = 0;

    bool created = false;

    GameObject obj = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;

        if (sdt > delayTime)
        {
            cnt = Random.Range(0, 2);

            if (obj == null)
            {
                obj = (GameObject)Instantiate(Traps[cnt], new Vector3(20, -3.2f, 0), Quaternion.identity);
                obj.SetActive(true);
            }

            if (obj.transform.position.x < -10)
            {
                obj.GetComponent<TrapCollision>().plzDes();
                obj = null;
            }

            sdt = 0;
        }

        
    }
}
