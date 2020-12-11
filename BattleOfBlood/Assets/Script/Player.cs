using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int PlayerHp = 100;
    public static Vector3 PlayerPos;
    public static Vector3 PlayerColPos;
    bool col = false;
    public GameObject WaterBalloon;
    public static float PlayerSpeed = 3f;
    public Rigidbody rb;
    public static GameObject[] characters;

    public static int[] Team_Hp = new int[3];
    public static int[] Enemy_Hp = new int[3];

    public static bool pl;
    public static bool ba;
    public static bool sn;
    public static bool hl;
    public static bool bo;
    public static bool sh;
    public static int n = 0;

    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    public GameObject char4;
    public GameObject char5;
    public GameObject char6;

    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject Char4;
    public GameObject Char5;
    public GameObject Char6;

    public Rigidbody b_rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPos = gameObject.transform.position;

        if(SelectMng.booster1 == "Team")
            GameObject.Find("Booster").tag = "Team";
        else if(SelectMng.booster1 == "Enemy")
            GameObject.Find("Booster").tag = "Enemy";

        if (SelectMng.bastion1 == "Team")
            GameObject.Find("Bastion").tag = "Team";
        else if (SelectMng.bastion1 == "Enemy")
            GameObject.Find("Bastion").tag = "Enemy";

        if (SelectMng.healer1 == "Team")
            GameObject.Find("Healer").tag = "Team";
        else if (SelectMng.healer1 == "Enemy")
            GameObject.Find("Healer").tag = "Enemy";

        if (SelectMng.sonny1 == "Team")
            GameObject.Find("Sonny").tag = "Team";
        else if (SelectMng.sonny1 == "Enemy")
            GameObject.Find("Sonny").tag = "Enemy";

        if (SelectMng.shooter1 == "Team")
            GameObject.Find("Shooter").tag = "Team";
        else if (SelectMng.shooter1 == "Enemy")
            GameObject.Find("Shooter").tag = "Enemy";


        if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")
            char1 = GameObject.Find("Player");
        if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")
            char2 = GameObject.Find("Sonny");
        if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")
            char3 = GameObject.Find("Bastion");
        if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")
            char4 = GameObject.Find("Shooter");
        if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")
            char5 = GameObject.Find("Healer");
        if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")
            char6 = GameObject.Find("Booster");

        if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")
            Char1 = GameObject.Find("Player");
        if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Enemy")
            Char2 = GameObject.Find("Sonny");
        if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Enemy")
            Char3 = GameObject.Find("Bastion");
        if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Enemy")
            Char4 = GameObject.Find("Shooter");
        if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Enemy")
            Char5 = GameObject.Find("Healer");
        if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Enemy")
            Char6 = GameObject.Find("Booster");


        for (int i = 0; i < 2; i++)
        {
            Team_Hp[i] = 100;
            Enemy_Hp[i] = 100;
        }

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            pl = false;
            ba = false;
            sn = false;
            hl = false;
            bo = false;
            sh = false;

            if (char1 != null && char1.tag == "Team")
                pl = true;
            if (char2 != null && char2.tag == "Team")
                sn = true;
            if (char3 != null && char3.tag == "Team")
                ba = true;
            if (char4 != null && char4.tag == "Team")
                sh = true;
            if (char5 != null && char5.tag == "Team")
                hl = true;
            if (char6 != null && char6.tag == "Team")
                bo = true;

            if (Char1 != null && Char1.tag == "Enemy")
                pl = true;
            if (Char2 != null && Char2.tag == "Enemy")
                sn = true;
            if (Char3 != null && Char3.tag == "Enemy")
                ba = true;
            if (Char4 != null && Char4.tag == "Enemy")
                sh = true;
            if (Char5 != null && Char5.tag == "Enemy")
                hl = true;
            if (Char6 != null && Char6.tag == "Enemy")
                bo = true;

            Player.PlayerHp = 100;
            Shooter_Move.ShooterHp = 100;
            HealerMove.HealerHp = 100;
            BoosterMove.BoosterHp = 100;
            BastionMove.BastionHp = 100;
            SonnyMove.SonnyHp = 100;
        }
        

        if (ba == false)
            GameObject.Find("Bastion").active = false;
        if (bo == false)
            GameObject.Find("Booster").active = false;
        if (sh == false)
            GameObject.Find("Shooter").active = false;
        if (hl == false)
            GameObject.Find("Healer").active = false;
        if (sn == false)
            GameObject.Find("Sonny").active = false;



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
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2" && n == 0)
        {
            ba = true;
            bo = true;
            ba = true;
            sh = true;
            hl = true;

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
            n++;
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
        float xSpeed = xInput * PlayerSpeed;
        float zSpeed = zInput * PlayerSpeed;

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