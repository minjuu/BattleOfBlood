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
        cameraPosition.x = player.transform.position.x + offsetX; //캐릭터 3인칭 시점 카메라의 x좌표 설정
        cameraPosition.y = player.transform.position.y + offsetY; //캐릭터 3인칭 시점 카메라의 y좌표 설정
        cameraPosition.z = player.transform.position.z + offsetZ; //캐릭터 3인칭 시점 카메라의 z좌표 설정

        transform.position = cameraPosition;       
    }
}
