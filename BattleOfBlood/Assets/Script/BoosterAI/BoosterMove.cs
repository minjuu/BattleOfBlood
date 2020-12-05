using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMove : MonoBehaviour
{
    public static float SonnySpeed = 0.05f;//SonnyMove 코드 만들어서 넣기
    public static float BoosterSpeed = 0.05f;
    public static int BoosterHp = 100;

    public GameObject Prefab_bullet;
    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.02f;
    int nTime = 0;

    float shortDistance;
    public GameObject shortEnemy;
    float distance = 0.0f;
    int sd_1 = 0;

    float wtimer;
    float etimer;

    Vector3 Enemy_Dir;
    Vector3 lookat;
    float min1, min2, min3, min4, min5;

    private bool col;
    public static bool cubecol;
    public static Vector3 cube_position;

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
                if (GameObject.Find("Sonny").gameObject.tag == "Team")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Team")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Team")
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
                Debug.Log(shortEnemy.name);
                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);
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

                //Quaternion Rot = Quaternion.LookRotation(lookat, new Vector3(0, 1, 0));
                //gameObject.transform.rotation = Rot;
                transform.rotation = Quaternion.Euler(lookat);

                if (shortDistance > 1.5f)
                {
                    gameObject.transform.position += lookat * BoosterSpeed;
                }
                else
                {
                    gameObject.transform.position -= lookat * BoosterSpeed;
                }
            }

            if (gameObject.tag == "Enemy")
            {
                if (GameObject.Find("Player").gameObject.tag == "Enemy")
                    min1 = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min2 = Vector3.Distance(GameObject.Find("Sonny").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min3 = Vector3.Distance(GameObject.Find("Bastion").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
                    min4 = Vector3.Distance(GameObject.Find("Shooter").transform.position, gameObject.transform.position);
                if (GameObject.Find("Sonny").gameObject.tag == "Enemy")
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
                Debug.Log(shortEnemy.name);
                shortDistance = Vector3.Distance(shortEnemy.transform.position, gameObject.transform.position);
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

                //Quaternion Rot = Quaternion.LookRotation(lookat, new Vector3(0, 1, 0));
                //gameObject.transform.rotation = Rot;
                transform.rotation = Quaternion.Euler(lookat);

                if (shortDistance > 1.5f)
                {
                    gameObject.transform.position += lookat * BoosterSpeed;
                }
                else
                {
                    gameObject.transform.position -= lookat * BoosterSpeed;
                }
            }
            return true;
        }
        return false;
    }
    void Start()
    {
        nTime = 0;
        wtimer = 0;
        etimer = wtimer + 2f;
    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }

    public bool BoosterObstacleDetect()
    {
        if (cubecol == true)
        {
            cubecol = false;
            return true;
        }
        return false;
    }

    public bool BoosterTeamPosDetect()
    {
        if (gameObject.tag == "Team")
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
            wtimer += Time.deltaTime;
            if (wtimer > etimer)
            {
                if (shortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Sonny"))
                {
                    //SonnyHp = 0 ;
                }
                if (shortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0;
                }
            }
        }

        if (gameObject.tag == "Enemy")
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
            wtimer += Time.deltaTime;
            if (wtimer > etimer)
            {
                if (shortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Sonny"))
                {
                    //SonnyHp = 0 ;
                }
                if (shortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0;
                }
            }
        }
        return false;
    }

    public bool BoosterEnemyPosDetect()      // 적 위치 감지
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
            wtimer += Time.deltaTime;
            if (wtimer > etimer)
            {
                if (shortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Sonny"))
                {
                    //SonnyHp = 0 ;
                }
                if (shortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0;
                }
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
            wtimer += Time.deltaTime;
            if (wtimer > etimer)
            {
                if (shortEnemy == GameObject.Find("Player"))
                {
                    Player.PlayerSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Sonny"))
                {
                    //SonnyHp = 0 ;
                }
                if (shortEnemy == GameObject.Find("Bastion"))
                {
                    BastionMove.BastionSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Shooter"))
                {
                    Shooter_Move.ShooterSpeed = 0;
                }
                if (shortEnemy == GameObject.Find("Healer"))
                {
                    HealerMove.HealerSpeed = 0;
                }
            }
        }
        return false;
    }

    public bool BoosterIsDead() // Enemy의 죽음
    {
        if (BoosterHp <= 0) // Enemy의 체력이 0이하이면
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