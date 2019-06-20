using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLaser : MonoBehaviour
{
    public int damage = 1;
    public GameObject player;
    public GameObject Alien;
    public Camera cam;

    public BoxCollider2D coli;
    public LineRenderer lineRenderer;
    private Vector3 angle;

    private float sdt;
    private float ldt;

    void Start()
    {
        lineRenderer.startWidth = 0;
        lineRenderer.endWidth = 0;

        angle = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;
        
        if (sdt > 8) {
            ldt += Time.deltaTime * 0.6f;
            lineRenderer.startWidth = ldt;
            lineRenderer.endWidth = ldt;
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.white;
            lineRenderer.SetPosition(0, Alien.transform.position - new Vector3(0, 2, 0));

            lineRenderer.SetPosition(1, angle);

            Vector3 startPoint = Alien.transform.position - new Vector3(0, 2, 0);
            Vector3 endPoint = angle;

            if(sdt > 9f)
            {
                float lineWidth = ldt * 0.25f;
                float lineLength = Vector3.Distance(startPoint, endPoint);
                coli.size = new Vector3(lineLength, lineWidth, 1f);

                Vector3 midPoint = ((startPoint + endPoint)) / 2;
                coli.transform.position = midPoint;

                float angless = Mathf.Atan2((endPoint.y - startPoint.y), (endPoint.x - startPoint.x));
                angless *= Mathf.Rad2Deg;
                coli.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angless));

                cam.transform.localPosition = (Vector3)Random.insideUnitCircle * 0.1f + new Vector3(0, 0, -10);
            }

            if (sdt >= 11)
            {
                ldt -= Time.deltaTime * 3f;
                lineRenderer.startWidth = ldt;
                lineRenderer.endWidth = ldt;

                if (ldt <= 0 ) {
                    sdt = 0;
                    lineRenderer.startWidth = 0;
                    lineRenderer.endWidth = 0;
                    coli.size = new Vector3(0, 0, 0);
                    cam.transform.localPosition = new Vector3(0, 0, -10);
                }

            }
        }
        else if (sdt > 5)
        {
            lineRenderer.startWidth = 0.08f;
            lineRenderer.endWidth = 0.08f;
            lineRenderer.useWorldSpace = true;
            lineRenderer.startColor = Color.gray;
            lineRenderer.endColor = Color.white;
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
