using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Move : MonoBehaviour
{
    public static float ShooterSpeed = 3f;
    public static int ShooterHp = 100;

    GameObject[] teamObject;
    GameObject[] enemyObject;

    public GameObject Prefab_bullet;
    public GameObject shortEnemy; //슈터와 가장 가까운 적
    public static Vector3 Goal;
    float DirR = 180.0f; //플레이어와 반대방향
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

    int sd_1 = 0;

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

        if (transform.position.x < -15)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -15;//고정 위치 설정
            transform.position = swap3;
            col = true;
        }
        if (transform.position.x > 15)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 15;//고정 위치 설정
            transform.position = swap4;
            col = true;
        }
        //shooter이동

        float gtimer = Time.time;
        etimer = gtimer + 0.035f;

        gtimer += Time.deltaTime;
        if (gtimer > etimer || col == true)
        {
            if (Player.ShooterHp >= 50)
            {
                int ran = Random.Range(0, 4);

                if (ran == 0)
                {
                    Goal = new Vector3(1, 0, 0);
                }
                if (ran == 1)
                {
                    Goal = new Vector3(-1, 0, 0);
                }
                if (ran == 2)
                {
                    Goal = new Vector3(0, 0, 1);
                }
                if (ran == 3)
                {
                    Goal = new Vector3(0, 0, -1);
                }
            }
            Quaternion Rot = Quaternion.LookRotation(Goal);
            gameObject.transform.localRotation = Rot;


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
        if (ShooterHp > 0)
        {
            if (gameObject.tag == "Enemy")
            {
                shortDistance = Vector3.Distance(Player.Team_array[0].transform.position, gameObject.transform.position);
                for (sd_1 = 0; sd_1 < Player.Team_array.Count; sd_1++)
                {
                    float distance = Vector3.Distance(Player.Team_array[sd_1].transform.position, gameObject.transform.position);
                    if (distance <= shortDistance)
                    {
                        shortDistance = distance;
                        shortEnemy = Player.Team_array[sd_1];
                    }
                }

                Vector3 Enemy_Dir = shortEnemy.transform.position - gameObject.transform.position;
                Enemy_Dir.Normalize();
                Dir = Enemy_Dir;
                Debug.Log("가까운enemy: " + shortEnemy.name + "\ndir : " + Dir);
            }
            else
            {
                shortDistance = Vector3.Distance(Player.Enemy_array[0].transform.position, gameObject.transform.position);
                for (sd_1 = 0; sd_1 < Player.Enemy_array.Count; sd_1++)
                {
                    float distance = Vector3.Distance(Player.Enemy_array[sd_1].transform.position, gameObject.transform.position);
                    if (distance <= shortDistance)
                    {
                        shortDistance = distance;
                        shortEnemy = Player.Enemy_array[sd_1];
                    }
                }
            }
            return true;
        }
        return false;
    }

    public bool ChangeGun() //물총장전
    {
        if (cubecol == false)
        {

        }
        return false;
    }
    public bool IsCollision() //충돌 처리 기능 추가
    {
        if (cubecol == true)
        {
            Dir = cube_position.normalized;
            Dir.y = 0;
            cubecol = false;
            return true;
        }
        else
        {
            Dir = Goal;
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
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        nTime++;
    }
    public bool IsDead()
    {
        if (Player.ShooterHp <= 0)
        {
            Debug.Log("Shooter is Dead");
            Destroy(gameObject, 0f);
            return false;
        }
        return true;
    }

    public bool AddBullet()
    {
        if (Player.ShooterHp > 0 && bulletCount > 0)
        {
            if (nTime % 100 == 0)
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