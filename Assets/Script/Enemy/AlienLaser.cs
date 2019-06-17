using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLaser : MonoBehaviour
{
    public int damage = 1;
    public GameObject player;
    public GameObject Alien;
    public Camera camera;

    public BoxCollider2D coli;
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
        
        if (sdt > 15) {
            ldt += Time.deltaTime * 0.6f;
            lineRenderer.SetWidth(ldt, ldt);
            lineRenderer.SetColors(Color.yellow, Color.white);
            lineRenderer.SetPosition(0, Alien.transform.position - new Vector3(0, 2, 0));

            lineRenderer.SetPosition(1, angle);

            Vector3 startPoint = Alien.transform.position - new Vector3(0, 2, 0);
            Vector3 endPoint = angle;

            if(sdt > 16.4f)
            {
                float lineWidth = ldt * 0.25f;
                float lineLength = Vector3.Distance(startPoint, endPoint);
                coli.size = new Vector3(lineLength, lineWidth, 1f);

                Vector3 midPoint = ((startPoint + endPoint)) / 2;
                coli.transform.position = midPoint;

                float angless = Mathf.Atan2((endPoint.y - startPoint.y), (endPoint.x - startPoint.x));
                angless *= Mathf.Rad2Deg;
                coli.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angless));

                camera.transform.localPosition = (Vector3)Random.insideUnitCircle * 0.1f + new Vector3(0, 0, -10);
            }

            if (sdt >= 18)
            {
                ldt -= Time.deltaTime * 3f;
                lineRenderer.SetWidth(ldt, ldt);

                if (ldt <= 0 ) {
                    sdt = 0;
                    lineRenderer.SetWidth(0, 0);
                    coli.size = new Vector3(0, 0, 0);
                    camera.transform.localPosition = new Vector3(0, 0, -10);
                }

            }
        }
        else if (sdt > 7)
        {
            lineRenderer.SetWidth(0.08f, 0.08f);
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetColors(Color.grey, Color.white);
            ShotInWindow();
        }

    }

    private void ShotInWindow()
    {
        lineRenderer.transform.localScale = new Vector3(1, 1, 1);
        lineRenderer.SetPosition(0, Alien.transform.position - new Vector3(0,2,0));
        lineRenderer.SetPosition(1, player.transform.position * Mathf.Abs(player.transform.position.x)/1.6f);

        angle = player.transform.position * Mathf.Abs(player.transform.position.x)/1.6f;
    }
}
