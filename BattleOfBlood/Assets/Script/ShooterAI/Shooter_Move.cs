using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Move : MonoBehaviour
{
    public static float ShooterSpeed = 3f;  //슈터 스피드 변수 선언
    public static int ShooterHp = 100;      //슈터 HP
    public static int ShooterAp = 10;       //슈터 AP
    public static int bulletTime = 100;     //bullet 시간
    public static string ShooterTag;        //슈터의 태그
    GameObject[] teamObject;                //팀 오브젝트 배열 
    GameObject[] enemyObject;               //enemy 오브젝트 배열

    public GameObject Prefab_bullet;        //물총 프리팹
    public GameObject shortEnemy;           //슈터와 가장 가까운 적
    public static Vector3 Goal;             //오브젝트 방향 벡터
    Vector3 Dir;                            //물총 방향 벡터
    Vector3 lookat;                         //바라보는 방향 벡터
    int nTime = 0;                          // 타이머 변수 
    public Rigidbody rb;                    //리지드바디 변수
    private bool col;                       //충돌 감지 변수
    public static Vector3 cube_position;    //큐브 위치 변수
    public static bool cubecol;             //큐브 충돌 변수
    public static int bulletCount = 3;      //물총 개수
    private float shortDistance;            //가까운 오브젝트 거리
    public static int shooter_dir = -1;     //슈터 방향

    private float x;     //x좌표
    private float z;     //y좌표
    float min1, min2, min3, min4, min5;
    public bool ShooterMove()
    {
        if (transform.position.z < -15) //절벽 범위 조건문
        {
            Vector3 swap1 = transform.position; //벡터 저장
            swap1.z = -15;                                  //고정 위치 설정
            transform.position = swap1;
            col = true;                             //충돌 true
        }

        if (transform.position.z > 15)//절벽 범위 조건문
        {
            Vector3 swap2 = transform.position;//벡터 저장
            swap2.z = 15;//고정 위치 설정
            transform.position = swap2;
            col = true;                          //충돌 true
        }

        if (transform.position.x < -20)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -20;//고정 위치 설정
            transform.position = swap3;
            col = true;                         //충돌 true
        }
        if (transform.position.x > 20)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 20;//고정 위치 설정
            transform.position = swap4;
            col = true;                         //충돌 true
        }
        //shooter이동

        //float gtimer = Time.time;
        //etimer = gtimer + 0.035f;
        //gtimer += Time.deltaTime;

        x = gameObject.transform.position.x - shortEnemy.transform.position.x;  //가까운 적과 플레이어 사이의 x거리
        z = gameObject.transform.position.z - shortEnemy.transform.position.z;  //가까운 적과 플레이어 사이의 z거리
        if (ShooterHp > 0 && nTime % 80 == 0) //슈터의 hp가 0보다 크고 특정 시간마다
        {
            if (Mathf.Abs(x) > Mathf.Abs(z))  //x가 y보다 멀면
            {
                if (x < 0)                     //x가 0 보다 작으면
                    shooter_dir = 0;           //슈터방향 0
                if (x >= 0)                    //x가 0보다 크면
                    shooter_dir = 1;           //슈터 방향1
            }
            if (Mathf.Abs(x) < Mathf.Abs(z))    //x가 y보다 멀면
            {
                if (z < 0) //적이 슈터보다 z값큼
                    shooter_dir = 2;      //슈터방향2
                if (z >= 0)              //z가 0보다 작으면
                    shooter_dir = 3;     //슈터방향 3
            }
            if (cubecol == true || col == true)  //충돌 시
                shooter_dir = Random.Range(0, 4);  //랜덤한 방향으로 경로 재설정

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                shooter_dir = 2; //슈터방향 2
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                shooter_dir = 3;  //슈터방향 3
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                shooter_dir = 0;  //슈터 방향 0
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                shooter_dir = 1; //슈터 방향 1
            }
            if (Shooter_Move.ShooterHp >= 0 || col == true)  //슈터hp가 0보다 크고 충돌 시
            {
                if (shooter_dir == 0)  //슈터 방향 0이면
                {
                    Goal = new Vector3(1, 0, 0);
                }
                if (shooter_dir == 1)  //슈터 방향 1이면
                {
                    Goal = new Vector3(-1, 0, 0);
                }
                if (shooter_dir == 2)  //슈터 방향 2 면
                {
                    Goal = new Vector3(0, 0, 1);
                }
                if (shooter_dir == 3)  //슈터 방향 3이면
                {
                    Goal = new Vector3(0, 0, -1);
                }
                if (shooter_dir == 4) //슈터 방향 4면
                {
                    Goal = new Vector3(0, 0, 0);
                }
                if (shortDistance <= 2)  //거리가 2보다 작으면
                {
                    Goal = -Goal;  //방향 반대로
                }
            }
            Quaternion Rot = Quaternion.LookRotation(Goal);  //골을 바라보게함
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized; //슈터 물풍선 총방향 적방향으로
            Dir.y = 0;  //물총 y위치 고정

            cubecol = false;  //큐브 충돌 변수 끄기
            col = false;      //충돌 변수 끄기
            return true;
        }
        Vector3 newVelocity = Goal * ShooterSpeed;  //속도에 방향과 스피드 할당
        // 리지드바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;  //리지드 바디에 넣어줌
        return false;
    }

    public bool DetectPos() //적 위치 감지
    {
        if (Shooter_Move.ShooterHp > 0)
        {
            if (gameObject.tag == "Team")//플레이어의 태그가 팀이면
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")//각 오브젝트들과의 거리를 계산해 MIN변수에 넣음
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                    min4 = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5); //거리들 중 가장 가까운 거리를 계산해서

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")   //그 거리에 해당하는 오브젝트를 저장함
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")    //그 거리에 해당하는 오브젝트를 저장함
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minDistance == min4 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
                {
                    shortEnemy = GameObject.Find("Booster");
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")   //그 거리에 해당하는 오브젝트를 저장함
                {
                    shortEnemy = GameObject.Find("Healer");
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);
            }
            else
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //각 오브젝트들과의 거리를 계산해 MIN변수에 넣음
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                    min4 = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5); //거리들 중 가장 가까운 거리를 계산해서

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")  //그 거리에 해당하는 오브젝트 저장
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")//그 거리에 해당하는 오브젝트 저장
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")//그 거리에 해당하는 오브젝트 저장
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minDistance == min4 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")//그 거리에 해당하는 오브젝트 저장
                {
                    shortEnemy = GameObject.Find("Booster");
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")//그 거리에 해당하는 오브젝트 저장
                {
                    shortEnemy = GameObject.Find("Healer");
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);

            }
            return true;
        }
        return false;
    }

    public bool ChangeGun() //물총장전
    {
        if (Shooter_Move.ShooterHp > 0)    //슈터hp 0보다 크면
        {
            if (shortEnemy.name == "Shooter")  //가까운 적 슈터
            {
                Shooter_Move.ShooterAp = 5;   //공격력 5
                bulletTime = 100;             //물총 타이머 100
            }
            if (shortEnemy.name == "Healer")    //가까운 적 힐러
            {
                Shooter_Move.ShooterAp = 3;        //공격력 3
                bulletTime = 100;                  //물총 타이머 100
            }
            if (shortEnemy.name == "Bastion")    //가까운적 바스티온
            {
                Shooter_Move.ShooterAp = 5;          //공격력 5
                bulletTime = 100;                    //물총 타이머 100
            }
            if (shortEnemy.name == "Booster")   //가까운 적 부스터
            {
                Shooter_Move.ShooterAp = 3;      //공격력 3
                bulletTime = 100;                //물총 타이머 100
            }
            if (shortEnemy.name == "Player")    //가까운 적 플레이어
            {
                Shooter_Move.ShooterAp = 5;     //공격력 5
                bulletTime = 100;               //물총 타이머 100
            }
            return true;
        }
        return false;
    }
    public bool IsCollision() //충돌 처리 기능 추가
    {
        if (cubecol == true)  //큐브 충돌 시
        {
            Dir = (cube_position - gameObject.transform.position).normalized; //큐브로 총알 위치
            Dir.y = 0;  //총알 y 0
            cubecol = false;  //큐브콜 끄기
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    //rigidbody 넣기
        teamObject = GameObject.FindGameObjectsWithTag("Team");  //team 배열
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy"); //enemy 배열
        col = false; //col 초기화
        cubecol = false;    //큐브 콜 초기화
        ShooterTag = gameObject.tag;     //슈터의 태그 
        shortEnemy = GameObject.Find("Player");   //가까운적 초기에는 플레이어로 해서 null 방지

        min1 = 100000;
        min2 = 100000;
        min3 = 100000;
        min4 = 100000;
        min5 = 100000;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        nTime++;  //타이머 업데이트
    }
    public bool IsDead()    //죽었을 때 
    {
        if (ShooterHp <= 0)  //슈터 hp 0이하
        {
            gameObject.active = false;  //안보이게
            return false;
        }
        return true;
    }

    public bool AddBullet() //물총 발사
    {
        if (Shooter_Move.ShooterHp > 0 && bulletCount > 0)  //슈터 hp 0 초과, 총알 0 초과
        {
            if (nTime % bulletTime == 0) //일정 시간 간격
            {
                GameObject bullet = GameObject.Instantiate(Prefab_bullet) as GameObject; //총알 받아오기
                bullet.GetComponent<Bullet_Move>().Dir = Dir;  //방향 설정
                bullet.transform.parent = null;  //부모 null
                bullet.transform.position = transform.position; //총알 위치
            }
            return true;
        }
        return false;
    }
    void OnCollisionEnter(Collision collision)
    {
        col = true;            //충돌 변수 true
        if (collision.collider.CompareTag("Cube"))  //큐브와 충돌시
        {
            cube_position = collision.transform.position;  //큐브 위치 받아오기
            cubecol = true;                   //큐브 충돌 변수 켜기
        }
    }

    void OnCollisionStay(Collision collision)
    {
        col = true; //충돌 변수 true
        if (collision.collider.CompareTag("Cube"))  //큐브와 충돌시
        {
            cube_position = collision.transform.position;  //큐브 위치 받아오기
            cubecol = true;                   //큐브 충돌 변수 켜기
        }
    }
}