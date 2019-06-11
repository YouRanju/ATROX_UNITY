using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int damage = 1;
    public GameObject Player;
    public GameObject Shot;

    public LineRenderer lineRenderer;
    private bool isTargeting;
    private Vector3 angle;
    private bool an = false;

    private float sdt;
    private float dt;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.SetColors(Color.red, Color.yellow);

        angle = Vector3.Normalize(new Vector3(3f, 3f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && sdt > 0.2)
        {
            Shot.transform.position = Player.transform.position;
            Shot.GetComponent<ShootMove>().dir = angle;
            Instantiate(Shot);

            sdt = 0;
        }

        if (Input.GetKey(KeyCode.LeftControl)) ShotInWindow();
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            lineRenderer.transform.localScale = new Vector3(0, 0, 0);
            isTargeting = false;
        }
    }

    private void ShotInWindow()
    {
        lineRenderer.transform.localScale = new Vector3(1, 1, 1);
        lineRenderer.SetPosition(0, new Vector3(-0.3f, 0, 0));
        lineRenderer.SetPosition(1, Vector3.Normalize(angle));

        isTargeting = true;
       
        if (isTargeting)
        {
            Vector2 target = lineRenderer.GetPosition(1);
            dt += Time.deltaTime;
       
            if(dt > 0.02f)
            {
                if (angle.x < 1.8f && !an)
                {
                    angle.x += Time.deltaTime * 3 ;
                    angle.y -= Time.deltaTime * 3;
                }
                else
                {
                    an = true;
                    angle.x -= Time.deltaTime * 3;
                    angle.y += Time.deltaTime * 3;

                    if (angle.x < 0f)
                    {
                        an = false;
                    }
                }

                dt = 0;
            }
            

            lineRenderer.SetPosition(1, Vector3.Normalize(angle));
        }        
    } 
}
