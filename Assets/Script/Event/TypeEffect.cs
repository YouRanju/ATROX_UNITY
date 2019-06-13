using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeEffect : MonoBehaviour
{
    public float delay;
    public int cnt;

    public string[] fulltext;
    public int dialog_cnt;
    string currentText;

    public bool text_exit;

    void Start()
    {
        this.GetComponent<Text>().text = "";
    }

    public void Get_Typing()
    {
        text_exit = false;
        cnt = 0;

        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        if (cnt >= dialog_cnt)
        {
            text_exit = true;
            StopCoroutine("showText");
        }
        else
        {
            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                currentText = _fullText[cnt].Substring(0, i + 1);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
