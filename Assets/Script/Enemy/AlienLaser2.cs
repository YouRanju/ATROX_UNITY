using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLaser2 : MonoBehaviour
{
    public int damage = 1;
    public GameObject player;
    public GameObject Alien;
    public Camera camera;

    public BoxCollider2D coli;
    public LineRenderer lineRenderer;
    public float y;
    public float delay;

    private float sdt;
    private float ldt;

    void Start()
    {
        lineRenderer.SetWidth(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;
        
        if (sdt > delay) {
            ldt += Time.deltaTime * 0.6f;
            lineRenderer.SetWidth(ldt, ldt);
            lineRenderer.SetColors(Color.white, Color.blue);

            Vector3 startPoint = new Vector3(10.7f, y, 0);
            Vector3 endPoint = new Vector3(-10f, y, 0);

            if(sdt > delay+0.4f)
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

            if (sdt >= delay+1)
            {
                ldt -= Time.deltaTime * 3f;
                lineRenderer.SetPosition(0, new Vector3(10.7f+ldt, y, 0));

                if (ldt <= 0) {
                    sdt = 0;
                    lineRenderer.SetWidth(0, 0);
                    coli.size = new Vector3(0, 0, 0);
                    camera.transform.localPosition = new Vector3(0, 0, -10);
                }

            }
        }
        else if (sdt > delay-3)
        {
            lineRenderer.SetWidth(0.08f, 0.08f);
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetColors(Color.cyan, Color.red);
            ShotInWindow();
        }

    }

    private void ShotInWindow()
    {
        lineRenderer.transform.localScale = new Vector3(1, 1, 1);
        lineRenderer.SetPosition(0, new Vector3(10.7f, y, 0));
        lineRenderer.SetPosition(1, new Vector3(-10f, y, 0));
    }
}
