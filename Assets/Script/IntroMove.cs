using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMove : MonoBehaviour
{
    public GameObject[] IntroImg;
    private float rdt;
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < IntroImg.Length; i++)
        {
            if(i%2 == 0)
            {
                Vector2 vec = new Vector2(0, -2);
                IntroImg[i].GetComponent<Transform>().position = vec; 
            } else
            {
                Vector2 vec = new Vector2(0, 2);
                IntroImg[i].GetComponent<Transform>().position = vec;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (cnt < IntroImg.Length)
        {
            if (IntroImg[cnt].activeInHierarchy == true && cnt < IntroImg.Length)
            {
                rdt += Time.deltaTime;

                if (cnt % 2 == 0)
                {
                    IntroImg[cnt].GetComponent<Rigidbody2D>().velocity = (Vector2.up * 2f);

                }
                else
                {
                    IntroImg[cnt].GetComponent<Rigidbody2D>().velocity = (Vector2.down * 2f);

                }

                if (rdt > 1f)
                {
                    IntroImg[cnt].GetComponent<Rigidbody2D>().velocity = (Vector2.zero);
                    rdt = 0;
                    cnt++;
                }


            }
        }
        
    }
}
