using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerMove : MonoBehaviour
{
    public static float HealerSpeed = 0.05f;
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

    public bool MoveHealer()
    {
        //팀 위치 감지 후 그쪽으로 이동
        if (HealerHp >= 50)
        {
            Dir = Player.PlayerPos - gameObject.transform.position;
            Dir.Normalize();
            Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
            DirR = Rot.eulerAngles.y;
            gameObject.transform.localRotation = Rot;
            gameObject.transform.position += Dir * speed;
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
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