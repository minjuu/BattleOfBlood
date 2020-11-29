using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonnyMove : MonoBehaviour
{
    public static int SonnyHp = 200; //체력
    public static int SonnyAp = 10; //공격력
    public static Vector3 SonnyPos;
    public static float SonnySpeed = 0.3f;
    public GameObject Ballon;

    public static Vector3 GoalPos; // 물풍선 미는 위치
    float min = 1000000;
    int nTime = 0;
    bool f_balloon = false;

    public bool MoveinMap()
    {
        if (SonnyMove.SonnyHp > 0)
        {
            transform.position += transform.forward * SonnySpeed;
            if (transform.position.z < -15) //절벽 범위 조건문
            {
                Vector3 swap1 = transform.position; //벡터 저장
                swap1.z = -15;                                  //고정 위치 설정
                transform.position = swap1;
               
            }

            if (transform.position.z > 15)//절벽 범위 조건문
            {
                Vector3 swap2 = transform.position;//벡터 저장
                swap2.z = 15;//고정 위치 설정
                transform.position = swap2;
              
            }

            if (transform.position.x < -15)//절벽 범위 조건문
            {
                Vector3 swap3 = transform.position;//벡터 저장
                swap3.x = -15;//고정 위치 설정
                transform.position = swap3;
               
            }
            if (transform.position.x > 15)//절벽 범위 조건문
            {
                Vector3 swap4 = transform.position;//벡터 저장
                swap4.x = 15;//고정 위치 설정
                transform.position = swap4;
            }

            Debug.Log("MoveMap");

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
    public bool SonnyIsDead()
    {
        if (SonnyMove.SonnyHp <= 0)
        {
            return false;
        }
        return true;
    }

    public bool FindingGoalPos()
    {
        if (SonnyHp > 0)
        {
            if (nTime % 100 == 0)
            {

            }
            return true;
        }
        return false;
    }

    public bool AddBalloon()
    {
        if (SonnyHp > 0)
        {
            if (nTime % 500 == 0)
            {
                GameObject ballon = GameObject.Instantiate(Ballon) as GameObject;
                ballon.transform.parent = null;
                ballon.transform.position = transform.position;
            }
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision col)
    {
        int m_idx=0;
        if (col.gameObject.tag == "Balloon")
        {
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
                GoalPos = (transform.position - e_Array[m_idx].transform.position);
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
                GoalPos = transform.position - e_Array[m_idx].transform.position;
            }
            BalloonMove.Sonnykick = true; //물풍선 충돌시 물풍선 목표 지점까지 이동시키는 BallonMove내 코드 실행
        }

        if (col.gameObject.tag == "Cube") //장애물 감지
        {


        }


    }

    public bool FindBalloon()
    {
        if (SonnyMove.SonnyHp > 0)
        {
            min = 1000000;
            int m_idx=0;
            GameObject[] objArray = GameObject.FindGameObjectsWithTag("Balloon");
            for (int i = 0; i < objArray.Length; i++)
            { 
                if ((objArray[i].transform.position - gameObject.transform.position).magnitude < min)
                {
                    min = (objArray[i].transform.position - gameObject.transform.position).magnitude;
                    m_idx = i;
                }
            }
           if ((objArray[m_idx].transform.position - gameObject.transform.position).magnitude < 5)
            {
                Vector3 Dir = transform.position - objArray[m_idx].transform.position;
                Dir.Normalize();
                Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                gameObject.transform.localRotation = Rot;
                gameObject.transform.position += Dir * SonnySpeed;
            }
           else
            {
                if (gameObject.tag == "Team")
                {
                    float e_min = 1000000;
                    m_idx=0;
                    GameObject[] e_Array = GameObject.FindGameObjectsWithTag("Enemy");
                    for (int i = 0; i < e_Array.Length; i++)
                    {
                        if ((e_Array[i].transform.position - gameObject.transform.position).magnitude < e_min)
                        {
                            e_min = (e_Array[i].transform.position - gameObject.transform.position).magnitude;
                            m_idx = i;
                        }
                    }
                    Vector3 Dir = transform.position - e_Array[m_idx].transform.position;
                    Dir.Normalize();
                    Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                    gameObject.transform.localRotation = Rot;
                    gameObject.transform.position += Dir * SonnySpeed;
                }
                else if (gameObject.tag == "Enemy")
                {
                    m_idx=0;
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
                    Vector3 Dir = transform.position - e_Array[m_idx].transform.position;
                    Dir.Normalize();
                    Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                    gameObject.transform.localRotation = Rot;
                    gameObject.transform.position += Dir * SonnySpeed;
                }
            }
            Debug.Log("Move");
            return true;
        }
        return false;
    }
}


