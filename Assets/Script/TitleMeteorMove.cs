using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMeteorMove : MonoBehaviour
{
    private float fdt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fdt += Time.deltaTime;

        if(fdt > 1f)
        {
            GetComponent<Rigidbody2D>().velocity = (Vector2.up * 0.3f);
            
        }
        if (fdt > (1.5f) )
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fdt = 0;
        }
    }
}
