using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1to2 : MonoBehaviour
{
    public Text text;
    public Text press;
    public GameObject tank;
    float dt;
    float rdt;
    bool right;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "SCORE: " + OnlyScore.score;
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
      
        rdt += Time.deltaTime;

        tank.transform.Rotate(new Vector3(0, 0, rdt * 2));

        if (Input.anyKey && dt > 3f)
        {
            SceneManager.LoadScene("Title");
            dt = 0;
        }

        rdt = 0;
    }
    public IEnumerator BlinkText()
    {
        while (true)
        {
            press.text = "";
            yield return new WaitForSeconds(0.6f);
            press.text = "PRESS ANY KEY";
            yield return new WaitForSeconds(0.6f);
        }
    }
}
