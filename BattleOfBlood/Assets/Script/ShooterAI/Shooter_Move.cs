using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Move : MonoBehaviour
{
    public static float ShooterSpeed = 3f;
    public static int ShooterHp = 100;
    public static int ShooterAp = 10;
    public static int bulletTime = 100;
    public static string ShooterTag;
    GameObject[] teamObject;
    GameObject[] enemyObject;

    public GameObject Prefab_bullet;
    public static GameObject shortEnemy; //슈터와 가장 가까운 적
    public static Vector3 Goal;
    Vector3 Dir;
    Vector3 lookat;
    int nTime = 0;
    private float gtimer;
    private float etimer;
    public Rigidbody rb;
    private float fTime;
    private bool col;
    public static Vector3 cube_position;
    public static bool cubecol;
    public static int bulletCount = 3;
    private float shortDistance;
    public static int shooter_dir = -1;

    int sd_1 = 0;
    private float x;
    private float z;
    float min1, min2, min3, min4, min5;

    public bool ShooterMove()
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
        //shooter이동

        //float gtimer = Time.time;
        //etimer = gtimer + 0.035f;
        //gtimer += Time.deltaTime;

        x = gameObject.transform.position.x - shortEnemy.transform.position.x;
        z = gameObject.transform.position.z - shortEnemy.transform.position.z;
        if (ShooterHp > 0 && nTime % 80 == 0)
        {

            if (Mathf.Abs(x) > Mathf.Abs(z))
            {
                if (x < 0)
                    shooter_dir = 0;
                if (x >= 0)
                    shooter_dir = 1;
            }
            if (Mathf.Abs(x) < Mathf.Abs(z))
            {
                if (z < 0) //적이 슈터보다 z값큼
                    shooter_dir = 2;
                if (z >= 0)
                    shooter_dir = 3;
            }
            if (cubecol == true || col == true)
                shooter_dir = Random.Range(0, 4);

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                shooter_dir = 2;
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                shooter_dir = 3;
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                shooter_dir = 0;
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                shooter_dir = 1;
            }
            if (Shooter_Move.ShooterHp >= 0 || col == true)
            {
                if (shooter_dir == 0)
                {
                    Goal = new Vector3(1, 0, 0);
                }
                if (shooter_dir == 1)
                {
                    Goal = new Vector3(-1, 0, 0);
                }
                if (shooter_dir == 2)
                {
                    Goal = new Vector3(0, 0, 1);
                }
                if (shooter_dir == 3)
                {
                    Goal = new Vector3(0, 0, -1);
                }
                if (shooter_dir == 4)
                {
                    Goal = new Vector3(0, 0, 0);
                }
                if (shortDistance <= 2)
                {
                    Goal = -Goal;
                }
            }
            Quaternion Rot = Quaternion.LookRotation(Goal);
            gameObject.transform.localRotation = Rot;

            Dir = (shortEnemy.transform.position - gameObject.transform.position).normalized;
            Dir.y = 0;

            cubecol = false;
            col = false;
            return true;
        }
        Vector3 newVelocity = Goal * ShooterSpeed;
        // 리지드바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;
        return false;
    }

    public bool DetectPos() //적 위치 감지
    {
        if (Shooter_Move.ShooterHp > 0)
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
                shortEnemy = GameObject.Find("Player");

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

    public bool ChangeGun() //물총장전
    {
        if (Shooter_Move.ShooterHp > 0)
        {
            if (shortEnemy.name == "Shooter")
            {
                Shooter_Move.ShooterAp = 10;
                bulletTime = 100;
            }
            if (shortEnemy.name == "Healer")
            {
                Shooter_Move.ShooterAp = 6;
                bulletTime = 50;
            }
            if (shortEnemy.name == "Bastion")
            {
                Shooter_Move.ShooterAp = 10;
                bulletTime = 100;
            }
            if (shortEnemy.name == "Booster")
            {
                Shooter_Move.ShooterAp = 6;
                bulletTime = 50;
            }
            if (shortEnemy.name == "Player")
            {
                Shooter_Move.ShooterAp = 10;
                bulletTime = 100;
            }
            return true;
        }
        return false;
    }
    public bool IsCollision() //충돌 처리 기능 추가
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        teamObject = GameObject.FindGameObjectsWithTag("Team");
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        col = false;
        cubecol = false;
        ShooterTag = gameObject.tag;

        min1 = 100000;
        min2 = 100000;
        min3 = 100000;
        min4 = 100000;
        min5 = 100000;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        nTime++;
    }
    public bool IsDead()
    {
        if (ShooterHp <= 0)
        {
            gameObject.active = false;
            return false;
        }
        return true;
    }

    public bool AddBullet()
    {
        if (Shooter_Move.ShooterHp > 0 && bulletCount > 0)
        {
            if (nTime % bulletTime == 0)
            {
                GameObject bullet = GameObject.Instantiate(Prefab_bullet) as GameObject;
                bullet.GetComponent<Bullet_Move>().Dir = Dir;
                bullet.transform.parent = null;
                bullet.transform.position = transform.position;
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