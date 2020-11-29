using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMove : MonoBehaviour
{
    public static float SonnySpeed = 0.05f;    //SonnyMove 코드 만들어서 넣기
    public static float BastionSpeed = 0.05f;
    public static float ShooterSpeed = 0.05f;
    public static float HealerSpeed = 0.05f;
    public static float BoosterSpeed = 0.05f;
    public static int BoosterHp = 100;

    float startTime;
    float EnemystartTime;

    public GameObject Prefab_bullet;
    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.02f;
    int nTime = 0;

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
        startTime = 0;
        EnemystartTime = 0;
        nTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }

    public bool BoosterObstacleDetect()
    {
        return false;
    }

    public bool BoosterTeamPosDetect()
    {
        //위치 감지

        startTime += Time.time;

        if (startTime > 3f)
        {
            startTime = 0;
            return true;
        }

        //Player.PlayerSpeed += 0.01f;
        return false;
    }

    public bool BoosterEnemyPosDetect()      // 적 위치 감지
    {
        //위치 감지

        EnemystartTime += Time.time;

        if (EnemystartTime > 3f)
        {
            startTime = 0;
            return true;
        }

        //Player.PlayerSpeed = 0.0f;
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
}