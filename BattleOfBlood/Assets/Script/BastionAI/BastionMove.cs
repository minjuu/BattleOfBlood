using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastionMove : MonoBehaviour
{
    public static float BastionSpeed = 0.01f;
    public static int BastionHp = 100;

    public GameObject Prefab_balloon;
    float DirR = 180.0f;
    Vector3 Dir;
    Vector3 Enemy_Dir;
    Vector3 lookat;

    int nTime = 0;

    Vector3 pos; //오브젝트의 위치 저장 변수

    Rigidbody Bastion_rigid;
    Vector3 point;
    Vector3 point1;
    Vector3 point2;
    Vector3 point3;
    Vector3 point4;
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

    bool make_wb;
    void Start()
    {
        nTime = 0;
        pos = transform.position; //오브젝트의 위치를 변수에 저장

        point1 = new Vector3(1, 0, 0);
        point2 = new Vector3(0, 0, -1);
        point3 = new Vector3(-1, 0, 0);
        point4 = new Vector3(0, 0, 1);
        Bastion_rigid = gameObject.GetComponent<Rigidbody>();

        make_wb = false;
    }
    public bool BastionMoveFollowTarget()
    {
        if (Player.BastionHp > 0)
        {
            if (gameObject.tag == "Team")
            {
                shortDistance = Vector3.Distance(Player.Enemy_array[0].transform.position, gameObject.transform.position);
                for (sd_1 = 0; sd_1 < Player.Enemy_array.Count; sd_1++)
                {
                    distance = Vector3.Distance(Player.Enemy_array[sd_1].transform.position, gameObject.transform.position);
                    if (distance <= shortDistance)
                    {
                        shortDistance = distance;
                        shortEnemy = Player.Enemy_array[sd_1];
                    }
                }
                Enemy_Dir = shortEnemy.transform.position - gameObject.transform.position;
                Enemy_Dir.Normalize();
                if (Enemy_Dir.x >= 0 && Enemy_Dir.z >= 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, 1);

                }
                else if (Enemy_Dir.x >= 0 && Enemy_Dir.z < 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, -1);
                }
                else if (Enemy_Dir.x < 0 && Enemy_Dir.z >= 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(-1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, 1);
                }
                else if (Enemy_Dir.x < 0 && Enemy_Dir.z < 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(-1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, -1);
                }

                Quaternion Rot = Quaternion.LookRotation(lookat, new Vector3(0, 1, 0));
                DirR = Rot.eulerAngles.y;
                gameObject.transform.localRotation = Rot;

                //gameObject.transform.position += lookat * BastionSpeed;

                if (shortDistance > 1.5f)
                {
                    gameObject.transform.position += lookat * BastionSpeed;
                }
                else
                {
                    gameObject.transform.position -= lookat * BastionSpeed;
                }

            }
            if (gameObject.tag == "Enemy")
            {
                shortDistance = Vector3.Distance(Player.Team_array[0].transform.position, gameObject.transform.position);
                for (sd_1 = 0; sd_1 < Player.Team_array.Count; sd_1++)
                {
                    distance = Vector3.Distance(Player.Team_array[sd_1].transform.position, gameObject.transform.position);
                    if (distance <= shortDistance)
                    {
                        shortDistance = distance;
                        shortEnemy = Player.Team_array[sd_1];
                    }
                }
                Enemy_Dir = shortEnemy.transform.position - gameObject.transform.position;
                Enemy_Dir.Normalize();
                if (Enemy_Dir.x >= 0 && Enemy_Dir.z >= 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, 1);

                }
                else if (Enemy_Dir.x >= 0 && Enemy_Dir.z < 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, -1);
                }
                else if (Enemy_Dir.x < 0 && Enemy_Dir.z >= 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(-1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, 1);
                }
                else if (Enemy_Dir.x < 0 && Enemy_Dir.z < 0)
                {
                    if (Mathf.Abs(Enemy_Dir.x) >= Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(-1, 0, 0);
                    else if (Mathf.Abs(Enemy_Dir.x) < Mathf.Abs(Enemy_Dir.z))
                        lookat = new Vector3(0, 0, -1);
                }

                Quaternion Rot = Quaternion.LookRotation(lookat, new Vector3(0, 1, 0));
                DirR = Rot.eulerAngles.y;
                gameObject.transform.localRotation = Rot;

                if (shortDistance > 1.5f)
                {
                    gameObject.transform.position += lookat * BastionSpeed;
                }
                else
                {
                    gameObject.transform.position -= lookat * BastionSpeed;
                }
            }

            return true;
        }
        return false;
    }

    public bool BastionMoveBackFollowTarget()
    {
        if (Player.PlayerHp < 50 && Player.PlayerHp > 0)
        {
            Dir = Player.PlayerPos - gameObject.transform.position;
            Dir.Normalize();
            Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
            DirR = Rot.eulerAngles.y;
            gameObject.transform.localRotation = Rot;

            gameObject.transform.position -= Dir * BastionSpeed;

            return true;
        }
        return false;
    }

    public bool FindEnemy() //제일 가까운 상대팀 위치
    {
        if (Player.BastionHp > 0)
        {
            if (gameObject.tag == "Team")
            {
                //shortDistance = Vector3.Distance(Player.Enemy_array[0].transform.position, gameObject.transform.position);
                for (sd_1 = 0; sd_1 < Player.Enemy_Pos.Count; sd_1++)
                {
                    distance = Vector3.Distance(Player.Enemy_array[sd_1].transform.position, gameObject.transform.position);
                    if (distance <= shortDistance)
                    {
                        shortDistance = distance;
                        shortEnemy = Player.Enemy_array[sd_1];
                    }
                }
            }
            else
            {
                for (int i = 0; i < Player.Team_Pos.Count; i++)
                {
                    float distance = Vector3.Distance(Player.Team_Pos[i], gameObject.transform.position);
                    if (distance < shortDistance)
                    {
                        shortDistance = distance;
                        shortDistance_index = i;
                    }
                }
            }

            //이동 방법에 따라 바꿔야하나
            //Enemy_Dir = Player.Team_Pos[shortDistance_index] - gameObject.transform.position;
            //Enemy_Dir.Normalize();
            //Quaternion Rot = Quaternion.LookRotation(Enemy_Dir, new Vector3(0, 1, 0));
            //DirR = Rot.eulerAngles.y;
            //gameObject.transform.localRotation = Rot;
            //gameObject.transform.position += Enemy_Dir * BastionSpeed;

            return true;
        }
        return false;
    }

    void Update()
    {
        nTime++;
    }
    public bool BastionIsDead()
    {
        if (BastionHp <= 10)
        {
            if (gameObject.tag == "Team")
            {
                for (ap = 0; ap < Player.Enemy_Ap.Count; ap++)
                {
                    float Ap_ap = Player.Enemy_Ap[0];
                    if (Ap_ap >= Player.Enemy_Ap[ap])
                    {
                        largestAp = Ap_ap;
                        largestAp_index = ap;
                    }
                }
            }
            else
            {

            }

            Destroy(gameObject, 0f);
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
                water_balloon.GetComponent<WaterBalloon>().Dir = lookat;
                water_balloon.tag = "Bastion_balloon"; //태그 추가하기
                water_balloon.transform.position = transform.position;
                water_balloon.transform.parent = null;
                water_balloon.transform.position = transform.position;

                if (BastionHp <= 10)
                {
                    //어떻게 만들지
                    make_wb = true;
                }
            }
            return true;
        }
        return false;
    }
}