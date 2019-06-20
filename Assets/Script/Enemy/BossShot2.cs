using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot2 : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject[] Alien;
    public GameObject Shot;
    public float delayTime;

    private float sdt;
    private float adt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject target = player;
        sdt += Time.deltaTime;
        adt += Time.deltaTime;

        if(sdt > delayTime)
        {
            Vector2 direction = (Vector2)target.transform.position - (Vector2)Enemy.transform.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;


            GameObject obj;
            obj = (GameObject)Instantiate(Shot, transform.position, Quaternion.identity);
            obj.SetActive(true);

            if(360 * -rotateAmount > -20)
            {
                obj.transform.Rotate(new Vector3(0f, 0f, (-90)));
            } else
            {
                obj.transform.Rotate(new Vector3(0f, 0f, (360 * -rotateAmount + 20)));
            }
           
            
            obj.GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * 400f;
            obj.GetComponent<Rigidbody2D>().velocity = direction * 4;
            obj.GetComponent<AlienShotCollision>().isBoss = true;

            sdt = 0;
        }

        if(adt > 8f)
        {
            GameObject[] obj = new GameObject[2];
            for(int i =0; i < 2; i++)
            {
                if(obj[i] == null)
                {
                    obj[i] = (GameObject)Instantiate(Alien[Random.Range(0,2)], transform.position, Quaternion.identity);
                    obj[i].SetActive(true);
                }
            }

            adt = 0;
        }
    }
}
