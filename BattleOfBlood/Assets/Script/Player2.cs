using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject WaterBalloon; //WaterBalloon 오브젝트
    public Rigidbody rb;
    public Rigidbody b_rb;

    // Start is called before the first frame update
    void Start()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2") //현재 스테이지가 스테이지2 일때
        {
            Player.PlayerHp = 100; //각 캐릭터 Hp초기 지정
            Shooter_Move.ShooterHp = 100; //각 캐릭터 Hp초기 지정
            HealerMove.HealerHp = 100; //각 캐릭터 Hp초기 지정
            BoosterMove.BoosterHp = 100; //각 캐릭터 Hp초기 지정
            BastionMove.BastionHp = 100; //각 캐릭터 Hp초기 지정
            SonnyMove.SonnyHp = 100; //각 캐릭터 Hp초기 지정

            for (int i = 0; i < 3; i++)
            {
                Player.Team_Hp[i] = 100; //팀 Hp 초기 지정
                Player.Enemy_Hp[i] = 100; //적 Hp 초기 지정
            }

            GameObject.Find("Char").transform.Find("Booster").gameObject.SetActive(true); //비활성화 된 각 ai들을 다시 활성화 시킴
            GameObject.Find("Char").transform.Find("Sonny").gameObject.SetActive(true); //비활성화 된 각 ai들을 다시 활성화 시킴
            GameObject.Find("Char").transform.Find("Bastion").gameObject.SetActive(true); //비활성화 된 각 ai들을 다시 활성화 시킴
            GameObject.Find("Char").transform.Find("Shooter").gameObject.SetActive(true); //비활성화 된 각 ai들을 다시 활성화 시킴
            GameObject.Find("Char").transform.Find("Healer").gameObject.SetActive(true); //비활성화 된 각 ai들을 다시 활성화 시킴

            Player.ba = true;
            Player.bo = true;
            Player.sn = true;
            Player.sh = true;
            Player.hl = true;

        }
        rb = GetComponent<Rigidbody>();

        Player.PlayerPos = gameObject.transform.position;

        if (SelectMng.booster1 == "Team") //스테이지2에서 booster을 팀으로 선택했을 때
            GameObject.Find("Booster").tag = "Team"; //Booster태그 Team저장
        else if (SelectMng.booster1 == "Enemy") //스테이지2 캐릭터 선택에서 적으로 된 경우
            GameObject.Find("Booster").tag = "Enemy"; //태그를 Enemy로 저장

        if (SelectMng.bastion1 == "Team") //스테이지2 캐릭터 선택에서 우리 팀으로 된 경우
            GameObject.Find("Bastion").tag = "Team"; //태그 Team으로 저장
        else if (SelectMng.bastion1 == "Enemy") //스테이지2 캐릭터 선택에서 적으로 된 경우
            GameObject.Find("Bastion").tag = "Enemy"; //태그를 Enemy로 저장

        if (SelectMng.healer1 == "Team") //스테이지2 캐릭터 선택에서 우리 팀으로 된 경우
            GameObject.Find("Healer").tag = "Team"; //태그 Team으로 저장
        else if (SelectMng.healer1 == "Enemy") //스테이지2 캐릭터 선택에서 적으로 된 경우
            GameObject.Find("Healer").tag = "Enemy"; //태그를 Enemy로 저장

        if (SelectMng.sonny1 == "Team") //스테이지2 캐릭터 선택에서 우리 팀으로 된 경우
            GameObject.Find("Sonny").tag = "Team"; //태그 Team으로 저장
        else if (SelectMng.sonny1 == "Enemy") //스테이지2 캐릭터 선택에서 적으로 된 경우
            GameObject.Find("Sonny").tag = "Enemy"; //태그를 Enemy로 저장

        if (SelectMng.shooter1 == "Team") //스테이지2 캐릭터 선택에서 우리 팀으로 된 경우
            GameObject.Find("Shooter").tag = "Team"; //태그 Team으로 저장
        else if (SelectMng.shooter1 == "Enemy") //스테이지2 캐릭터 선택에서 적으로 된 경우
            GameObject.Find("Shooter").tag = "Enemy"; //태그를 Enemy로 저장




    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z < -15) //절벽 범위 조건문
        {
            Vector3 swap1 = transform.position; //벡터 저장
            swap1.z = -15;                                  //고정 위치 설정
            transform.position = swap1;
        }

        if (transform.position.z > 15)//절벽 범위 조건문
        {
            Vector3 swap2 = transform.position;//벡터 저장
            swap2.z = 15;//고정 위치 설정
            transform.position = swap2;
        }

        if (transform.position.x < -20)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -20;//고정 위치 설정
            transform.position = swap3;
        }
        if (transform.position.x > 20)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 20;//고정 위치 설정
            transform.position = swap4;
        }
        // 수평축과 수직축의 입력값을 지정하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * Player.PlayerSpeed;
        float zSpeed = zInput * Player.PlayerSpeed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); //(0, 0, 0)으로 회전
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //(0, 180, 0)으로 회전
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(0, -90, 0); //(0, -90, 0)으로 회전
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); //(0, 90, 0)으로 회전
        }
        // 스테이지 2에서 방향키를 이용하여 이동함


        if (Input.GetKeyDown(KeyCode.Space)) //스페이스 바를 누르면
        {
            GameObject balloon = GameObject.Instantiate(WaterBalloon)
               as GameObject; //WaterBalloon을 생성
            b_rb = balloon.GetComponent<Rigidbody>();
            b_rb.isKinematic = false;
            Vector3 v = transform.position;
            v.x = Mathf.Round(v.x); //물풍선 놓는 곳을 정수에 놔두도록 함
            v.y = 0.8f; //물풍선 생성의 y좌표
            v.z = Mathf.Round(v.z); //물풍선 놓는 곳을 정수에 놔두도록 함
            balloon.transform.position = v;
        }



    }
    void OnCollisionEnter(Collision collision) //충돌 감지
    {
        if (collision.collider.CompareTag("Cube"))
        {
            //Debug.Log("충돌");
        }
    }


}