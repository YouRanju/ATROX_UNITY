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

    void Start()
    {
        timeUI.text = 90.ToString();
        ftime = 0;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ftime += Time.deltaTime;

        timeUI.text = (90 - Mathf.CeilToInt(ftime)).ToString();

        if (90 - ftime < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void timeadd()
    {
        dt += Time.deltaTime;

        float tem = (90 - Mathf.CeilToInt(ftime)) * 0.06f;
        i += dt;

        Debug.Log(i + "i");
        Debug.Log(tem);
        if (dt > 0.06f && i < tem)
        {
            player.GetComponent<Player>().scoring += 1;
            dt = 0;
        }
    }
}
