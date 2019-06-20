using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RakingReport : MonoBehaviour
{
    string m_strPath = "./";
    public InputField Playername;
    public Text Score;

    void Start()
    {
        Score.text = "SCORE: " + OnlyScore.score;
    }

    public void WriteData()
    {
        FileStream f = new FileStream(m_strPath + "RankingSave.txt", FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.WriteLine(Playername.text + "," + OnlyScore.score);
        writer.Close();

        Destroy(GameObject.Find("OnlyScore"));
        SceneManager.LoadScene("Title");
    }
}
