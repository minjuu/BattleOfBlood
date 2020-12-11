using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonnyMove : MonoBehaviour
{
    public static int SonnyHp = 100; //체력
    public static int SonnyAp = 10; //공격력
    public static Vector3 SonnyPos; // 쏘니 위치 저장 변수
    public static float SonnySpeed = 8f; // 쏘니 스피트
    public GameObject Ballon; //쏘니가 생성할 물풍선

    public static Vector3 GoalPos; // 물풍선 미는 위치
    int nTime = 0; // 타이머 변수

    private float x;
    private float z;
    private bool coll; //충돌 변수
    public static Vector3 cube_position; //큐브 위치 저장변수

    public static int sonny_dir = -1;
    public static Vector3 Goal; // 쏘니 이동 방향
    private float shortDistance; //가장 가까운 적 저장
    public GameObject shortEnemy; //슈터와 가장 가까운 적
    public static bool cubecoll; //장애물과의 충돌여부

    Vector3 Dir;
    Vector3 Now; //현재 위치 저장 변수
    public Rigidbody bb_rb; //생성한 물풍선의 리지드바디

    public Rigidbody srb; // 쏘니 리지드바디

    float min1, min2, min3, min4, min5; //적과의 거리 저장변수


    // Start is called before the first frame update
    void Start()
    {
        shortEnemy = GameObject.Find("Player"); //shortEnemy에 Player를 저장하여 초기화
        nTime = 0; //타이머 초기화
        srb = GetComponent<Rigidbody>(); //Rigidbody받아옴
        min1 = 100000; //임의의 최소값
        min2 = 100000; //임의의 최소값 
        min3 = 100000; //임의의 최소값
        min4 = 100000; //임의의 최소값
        min5 = 100000; //임의의 최소값


        coll = false; //충돌변수 초기화

    }

    public bool MoveinMap()
    {
        if (transform.position.z < -15) //절벽 범위 조건문
        {
            Vector3 swap1 = transform.position; //벡터 저장
            swap1.z = -15;                                  //고정 위치 설정
            transform.position = swap1; //위치 변경
            coll = true;
        }

        if (transform.position.z > 15)//절벽 범위 조건문
        {
            Vector3 swap2 = transform.position;//벡터 저장
            swap2.z = 15;//고정 위치 설정
            transform.position = swap2; //위치 변경
            coll = true;
        }

        if (transform.position.x < -20)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -20;//고정 위치 설정
            transform.position = swap3; //위치 변경
            coll = true;
        }
        if (transform.position.x > 20)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 20;//고정 위치 설정
            transform.position = swap4; //위치 변경
            coll = true;
        }


        x = gameObject.transform.position.x - shortEnemy.transform.position.x; //오브젝트 위치와 가까운 적위치의 변화량
        z = gameObject.transform.position.z - shortEnemy.transform.position.z; //오브젝트 위치와 가까운 적위치의 변화량
        if (SonnyHp > 0 && nTime % 80 == 0)
        {

            if (Mathf.Abs(x) > Mathf.Abs(z)) //적을 바라보는 방향을 설정하기 위함
            {
                if (x < 0)   //적이 쏘니보다 x값큼
                    sonny_dir = 0;
                if (x >= 0) //적이 쏘니보다 x값 작음
                    sonny_dir = 1;
            }
            if (Mathf.Abs(x) < Mathf.Abs(z)) //적을 바라보는 방향을 설정하기 위함
            {
                if (z < 0) //적이 쏘니보다 z값큼
                    sonny_dir = 2;
                if (z >= 0) //적이 쏘니보다 z값 작음
                    sonny_dir = 3;
            }
            if (cubecoll == true || coll == true) // 다른 물체와 충돌한 경우
                sonny_dir = Random.Range(0, 4); // 이동 방향 변경

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                sonny_dir = 2; //이동 방향 변경
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                sonny_dir = 3; //이동 방향 변경
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                sonny_dir = 0; //이동 방향 변경
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                sonny_dir = 1; //이동 방향 변경
            }

            if (SonnyHp >= 0 || coll == true) //장애물과 충돌 할때
            {
                if (sonny_dir == 0)
                {
                    Goal = new Vector3(1, 0, 0); //바라보는 방향
                }
                if (sonny_dir == 1)
                {
                    Goal = new Vector3(-1, 0, 0); //바라보는 방향
                }
                if (sonny_dir == 2)
                {
                    Goal = new Vector3(0, 0, 1); //바라보는 방향
                }
                if (sonny_dir == 3)
                {
                    Goal = new Vector3(0, 0, -1); //바라보는 방향
                }
                if (sonny_dir == 4)
                {
                    Goal = new Vector3(0, 0, 0);  //바라보는 방향
                }
                if (shortDistance <= 2) //가까운 적과 거리가 2 이하일때
                {
                    Goal = -Goal; //반대방향으로 바라보게 함
                }
            }
            Quaternion Rot = Quaternion.LookRotation(Goal); //바라보는 방향으로 회전
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized;
            Dir.y = 0;
            cubecoll = false;
            coll = false;

            Vector3 newVelocity = Goal * SonnySpeed; //오브젝트 이동
            // 리지드바디의 속도에 newVelocity 할당
            srb.velocity = newVelocity;
            return true;
        }
        else if (transform.position.z < -15 || transform.position.z > 15 || transform.position.x < -20 || transform.position.x > 20) //절벽에 도착하면
        {

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                sonny_dir = 2; //이동 방향 변경
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                sonny_dir = 3; //이동 방향 변경
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                sonny_dir = 0; //이동 방향 변경
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                sonny_dir = 1; //이동 방향 변경
            }

            if (SonnyHp >= 0 || coll == true) //장애물과 충돌했을때
            {
                if (sonny_dir == 0)
                {
                    Goal = new Vector3(1, 0, 0); //바라보는 방향 저장
                }
                if (sonny_dir == 1)
                {
                    Goal = new Vector3(-1, 0, 0); //바라보는 방향 저장
                }
                if (sonny_dir == 2)
                {
                    Goal = new Vector3(0, 0, 1); //바라보는 방향 저장
                }
                if (sonny_dir == 3)
                {
                    Goal = new Vector3(0, 0, -1); //바라보는 방향 저장
                }
                if (sonny_dir == 4)
                {
                    Goal = new Vector3(0, 0, 0);
                }
                if (shortDistance <= 2) //가장 가까운 적과 거리가 2 이하일때
                {
                    Goal = -Goal; //바라보는 방향과 반대방향으로 바라봄
                }
            }
            Quaternion Rot = Quaternion.LookRotation(Goal); //바라보는 방향으로 회전함
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized;
            Dir.y = 0;
            cubecoll = false;
            coll = false;

            Vector3 newVelocity = Goal * SonnySpeed;
            // 리지드바디의 속도에 newVelocity 할당
            srb.velocity = newVelocity;
            return true;

        }
        Vector3 newVelocity2 = Goal * SonnySpeed;
        // 리지드바디의 속도에 newVelocity 할당
        srb.velocity = newVelocity2;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        nTime++; //타이머 작동
        Now = transform.position; //현재 위치 저장
        Now.y = 0.3f; //y변수 조정
        transform.position = Now; //조정된 위치로 이동
    }
    public bool SonnyIsDead()
    {
        if (SonnyHp <= 0) //Hp가 0이하일때
        {
            gameObject.active = false; //오브젝트를 비활성화함
            return false;
        }
        return true;

    }


    public bool AddBalloon()
    {
        if (SonnyHp > 0)
        {
            if (nTime % 300 == 0) //nTime이 300의 배수일때마다
            {
                GameObject ballon = GameObject.Instantiate(Ballon) as GameObject; //물풍선 생성
                ballon.GetComponent<WaterBalloon>().Dir = Dir; //물풍선 이동 방향 조정
                bb_rb = ballon.GetComponent<Rigidbody>();
                bb_rb.isKinematic = false; // 생성할 때 isKinematic 속성 변경
                ballon.transform.parent = null; //위치 독립
                ballon.gameObject.tag = "SonnyBalloon"; //태그 변경
                Vector3 bPos; // 물풍선 위치 저장 변수

                bPos = transform.position; // 현재 위치 저장
                bPos.y = 0.8f; //y값 조정
                ballon.transform.position = bPos; //조정된 위치로 이동

            }
            return true;
        }
        return false;
    }
    private void OnCollisionEnter(Collision col)
    {
        int m_idx = 0; //최소값을 가진 인덱스 저장 변수
        if (col.gameObject.tag == "Balloon" || col.gameObject.tag == "SonnyBalloon") // 충돌한 오브젝트의 태그 구분
        {
            col.gameObject.tag = "SonnyBalloon"; //충돌한 물풍선의 태그 변경

            if (gameObject.tag == "Team") // 쏘니 캐릭터의 태그가 Team 일 경우
            {
                float e_min = 1000000; //임의 최소값 설정
                GameObject[] e_Array = GameObject.FindGameObjectsWithTag("Enemy"); //적 오브젝트 배열 생성
                for (int i = 0; i < e_Array.Length; i++)
                {
                    if ((e_Array[i].transform.position - gameObject.transform.position).magnitude < e_min)
                    {
                        e_min = (e_Array[i].transform.position - gameObject.transform.position).magnitude;
                        m_idx = i;
                    }
                    // 현재 오브젝트와 거리가 가장 가까운 오브젝트의 인덱스 저장
                }
                GoalPos.y = 0.8f;
                Vector3 epos = e_Array[m_idx].transform.position; //거리가 가장 가까운 오브젝트의 위치 저장
                epos.y = 0.8f; //y값 조정
                GoalPos = (epos - transform.position).normalized; //벡터 정규화
                // GoalPos.Normalize();

            }
            else if (gameObject.tag == "Enemy") // 쏘니 캐릭터의 태그가 Enemy 일 경우
            {
                float e_min = 1000000; //임의 최소값 설정
                GameObject[] e_Array = GameObject.FindGameObjectsWithTag("Team"); //팀 오브젝트 배열 생성
                for (int i = 0; i < e_Array.Length; i++)
                {
                    if ((e_Array[i].transform.position - gameObject.transform.position).magnitude < e_min)
                    {
                        e_min = (e_Array[i].transform.position - gameObject.transform.position).magnitude;
                        m_idx = i;
                    }
                    // 현재 오브젝트와 거리가 가장 가까운 오브젝트의 인덱스 저장
                }

                GoalPos.y = 0.8f;
                Vector3 epos = e_Array[m_idx].transform.position; //거리가 가장 가까운 오브젝트의 위치 저장
                epos.y = 0.8f;  //y값 조정
                GoalPos = (epos - transform.position).normalized; //벡터 정규화


            }
            BalloonMove.Sonnykick = true; //물풍선 충돌시 물풍선 목표 지점까지 이동시키는 BallonMove내 코드 실행
        }

        coll = true;
        if (col.collider.CompareTag("Cube")) //큐브와 충돌시
        {
            cube_position = col.transform.position; //큐브 위치 저장
            cubecoll = true;
        }


    }

    public bool DetectPosi() //적 위치 감지
    {
        if (SonnyHp > 0)
        {
            if (gameObject.tag == "Team") //쏘니가 팀일때
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position); //플레이어와의 거리 저장
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                    min2 = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position); //부스터와의 거리 저장
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position); //바스티온과의 거리 저장
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position); //슈터와의 거리 저장
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position); //힐러와의 거리 저장

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5); //저장한 거리중에 제일 짧은 거리 저장

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Player"); //가장 짧은 거리가 플레이어일때 shortEnemy저장
                }
                if (minDistance == min2 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Sonny"); //가장 짧은 거리가 부스터일때 shortEnemy저장
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Bastion"); //가장 짧은 거리가 바스티온일때 shortEnemy저장
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Shooter"); //가장 짧은 거리가 슈터일때 shortEnemy저장
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Healer"); //가장 짧은 거리가 힐러일때 shortEnemy저장
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position); //가장짧은 거리에 있는 적과의 거리
                GoalPos.y = 0.8f;
                Vector3 epos = shortEnemy.transform.position;
                epos.y = 0.8f;
                GoalPos = (epos - transform.position).normalized;
            }
            else
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position); //플레이어와의 거리 저장
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                    min2 = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position); //부스터와의 거리 저장
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position); //바스티온과의 거리 저장
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position); //슈터와의 거리 저장
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position); //힐러와의 거리 저장

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5); //저장한 값중에 제일 작은 값 찾아냄

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Player"); //가장 짧은 거리가 플레이어일때 shortEnemy저장
                }
                if (minDistance == min2 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Sonny"); //가장 짧은 거리가 부스터일때 shortEnemy저장
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Bastion"); //가장 짧은 거리가 바스티온일때 shortEnemy저장
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Shooter"); //가장 짧은 거리가 슈터일때 shortEnemy저장
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Healer"); //가장 짧은 거리가 힐러일때 shortEnemy저장
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position); //가장 짧은 적과의 거리 저장
                GoalPos.y = 0.8f;
                Vector3 epos = shortEnemy.transform.position; //거리가 가장 가까운 적의 위치 저장
                epos.y = 0.8f; // y값 조정
                GoalPos = (epos - transform.position).normalized; //벡터 정규화

            }
            return true;
        }
        return false;
    }

    public bool Is_Collision() //충돌 처리 기능 추가
    {
        if (cubecoll == true) //장애물과 부딪혔을때
        {
            Dir = (cube_position - gameObject.transform.position).normalized; //장애물과 오브젝트 방향벡터 계산
            Dir.y = 0;
            cubecoll = false;
            return true;
        }
        return false;
    }


}