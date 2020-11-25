using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float wtimer;
    float etimer;
 
    // Start is called before the first frame update
    void Start()
    {
        float wtimer = Time.time;
        etimer = wtimer + 0.5f;
      
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        wtimer += Time.deltaTime;
        if (wtimer > etimer)
        {
            Destroy(gameObject, 0.0f);
      
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(col.gameObject, 0.0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(col.gameObject, 0.0f);
        }
    }
}
