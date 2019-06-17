using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FullTime : MonoBehaviour
{
    public Text timeUI;
    public GameObject player;
    float ftime;

    float dt;
    float i;
    float tem;

    public bool checking = true;

    void Start()
    {
        timeUI.text = 100.ToString();
        ftime = 0;
        i = 0;
        checking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(checking)
        {
            ftime += Time.deltaTime;

            timeUI.text = (100 - Mathf.CeilToInt(ftime)).ToString();

            if (100 - ftime < 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            tem = (100 - Mathf.CeilToInt(ftime)) * 0.06f;
            timeadd();
        }
       
    }

    public void timeadd()
    {
        dt += Time.deltaTime;
        i += dt;

        if (dt > 0.06f && i < tem)
        {
            player.GetComponent<Player>().scoring += 120;
            dt = 0;
        }
    }
}
