using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastionMove : MonoBehaviour
{
    public static float BastionSpeed = 15f;
    public static int BastionHp = 100;
    public static int BastionAp = 10;

    public static Vector3 cube_position;
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

    float shortDistance;
    int shortDistance_index;
    float largestAp;
    int largestAp_index = -1;
    public GameObject shortEnemy; //바스티온과 가장 가까운 적

    float distance = 0.0f; //바스티온과 적과의 거리

    int sd_1 = 0;
    int ap = 0;

    private float etimer;
    private float x;
    private float z;

    public static bool cubecol;
    private bool col;
    bool make_wb;

    float min1, min2, min3, min4, min5;

    void Start()
    {
        nTime = 0;
        pos = transform.position; //오브젝트의 위치를 변수에 저장
        Bastion_rigid = gameObject.GetComponent<Rigidbody>();
        col = false;
        cubecol = false;
        make_wb = false;
        min1 = 100000;
        min2 = 100000;
        min3 = 100000;
        min4 = 100000;
        min5 = 100000;
        shortEnemy = GameObject.Find("Player");
    }
    public bool BastionMoveFollowTarget()
    {

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

        x = gameObject.transform.position.x - shortEnemy.transform.position.x;
        z = gameObject.transform.position.z - shortEnemy.transform.position.z;

        if (BastionHp > 0 && nTime % 80 == 0)
        {
            if (Mathf.Abs(x) > Mathf.Abs(z))
            {
                if (x < 0)
                    bastion_dir = 0;
                if (x >= 0)
                    bastion_dir = 1;
            }
            if (Mathf.Abs(x) < Mathf.Abs(z))
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

            if (BastionMove.BastionHp >= 0 || col == true)
            {
                if (bastion_dir == 0)
                {
                    b_lookat = new Vector3(1, 0, 0);
                }
                if (bastion_dir == 1)
                {
                    b_lookat = new Vector3(-1, 0, 0);
                }
                if (bastion_dir == 2)
                {
                    b_lookat = new Vector3(0, 0, 1);
                }
                if (bastion_dir == 3)
                {
                    b_lookat = new Vector3(0, 0, -1);
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
            Quaternion Rot = Quaternion.LookRotation(b_lookat);
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized;
            Dir.y = 0;

            cubecol = false;
            col = false;
            return true;
        }
        Vector3 newVelocity = b_lookat * BastionSpeed;
        // 리지드바디의 속도에 newVelocity 할당
        Bastion_rigid.velocity = newVelocity;
        return false;
    }

    public bool BastionFindEnemy()
    {
        if (BastionMove.BastionHp > 0)
        {
            if (gameObject.tag == "Team")
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5);

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Shooter");
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Healer");
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);
            }
            else
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5);

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Shooter");
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Healer");
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);

            }
            return true;
        }
        return false;
    }

    public bool IsBastionCol() //충돌 처리 기능 추가
    {
        if (cubecol == true)
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
        if (BastionHp >= 5 && BastionHp <=20)
        {
            //어떻게 만들지
            GameObject water_balloon1 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon1.x = transform.position.x + 1;
            balloon1.y = transform.position.y;
            balloon1.z = transform.position.z;
            water_balloon1.transform.parent = null;
            water_balloon1.transform.position = balloon1;

            GameObject water_balloon2 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon2.x = transform.position.x + 1;
            balloon2.y = transform.position.y;
            balloon2.z = transform.position.z + 1;
            water_balloon2.transform.parent = null;
            water_balloon2.transform.position = balloon2;

            GameObject water_balloon3 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon3.x = transform.position.x;
            balloon3.y = transform.position.y;
            balloon3.z = transform.position.z + 1;
            water_balloon3.transform.parent = null;
            water_balloon3.transform.position = balloon3;

            GameObject water_balloon4 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon4.x = transform.position.x - 1;
            balloon4.y = transform.position.y;
            balloon4.z = transform.position.z + 1;
            water_balloon4.transform.parent = null;
            water_balloon4.transform.position = balloon4;

            GameObject water_balloon5 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon5.x = transform.position.x - 1;
            balloon5.y = transform.position.y;
            balloon5.z = transform.position.z;
            water_balloon5.transform.parent = null;
            water_balloon5.transform.position = balloon5;

            GameObject water_balloon6 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon6.x = transform.position.x - 1;
            balloon6.y = transform.position.y;
            balloon6.z = transform.position.z - 1;
            water_balloon6.transform.parent = null;
            water_balloon6.transform.position = balloon6;

            GameObject water_balloon7 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon7.x = transform.position.x;
            balloon7.y = transform.position.y;
            balloon7.z = transform.position.z - 1;
            water_balloon7.transform.parent = null;
            water_balloon7.transform.position = balloon7;

            GameObject water_balloon8 = GameObject.Instantiate(Prefab_balloon) as GameObject;
            balloon8.x = transform.position.x + 1;
            balloon8.y = transform.position.y;
            balloon8.z = transform.position.z - 1;
            water_balloon8.transform.parent = null;
            water_balloon8.transform.position = balloon8;

            BastionHp = 0;
            gameObject.active = false;
            return false;
        }
        return true;
    }

    public bool BastionAddBalloon()
    {
        if (Player.PlayerHp > 0)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft;
                GameObject water_balloon = GameObject.Instantiate(Prefab_balloon) as GameObject;
                water_balloon.GetComponent<WaterBalloon>().Dir = b_lookat;
                water_balloon.tag = "Bastion_balloon"; //태그 추가하기
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
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
        }
    }
}