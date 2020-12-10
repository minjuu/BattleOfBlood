using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject WaterBalloon;
    public Rigidbody rb;
    public Rigidbody b_rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Player.PlayerPos = gameObject.transform.position;

        Player.Team_array = new List<GameObject>(GameObject.FindGameObjectsWithTag("Team"));
        Player.Enemy_array = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        Player.Team_Pos = new List<Vector3>();
        Player.Enemy_Pos = new List<Vector3>();
        Player.Team_Ap = new List<float>();
        Player.Enemy_Ap = new List<float>();

        for (int i = 0; i < 3; i++)
        {
            Player.Team_Hp[i] = 100;
            Player.Enemy_Hp[i] = 100;
        }

        for (int i = 0; i < Player.Team_Ap.Count; i++)
        {
            Player.Team_Ap.Add(5.0f); //공격력 임의로 추가
            Player.Enemy_Ap.Add(5.0f); //공격력 임의로 추가
        }

        for (int i = 0; i < Player.Team_array.Count; i++)
        {
            Player.Team_Pos.Add(Player.Team_array[i].transform.position); //우리 팀의 위치를 리스트에 저장
        }

        for (int i = 0; i < Player.Enemy_array.Count; i++)
        {
            Player.Enemy_Pos.Add(Player.Enemy_array[i].transform.position); //상대 팀의 위치를 리스트에 저장
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2")
        {
            Player.ba = true;
            Player.bo = true;
            Player.ba = true;
            Player.sh = true;
            Player.hl = true;

            GameObject.Find("Player").active = true;
            GameObject.Find("Bastion").active = true;
            GameObject.Find("Booster").active = true;
            GameObject.Find("Shooter").active = true;
            GameObject.Find("Healer").active = true;
            GameObject.Find("Sonny").active = true;

            Player.PlayerHp = 100;
            Shooter_Move.ShooterHp = 100;
            HealerMove.HealerHp = 100;
            BoosterMove.BoosterHp = 100;
            BastionMove.BastionHp = 100;
            SonnyMove.SonnyHp = 100;
        }


        //int count_1 = 0;
        //for (int i = 0; i < characters.Length; i++)
        //{
        //    if (characters[i].tag == "Team") //tag가 Team 일때
        //    {
        //        Team_arr[count_1] = characters[i]; //characters배열에 있는 순서대로 재배열하여 저장
        //        Team_Ap[count_1] = characters_Ap[i];
        //        count_1++;
        //    }
        //}

        //int count_2 = 0;
        //for (int i = 0; i < characters.Length; i++)
        //{
        //    if (characters[i].tag == "Enemy")
        //    {
        //        Enemy_arr[count_2] = characters[i];
        //        Enemy_Ap[count_1] = characters_Ap[i];
        //        count_2++;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2" && Player.n == 0)
        {
            Player.ba = true;
            Player.bo = true;
            Player.ba = true;
            Player.sh = true;
            Player.hl = true;

            GameObject.Find("Player").active = true;
            GameObject.Find("Bastion").active = true;
            GameObject.Find("Booster").active = true;
            GameObject.Find("Shooter").active = true;
            GameObject.Find("Healer").active = true;
            GameObject.Find("Sonny").active = true;

            Player.PlayerHp = 100;
            Shooter_Move.ShooterHp = 100;
            HealerMove.HealerHp = 100;
            BoosterMove.BoosterHp = 100;
            BastionMove.BastionHp = 100;
            SonnyMove.SonnyHp = 100;
            Player.n++;
        }

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

        if (transform.position.x < -20)//절벽 범위 조건문
        {
            Vector3 swap3 = transform.position;//벡터 저장
            swap3.x = -20;//고정 위치 설정
            transform.position = swap3;
        }
        if (transform.position.x > 20)//절벽 범위 조건문
        {
            Vector3 swap4 = transform.position;//벡터 저장
            swap4.x = 20;//고정 위치 설정
            transform.position = swap4;
        }
        // 수평축과 수직축의 입력값을 지정하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * Player.PlayerSpeed;
        float zSpeed = zInput * Player.PlayerSpeed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        rb.velocity = newVelocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject balloon = GameObject.Instantiate(WaterBalloon)
               as GameObject;
            b_rb = balloon.GetComponent<Rigidbody>();
            b_rb.isKinematic = false;
            Vector3 v = transform.position;
            v.x = Mathf.Round(v.x);
            v.y = 0.8f;
            v.z = Mathf.Round(v.z);
            balloon.transform.position = v;
        }



    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Cube"))
        {
            Debug.Log("충돌");
        }
    }


}