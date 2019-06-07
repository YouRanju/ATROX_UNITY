using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Shot;
    public float delayTime;
    public float oneShoting;

    private float sdt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;

        if (sdt > delayTime)
        {
            Shot.transform.position = Enemy.transform.position;
            if (Enemy.name == "Boss")
            {
                

                    for (int i = 0; i < oneShoting; i++)
                    {
                        float angle = 360 / oneShoting;
                        Shot.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle);
                    }
            }
            Instantiate(Shot);

            sdt = 0;
        }
    }
}
