using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Shot;
    public float delayTime;

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
            Instantiate(Shot);

            sdt = 0;
        }
    }

}
