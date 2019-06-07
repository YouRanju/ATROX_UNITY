using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStar : MonoBehaviour
{
    private float dt = 0.3f;
    private bool faded = false;

    void Update()
    {
        if(!faded)
        {
            dt += Time.deltaTime * 0.2f;

            if (dt > 0.9)
            {
                dt = 1;
                faded = true;
            }
        }

        if (faded)
        {
            dt -= Time.deltaTime * 0.2f;
            if (dt <= 0.3)
            {
                faded = false;
            }
        }

        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, dt);
    }
}
