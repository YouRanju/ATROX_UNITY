using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
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
            obj.SetActive(true);

           
                float angle = 360 / oneShoting;

                cnt++;

                obj.GetComponent<Rigidbody2D>().velocity = (new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * cnt / oneShoting), speed * Mathf.Sin((Mathf.PI * 2 * cnt / oneShoting))));
                obj.transform.position += new Vector3(0, -2, 0);
                obj.transform.Rotate(new Vector3(0f, 0f, (360 * cnt / oneShoting + 90)));


                if (cnt >= oneShoting) cnt = 0;

            sdt = 0;
        }
    }

}
