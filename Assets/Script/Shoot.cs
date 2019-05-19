using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int damage = 1;
    public GameObject Player;
    public GameObject Shot;

    private float sdt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sdt += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && sdt > 0.3)
        {
            Shot.transform.position = Player.transform.position;
            Instantiate(Shot);

            sdt = 0;
        }
    }
}
