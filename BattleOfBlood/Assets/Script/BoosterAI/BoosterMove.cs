using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMove : MonoBehaviour
{
    public static float BoosterSpeed = 0.03f;
    public static int BoosterHp = 100;

    public GameObject Prefab_bullet;
    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.02f;
    int nTime = 0;

    public Rigidbody rb;
    float shortDistance;
    public GameObject shortEnemy;
    public GameObject ShortEnemy;
    public GameObject ShortEnemy2;
    float distance = 0.0f;
    int sd_1 = 0;

    float wtimer;
    float wtimer2;
    float etimer;
    float etimer2;
    float gtimer3;
    float etimer3;

    public static int booster_dir = -1;
    private float x;
    private float z;

    Vector3 Enemy_Dir;
    Vector3 lookat;
    float min1, min2, min3, min4, min5;
    float Min1, Min2, Min3, Min4, Min5;
    float MMin1, MMin2, MMin3, MMin4, MMin5;

    private bool col;
    public static bool cubecol;
    public static Vector3 cube_position;

    Vector3 Pos;

    // Start is called before the first frame update
    public bool MoveBooster()
    {
        if (BoosterHp > 0)
        {
            if (gameObject.tag == "Team")
            {
                if (GameObject.Find("Player").gameObject.tag == "Team")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Team")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion").gameObject.tag == "Team")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter").gameObject.tag == "Team")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer").gameObject.tag == "Team")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5);

                if (minDistance == min1 && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minDistance == min2 && GameObject.Find("Sonny").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minDistance == min3 && GameObject.Find("Bastion").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minDistance == min4 && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Shooter");
                }
                if (minDistance == min5 && GameObject.Find("Healer").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Healer");
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);

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
                    //Debug.Log("aaaa");
                    if (Mathf.Abs(x) > Mathf.Abs(z))
                    {
                        if (x < 0)
                            booster_dir = 0;
                        if (x >= 0)
                            booster_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z))
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            booster_dir = 2;
                        if (z >= 0)
                            booster_dir = 3;
                    }

                    if (cubecol == true)
                    {
                        Debug.Log("cubecol");
                        booster_dir = Random.Range(0, 4);
                    }

                    if (BoosterHp >= 0 || col == true)
                    {
                        if (booster_dir == 0)
                        {
                            lookat = new Vector3(1, 0, 0);
                        }
                        if (booster_dir == 1)
                        {
                            lookat = new Vector3(-1, 0, 0);
                        }
                        if (booster_dir == 2)
                        {
                            lookat = new Vector3(0, 0, 1);
                        }
                        if (booster_dir == 3)
                        {
                            lookat = new Vector3(0, 0, -1);
                        }
                        if (booster_dir == 4)
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
                transform.position += lookat * BoosterSpeed;
                //Vector3 newVelocity = lookat * BoosterSpeed;
                //rb.velocity = newVelocity;
            }
            //Debug.Log("bbb");
            if (gameObject.tag == "Enemy")
            {
                if (GameObject.Find("Player").gameObject.tag == "Enemy")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion").gameObject.tag == "Enemy")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter").gameObject.tag == "Enemy")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer").gameObject.tag == "Enemy")
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5);

                if (minDistance == min1 && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minDistance == min2 && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minDistance == min3 && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minDistance == min4 && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Shooter");
                }
                if (minDistance == min5 && GameObject.Find("Healer").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Healer");
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);

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
                            booster_dir = 0;
                        if (x >= 0)
                            booster_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z))
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            booster_dir = 2;
                        if (z >= 0)
                            booster_dir = 3;
                    }
                    if (cubecol == true)
                        booster_dir = Random.Range(0, 4);

                    if (BoosterHp >= 0 || col == true)
                    {
                        if (booster_dir == 0)
                        {
                            lookat = new Vector3(1, 0, 0);
                        }
                        if (booster_dir == 1)
                        {
                            lookat = new Vector3(-1, 0, 0);
                        }
                        if (booster_dir == 2)
                        {
                            lookat = new Vector3(0, 0, 1);
                        }
                        if (booster_dir == 3)
                        {
                            lookat = new Vector3(0, 0, -1);
                        }
                        if (booster_dir == 4)
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
                transform.position += lookat * BoosterSpeed;
                //Vector3 newVelocity = lookat * BoosterSpeed;
                // 리지드바디의 속도에 newVelocity 할당
                //rb.velocity = newVelocity;
            }
            return true;
        }
        return false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nTime = 0;
        wtimer = 0;
        wtimer2 = 0;
        etimer = wtimer + 3f;
        etimer2 = wtimer2 + 3f;
        gtimer3 = 0;
        etimer3 = gtimer3 + 1f;

        Pos = gameObject.transform.position;

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

        MMin1 = 100000;
        MMin2 = 100000;
        MMin3 = 100000;
        MMin4 = 100000;
        MMin5 = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }

    public bool BoosterTeamPosDetect()
    {
        if (gameObject.tag == "Team")
        {
            if (GameObject.Find("Player").gameObject.tag == "Team")
                Min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny").gameObject.tag == "Team")
                Min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion").gameObject.tag == "Team")
                Min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter").gameObject.tag == "Team")
                Min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer").gameObject.tag == "Team")
                Min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MinDistance = Mathf.Min(Min1, Min2, Min3, Min4, Min5);

            if (MinDistance == Min1 && GameObject.Find("Player").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Player");
            }
            if (MinDistance == Min2 && GameObject.Find("Sonny").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Sonny");
            }
            if (MinDistance == Min3 && GameObject.Find("Bastion").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Bastion");
            }
            if (MinDistance == Min4 && GameObject.Find("Shooter").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Shooter");
            }
            if (MinDistance == Min5 && GameObject.Find("Healer").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Healer");
            }

            wtimer += Time.deltaTime;

            if (wtimer < etimer)
            {
                if (ShortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 10f;
                }
                if (ShortEnemy == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0.1f;
                }
                if (ShortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0.1f;
                }
                if (ShortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 10f;
                }
                if (ShortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0.1f;
                }
            }
            else if (wtimer < (etimer + 3f))
            {
                if (ShortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 3f;
                }
                if (ShortEnemy == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0.03f;
                }
                if (ShortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0.01f;
                }
                if (ShortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (ShortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0.02f;
                }
            }
            else
            {
                wtimer = 0;
                return true;
            }

        }

        if (gameObject.tag == "Enemy")
        {
            if (GameObject.Find("Player").gameObject.tag == "Enemy")
                Min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
                Min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion").gameObject.tag == "Enemy")
                Min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter").gameObject.tag == "Enemy")
                Min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer").gameObject.tag == "Enemy")
                Min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MinDistance = Mathf.Min(Min1, Min2, Min3, Min4, Min5);

            if (MinDistance == Min1 && GameObject.Find("Player").gameObject.tag == "Enemy")
            {
                ShortEnemy = GameObject.Find("Player");
            }
            if (MinDistance == Min2 && GameObject.Find("Sonny").gameObject.tag == "Enemy")
            {
                ShortEnemy = GameObject.Find("Sonny");
            }
            if (MinDistance == Min3 && GameObject.Find("Bastion").gameObject.tag == "Enemy")
            {
                ShortEnemy = GameObject.Find("Bastion");
            }
            if (MinDistance == Min4 && GameObject.Find("Shooter").gameObject.tag == "Enemy")
            {
                ShortEnemy = GameObject.Find("Shooter");
            }
            if (MinDistance == Min5 && GameObject.Find("Healer").gameObject.tag == "Enemy")
            {
                ShortEnemy = GameObject.Find("Healer");
            }

            wtimer += Time.deltaTime;

            if (wtimer < etimer)
            {
                if (ShortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 10f;
                }
                if (ShortEnemy == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0.1f;
                }
                if (ShortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0.1f;
                }
                if (ShortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 10f;
                }
                if (ShortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed += 0.1f;
                }
            }
            else if (wtimer < (etimer + 3f))
            {
                if (ShortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 3f;
                }
                if (ShortEnemy == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0.03f;
                }
                if (ShortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0.01f;
                }
                if (ShortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (ShortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0.02f;
                }
            }
            else
            {
                wtimer = 0;
                return true;
            }
        }
        return false;
    }

    public bool BoosterEnemyPosDetect()      // 적 위치 감지
    {
        if (gameObject.tag == "Team")
        {
            if (GameObject.Find("Player").gameObject.tag == "Enemy")
                MMin1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
                MMin2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion").gameObject.tag == "Enemy")
                MMin3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter").gameObject.tag == "Enemy")
                MMin4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer").gameObject.tag == "Enemy")
                MMin5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MMinDistance = Mathf.Min(MMin1, MMin2, MMin3, MMin4, MMin5);

            if (MMinDistance == MMin1 && GameObject.Find("Player").gameObject.tag == "Enemy")
            {
                ShortEnemy2 = GameObject.Find("Player");
            }
            if (MMinDistance == MMin2 && GameObject.Find("Sonny").gameObject.tag == "Enemy")
            {
                ShortEnemy2 = GameObject.Find("Sonny");
            }
            if (MMinDistance == MMin3 && GameObject.Find("Bastion").gameObject.tag == "Enemy")
            {
                ShortEnemy2 = GameObject.Find("Bastion");
            }
            if (MMinDistance == MMin4 && GameObject.Find("Shooter").gameObject.tag == "Enemy")
            {
                ShortEnemy2 = GameObject.Find("Shooter");
            }
            if (MMinDistance == MMin5 && GameObject.Find("Healer").gameObject.tag == "Enemy")
            {
                ShortEnemy2 = GameObject.Find("Healer");
            }

            wtimer2 += Time.deltaTime;

            if (wtimer2 < etimer2)
            {
                if (ShortEnemy2 == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0f;
                }
            }
            else if (wtimer2 < (etimer2 + 3f))
            {
                if (ShortEnemy2 == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 3f;
                }
                if (ShortEnemy2 == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0.03f;
                }
                if (ShortEnemy2 == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0.01f;
                }
                if (ShortEnemy2 == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (ShortEnemy2 == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0.02f;
                }
            }
            else
            {
                wtimer2 = 0;
                return true;
            }
        }

        if (gameObject.tag == "Enemy")
        {
            if (GameObject.Find("Player").gameObject.tag == "Team")
                MMin1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny").gameObject.tag == "Team")
                MMin2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion").gameObject.tag == "Team")
                MMin3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter").gameObject.tag == "Team")
                MMin4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer").gameObject.tag == "Team")
                MMin5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MMinDistance = Mathf.Min(MMin1, MMin2, MMin3, MMin4, MMin5);

            if (MMinDistance == MMin1 && GameObject.Find("Player").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Player");
            }
            if (MMinDistance == MMin2 && GameObject.Find("Sonny").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Sonny");
            }
            if (MMinDistance == MMin3 && GameObject.Find("Bastion").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Bastion");
            }
            if (MMinDistance == MMin4 && GameObject.Find("Shooter").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Shooter");
            }
            if (MMinDistance == MMin5 && GameObject.Find("Healer").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Healer");
            }

            wtimer2 += Time.deltaTime;

            if (wtimer2 < etimer2)
            {
                if (ShortEnemy2 == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 0f;
                }
                if (ShortEnemy2 == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0f;
                }
            }
            else if (wtimer2 < (etimer2 + 3f))
            {
                if (ShortEnemy2 == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 3f;
                }
                if (ShortEnemy2 == GameObject.Find("Sonny"))
                {
                    SonnyMove.SonnySpeed = 0.03f;
                }
                if (ShortEnemy2 == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0.01f;
                }
                if (ShortEnemy2 == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (ShortEnemy2 == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0.02f;
                }
            }
            else
            {
                wtimer2 = 0;
                return true;
            }
        }
        return false;
    }

    public bool BoosterIsDead() // Enemy의 죽음
    {
        if (BoosterHp <= 0)
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
            Debug.Log("booster큐브 충돌");
        }
    }
    void OnCollisionStay(Collision collision)
    {
        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
            Debug.Log("booster큐브 충돌2");
        }
    }
}