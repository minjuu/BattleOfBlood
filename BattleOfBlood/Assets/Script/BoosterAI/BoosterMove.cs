using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMove : MonoBehaviour
{
    public static float BoosterSpeed = 0.01f; //부스터 속도
    public static int BoosterHp = 100; //부스터 체력

    public GameObject Prefab_bullet; //총알 프리펩
    int nTime = 0;

    public Rigidbody rb;
    float shortDistance; //가장 가까운 거리 계산
    public GameObject shortEnemy; //가장 가까운 오브젝트
    public GameObject ShortEnemy;
    public GameObject ShortEnemy2;

    float wtimer; //시작 타이머와 종료 타이머 3세트
    float wtimer2;
    float etimer;
    float etimer2;
    float gtimer3;
    float etimer3;

    public static int booster_dir = -1; //부스터가 바라보는 방향
    private float x; //x좌표
    private float z; //z좌표

    Vector3 lookat; //방향변수
    float min1, min2, min3, min4, min5; //가장 작은 거리 계산용 변수
    float Min1, Min2, Min3, Min4, Min5;
    float MMin1, MMin2, MMin3, MMin4, MMin5;

    private bool col; //충돌 감지 변수
    public static bool cubecol; //큐브 충돌 감지 변수
    public static Vector3 cube_position;

    // Start is called before the first frame update
    public bool MoveBooster() //부스터 이동 함수
    {
        if (BoosterHp > 0)
        {
            if (gameObject.tag == "Team") //부스터의 태그가 팀이면
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //플레이어가 팀이면 min변수에 거리를 넣음
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //쏘니가 팀이면 min변수에 거리를 넣음
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //바스티온이 팀이면 min변수에 거리를 넣음
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //슈터가 팀이면 min변수에 거리를 넣음
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team") //힐러가 팀이면 min변수에 거리를 넣음
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5); //가장 적은 거리 계산

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //가장 가까운 거리가 플레이어면
                {
                    shortEnemy = GameObject.Find("Player"); //플레이어를 shortEnemy에 넣음
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //가장 가까운 거리가 쏘니면
                {
                    shortEnemy = GameObject.Find("Sonny"); //쏘니를 shortEnemy에 넣음
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //가장 가까운 거리가 바스티온이면
                {
                    shortEnemy = GameObject.Find("Bastion"); //바스티온을 shortEnemy에 넣음
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //가장 가까운 거리가 슈터면
                {
                    shortEnemy = GameObject.Find("Shooter"); //슈터를 shortEnemy에 넣음
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team") //가장 가까운 거리가 힐러면
                {
                    shortEnemy = GameObject.Find("Healer"); //힐러를 shortEnemy에 넣음
                }

                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position); //거리 계산

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

                gtimer3 += Time.deltaTime; //타이머 작동

                x = gameObject.transform.position.x - shortEnemy.transform.position.x;
                z = gameObject.transform.position.z - shortEnemy.transform.position.z;

                if (gtimer3 > etimer3)
                {
                    if (Mathf.Abs(x) > Mathf.Abs(z)) //x좌표가 z좌표보다 크면 x좌표로 설정
                    {
                        if (x < 0)
                            booster_dir = 0;
                        if (x >= 0)
                            booster_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z)) //z좌표가 x좌표보다 크면 z좌표로 설정
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            booster_dir = 2;
                        if (z >= 0)
                            booster_dir = 3;
                    }

                    if (cubecol == true) //큐브와 부딪히면 방향 재설정
                    {
                        booster_dir = Random.Range(0, 4);
                    }

                    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene") //스테이지 1에서 같은 팀이 다 죽으면 방향 재설정
                    {
                        if (Player.Team_Hp[0] + Player.Team_Hp[1] == BoosterHp)
                            booster_dir = Random.Range(0, 4);
                    }
                    else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2") //스테이지 2에서 같은 팀이 다 죽으면 방향 재설정
                    {
                        if (Player.Team_Hp[0] + Player.Team_Hp[1] + Player.Team_Hp[2] == BoosterHp)
                            booster_dir = Random.Range(0, 4);
                    }

                    if (BoosterHp >= 0 || col == true) //부스터 방향 설정
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
                transform.position += lookat * BoosterSpeed; //바라보는 방향으로 부스터를 이동시킴
            }

            if (gameObject.tag == "Enemy") //부스터의 태그가 적이면
            {
                shortEnemy = GameObject.Find("Player");

                if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //플레이어가 팀이면 min변수에 거리를 넣음
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //쏘니가 팀이면 min변수에 거리를 넣음
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //바스티온이 팀이면 min변수에 거리를 넣음
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //슈터가 팀이면 min변수에 거리를 넣음
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy") //힐러가 팀이면 min변수에 거리를 넣음
                    min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

                float minDistance = Mathf.Min(min1, min2, min3, min4, min5);

                if (minDistance == min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //가장 가까운 거리가 플레이어면
                {
                    shortEnemy = GameObject.Find("Player"); //플레이어를 shortEnemy에 넣음
                }
                if (minDistance == min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //가장 가까운 거리가 쏘니면
                {
                    shortEnemy = GameObject.Find("Sonny"); //쏘니를 shortEnemy에 넣음
                }
                if (minDistance == min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //가장 가까운 거리가 바스티온이면
                {
                    shortEnemy = GameObject.Find("Bastion"); //바스티온을 shortEnemy에 넣음
                }
                if (minDistance == min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //가장 가까운 거리가 슈터면
                {
                    shortEnemy = GameObject.Find("Shooter"); //슈터를 shortEnemy에 넣음
                }
                if (minDistance == min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy") //가장 가까운 거리가 힐러면
                {
                    shortEnemy = GameObject.Find("Healer"); //힐러를 shortEnemy에 넣음
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

                gtimer3 += Time.deltaTime; //타이머 작동

                x = gameObject.transform.position.x - shortEnemy.transform.position.x;
                z = gameObject.transform.position.z - shortEnemy.transform.position.z;
                if (gtimer3 > etimer3) //타이머 시간동안
                {

                    if (Mathf.Abs(x) > Mathf.Abs(z)) //X좌표가 Z좌표보다 크면 X쪽으로 이동
                    {
                        if (x < 0)
                            booster_dir = 0;
                        if (x >= 0)
                            booster_dir = 1;
                    }
                    if (Mathf.Abs(x) < Mathf.Abs(z)) //Z좌표가 X좌표보다 크면 Z쪽으로 이동
                    {
                        if (z < 0) //적이 슈터보다 z값큼
                            booster_dir = 2;
                        if (z >= 0)
                            booster_dir = 3;
                    }
                    if (cubecol == true) //큐브와 충돌하면 방향재설정
                        booster_dir = Random.Range(0, 4);

                    if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene") //스테이지 1에서 팀원이 다 죽으면 방향 재설정
                    {
                        if (Player.Team_Hp[0] + Player.Team_Hp[1] == BoosterHp)
                            booster_dir = Random.Range(0, 4);
                    }
                    else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2") //스테이지 2에서 팀원이 다 죽으면 방향 재설정
                    {
                        if (Player.Team_Hp[0] + Player.Team_Hp[1] + Player.Team_Hp[2] == BoosterHp)
                            booster_dir = Random.Range(0, 4);
                    }

                    if (BoosterHp >= 0 || col == true) //부스터의 방향 설정
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
                transform.position += lookat * BoosterSpeed; //바라보는 방향으로 부스터를 이동시킴
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
        etimer = wtimer + 1f;
        etimer2 = wtimer2 + 1f;
        gtimer3 = 0;
        etimer3 = gtimer3 + 5f;

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
        if (gameObject.tag == "Team") //힐러의 태그가 팀이면
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //플레이어가 팀이면 min변수에 거리를 넣음
                Min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team") //쏘니가 팀이면 min변수에 거리를 넣음
                Min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team") //바스티온이 팀이면 min변수에 거리를 넣음
                Min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team") //슈터가 팀이면 min변수에 거리를 넣음
                Min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team") //힐러가 팀이면 min변수에 거리를 넣음
                Min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MinDistance = Mathf.Min(Min1, Min2, Min3, Min4, Min5); //가장 적은 거리 계산

            if (MinDistance == Min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Player"); //플레이어를 shortEnemy에 넣음
            }
            if (MinDistance == Min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Sonny"); //쏘니를 shortEnemy에 넣음
            }
            if (MinDistance == Min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Bastion"); //바스티온을 shortEnemy에 넣음
            }
            if (MinDistance == Min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Shooter"); //슈터를 shortEnemy에 넣음
            }
            if (MinDistance == Min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
            {
                ShortEnemy = GameObject.Find("Healer"); //힐러를 shortEnemy에 넣음
            }

            wtimer += Time.deltaTime;

            if (wtimer < etimer) //타이머 시간동안
            {
                if (GameObject.Find("Player") != null && ShortEnemy == GameObject.Find("Player")) //플레이어의 속도를 증가시킴
                {
                    Player.PlayerSpeed = 6f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy == GameObject.Find("Sonny")) //쏘니의 속도를 증가시킴
                {
                    SonnyMove.SonnySpeed = 15f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy == GameObject.Find("Bastion")) //바스티온의 속도를 증가시킴
                {
                    BastionMove.BastionSpeed = 15f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy == GameObject.Find("Shooter")) //슈터의 속도를 증가시킴
                {
                    Shooter_Move.ShooterSpeed = 6f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy == GameObject.Find("Healer")) //힐러의 속도를 증가시킴
                {
                    HealerMove.HealerSpeed = 0.02f;
                }
            }
            else if (wtimer < (etimer + 10f))
            {
                if (GameObject.Find("Player") != null && ShortEnemy == GameObject.Find("Player")) //일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    Player.PlayerSpeed = 3f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy == GameObject.Find("Sonny")) //일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    SonnyMove.SonnySpeed = 8f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy == GameObject.Find("Bastion")) //일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    BastionMove.BastionSpeed = 8f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy == GameObject.Find("Shooter")) //일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy == GameObject.Find("Healer")) //일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    HealerMove.HealerSpeed = 0.01f;
                }
            }
            else
            {
                wtimer = 0; //타이머를 리셋함
                return true;
            }

        }

        if (gameObject.tag == "Enemy") //힐러의 태그가 적이면
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //플레이어가 팀이면 min변수에 거리를 넣음
                Min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //쏘니가 팀이면 min변수에 거리를 넣음
                Min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //바스티온가 팀이면 min변수에 거리를 넣음
                Min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //슈터가 팀이면 min변수에 거리를 넣음
                Min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy") //힐러가 팀이면 min변수에 거리를 넣음
                Min5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MinDistance = Mathf.Min(Min1, Min2, Min3, Min4, Min5); //가장 적은 거리를 계산해

            if (MinDistance == Min1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //적은 거리에 해당하는 오브젝트를 shortEnemy 변수에 넣어줌
            {
                ShortEnemy = GameObject.Find("Player");
            }
            if (MinDistance == Min2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //적은 거리에 해당하는 오브젝트를 shortEnemy 변수에 넣어줌
            {
                ShortEnemy = GameObject.Find("Sonny");
            }
            if (MinDistance == Min3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //적은 거리에 해당하는 오브젝트를 shortEnemy 변수에 넣어줌
            {
                ShortEnemy = GameObject.Find("Bastion");
            }
            if (MinDistance == Min4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //적은 거리에 해당하는 오브젝트를 shortEnemy 변수에 넣어줌
            {
                ShortEnemy = GameObject.Find("Shooter");
            }
            if (MinDistance == Min5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy") //적은 거리에 해당하는 오브젝트를 shortEnemy 변수에 넣어줌
            {
                ShortEnemy = GameObject.Find("Healer");
            }

            wtimer += Time.deltaTime; //타이머를 작동시킴

            if (wtimer < etimer) //타이머 시간동안
            {
                if (GameObject.Find("Player") != null && ShortEnemy == GameObject.Find("Player")) //shortEnemy에 해당하는 오브젝트를 확인해 속도를 증가시킴
                {
                    Player.PlayerSpeed = 6f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy == GameObject.Find("Sonny")) //shortEnemy에 해당하는 오브젝트를 확인해 속도를 증가시킴
                {
                    SonnyMove.SonnySpeed = 15f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy == GameObject.Find("Bastion")) //shortEnemy에 해당하는 오브젝트를 확인해 속도를 증가시킴
                {
                    BastionMove.BastionSpeed = 15f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy == GameObject.Find("Shooter")) //shortEnemy에 해당하는 오브젝트를 확인해 속도를 증가시킴
                {
                    Shooter_Move.ShooterSpeed = 6f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy == GameObject.Find("Healer")) //shortEnemy에 해당하는 오브젝트를 확인해 속도를 증가시킴
                {
                    HealerMove.HealerSpeed += 0.02f;
                }
            }
            else if (wtimer < (etimer + 10f)) 
            {
                if (GameObject.Find("Player") != null && ShortEnemy == GameObject.Find("Player"))//일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    Player.PlayerSpeed = 3f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy == GameObject.Find("Sonny"))//일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    SonnyMove.SonnySpeed = 8f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy == GameObject.Find("Bastion"))//일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    BastionMove.BastionSpeed = 8f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy == GameObject.Find("Shooter"))//일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy == GameObject.Find("Healer"))//일정 시간동안 속도를 증가시켰던 오브젝트의 속도를 다시 복구시킴
                {
                    HealerMove.HealerSpeed = 0.01f;
                }
            }
            else
            {
                wtimer = 0; //타이머를 리셋함
                return true;
            }
        }
        return false;
    }

    public bool BoosterEnemyPosDetect()      // 적 위치 감지
    {
        if (gameObject.tag == "Team") //플레이어의 태그가 팀이면
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //각 오브젝트들과의 거리를 계산해 MIN변수에 넣음
                MMin1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
                MMin2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
                MMin3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
                MMin4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
                MMin5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MMinDistance = Mathf.Min(MMin1, MMin2, MMin3, MMin4, MMin5); //거리들 중 가장 가까운 거리를 계산해서

            if (MMinDistance == MMin1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
            {
                ShortEnemy2 = GameObject.Find("Player");
            }
            if (MMinDistance == MMin2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
            {
                ShortEnemy2 = GameObject.Find("Sonny");
            }
            if (MMinDistance == MMin3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
            {
                ShortEnemy2 = GameObject.Find("Bastion");
            }
            if (MMinDistance == MMin4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
            {
                ShortEnemy2 = GameObject.Find("Shooter");
            }
            if (MMinDistance == MMin5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy") //그 거리에 해당하는 오브젝트를 저장함
            {
                ShortEnemy2 = GameObject.Find("Healer");
            }

            wtimer2 += Time.deltaTime; //타이머를 작동시킴

            if (wtimer2 < etimer2) //타이머 시간동안
            {
                if (GameObject.Find("Player") != null && ShortEnemy2 == GameObject.Find("Player")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    Player.PlayerSpeed = 1.5f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy2 == GameObject.Find("Sonny")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    SonnyMove.SonnySpeed = 4f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy2 == GameObject.Find("Bastion")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    BastionMove.BastionSpeed = 4f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy2 == GameObject.Find("Shooter")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    Shooter_Move.ShooterSpeed = 1.5f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy2 == GameObject.Find("Healer")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    HealerMove.HealerSpeed = 0.005f;
                }
            }
            else if (wtimer2 < (etimer2 + 3f)) //일정 시간동안
            {
                if (GameObject.Find("Player") != null && ShortEnemy2 == GameObject.Find("Player")) //shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    Player.PlayerSpeed = 3f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy2 == GameObject.Find("Sonny")) //shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    SonnyMove.SonnySpeed = 8f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy2 == GameObject.Find("Bastion")) //shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    BastionMove.BastionSpeed = 8f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy2 == GameObject.Find("Shooter")) //shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy2 == GameObject.Find("Healer")) //shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    HealerMove.HealerSpeed = 0.01f;
                }
            }
            else
            {
                wtimer2 = 0; //타이머 리셋
                return true;
            }
        }

        if (gameObject.tag == "Enemy") //부스터의 태그가 적이면
        {
            if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //각 오브젝트들과의 거리를 계산해 MIN변수에 넣음
                MMin1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
            if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
                MMin2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
            if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
                MMin3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
            if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
                MMin4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
            if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
                MMin5 = Vector3.Distance(GameObject.Find("Healer").transform.position, gameObject.transform.position);

            float MMinDistance = Mathf.Min(MMin1, MMin2, MMin3, MMin4, MMin5); //거리들 중 가장 가까운 거리를 계산해서

            if (MMinDistance == MMin1 && GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team") //그 거리에 해당하는 오브젝트 저장
            {
                ShortEnemy2 = GameObject.Find("Player");
            }
            if (MMinDistance == MMin2 && GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Sonny");
            }
            if (MMinDistance == MMin3 && GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Bastion");
            }
            if (MMinDistance == MMin4 && GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Shooter");
            }
            if (MMinDistance == MMin5 && GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
            {
                ShortEnemy2 = GameObject.Find("Healer");
            }

            wtimer2 += Time.deltaTime;

            if (wtimer2 < etimer2) //타이머 시간동안
            {
                if (GameObject.Find("Player") != null && ShortEnemy2 == GameObject.Find("Player")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    Player.PlayerSpeed = 1.5f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy2 == GameObject.Find("Sonny")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    SonnyMove.SonnySpeed = 4f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy2 == GameObject.Find("Bastion")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    BastionMove.BastionSpeed = 4f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy2 == GameObject.Find("Shooter")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    Shooter_Move.ShooterSpeed = 1.5f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy2 == GameObject.Find("Healer")) // shortEnemy에 해당하는 오브젝트의 속도를 줄임
                {
                    HealerMove.HealerSpeed = 0.005f;
                }
            }
            else if (wtimer2 < (etimer2 + 3f))
            {
                if (GameObject.Find("Player") != null && ShortEnemy2 == GameObject.Find("Player"))// shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    Player.PlayerSpeed = 3f;
                }
                if (GameObject.Find("Sonny") != null && ShortEnemy2 == GameObject.Find("Sonny"))// shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    SonnyMove.SonnySpeed = 8f;
                }
                if (GameObject.Find("Bastion") != null && ShortEnemy2 == GameObject.Find("Bastion"))// shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    BastionMove.BastionSpeed = 8f;
                }
                if (GameObject.Find("Shooter") != null && ShortEnemy2 == GameObject.Find("Shooter"))// shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    Shooter_Move.ShooterSpeed = 3f;
                }
                if (GameObject.Find("Healer") != null && ShortEnemy2 == GameObject.Find("Healer"))// shortEnemy에 해당하는 오브젝트의 속도를 복구함
                {
                    HealerMove.HealerSpeed = 0.01f;
                }
            }
            else
            {
                wtimer2 = 0; //타이머 리셋
                return true;
            }
        }
        return false;
    }

    public bool BoosterIsDead() // 부스터의 죽음
    {
        if (BoosterHp <= 0) //부스터가 죽으면
        {
            gameObject.active = false; //오브젝트 비활성화
            return false;
        }
        return true;
    }
    void OnCollisionEnter(Collision collision) //충돌 감지
    {
        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
        }
    }
    void OnCollisionStay(Collision collision) //충돌 감지
    {
        col = true;
        if (collision.collider.CompareTag("Cube"))
        {
            cube_position = collision.transform.position;
            cubecol = true;
        }
    }
}