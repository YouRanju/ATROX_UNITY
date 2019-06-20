using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introtoTitle : MonoBehaviour
{
    public void isClick()
    {
        SceneManager.LoadScene("Title");
    }
}
