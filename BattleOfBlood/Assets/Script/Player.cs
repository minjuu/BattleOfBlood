using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int PlayerHp = 100; //플레이어의 체력
    public static Vector3 PlayerPos; //플레이어 위치
    public static Vector3 PlayerColPos;
    bool col = false;
    public GameObject WaterBalloon; //물풍선 오브젝트
    public static float PlayerSpeed = 3f; //플레이어 스피드
    public Rigidbody rb; //플레이어 리지드바디
    public static GameObject[] characters; //캐릭터 변수들

    public static int[] Team_Hp = new int[3]; //같은 팀 체력 배열
    public static int[] Enemy_Hp = new int[3]; //적 팀 체력 배열

    public static bool pl; //플레이어 활성변수
    public static bool ba; //바스티온 활성변수
    public static bool sn; //쏘니 활성변수
    public static bool hl; //힐러 활성변수
    public static bool bo; //부스터 활성변수
    public static bool sh; //슈터 활성변수
    public static int n = 0;

    public GameObject char1; //캐릭터 저장 변수들
    public GameObject char2;
    public GameObject char3;
    public GameObject char4;
    public GameObject char5;
    public GameObject char6;

    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject Char4;
    public GameObject Char5;
    public GameObject Char6;

    public Rigidbody b_rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPos = gameObject.transform.position;

        if(SelectMng.booster1 == "Team") //SelectMng 스크립트에서 나눈 태그에 따라 오브젝트의 태그를 달아줌
            GameObject.Find("Booster").tag = "Team";
        else if(SelectMng.booster1 == "Enemy")
            GameObject.Find("Booster").tag = "Enemy";

        if (SelectMng.bastion1 == "Team") //SelectMng 스크립트에서 나눈 태그에 따라 오브젝트의 태그를 달아줌
            GameObject.Find("Bastion").tag = "Team";
        else if (SelectMng.bastion1 == "Enemy")
            GameObject.Find("Bastion").tag = "Enemy";

        if (SelectMng.healer1 == "Team") //SelectMng 스크립트에서 나눈 태그에 따라 오브젝트의 태그를 달아줌
            GameObject.Find("Healer").tag = "Team";
        else if (SelectMng.healer1 == "Enemy")
            GameObject.Find("Healer").tag = "Enemy";

        if (SelectMng.sonny1 == "Team") //SelectMng 스크립트에서 나눈 태그에 따라 오브젝트의 태그를 달아줌
            GameObject.Find("Sonny").tag = "Team";
        else if (SelectMng.sonny1 == "Enemy")
            GameObject.Find("Sonny").tag = "Enemy";

        if (SelectMng.shooter1 == "Team") //SelectMng 스크립트에서 나눈 태그에 따라 오브젝트의 태그를 달아줌
            GameObject.Find("Shooter").tag = "Team";
        else if (SelectMng.shooter1 == "Enemy")
            GameObject.Find("Shooter").tag = "Enemy";


        if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //플레이어의 태그가 팀이면 오브젝트 변수를 팀 캐릭터 변수에 넣어줌
            char1 = GameObject.Find("Player");
        if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //쏘니의 태그가 팀이면 오브젝트 변수를 팀 캐릭터 변수에 넣어줌
            char2 = GameObject.Find("Sonny");
        if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //바스티온의 태그가 팀이면 오브젝트 변수를 팀 캐릭터 변수에 넣어줌
            char3 = GameObject.Find("Bastion");
        if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //슈터의 태그가 팀이면 오브젝트 변수를 팀 캐릭터 변수에 넣어줌
            char4 = GameObject.Find("Shooter");
        if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team") //힐러의 태그가 팀이면 오브젝트 변수를 팀 캐릭터 변수에 넣어줌
            char5 = GameObject.Find("Healer");
        if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team") //부스터의 태그가 팀이면 오브젝트 변수를 팀 캐릭터 변수에 넣어줌
            char6 = GameObject.Find("Booster");

        if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //플레이어의 태그가 적이면 오브젝트 변수를 적 캐릭터 변수에 넣어줌
            Char1 = GameObject.Find("Player");
        if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //쏘니의 태그가 적이면 오브젝트 변수를 적 캐릭터 변수에 넣어줌
            Char2 = GameObject.Find("Sonny");
        if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //바스티온의 태그가 적이면 오브젝트 변수를 적 캐릭터 변수에 넣어줌
            Char3 = GameObject.Find("Bastion");
        if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //슈터의 태그가 적이면 오브젝트 변수를 적 캐릭터 변수에 넣어줌
            Char4 = GameObject.Find("Shooter");
        if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy") //힐러의 태그가 적이면 오브젝트 변수를 적 캐릭터 변수에 넣어줌
            Char5 = GameObject.Find("Healer");
        if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy") //부스터의 태그가 적이면 오브젝트 변수를 적 캐릭터 변수에 넣어줌
            Char6 = GameObject.Find("Booster");


        for (int i = 0; i < 2; i++) //팀 체력, 적 체력 배열 초기화
        {
            Team_Hp[i] = 100;
            Enemy_Hp[i] = 100;
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene") //스테이지 1이면
        {
            pl = false; //모든 캐릭터 활성변수 초기화
            ba = false;
            sn = false;
            hl = false;
            bo = false;
            sh = false;

            if (char1 != null && char1.tag == "Team") //캐릭터마다 태그가 팀인지 검사하여 활성화시킴
                pl = true;
            if (char2 != null && char2.tag == "Team")
                sn = true;
            if (char3 != null && char3.tag == "Team")
                ba = true;
            if (char4 != null && char4.tag == "Team")
                sh = true;
            if (char5 != null && char5.tag == "Team")
                hl = true;
            if (char6 != null && char6.tag == "Team")
                bo = true;

            if (Char1 != null && Char1.tag == "Enemy") //캐릭터마다 태그가 적인지 검사하여 활성화시킴
                pl = true;
            if (Char2 != null && Char2.tag == "Enemy")
                sn = true;
            if (Char3 != null && Char3.tag == "Enemy")
                ba = true;
            if (Char4 != null && Char4.tag == "Enemy")
                sh = true;
            if (Char5 != null && Char5.tag == "Enemy")
                hl = true;
            if (Char6 != null && Char6.tag == "Enemy")
                bo = true;

            Player.PlayerHp = 100; //모든 캐릭터의 체력을 초기화
            Shooter_Move.ShooterHp = 100;
            HealerMove.HealerHp = 100;
            BoosterMove.BoosterHp = 100;
            BastionMove.BastionHp = 100;
            SonnyMove.SonnyHp = 100;
        }
        

        if (ba == false) //bool변수가 비활성화된 캐릭터를 비활성화함
            GameObject.Find("Bastion").active = false;
        if (bo == false) //bool변수가 비활성화된 캐릭터를 비활성화함
            GameObject.Find("Booster").active = false;
        if (sh == false) //bool변수가 비활성화된 캐릭터를 비활성화함
            GameObject.Find("Shooter").active = false;
        if (hl == false) //bool변수가 비활성화된 캐릭터를 비활성화함
            GameObject.Find("Healer").active = false;
        if (sn == false) //bool변수가 비활성화된 캐릭터를 비활성화함
            GameObject.Find("Sonny").active = false;
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
        float xSpeed = xInput * PlayerSpeed;
        float zSpeed = zInput * PlayerSpeed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;

        if (Input.GetKey(KeyCode.UpArrow)) //위 방향키를 누르면 위로 이동
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //아래 방향키를 누르면 아래로 이동
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽 방향키를 누르면 왼쪽으로 이동
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) //오른쪽 방향키를 누르면 오른쪽으로 이동
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 누르면
        {
            GameObject balloon = GameObject.Instantiate(WaterBalloon) //물풍선 생성해서 놓음
               as GameObject;
            b_rb = balloon.GetComponent<Rigidbody>();
            b_rb.isKinematic = false;
            Vector3 v = transform.position;
            v.x = Mathf.Round(v.x);
            v.y = 0.8f;
            v.z = Mathf.Round(v.z);
            balloon.transform.position = v;
        }



    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cube"))
        {
            Debug.Log("충돌");
        }
    }

    
}