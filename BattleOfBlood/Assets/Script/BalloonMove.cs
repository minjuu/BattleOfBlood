using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    public static bool Sonnykick=false;
    public Vector3 Dir;
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "Sonnyballoon")
        {
            SonnyMove.GoalPos.y = 0.3f;
            if (Sonnykick == true)
                transform.position = Vector3.MoveTowards(transform.position, SonnyMove.GoalPos, SonnyMove.SonnySpeed);
            if (transform.position == SonnyMove.GoalPos)
                Sonnykick = false;
        }
    }

    

}

