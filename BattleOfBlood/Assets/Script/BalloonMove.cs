using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    public static bool Sonnykick = false; // sonny와 물풍선 충돌 감지 변수
    public Vector3 Dir; // 공의 방향
    public Rigidbody rb; //공의 리지드바디
    public bool stop; // 공과 큐브 충돌 감지
    public Vector3 pos; // 공의 위치
    void Start()
    {
        stop = false; // 공과 충돌 초기화
        Destroy(gameObject, 5.0f); //5초후 사라짐
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "SonnyBalloon") // Sonny가 만든 물풍선일 경우
        {

            if (stop == false) // 물풍선이 큐브와 충돌하지 않았을때
            {
                gameObject.transform.position += SonnyMove.GoalPos * 0.05f; // Sonny에서 얻은 목표지점으로 이동
                pos = gameObject.transform.position; // 물풍선 좌표 저장
                pos.y = 0.8f; // 물풍선 y 조정
                gameObject.transform.position = pos; //물풍선 위치 변경
            }
            else
            {
                transform.position = pos; // 큐브와 충돌하면 멈춤
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Sonny") // Player와 Sonny 충돌
        {
            rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true; //Kinematic 속성 변경
        }
    }
    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "Cube") // 큐브와 충돌시
        {
            pos = transform.position; // 현재 위치 저장
            stop = true; // 충돌 변수값 변경
        }
    }



}