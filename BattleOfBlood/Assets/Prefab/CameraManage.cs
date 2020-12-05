using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;



    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && mainCamera.enabled == false)
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && mainCamera.enabled == true)
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;
        }
    }

}
