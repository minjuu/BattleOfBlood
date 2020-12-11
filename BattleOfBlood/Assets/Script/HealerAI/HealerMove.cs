using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerMove : MonoBehaviour
{
    public static float HealerSpeed = 0.01f; //힐러 속도
    public static int HealerHp = 100; //힐러 체력

    public GameObject Prefab_bullet; //총알 오브젝트
    int nTime = 0;

    private bool col; //충돌 확인 변수
    public static bool cubecol; //큐브 충돌 확인 변수
    public static Vector3 cube_position; //큐브

    Vector3 lookat; //바라보는 방향
    public GameObject shortEnemy; //힐러와 가장 가까운 팀원
    float shortDistance;

    float wtimer; //시작 타이머1
    float etimer; //종료 타이머1
    float wtimer2; //시작 타이머2
    float etimer2; //종료 타이머2
    float gtimer3; //시작 타이머1
    float etimer3; //종료 타이머2
    int count;

    float min1, min2, min3, min4, min5; //가장 적은 체력 감지하는 변수
    float Min1, Min2, Min3, Min4, Min5;

    public static int healer_dir = -1; //힐러가 바라보는 방향
    private float x; //x좌표
    private float z; //z좌표
    public Rigidbody rb;

    public bool MoveHealer() //힐러 움직임 노드
    {
        if (HealerHp > 0)
        {
            if (gameObject.tag == "Team") //힐러의 태그가 팀이면
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //플레이어가 팀이면 min변수에 Hp를 넣음
                    min1 = Player.PlayerHp;
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //쏘니가 팀이면 min변수에 Hp를 넣음
                    min2 = SonnyMove.SonnyHp;
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //바스티온이 팀이면 min변수에 Hp를 넣음
                    min3 = BastionMove.BastionHp;
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //슈터가 팀이면 min변수에 Hp를 넣음
                    min4 = Shooter_Move.ShooterHp;
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team") //부스터가 팀이면 min변수에 Hp를 넣음
                    min5 = BoosterMove.BoosterHp;

                float MinHp = Mathf.Min(min1, min2, min3, min4, min5); //가장 적은 체력 계산

                if (MinHp == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //가장 적은 체력이 플레이어면
                {
                    shortEnemy = GameObject.Find("Player");
                    shortDistance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position); //플레이어와의 거리를 계산
                }
                if (MinHp == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //가장 적은 체력이 쏘니면
                {
                    shortEnemy = GameObject.Find("Sonny");
                    shortDistance = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position); //쏘니와의 거리를 계산
                }
                if (MinHp == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //가장 적은 체력이 바스티온이면
                {
                    shortEnemy = GameObject.Find("Bastion");
                    shortDistance = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position); //바스티온과의 거리를 계산
                }
                if (MinHp == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //가장 적은 체력이 슈터면
                {
                    shortEnemy = GameObject.Find("Shooter");
                    shortDistance = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position); //슈터와의 거리를 계산
                }
                if (MinHp == min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team") //가장 적은 체력이 부스터면
                {
                    shortEnemy = GameObject.Find("Booster");
                    shortDistance = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position); //부스터와의 거리를 계산
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

                gtimer3 += Time.deltaTime; //움직임 타이머 작동

                x = gameObject.transform.position.x - shortEnemy.transform.position.x;
                z = gameObject.transform.position.z - shortEnemy.transform.position.z;
                if (gtimer3 > etimer3) //타이머 시간동안
                {
                    
                    if (Mathf.Abs(x) > Mathf.Abs(z)) //x좌표가 z좌표보다 크면 x좌표쪽으로 이동
                    {
                        if (x < 0)
                            healer_dir = 0;
                        if (x >= 0)
                            healer_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z)) //z좌표가 x좌표보다 크면 z좌표쪽으로 이동
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            healer_dir = 2;
                        if (z >= 0)
                            healer_dir = 3;
                    }
                    if (cubecol == true) //큐브와 충돌하면
                    {
                        healer_dir = Random.Range(0, 4); //방향을 바꿔줌
                    }
                    if (MinHp == 0) //같은 팀이 다 죽으면
                        healer_dir = Random.Range(0, 4); //랜덤하게 방향 설정

                    if (HealerHp >= 0 || col == true) //힐러의 방향 설정
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
                transform.position += lookat * HealerSpeed; //설정한 방향으로 힐러의 속도만큼 이동함
            }

            if (gameObject.tag == "Enemy") //힐러의 태그가 적이면
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //플레이어가 적이면 min변수에 Hp를 넣음
                    min1 = Player.PlayerHp;
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //쏘니가 적이면 min변수에 Hp를 넣음
                    min2 = SonnyMove.SonnyHp;
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //바스티온이 적이면 min변수에 Hp를 넣음
                    min3 = BastionMove.BastionHp;
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //슈터가 적이면 min변수에 Hp를 넣음
                    min4 = Shooter_Move.ShooterHp;
                if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy") //부스터가 적이면 min변수에 Hp를 넣음
                    min5 = BoosterMove.BoosterHp;

                float MinHp = Mathf.Min(min1, min2, min3, min4, min5); //가장 적은 체력 계산

                if (MinHp == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //가장 적은 체력이 플레이어면
                {
                    shortEnemy = GameObject.Find("Player");
                    shortDistance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position); //플레이어와의 거리 감지
                }
                if (MinHp == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //가장 적은 체력이 쏘니면
                {
                    shortEnemy = GameObject.Find("Sonny");
                    shortDistance = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position); //쏘니와의 거리 감지
                }
                if (MinHp == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //가장 적은 체력이 바스티온이면
                {
                    shortEnemy = GameObject.Find("Bastion");
                    shortDistance = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position); //바스티온와의 거리 감지
                }
                if (MinHp == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //가장 적은 체력이 슈터면
                {
                    shortEnemy = GameObject.Find("Shooter");
                    shortDistance = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position); //슈터와의 거리 감지
                }
                if (MinHp == min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy") //가장 적은 체력이 부스터면
                {
                    shortEnemy = GameObject.Find("Booster");
                    shortDistance = Vector3.Distance(GameObject.Find("Booster").transform.position, gameObject.transform.position); //부스터와의 거리 감지
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

                gtimer3 += Time.deltaTime; //움직임 타이머 작동

                x = gameObject.transform.position.x - shortEnemy.transform.position.x;
                z = gameObject.transform.position.z - shortEnemy.transform.position.z;
                if (gtimer3 > etimer3) //타이머 시간동안
                {

                    if (Mathf.Abs(x) > Mathf.Abs(z)) //x좌표가 z좌표보다 크면 x쪽으로 이동
                    {
                        if (x < 0)
                            healer_dir = 0;
                        if (x >= 0)
                            healer_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z))//z좌표가 x좌표보다 크면 z쪽으로 이동
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            healer_dir = 2;
                        if (z >= 0)
                            healer_dir = 3;
                    }
                    if (cubecol == true) //큐브와 충돌하면
                    {
                        healer_dir = Random.Range(0, 4); //방향 변경
                    }
                    if (MinHp == 0) //같은 팀이 다 죽으면
                        healer_dir = Random.Range(0, 4); //랜덤하게 방향 설정
                    if (HealerHp >= 0 || col == true) //힐러의 방향 설정
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
                transform.position += lookat * HealerSpeed; //바라보는 방향으로 힐러 속도만큼 이동
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
        etimer = wtimer + 1f;
        wtimer2 = 0.0f;
        etimer = wtimer + 1000f;
        gtimer3 = 0;
        etimer3 = gtimer3 + 5f;
        count = 0;

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
        if (gameObject.tag == "Team") //힐러의 태그가 팀이면
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //가장 적은 체력이 플레이어면
                Min1 = Player.PlayerHp;
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //가장 적은 체력이 쏘니면
                Min2 = SonnyMove.SonnyHp;
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //가장 적은 체력이 바스티온이면
                Min3 = BastionMove.BastionHp;
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //가장 적은 체력이 슈터면
                Min4 = Shooter_Move.ShooterHp;
            if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team") //가장 적은 체력이 부스터면
                Min5 = BoosterMove.BoosterHp;

            float minHp = Mathf.Min(Min1, Min2, Min3, Min4, Min5); //가장 적은 체력 계산
            wtimer += Time.deltaTime;

            if (wtimer > etimer) //타이머 시간동안
            {
                if (minHp == Min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //플레이어의 체력을 높여줌
                {
                    Player.PlayerHp += 1;
                }
                if (minHp == Min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //쏘니의 체력을 높여줌
                {
                    SonnyMove.SonnyHp += 1;
                }
                if (minHp == Min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //바스티온의 체력을 높여줌
                {
                    BastionMove.BastionHp += 1;
                }
                if (minHp == Min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //슈터의 체력을 높여줌
                {
                    Shooter_Move.ShooterHp += 1;
                }
                if (minHp == Min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team") //부스터의 체력을 높여줌
                {
                    BoosterMove.BoosterHp += 1;
                }
                wtimer = 0;
                return true;
            }

        }

        if (gameObject.tag == "Enemy") //힐러의 태그가 적이면
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //가장 적은 체력이 플레이어면
                Min1 = Player.PlayerHp;
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //가장 적은 체력이 쏘니면
                Min2 = SonnyMove.SonnyHp;
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //가장 적은 체력이 바스티온면
                Min3 = BastionMove.BastionHp;
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //가장 적은 체력이 슈터면
                Min4 = Shooter_Move.ShooterHp;
            if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy") //가장 적은 체력이 부스터면
                Min5 = BoosterMove.BoosterHp;

            float minHp = Mathf.Min(Min1, Min2, Min3, Min4, Min5); //가장 적은 체력 계산
            wtimer += Time.deltaTime;

            if (wtimer > etimer) //타이머 시간동안
            {
                if (minHp == Min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //플레이어의 체력을 높여줌
                {
                    Player.PlayerHp += 1;
                }
                if (minHp == Min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //쏘니의 체력을 높여줌
                {
                    SonnyMove.SonnyHp += 1;
                }
                if (minHp == Min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //바스티온의 체력을 높여줌
                {
                    BastionMove.BastionHp += 1;
                }
                if (minHp == Min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //슈터의 체력을 높여줌
                {
                    Shooter_Move.ShooterHp += 1;
                }
                if (minHp == Min5 && GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy") //부스터의 체력을 높여줌
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
        if (count < 1)
        {
            if (HealerHp <= 10) //힐러의 체력이 10 이하이면
            {
                HealerHp += 10; //10을 높여줌
                count++;
            }
            return true;
        }
        return false;
    }

    public bool HealerIsDead() // Enemy의 죽음
    {
        if (HealerHp <= 0) //힐러가 죽으면
        {
            gameObject.active = false; //오브젝트를 비활성화시킴
            return false;
        }
        return true;
    }

    void OnCollisionEnter(Collision collision) //충돌감지
    {

        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
        }
    }

    void OnCollisionStay(Collision collision) //충돌감지
    {
        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
        }
    }

}