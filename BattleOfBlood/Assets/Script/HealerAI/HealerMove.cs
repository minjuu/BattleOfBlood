using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerMove : MonoBehaviour
{
    public static float HealerSpeed = 0.01f;
    public static int HealerHp = 100;
    public static int SonnyHp = 100;

    public GameObject Prefab_bullet;
    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.02f;
    int nTime = 0;

    private bool col;
    public static bool cubecol;
    public static Vector3 cube_position;

    Vector3 Enemy_Dir;
    Vector3 lookat;
    public GameObject shortEnemy; //바스티온과 가장 가까운 적
    float distance = 0.0f; //바스티온과 적과의 거리
    int sd_1 = 0;
    float shortDistance;

    float wtimer;
    float etimer;
    float wtimer2;
    float etimer2;
    float gtimer3;
    float etimer3;

    float min1, min2, min3, min4, min5;
    float Min1, Min2, Min3, Min4, Min5;

    public static int healer_dir = -1;
    private float x;
    private float z;
    public Rigidbody rb;

    public bool MoveHealer()
    {
        if (HealerHp > 0)
        {
            if (gameObject.tag == "Team")
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                    min1 = Player.PlayerHp;
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                    min2 = SonnyMove.SonnyHp;
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                    min3 = BastionMove.BastionHp;
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                    min4 = Shooter_Move.ShooterHp;
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                    min5 = BoosterMove.BoosterHp;

                float MinHp = Mathf.Min(min1, min2, min3, min4, min5);

                if (MinHp == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Player");
                    shortDistance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                }
                if (MinHp == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Sonny");
                    shortDistance = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                }
                if (MinHp == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Bastion");
                    shortDistance = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                }
                if (MinHp == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Shooter");
                    shortDistance = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                }
                if (MinHp == min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Booster");
                    shortDistance = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position);
                }
                //Debug.Log(MinHp);
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

                gtimer3 += Time.deltaTime;

                x = gameObject.transform.position.x - shortEnemy.transform.position.x;
                z = gameObject.transform.position.z - shortEnemy.transform.position.z;
                if (gtimer3 > etimer3)
                {
                    //Debug.Log("xxxx");
                    if (Mathf.Abs(x) > Mathf.Abs(z))
                    {
                        if (x < 0)
                            healer_dir = 0;
                        if (x >= 0)
                            healer_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z))
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            healer_dir = 2;
                        if (z >= 0)
                            healer_dir = 3;
                    }
                    if (cubecol == true)
                    {
                        healer_dir = Random.Range(0, 4);
                        //Debug.Log("healer cubecol");
                    }
                    if (HealerHp >= 0 || col == true)
                    {
                        if (healer_dir == 0)
                        {
                            lookat = new Vector3(1, 0, 0);
                        }
                        if (healer_dir == 1)
                        {
                            lookat = new Vector3(-1, 0, 0);
                        }
                        if (healer_dir == 2)
                        {
                            lookat = new Vector3(0, 0, 1);
                        }
                        if (healer_dir == 3)
                        {
                            lookat = new Vector3(0, 0, -1);
                        }
                        if (healer_dir == 4)
                        {
                            lookat = new Vector3(0, 0, 0);
                        }
                        if (shortDistance <= 2)
                        {
                            lookat = -lookat;
                        }
                    }
                    Quaternion Rot = Quaternion.LookRotation(lookat);
                    gameObject.transform.localRotation = Rot;

                    gtimer3 = 0;
                    cubecol = false;
                    col = false;
                }
                transform.position += lookat * HealerSpeed;
                // 리지드바디의 속도에 newVelocity 할당
            }
            //Debug.Log("yyy");

            if (gameObject.tag == "Enemy")
            {
                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                    min1 = Player.PlayerHp;
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min2 = SonnyMove.SonnyHp;
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                    min3 = BastionMove.BastionHp;
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                    min4 = Shooter_Move.ShooterHp;
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                    min5 = BoosterMove.BoosterHp;

                float MinHp = Mathf.Min(min1, min2, min3, min4, min5);

                if (MinHp == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Player");
                    shortDistance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                }
                if (MinHp == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Sonny");
                    shortDistance = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                }
                if (MinHp == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Bastion");
                    shortDistance = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                }
                if (MinHp == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Shooter");
                    shortDistance = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                }
                if (MinHp == min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Booster");
                    shortDistance = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position);
                }

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

                gtimer3 += Time.deltaTime;

                x = gameObject.transform.position.x - shortEnemy.transform.position.x;
                z = gameObject.transform.position.z - shortEnemy.transform.position.z;
                if (gtimer3 > etimer3)
                {

                    if (Mathf.Abs(x) > Mathf.Abs(z))
                    {
                        if (x < 0)
                            healer_dir = 0;
                        if (x >= 0)
                            healer_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z))
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            healer_dir = 2;
                        if (z >= 0)
                            healer_dir = 3;
                    }
                    if (cubecol == true)
                    {
                        Debug.Log("cubecol healer");
                        healer_dir = Random.Range(0, 4);
                    }
                    if (HealerHp >= 0 || col == true)
                    {
                        if (healer_dir == 0)
                        {
                            lookat = new Vector3(1, 0, 0);
                        }
                        if (healer_dir == 1)
                        {
                            lookat = new Vector3(-1, 0, 0);
                        }
                        if (healer_dir == 2)
                        {
                            lookat = new Vector3(0, 0, 1);
                        }
                        if (healer_dir == 3)
                        {
                            lookat = new Vector3(0, 0, -1);
                        }
                        if (healer_dir == 4)
                        {
                            lookat = new Vector3(0, 0, 0);
                        }
                        if (shortDistance <= 2)
                        {
                            lookat = -lookat;
                        }
                    }
                    Quaternion Rot = Quaternion.LookRotation(lookat);
                    gameObject.transform.localRotation = Rot;

                    gtimer3 = 0;
                    cubecol = false;
                    col = false;
                }
                transform.position += lookat * HealerSpeed;
                // 리지드바디의 속도에 newVelocity 할당
            }
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        nTime = 0;
        wtimer = 0.0f;
        etimer = wtimer + 5f;
        wtimer2 = 0.0f;
        etimer = wtimer + 10f;
        gtimer3 = 0;
        etimer3 = gtimer3 + 1f;

        min1 = 100000;
        min2 = 100000;
        min3 = 100000;
        min4 = 100000;
        min5 = 100000;

        Min1 = 100000;
        Min2 = 100000;
        Min3 = 100000;
        Min4 = 100000;
        Min5 = 100000;

    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }

    public bool HealerTeamHpDetect()      // Team 체력 감지
    {
        if (gameObject.tag == "Team")
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                Min1 = Player.PlayerHp;
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                Min2 = SonnyMove.SonnyHp;
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                Min3 = BastionMove.BastionHp;
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                Min4 = Shooter_Move.ShooterHp;
            if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                Min5 = BoosterMove.BoosterHp;

            float minHp = Mathf.Min(Min1, Min2, Min3, Min4, Min5);
            wtimer += Time.deltaTime;

            if (wtimer > etimer)
            {
                if (minHp == Min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    Player.PlayerHp += 1;
                }
                if (minHp == Min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                {
                    SonnyMove.SonnyHp += 1;
                }
                if (minHp == Min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                {
                    BastionMove.BastionHp += 1;
                }
                if (minHp == Min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    Shooter_Move.ShooterHp += 1;
                }
                if (minHp == Min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
                {
                    BoosterMove.BoosterHp += 1;
                }
                wtimer = 0;
                return true;
            }

        }

        if (gameObject.tag == "Enemy")
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                Min1 = Player.PlayerHp;
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                Min2 = SonnyMove.SonnyHp;
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                Min3 = BastionMove.BastionHp;
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                Min4 = Shooter_Move.ShooterHp;
            if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                Min5 = BoosterMove.BoosterHp;

            float minHp = Mathf.Min(Min1, Min2, Min3, Min4, Min5);
            wtimer += Time.deltaTime;

            if (wtimer > etimer)
            {
                if (minHp == Min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    Player.PlayerHp += 1;
                }
                if (minHp == Min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                {
                    SonnyMove.SonnyHp += 1;
                }
                if (minHp == Min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                {
                    BastionMove.BastionHp += 1;
                }
                if (minHp == Min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    Shooter_Move.ShooterHp += 1;
                }
                if (minHp == Min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
                {
                    BoosterMove.BoosterHp += 1;
                }
                wtimer = 0;
                return true;
            }
        }
        return false;
    }

    public bool HealerMyHpDetect()    // 자기 체력 감지
    {
        wtimer2 += Time.deltaTime;
        if (wtimer2 > etimer2)
        {
            if (HealerHp <= 30)
            {
                HealerHp += 10;
            }
            return true;
        }
        return false;
    }

    public bool HealerIsDead() // Enemy의 죽음
    {
        if (HealerHp <= 0)
        {
            gameObject.active = false;
            return false;
        }
        return true;
    }

    void OnCollisionEnter(Collision collision)
    {

        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
            //Debug.Log("healer큐브 충돌");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
            //Debug.Log("healer큐브 충돌2");
        }
    }

}