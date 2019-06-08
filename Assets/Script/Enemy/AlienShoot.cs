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
    private float speed = 4;
    private int cnt = 0;

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

            GameObject obj;
            obj = (GameObject)Instantiate(Shot, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.down *4f;
                
            sdt = 0;
        }
    }
}
