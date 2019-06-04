using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartBtn : MonoBehaviour
{
    public Image fade;
    private float fades;
    private float time;

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

}
