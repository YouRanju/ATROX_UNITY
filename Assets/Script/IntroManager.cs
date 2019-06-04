using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public GameObject[] IntroImg;
    public Image fade;
    private float rdt;
    private int cnt = 0;

    float fades = 0.0f;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        fade.color = new Color(0, 0, 0, 0);
        IntroImg[cnt].SetActive(true);
        cnt++;
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;

        if (cnt > IntroImg.Length - 1 && rdt >2f)
        {
            time += Time.deltaTime;
            if (fades < 1.0f && time >= 0.1f)
            {
                fades += time;
                fade.color = new Color(0, 0, 0, fades);
                time = 0;
            }
            else if (fades >= 1.0f)
            {
                SceneManager.LoadScene("Title");
            }
        } else
        {
            if (cnt == 4 && rdt > 2f)
            {
                time += Time.deltaTime;
                if (fades < 1.0f && time >= 0.1f)
                {
                    fades += time;
                    fade.color = new Color(0, 0, 0, fades);
                    time = 0;
                } else if (fades > 1.0f)
                {
                    fade.color = new Color(255, 255, 255, 0);
                    for(int i = 0; i < 4; i++)
                    {
                        IntroImg[i].SetActive(false);
                    }
                    IntroImg[cnt++].SetActive(true);
                    rdt = 0;
                    fades = 0;
                    time = 0;
                }
               
            }
            else if(rdt > 2f && cnt < IntroImg.Length)
            {
                IntroImg[cnt].SetActive(true);
                cnt++;

                rdt = 0;
            }
        }        
    }
}
