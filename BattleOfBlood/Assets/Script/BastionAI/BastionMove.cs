using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastionMove : MonoBehaviour
{
    public static float BastionSpeed = 10f; //바스티온의 기본 스피드
    public static int BastionHp = 100; //바스티온의 Hp
    public static int BastionAp = 10; //바스티온의 Ap

    public static Vector3 cube_position; //장애물 위치
    public static int bastion_dir = -1;
    public GameObject Prefab_balloon;

    float DirR = 180.0f;
    Vector3 Dir;
    public static Vector3 b_lookat;

    int nTime = 0;

    Vector3 pos; //오브젝트의 위치 저장 변수

    public Rigidbody Bastion_rigid;

    Vector3 balloon1;
    Vector3 balloon2;
    Vector3 balloon3;
    Vector3 balloon4;
    Vector3 balloon5;
    Vector3 balloon6;
    Vector3 balloon7;
    Vector3 balloon8;

    float turnTime = 1.0f;
    float nextTurn = 0.0f;
    float TimeLeft = 5.0f; //물풍선 생성시간
    float nextTime = 0.0f; //물풍선 생성을 위한 시간변수

    float shortDistance; //가장 가까운 적과 거리

    public GameObject shortEnemy; //바스티온과 가장 가까운 적

    float distance = 0.0f; //바스티온과 적과의 거리

    int sd_1 = 0;
    int ap = 0;

    private float etimer;
    private float x;
    private float z;

    public static bool cubecol;
    private bool col;

    float min1, min2, min3, min4, min5;

    void Start()
    {
        nTime = 0;
        pos = transform.position; //오브젝트의 위치를 변수에 저장
        Bastion_rigid = gameObject.GetComponent<Rigidbody>(); //Rigidbody쓰기위해 저장
        col = false;
        cubecol = false;
        min1 = 100000;
        min2 = 100000;
        min3 = 100000;
        min4 = 100000;
        min5 = 100000;
        shortEnemy = GameObject.Find("Player"); //shortEnemy변수 초기화
    }
    public bool BastionMoveFollowTarget()
    {
        Debug.Log("bastionMove");
        if (transform.position.z < -15) //절벽 범위 조건문
        {
            Vector3 swap1 = transform.position; //벡터 저장
            swap1.z = -15;                                  //고정 위치 설정
            transform.position = swap1;
            col = true;
        }

        if (transform.position.z > 15)//절벽 범위 조건문
        {
            Vector3 swap2 = transform.position;//벡터 저장
            swap2.z = 15;//고정 위치 설정
            transform.position = swap2;
            col = true;
        }

        if (transform.position.x < -20)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -20;//고정 위치 설정
            transform.position = swap3;
            col = true;
        }
        if (transform.position.x > 20)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 20;//고정 위치 설정
            transform.position = swap4;
            col = true;
        }

        float gtimer = Time.time;
        etimer = gtimer + 0.02f;
        gtimer += Time.deltaTime;

        x = gameObject.transform.position.x - shortEnemy.transform.position.x; //오브젝트 위치와 가까운 적위치의 변화량
        z = gameObject.transform.position.z - shortEnemy.transform.position.z; //오브젝트 위치와 가까운 적위치의 변화량

        if (BastionHp > 0 && nTime % 80 == 0)
        {
            if (Mathf.Abs(x) > Mathf.Abs(z)) //적을 바라보는 방향을 설정하기 위함
            {
                if (x < 0)
                    bastion_dir = 0;
                if (x >= 0)
                    bastion_dir = 1;
            }
            if (Mathf.Abs(x) < Mathf.Abs(z)) //적을 바라보는 방향을 설정하기 위함
            {
                if (z < 0) //적이 슈터보다 z값큼
                    bastion_dir = 2;
                if (z >= 0)
                    bastion_dir = 3;
            }
            if (cubecol == true || col == true)
                bastion_dir = Random.Range(0, 4);

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                bastion_dir = 2;
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                bastion_dir = 3;
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                bastion_dir = 0;
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                bastion_dir = 1;
            }

            if (BastionMove.BastionHp >= 0 || col == true) //장애물에 부딪혔을 경우
            {
                if (bastion_dir == 0)
                {
                    b_lookat = new Vector3(1, 0, 0); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 1)
                {
                    b_lookat = new Vector3(-1, 0, 0); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 2)
                {
                    b_lookat = new Vector3(0, 0, 1); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 3)
                {
                    b_lookat = new Vector3(0, 0, -1); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 4)
                {
                    b_lookat = new Vector3(0, 0, 0);
                }
                if (shortDistance <= 2)
                {
                    b_lookat = -b_lookat; //가까운 적과 거리가 2이하 일때 겹치지 않기 위해 반대방향으로 바라봄
                }
            }
            Quaternion Rot = Quaternion.LookRotation(b_lookat); //바라보는 방향으로 회전
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized;
            Dir.y = 0;

            cubecol = false;
            col = false;
            return true;
        }
        else if (transform.position.z < -15 || transform.position.z > 15 || transform.position.x < -20 || transform.position.x > 20)
        {

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                bastion_dir = 2;
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                bastion_dir = 3;
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                bastion_dir = 0;
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                bastion_dir = 1;
            }

            if (BastionHp >= 0 || col == true) //장애물에 부딪혔을 경우
            {
                if (bastion_dir == 0)
                {
                    b_lookat = new Vector3(1, 0, 0); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 1)
                {
                    b_lookat = new Vector3(-1, 0, 0); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 2)
                {
                    b_lookat = new Vector3(0, 0, 1); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 3)
                {
                    b_lookat = new Vector3(0, 0, -1); //부딪힌 방향과 반대방향으로 바라봄
                }
                if (bastion_dir == 4)
                {
                    b_lookat = new Vector3(0, 0, 0);
                }
                if (shortDistance <= 2)
                {
                    b_lookat = -b_lookat;
                }
            }
            Quaternion Rot = Quaternion.LookRotation(b_lookat); //바라보는 방향으로 회전
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized;
            Dir.y = 0;
            cubecol = false;
            col = false;

            Vector3 newVelocity = b_lookat * BastionSpeed;
            // 리지드바디의 속도에 newVelocity 할당
            Bastion_rigid.velocity = newVelocity;
            return true;

        }
        Vector3 newVelocity2 = b_lookat * BastionSpeed;
        // 리지드바디의 속도에 newVelocity 할당
        Bastion_rigid.velocity = newVelocity2;
        return false;
    }

    public bool BastionFindEnemy()
    {
        if (BastionMove.BastionHp > 0)
        {
            if (gameObject.tag == "Team") //바스티온이 Team일 때
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //플레이어가 적 일때
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //쏘니가 적일때
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                    min3 = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")//슈터가 적일때
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5); //가장 작은 변수를 저장

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Player"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Sonny"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min3 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Booster"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Shooter"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Healer"); //가장 작은 변수인 오브젝트를 저장
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position); //가장 가까이에 있는 적과의 거리를 저장
            }
            else
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                    min3 = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position); //적과의 거리를 변수에 저장

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5);

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Player"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Sonny"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min3 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Booster"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Shooter"); //가장 작은 변수인 오브젝트를 저장
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Healer"); //가장 작은 변수인 오브젝트를 저장
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);

            }
            return true;
        }
        return false;
    }

    public bool IsBastionCol() //충돌 처리 기능 추가
    {
        if (cubecol == true) //큐브와의 충돌이 true일때
        {
            Dir = (cube_position - gameObject.transform.position).normalized;
            Dir.y = 0;
            cubecol = false;
            return true;
        }
        return false;
    }

    void Update()
    {
        nTime++;
    }
    public bool BastionIsDead()
    {/*
        if (BastionHp < 10)
        {
            BastionHp = 0;
            for (int i = 0; i < Player.Team_array.Count; i++)
            {
                if (Player.Enemy_Hp[1] == -10 || Player.Team_Hp[1] == -10) // Team모두 또는 Enemy모두 Hp가 0일때
                {
                    return false;
                }
                else
                    gameObject.SetActive(false);
            }
        }
        return true;*/
        if (BastionHp == 0)
        {
            gameObject.SetActive(false);
            return false;
        }
        if (BastionHp > 0 && BastionHp <= 20) //체력이 거의 안 남았을때 자폭하여 바스티온의 주변으로 물풍선이 8개 생기도록 함
        {
            GameObject water_balloon1 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선1을 생성
            balloon1.x = transform.position.x + 1;
            balloon1.y = transform.position.y;
            balloon1.z = transform.position.z;
            water_balloon1.transform.parent = null;
            water_balloon1.transform.position = balloon1;

            GameObject water_balloon2 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선2을 생성
            balloon2.x = transform.position.x + 1;
            balloon2.y = transform.position.y;
            balloon2.z = transform.position.z + 1;
            water_balloon2.transform.parent = null;
            water_balloon2.transform.position = balloon2;

            GameObject water_balloon3 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선3을 생성
            balloon3.x = transform.position.x;
            balloon3.y = transform.position.y;
            balloon3.z = transform.position.z + 1;
            water_balloon3.transform.parent = null;
            water_balloon3.transform.position = balloon3;

            GameObject water_balloon4 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선4를 생성
            balloon4.x = transform.position.x - 1;
            balloon4.y = transform.position.y;
            balloon4.z = transform.position.z + 1;
            water_balloon4.transform.parent = null;
            water_balloon4.transform.position = balloon4;

            GameObject water_balloon5 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선5를 생성
            balloon5.x = transform.position.x - 1;
            balloon5.y = transform.position.y;
            balloon5.z = transform.position.z;
            water_balloon5.transform.parent = null;
            water_balloon5.transform.position = balloon5;

            GameObject water_balloon6 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선 6을 생성
            balloon6.x = transform.position.x - 1;
            balloon6.y = transform.position.y;
            balloon6.z = transform.position.z - 1;
            water_balloon6.transform.parent = null;
            water_balloon6.transform.position = balloon6;

            GameObject water_balloon7 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선7을 생성
            balloon7.x = transform.position.x;
            balloon7.y = transform.position.y;
            balloon7.z = transform.position.z - 1;
            water_balloon7.transform.parent = null;
            water_balloon7.transform.position = balloon7;

            GameObject water_balloon8 = GameObject.Instantiate(Prefab_balloon) as GameObject; //풍선8을 생성
            balloon8.x = transform.position.x + 1;
            balloon8.y = transform.position.y;
            balloon8.z = transform.position.z - 1;
            water_balloon8.transform.parent = null;
            water_balloon8.transform.position = balloon8;

            BastionHp = 0; //자폭한뒤 Hp를 10으로 함
            gameObject.active = false; //죽은 뒤에 활성화되지 않게함
            return false;
        }
        return true;
    }

    public bool BastionAddBalloon()
    {
        if (Player.PlayerHp > 0)
        {
            if (Time.time > nextTime) //일정한 시간마다
            {
                nextTime = Time.time + TimeLeft;
                GameObject water_balloon = GameObject.Instantiate(Prefab_balloon) as GameObject; //물풍선 생성
                water_balloon.GetComponent<WaterBalloon>().Dir = b_lookat; //바라보는 방향으로 향해 물풍선 날아가는 방향
                water_balloon.tag = "Bastion_balloon"; //바스티온에서 날아가는 물풍선은 태그를 바꿈
                water_balloon.transform.position = transform.position;
                water_balloon.transform.parent = null;

            }
            return true;
        }
        return false;
    }
    void OnCollisionEnter(Collision collision)
    {

        col = true;
        if (collision.collider.CompareTag("Cube")) //장애물과 충돌했을때
        {
            cube_position = collision.transform.position;
            cubecol = true;
        }
    }
}