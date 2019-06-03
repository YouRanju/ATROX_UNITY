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
        
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;
        time += Time.deltaTime;

        if (fades < 1.0f && time >= 0.1f)
        {
            fades += time;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if (fades >= 1.0f)
        {
            SceneManager.LoadScene("Main");
        }

        if (rdt > 2f&& cnt < IntroImg.Length)
        {
            IntroImg[cnt].SetActive(true);
            cnt++;

            rdt = 0;
        }
    }
}
