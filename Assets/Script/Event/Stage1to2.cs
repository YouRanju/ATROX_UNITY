using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1to2 : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "SCORE: " + OnlyScore.score;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            //SceneManager.LoadScene("Stage2");
            SceneManager.LoadScene("Title");
        }
    }
}
