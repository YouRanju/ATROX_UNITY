using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAppear : MonoBehaviour
{
    public GameObject[] Back;
    public int m_Screen;

    public float appearTime;
    static float dt = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        
        if (dt > appearTime)
        {
            for (int i = 0; i < Back.Length; i++)
            {
                if(Back[i].transform.position.x >= 20 && Back[i].transform.position.x <= 40)
                {
                    Back[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    Back[i].GetComponent<SpriteRenderer>().enabled = false;

                }
            }
            dt = 0;
        } 
    }
}
