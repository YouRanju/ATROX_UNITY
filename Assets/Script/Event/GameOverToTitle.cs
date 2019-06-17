using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverToTitle : MonoBehaviour
{
    public Camera camera;
    public Text press;
    float dt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;

        camera.transform.localPosition = (Vector3)Random.insideUnitCircle * 0.02f + new Vector3(0, 0, -10);

        if (Input.anyKey && dt > 3f)
        {
            SceneManager.LoadScene("Title");
            dt = 0;
        }
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
