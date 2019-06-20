using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLaserMin : MonoBehaviour
{
    public int damage = 1;
    public GameObject player;
    GameObject Alien;

    public BoxCollider2D coli;
    public LineRenderer lineRenderer;
    private Vector3 angle;

    private float sdt;
    private float ldt;

    int rand;

    void Start()
    {
        lineRenderer.startWidth = 0;
        lineRenderer.endWidth = 0;

        angle = player.transform.position;
        Alien = this.gameObject;

        rand = Random.Range(0, 8);
    }

    void Update()
    {
        if(rand == 3)
        {
            sdt += Time.deltaTime;

            if (sdt > 6)
            {
                ldt += Time.deltaTime * 0.3f;
                lineRenderer.startWidth = ldt;
                lineRenderer.endWidth = ldt;
                lineRenderer.startColor = Color.yellow;
                lineRenderer.endColor = Color.white;
                lineRenderer.SetPosition(0, Alien.transform.position - new Vector3(0, 0.5f, 0));
                lineRenderer.SetPosition(1, angle);

                Vector3 startPoint = Alien.transform.position - new Vector3(0, 0.5f, 0);
                Vector3 endPoint = angle;

                if (sdt > 7f)
                {
                    coli.enabled = true;
                    float lineWidth = ldt * 0.15f;
                    float lineLength = Vector3.Distance(startPoint, endPoint);
                    coli.size = new Vector3(lineLength, lineWidth, 1f);

                    Vector3 midPoint = ((startPoint + endPoint)) / 2;
                    coli.transform.position = midPoint;

                    float angless = Mathf.Atan2((endPoint.y - startPoint.y), (endPoint.x - startPoint.x));
                    angless *= Mathf.Rad2Deg;
                    coli.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angless));
                }

                if (sdt >= 8.5f)
                {
                    ldt -= Time.deltaTime * 3f;
                    lineRenderer.startWidth = ldt;
                    lineRenderer.endWidth = ldt;

                    if (ldt <= 0)
                    {
                        sdt = 0;
                        lineRenderer.startWidth = 0;
                        lineRenderer.endWidth = 0;
                        coli.size = new Vector3(0, 0, 0);
                        coli.enabled = false;
                    }

                }
            }
            else if (sdt > 2)
            {
                lineRenderer.startWidth = 0.08f;
                lineRenderer.endWidth = 0.08f;
                lineRenderer.useWorldSpace = true;
                lineRenderer.startColor = Color.gray;
                lineRenderer.endColor = Color.white;
                ShotInWindow();
            }
        }
    }

    private void ShotInWindow()
    {
        lineRenderer.transform.localScale = new Vector3(1, 1, 1);
        lineRenderer.SetPosition(0, Alien.transform.position - new Vector3(0, 0.5f, 0));
        lineRenderer.SetPosition(1, player.transform.position);

        angle = player.transform.position;
    }
}
