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
    public static List<GameObject> Team_array;
    public static List<GameObject> Enemy_array;
    public static List<float> Team_Hp;
    public static List<float> Enemy_Hp;
    public static List<float> Team_Ap;
    public static List<float> Enemy_Ap;
    public static List<Vector3> Team_Pos;
    public static List<Vector3> Enemy_Pos;
    public Rigidbody b_rb;
    public static string str;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        PlayerPos = gameObject.transform.position;

        characters = new GameObject[6];
        characters[0] = GameObject.Find("Player");
        characters[1] = GameObject.Find("Sonny");
        characters[2] = GameObject.Find("Bastion");
        characters[3] = GameObject.Find("Shooter");
        characters[4] = GameObject.Find("Healer");
        characters[5] = GameObject.Find("Booster");

        Team_array = new List<GameObject>(GameObject.FindGameObjectsWithTag("Team"));
        Enemy_array = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        Team_Pos = new List<Vector3>();
        Enemy_Pos = new List<Vector3>();
        Team_Ap = new List<float>();
        Enemy_Ap = new List<float>();

        for (int i = 0; i < Team_Ap.Count; i++)
        {
            Team_Ap.Add(5.0f); //공격력 임의로 추가
            Enemy_Ap.Add(5.0f); //공격력 임의로 추가
        }

        for (int i = 0; i < Team_array.Count; i++)
        {
            Team_Pos.Add(Team_array[i].transform.position); //우리 팀의 위치를 리스트에 저장
        }

        for (int i = 0; i < Enemy_array.Count; i++)
        {
            Enemy_Pos.Add(Enemy_array[i].transform.position); //상대 팀의 위치를 리스트에 저장
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
        str = "";
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            for (int i = 0; i < 2; i++)
            {
                if (Team_array[i].name == "Player")
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                else if (Team_array[i].name == "Sonny")
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                else if (Team_array[i].name == "Bastion")
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                else if (Team_array[i].name == "Shooter")
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                else if (Team_array[i].name == "Healer")
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                else if (Team_array[i].name == "Booster")
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";

                if (Enemy_array[i].name == "Player")
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                else if (Enemy_array[i].name == "Sonny")
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                else if (Enemy_array[i].name == "Bastion")
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                else if (Enemy_array[i].name == "Shooter")
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                else if (Enemy_array[i].name == "Healer")
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                else if (Enemy_array[i].name == "Booster")
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (Team_array[i].name == "Player")
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                else if (Team_array[i].name == "Bastion")
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                else if (Team_array[i].name == "Bastion")
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                else if (Team_array[i].name == "Shooter")
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                else if (Team_array[i].name == "Healer")
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                else if (Team_array[i].name == "Booster")
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";

                if (Enemy_array[i].name == "Player")
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                else if (Enemy_array[i].name == "Bastion")
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                else if (Enemy_array[i].name == "Bastion")
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                else if (Enemy_array[i].name == "Shooter")
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                else if (Enemy_array[i].name == "Healer")
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                else if (Enemy_array[i].name == "Booster")
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
            }
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

    void OnGUI()
    {
        GUIStyle style;
        GUIStyle style2;
        Rect rect;
        Rect rect2;
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 4 / 100);
        rect2 = new Rect(w * 50 / 100, 0, w, h * 4 / 100);
        style = new GUIStyle();
        style2 = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style2.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 3 / 100;
        style2.fontSize = h * 3 / 100;
        style.normal.textColor = Color.white;
        style2.normal.textColor = Color.white;
        string text;

        text = str;

        string text2 = "";
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
            text2 = "Team : " + Team_array[0].name + ", " + Team_array[1].name + "\n"
                   + "Enemy : " + Enemy_array[0].name + ", " + Enemy_array[1].name;
        else
            text2 = "Team : " + Team_array[0].name + ", " + Team_array[1].name + ", " + Team_array[2].name + ", " + Team_array[3] + "\n"
                   + "Enemy : " + Enemy_array[0].name + ", " + Enemy_array[1].name + ", " + Enemy_array[2].name + ", " + Enemy_array[3] + "\n";

        GUI.Label(rect, text, style);
        GUI.Label(rect2, text2, style2);
    }
}