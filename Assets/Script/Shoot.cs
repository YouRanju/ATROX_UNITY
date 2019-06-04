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
    private float startAngle;
    private float guageBar;
    private float cannonGuage;
    private Vector3 angle;
    private bool an = false;

    private float sdt;

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

        if (Input.GetKey(KeyCode.Space) && sdt > 0.3)
        {
            Shot.transform.position = Player.transform.position;
            Shot.GetComponent<ShootMove>().dir = angle;
            Instantiate(Shot);

            sdt = 0;
        }

        if (Input.GetKey(KeyCode.LeftControl)) ChangeRotation();
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            lineRenderer.transform.localScale = new Vector3(0, 0, 0);
            isTargeting = false;

            //Fire();
        }
    }

    void ChangeRotation()
    {
        ShotInWindow();
    }

    public void ShotToTarget(Vector2 direction)
    {
        Shot.GetComponent<Rigidbody2D>().velocity = direction;
    }

    private void ShotInWindow()
    {
        lineRenderer.transform.localScale = new Vector3(1, 1, 1);
        lineRenderer.SetPosition(0, new Vector3(-0.3f, 0, 0));
        lineRenderer.SetPosition(1, Vector3.Normalize(angle));

        isTargeting = true;
        startAngle = transform.eulerAngles.z;
       
        if (isTargeting)
        {
            Vector2 target = lineRenderer.GetPosition(1);
       
            if (angle.x < 1.5f && !an)
            {
                angle.x += Time.deltaTime * 2;
                angle.y -= Time.deltaTime *2;
            }
            else
            { 
                an = true;
                angle.x -= Time.deltaTime * 2;
                angle.y += Time.deltaTime * 2;

                if(angle.x < 0f)
                {
                    an = false;
                }
            }

            Vector3.Normalize(angle);

            lineRenderer.SetPosition(1, angle);
            
                //lineRenderer.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, transform.forward);

            float power = Vector2.Distance(target, transform.position);

            if (Mathf.Abs(power) > cannonGuage)
                power = cannonGuage;

            guageBar = power / cannonGuage;
        }        
    } 
    
    private float DifferenceBetweenAngles(float angle1, float angle2)
    {
        float angle = angle1 - angle2;
        return Mathf.Atan2(Mathf.Sin(angle), Mathf.Cos(angle));
    }
    /*
    public void Fire()
    {
        Vector2 direction = directionArrow.transform.rotation * new Vector2(cannonSpeed, 0.0f) * guageBa * guageFactor;
        GameObject toInstance = Resources.Load<GameObject>("Prefabs/Cannon1");
        GameObject cannon = Instantiate(toInstance, transform.position, transform.rotation);

        cannon.GetComponent<PlayerCannon>().ShotToTarget(direction);

    }

    public class PlayerCannon : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        private Vector3 prevPosition;
        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 deltaPos = transform.position - prevPosition;
            float angle = Mathf.Atan2(deltaPos.y, deltaPos.x) * Mathf.Rad2Deg;

            if (0 != angle)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), 10.0f * Time.deltaTime);
                prevPosition = transform.position;
            }
        }

        

    } */
}
