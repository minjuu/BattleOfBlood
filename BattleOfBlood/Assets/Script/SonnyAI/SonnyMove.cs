using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonnyMove : MonoBehaviour
{
    public static int SonnyHp = 100; //체력
    public static int SonnyAp = 10; //공격력
    public static Vector3 SonnyPos;
    public static float SonnySpeed = 8f;
    public GameObject Ballon;

    public static Vector3 GoalPos; // 물풍선 미는 위치
    float min = 1000000;
    int nTime = 0;
    bool f_balloon = false;
    private float x;
    private float z;
    private bool coll;
    public static Vector3 cube_position;
    private float gtimer;
    private float etimer;
    public static int sonny_dir = -1;
    public static Vector3 Goal;
    private float shortDistance;
    public static GameObject shortEnemy; //슈터와 가장 가까운 적
    public static bool cubecoll;
    int sd_1 = 0;
    Vector3 Dir;
    Vector3 Now;
    public Rigidbody bb_rb;

    public Rigidbody srb;

    public bool MoveinMap()
    {
        if (transform.position.z < -15) //절벽 범위 조건문
        {
            Vector3 swap1 = transform.position; //벡터 저장
            swap1.z = -15;                                  //고정 위치 설정
            transform.position = swap1;
            coll = true;
        }

        if (transform.position.z > 15)//절벽 범위 조건문
        {
            Vector3 swap2 = transform.position;//벡터 저장
            swap2.z = 15;//고정 위치 설정
            transform.position = swap2;
            coll = true;
        }

        if (transform.position.x < -20)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -20;//고정 위치 설정
            transform.position = swap3;
            coll = true;
        }
        if (transform.position.x > 20)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 20;//고정 위치 설정
            transform.position = swap4;
            coll = true;
        }
        //sonny이동

        // float gtimer = Time.time;
        // etimer = gtimer + 0.035f;
        // gtimer += Time.deltaTime;

        x = gameObject.transform.position.x - shortEnemy.transform.position.x;
        z = gameObject.transform.position.z - shortEnemy.transform.position.z;
        if (SonnyHp > 0 && nTime % 80 == 0)
        {

            if (Mathf.Abs(x) > Mathf.Abs(z))
            {
                if (x < 0)
                    sonny_dir = 0;
                if (x >= 0)
                    sonny_dir = 1;
            }
            if (Mathf.Abs(x) < Mathf.Abs(z))
            {
                if (z < 0) //적이 슈터보다 z값큼
                    sonny_dir = 2;
                if (z >= 0)
                    sonny_dir = 3;
            }
            if (cubecoll == true || coll == true)
                sonny_dir = Random.Range(0, 4);

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                sonny_dir = 2;
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                sonny_dir = 3;
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                sonny_dir = 0;
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                sonny_dir = 1;
            }

            if (SonnyHp >= 0 || coll == true)
            {
                if (sonny_dir == 0)
                {
                    Goal = new Vector3(1, 0, 0);
                }
                if (sonny_dir == 1)
                {
                    Goal = new Vector3(-1, 0, 0);
                }
                if (sonny_dir == 2)
                {
                    Goal = new Vector3(0, 0, 1);
                }
                if (sonny_dir == 3)
                {
                    Goal = new Vector3(0, 0, -1);
                }
                if (sonny_dir == 4)
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
            cubecoll = false;
            coll = false;

            Vector3 newVelocity = Goal * SonnySpeed;
            // 리지드바디의 속도에 newVelocity 할당
            srb.velocity = newVelocity;
            return true;
        }
        else if (transform.position.z < -15 || transform.position.z > 15 || transform.position.x < -20 || transform.position.x > 20)
        {

            if (transform.position.z < -15) //절벽 범위 조건문
            {
                sonny_dir = 2;
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                sonny_dir = 3;
            }

            if (transform.position.x < -20)//절벽 범위 조건문
            {
                sonny_dir = 0;
            }
            if (transform.position.x > 20)//절벽 범위 조건문
            {
                sonny_dir = 1;
            }

            if (SonnyHp >= 0 || coll == true)
            {
                if (sonny_dir == 0)
                {
                    Goal = new Vector3(1, 0, 0);
                }
                if (sonny_dir == 1)
                {
                    Goal = new Vector3(-1, 0, 0);
                }
                if (sonny_dir == 2)
                {
                    Goal = new Vector3(0, 0, 1);
                }
                if (sonny_dir == 3)
                {
                    Goal = new Vector3(0, 0, -1);
                }
                if (sonny_dir == 4)
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
            cubecoll = false;
            coll = false;

            Vector3 newVelocity = Goal * SonnySpeed;
            // 리지드바디의 속도에 newVelocity 할당
            srb.velocity = newVelocity;
            return true;

        }
        Vector3 newVelocity2 = Goal * SonnySpeed;
        // 리지드바디의 속도에 newVelocity 할당
        srb.velocity = newVelocity2;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {

        nTime = 0;
        srb = GetComponent<Rigidbody>();
        ///

        coll = false;

    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
        Now = transform.position;
        Now.y = 0.3f;
        transform.position = Now;
    }
    public bool SonnyIsDead()
    {
        if (SonnyHp <= 0)
        {
            gameObject.active = false;
            return false;
        }
        return true;

    }


    public bool AddBalloon()
    {
        if (SonnyHp > 0)
        {
            if (nTime % 300 == 0)
            {
                GameObject ballon = GameObject.Instantiate(Ballon) as GameObject;
                ballon.GetComponent<WaterBalloon>().Dir = Dir;
                bb_rb = ballon.GetComponent<Rigidbody>();
                bb_rb.isKinematic = false; //////////////
                ballon.transform.parent = null; ////////////
                ballon.gameObject.tag = "SonnyBalloon"; /////////
                Vector3 bPos;

                bPos = transform.position;
                bPos.y = 0.8f;
                ballon.transform.position = bPos;

            }
            return true;
        }
        return false;
    }
    private void OnCollisionEnter(Collision col)
    {
        int m_idx = 0;
        if (col.gameObject.tag == "Balloon" || col.gameObject.tag == "SonnyBalloon")
        {
            col.gameObject.tag = "SonnyBalloon";

            if (gameObject.tag == "Team")
            {
                float e_min = 1000000;
                GameObject[] e_Array = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < e_Array.Length; i++)
                {
                    if ((e_Array[i].transform.position - gameObject.transform.position).magnitude < e_min)
                    {
                        e_min = (e_Array[i].transform.position - gameObject.transform.position).magnitude;
                        m_idx = i;
                    }
                }
                GoalPos.y = 0.8f;
                Vector3 epos = e_Array[m_idx].transform.position;
                epos.y = 0.8f;
                GoalPos = (epos - transform.position).normalized;
                // GoalPos.Normalize();

            }
            else if (gameObject.tag == "Enemy")
            {
                float e_min = 1000000;
                GameObject[] e_Array = GameObject.FindGameObjectsWithTag("Team");
                for (int i = 0; i < e_Array.Length; i++)
                {
                    if ((e_Array[i].transform.position - gameObject.transform.position).magnitude < e_min)
                    {
                        e_min = (e_Array[i].transform.position - gameObject.transform.position).magnitude;
                        m_idx = i;
                    }
                }
                // GoalPos = transform.position - e_Array[m_idx].transform.position;
                GoalPos.y = 0.8f;
                Vector3 epos = e_Array[m_idx].transform.position;
                epos.y = 0.8f;
                GoalPos = (epos - transform.position).normalized;

                //GoalPos.Normalize();
            }
            BalloonMove.Sonnykick = true; //물풍선 충돌시 물풍선 목표 지점까지 이동시키는 BallonMove내 코드 실행
        }

        coll = true;
        if (col.collider.CompareTag("Cube"))
        {
            cube_position = col.transform.position;
            cubecoll = true;
        }


    }

    public bool DetectPosi() //적 위치 감지
    {
        if (SonnyHp > 0)
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
                        GoalPos.y = 0.8f;
                        Vector3 epos = shortEnemy.transform.position;
                        epos.y = 0.8f;
                        GoalPos = (epos - transform.position).normalized;

                    }
                }


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
                        GoalPos.y = 0.8f;
                        Vector3 epos = shortEnemy.transform.position;
                        epos.y = 0.8f;
                        GoalPos = (epos - transform.position).normalized;
                    }
                }

            }
            return true;
        }
        return false;
    }

    public bool Is_Collision() //충돌 처리 기능 추가
    {
        if (cubecoll == true)
        {
            Dir = (cube_position - gameObject.transform.position).normalized;
            Dir.y = 0;
            cubecoll = false;
            return true;
        }
        return false;
    }


}