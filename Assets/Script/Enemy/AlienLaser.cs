using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLaser : MonoBehaviour
{
    public int damage = 1;
    public GameObject player;
    public GameObject Alien;

    public LineRenderer lineRenderer;
    private Vector3 angle;

    private float sdt;
    private float ldt;

    void Start()
    {
        lineRenderer.SetWidth(0, 0);
        lineRenderer.SetColors(Color.grey, Color.red);

        angle = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;
        
        if (sdt > 7) {
            ldt += Time.deltaTime;
            lineRenderer.SetWidth(ldt, ldt * 1.2f);
            lineRenderer.SetColors(Color.yellow, Color.white);
            lineRenderer.SetPosition(0, new Vector3(4.3f, 0.1f,0));
            lineRenderer.SetPosition(1, angle);

            lineRenderer.useWorldSpace = false;

            if(sdt >= 10)
            {
                ldt -= Time.deltaTime * 3f;
                lineRenderer.SetWidth(ldt, ldt);

                if (ldt <= 0 ) {
                    sdt = 0;
                    lineRenderer.SetWidth(0, 0);
                }

            }
        }
        else if (sdt > 3)
        {
            lineRenderer.SetWidth(0.2f, 0.2f);
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetColors(Color.grey, Color.red);
            ShotInWindow();
        }

    }

    private void ShotInWindow()
    {
        lineRenderer.transform.localScale = new Vector3(1, 1, 1);
        lineRenderer.SetPosition(0, Alien.transform.position - new Vector3(0,2,0));
        lineRenderer.SetPosition(1, player.transform.position);

        angle = player.transform.position + new Vector3(3,1,0);
    }
}
