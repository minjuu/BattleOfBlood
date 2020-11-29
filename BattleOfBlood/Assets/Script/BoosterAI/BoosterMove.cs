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

    private bool col;
    public static bool cubecol;
    public static Vector3 cube_position;

    // Start is called before the first frame update
    public bool MoveBooster()
    {
        //팀 위치 감지 후 제일 가까운애로 이동
        if (BoosterSpeed >= 0.05f)
        {
            Dir = Player.PlayerPos - gameObject.transform.position;
            Dir.Normalize();
            Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
            DirR = Rot.eulerAngles.y;
            gameObject.transform.localRotation = Rot;
            gameObject.transform.position -= Dir * speed;
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