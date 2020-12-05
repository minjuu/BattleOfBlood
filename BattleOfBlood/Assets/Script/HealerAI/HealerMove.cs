using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerMove : MonoBehaviour
{
    public Rigidbody rb;
    public static float HealerSpeed = 3f;
    public static int HealerHp = 100;
    public static int SonnyHp = 100;

    public static int healer_dir = -1;
    private float x;
    private float z;

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

    public Transform target;
    private float relativeHeigth = 1.0f; // 높이 즉 y값
    private float zDistance = -1.0f;// z값 나는 사실 필요 없었다.
    private float xDistance = 1.0f; // x값
    public float dampSpeed = 1;  // 따라가는 속도 짧으면 타겟과 같이 움직인다.


    public bool MoveHealer()
    {
        /*
        Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // 타겟 포지선에 해당 위치를 더해.. 즉 타겟 주변에 위치할 위치를 담는다.. 일정의 거리를 구하는 방법
        Dir = Player.PlayerPos - gameObject.transform.position;
        Dir.Normalize();
        Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
        DirR = Rot.eulerAngles.y;
        gameObject.transform.localRotation = Rot;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);
        */

        if (HealerHp > 0)
        {
            if (gameObject.tag == "Team")
            {
                int minHp = Mathf.Min(Player.PlayerHp, SonnyHp, BastionMove.BastionHp, Shooter_Move.ShooterHp, BoosterMove.BoosterHp);
                Debug.Log(minHp);
                if (minHp == Player.PlayerHp && GameObject.Find("Player").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minHp == SonnyHp && GameObject.Find("Sonny").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minHp == BastionMove.BastionHp && GameObject.Find("Bastion").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minHp == Shooter_Move.ShooterHp && GameObject.Find("Shooter").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Shooter");
                }
                if (minHp == BoosterMove.BoosterHp && GameObject.Find("Booster").gameObject.tag == "Team")
                {
                    shortEnemy = GameObject.Find("Booster");
                }
                Debug.Log(shortEnemy.name);
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

                float gtimer3 = Time.time;
                float etimer3 = gtimer3 + 0.035f;
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
                        if (z < 0) 
                            healer_dir = 2;
                        if (z >= 0)
                            healer_dir = 3;
                    }
                    if (cubecol == true)
                        healer_dir = Random.Range(0, 4);
                    if (Shooter_Move.ShooterHp >= 0 || col == true)
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

                    cubecol = false;
                    col = false;
                }
                Vector3 newVelocity = lookat * HealerSpeed;
                // 리지드바디의 속도에 newVelocity 할당
                rb.velocity = newVelocity;
            }
        

            if (gameObject.tag == "Enemy")
            {
                int minHp = Mathf.Min(Player.PlayerHp, SonnyHp, BastionMove.BastionHp, Shooter_Move.ShooterHp, BoosterMove.BoosterHp);
                Debug.Log(minHp);
                if (minHp == Player.PlayerHp && GameObject.Find("Player").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Player");
                }
                if (minHp == SonnyHp && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Sonny");
                }
                if (minHp == BastionMove.BastionHp && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Bastion");
                }
                if (minHp == Shooter_Move.ShooterHp && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Shooter");
                }
                if (minHp == BoosterMove.BoosterHp && GameObject.Find("Booster").gameObject.tag == "Enemy")
                {
                    shortEnemy = GameObject.Find("Booster");
                }
                Debug.Log(shortEnemy.name);
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

                float gtimer3 = Time.time;
                float etimer3 = gtimer3 + 0.035f;
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
                        healer_dir = Random.Range(0, 4);
                    if (Shooter_Move.ShooterHp >= 0 || col == true)
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

                    cubecol = false;
                    col = false;

                }
                Vector3 newVelocity = lookat * HealerSpeed;
                // 리지드바디의 속도에 newVelocity 할당
                rb.velocity = newVelocity;

            }
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }

    public bool HealerObstacleDetect()
    {
        if (cubecol == true)
        {
            cubecol = false;
            return true;
        }
        return false;
    }

    public bool HealerTeamHpDetect()      // Team 체력 감지
    {
        int minHp = Mathf.Min(Player.PlayerHp, SonnyHp, BastionMove.BastionHp, Shooter_Move.ShooterHp, HealerHp, BoosterMove.BoosterHp);

        if (minHp == Player.PlayerHp && GameObject.Find("Player").gameObject.tag == "team")
        {
            Player.PlayerHp += 10;
        }
        if (minHp == SonnyHp && GameObject.Find("Sonny").gameObject.tag == "team")
        {
            SonnyHp += 10;
        }
        if (minHp == BastionMove.BastionHp && GameObject.Find("Bastion").gameObject.tag == "team")
        {
            BastionMove.BastionHp += 10;
        }
        if (minHp == Shooter_Move.ShooterHp && GameObject.Find("Shooter").gameObject.tag == "team")
        {
            Shooter_Move.ShooterHp += 10;
        }
        if (minHp == HealerHp && GameObject.Find("Healer").gameObject.tag == "team")
        {
            HealerHp += 10;
        }
        if (minHp == BoosterMove.BoosterHp && GameObject.Find("Booster").gameObject.tag == "team")
        {
            BoosterMove.BoosterHp += 10;
        }
        return false;
    }

    public bool HealerMyHpDetect()    // 자기 체력 감지
    {
        if (HealerHp <= 30)
        {
            HealerHp += 20;
            return false;
        }
        return true;
    }

    public bool HealerIsDead() // Enemy의 죽음
    {
        if (HealerHp <= 0) // Enemy의 체력이 0이하이면
        {
            Debug.Log("Dead");
            return false; // false를 반환하고 노드가 끝난다.
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
            Debug.Log("큐브 충돌");
        }
    }

}