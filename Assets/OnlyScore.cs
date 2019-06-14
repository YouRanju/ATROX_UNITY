using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyScore : MonoBehaviour
{
    public static int score;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
