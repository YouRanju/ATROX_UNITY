﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject player;
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

            GameObject obj = null;
            if (player.GetComponent<Player>().isStart != false)
            {
                obj = (GameObject)Instantiate(Shot, transform.position, Quaternion.identity);
                obj.SetActive(true);
                obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * 4f;

                sdt = 0;
            }
        }
    }
}
