using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    bool bulletbullet; //총알끼리 충돌
    int chk = 0; //반복 방지
    public Vector3 Dir;
    void Start()
    {
        bulletbullet = false;  //총알 충돌 변수 false로 초기화
        chk = 0; //반복방지
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Dir * 0.2f;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(gameObject, 0.0f);
            Destroy(col.gameObject, 0.05f);
            Debug.Log("Cube총알 충돌 및 destroy");
        }
    }
}