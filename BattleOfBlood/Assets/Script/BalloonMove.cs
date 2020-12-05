using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    public static bool Sonnykick = false;
    public Vector3 Dir;
    public Rigidbody rb;
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Sonnyballoon")
        {
            //if (Sonnykick == true)
            //transform.position += SonnyMove.GoalPos * SonnyMove.SonnySpeed* Time.deltaTime;
             transform.position = Vector3.MoveTowards(transform.position, SonnyMove.GoalPos, 0.5f);
            //transform.position = new Vector3(0, 0, 0);
            //rb.MovePosition(transform.position + (SonnyMove.GoalPos * SonnyMove.SonnySpeed * Time.deltaTime));
            //gameObject.transform.position += Dir * 0.05f;
            // gameObject.transform.position +=  SonnyMove.GoalPos * 0.5f;
            //Vector3 p = new Vector3(1, 0, 0);
            //transform.position = p*5f * Time.deltaTime;
            //if (transform.position == SonnyMove.GoalPos)
            //  Sonnykick = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name=="Sonny")
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }


}

