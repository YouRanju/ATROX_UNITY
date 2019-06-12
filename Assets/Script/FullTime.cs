using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullTime : MonoBehaviour
{
    public Text timeUI;
    float ftime;

    void Start()
    {
        timeUI.text = 150.ToString();
        ftime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ftime += Time.deltaTime;

        timeUI.text = (150 - Mathf.CeilToInt(ftime)).ToString();
    }
}
