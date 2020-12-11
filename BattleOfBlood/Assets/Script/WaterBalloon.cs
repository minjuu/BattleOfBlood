using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : MonoBehaviour
{

    float wtimer; //타이머 시작 변수
    float etimer; // 타이머 종료 변수
    public GameObject water = null; //물줄기 오브젝트
    Vector3 water_pos; //물줄기 위치

    public Vector3 Dir;// 물풍선 이동 방향

    public Vector3 pos; //물풍선 위치 저장
    public bool stop; //물풍선 큐브 충돌 변수

    // Start is called before the first frame update
    void Start()
    {
        float wtimer = 0; // 시작 타이머 초기화
        etimer = wtimer + 2; //끝나는 시간 조절
        stop = false; //충돌 변수 초기화
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (gameObject.tag == "Bastion_balloon") //바스티온에서 나온 물풍선의 경우
        {
            if (stop == false) // 큐브와 충돌하지 않았으면
            {
                gameObject.transform.position += Dir * 0.08f; //목표지점으로 이동
            }
            else
                transform.position = pos; //저장된 위치에 고정
        }


        wtimer += Time.deltaTime;
        if (wtimer > etimer) // 일정 시간이 지나면
        {
            Destroy(gameObject, 0.0f); // 물풍선 사라짐
            GameObject Water = GameObject.Instantiate(water);
            water_pos.x = transform.position.x; // 물줄기의 x 위치 = 아이템 공의 x 위치
            water_pos.z = transform.position.z; // 물줄기의 z 위치 = 아이템 공의 z 위치
            water_pos.y = 0.35f; // 물줄기 y위치 조정
            Water.transform.position = water_pos; // Water 오브젝트의 위치 저장
            Water.transform.parent = null;  //위치 독립
        }
    }
    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "Cube") // 큐브에 물풍선이 충돌하면
        {
            pos = transform.position; //현재 위치 저장
            stop = true; //충돌 변수값 변경
        }
    }
}