using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public Sprite[] IntroImg;
    private float rdt;
    private int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = IntroImg[0];
    }

    // Update is called once per frame
    void Update()
    {
        rdt += Time.deltaTime;

        if (rdt > 2f)
        {
            cnt++;

            gameObject.GetComponent<SpriteRenderer>().sprite = IntroImg[cnt];
            rdt = 0;

            if (cnt >= IntroImg.Length - 1)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
