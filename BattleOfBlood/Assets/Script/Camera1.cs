using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera1 : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0f;
    public float offsetY = 5f;
    public float offsetZ = -5f;
    public bool cam = true;

    Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Tab) && cam == true)
        //    cam = false;
        //if (Input.GetKeyDown(KeyCode.Tab) && cam == false)
        //    cam = true;

  
            cameraPosition.x = player.transform.position.x + offsetX;
            cameraPosition.y = player.transform.position.y + offsetY;
            cameraPosition.z = player.transform.position.z + offsetZ;

            transform.position = cameraPosition;
        
    }
}
