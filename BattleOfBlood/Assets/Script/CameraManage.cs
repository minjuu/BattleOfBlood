using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CameraManage : MonoBehaviour
{
    public Camera mainCamera;  //카메라1
    public Camera subCamera;   //카메라2

    public GameObject char1;    //캐릭터 오브젝트 변수
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

    public static string str;    //gui용 string 변수



    void Start()
    {
        Player.PlayerHp = 100;           //체력 100으로 초기화
        Shooter_Move.ShooterHp = 100;
        HealerMove.HealerHp = 100;
        BoosterMove.BoosterHp = 100;
        BastionMove.BastionHp = 100;
        SonnyMove.SonnyHp = 100;

        for (int i = 0; i < 3; i++)   //체력 배열 100으로 초기화
        {
            Player.Team_Hp[i] = 100;
            Player.Enemy_Hp[i] = 100;
        }


        mainCamera.enabled = true;   //초기 main카메라 켬
        subCamera.enabled = false;    //sub 끔
        if (SceneManager.GetActiveScene().name == "Stage2")  //씬2
        {
            GameObject.Find("Char").transform.Find("Booster").gameObject.SetActive(true);  //오브젝트 active    
            GameObject.Find("Char").transform.Find("Sonny").gameObject.SetActive(true);
            GameObject.Find("Char").transform.Find("Bastion").gameObject.SetActive(true);
            GameObject.Find("Char").transform.Find("Shooter").gameObject.SetActive(true);
            GameObject.Find("Char").transform.Find("Healer").gameObject.SetActive(true);
        }


        if (SelectMng.booster1 == "Team")  //부스터가 팀
            GameObject.Find("Booster").tag = "Team";    //부스터 태그 팀으로
        else if (SelectMng.booster1 == "Enemy")             //부스터가 enemy
            GameObject.Find("Booster").tag = "Enemy";       //부스터 태그 enemy

        if (SelectMng.bastion1 == "Team")                  //팀이면
            GameObject.Find("Bastion").tag = "Team";       //태그 팀으로 바꿈
        else if (SelectMng.bastion1 == "Enemy")            //적이면
            GameObject.Find("Bastion").tag = "Enemy";      //태그 적으로 바꿈

        if (SelectMng.healer1 == "Team")                  //팀이면
            GameObject.Find("Healer").tag = "Team";       //태그 팀으로 바꿈
        else if (SelectMng.healer1 == "Enemy")            //적이면
            GameObject.Find("Healer").tag = "Enemy";      //태그 적으로 바꿈

        if (SelectMng.sonny1 == "Team")                   //팀이면
            GameObject.Find("Sonny").tag = "Team";        //태그 팀으로 바꿈
        else if (SelectMng.sonny1 == "Enemy")             //적이면
            GameObject.Find("Sonny").tag = "Enemy";       //태그 적으로 바꿈

        if (SelectMng.shooter1 == "Team")                //팀이면
            GameObject.Find("Shooter").tag = "Team";     //태그 팀으로 바꿈
        else if (SelectMng.shooter1 == "Enemy")          //적이면
            GameObject.Find("Shooter").tag = "Enemy";    //태그 적으로 바꿈

        if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Team")       //팀이면
            char1 = GameObject.Find("Player");                                                             //오브젝트 넣기
        if (GameObject.Find("Sonny") != null && GameObject.Find("Sonny").gameObject.tag == "Team")          //팀이면
            char2 = GameObject.Find("Sonny");                                                               //오브젝트 넣기
        if (GameObject.Find("Bastion") != null && GameObject.Find("Bastion").gameObject.tag == "Team")        //팀이면
            char3 = GameObject.Find("Bastion");                                                               //오브젝트 넣기
        if (GameObject.Find("Shooter") != null && GameObject.Find("Shooter").gameObject.tag == "Team")      //팀이면
            char4 = GameObject.Find("Shooter");                                                             //오브젝트 넣기
        if (GameObject.Find("Healer") != null && GameObject.Find("Healer").gameObject.tag == "Team")        //팀이면
            char5 = GameObject.Find("Healer");                                                              //오브젝트 넣기
        if (GameObject.Find("Booster") != null && GameObject.Find("Booster").gameObject.tag == "Team")      //팀이면
            char6 = GameObject.Find("Booster");                                                             //오브젝트 넣기

        if (GameObject.Find("Player") != null && GameObject.Find("Player").gameObject.tag == "Enemy")     //Eneny이면
            Char1 = GameObject.Find("Player");                                                              //오브젝트 넣기
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

    }



    void Update()
    {
        if (Player.PlayerHp <= 0)   //플레이어 죽으면
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;    //sub카메라로 고정
            if (GameObject.Find("Player") != null)     //플레이어 있으면
                GameObject.Find("Player").active = false;   //active false
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab) && mainCamera.enabled == false)   //탭 키 누르면
            {
                mainCamera.enabled = true;    //카메라 전환
                subCamera.enabled = false;
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && mainCamera.enabled == true)  //탭키 누르면
            {
                mainCamera.enabled = false;   //카메라 전환
                subCamera.enabled = true;
            }
        }

        //stage1 : 팀원이 다 죽으면 Lose 씬으로 이동 , 적이 다 죽으면 Win 씬으로 이동
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Player.Team_Hp[0] <= 0 && Player.Team_Hp[1] <= 0)
                SceneManager.LoadScene("Lose");
            else if (Player.Enemy_Hp[0] <= 0 && Player.Enemy_Hp[1] <= 0)
                SceneManager.LoadScene("Win");
        }
        //stage2 : 팀원이 다 죽으면 Lose2 씬으로 이동, 적이 다죽으면 Win2 씬으로 이동
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2")
        {
            if (Player.Team_Hp[0] <= 0 && Player.Team_Hp[1] <= 0 && Player.Team_Hp[2] <= 0)
                SceneManager.LoadScene("Lose");
            else if (Player.Enemy_Hp[0] <= 0 && Player.Enemy_Hp[1] <= 0 && Player.Enemy_Hp[2] <= 0)
                SceneManager.LoadScene("Win2");
        }
        str = "";// str 초기화
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene") //샘플 신에서
        {
            int i = 0;
            if (char1 != null && char1.tag == "Team")  //팀이면
            {
                if (Player.PlayerHp <= 0)    //체력 0이하 못가도록
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";   //str HP 더해줌
                Player.Team_Hp[i] = Player.PlayerHp;               //체력 배열에 넣기
                i++;
            }
            if (char2 != null && char2.tag == "Team")
            {
                if (SonnyMove.SonnyHp <= 0)  //체력 0이하 못가도록
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";     //str HP 더해줌
                Player.Team_Hp[i] = SonnyMove.SonnyHp;                //체력 배열에 넣기
                i++;
            }
            if (char3 != null && char3.tag == "Team")
            {
                if (BastionMove.BastionHp <= 0)  //체력 0이하 못가도록
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";      //str HP 더해줌
                Player.Team_Hp[i] = BastionMove.BastionHp;                   //체력 배열에 넣기
                i++;
            }
            if (char4 != null && char4.tag == "Team")
            {
                if (Shooter_Move.ShooterHp <= 0)  //체력 0이하 못가도록
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";    //str HP 더해줌
                Player.Team_Hp[i] = Shooter_Move.ShooterHp;                 //체력 배열에 넣기
                i++;
            }
            if (char5 != null && char5.tag == "Team")
            {
                if (HealerMove.HealerHp <= 0)  //체력 0이하 못가도록
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";   //str HP 더해줌
                Player.Team_Hp[i] = HealerMove.HealerHp;               //체력 배열에 넣기
                i++;
            }
            if (char6 != null && char6.tag == "Team")
            {
                if (BoosterMove.BoosterHp <= 0)  //체력 0이하 못가도록
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";    //str HP 더해줌
                Player.Team_Hp[i] = BoosterMove.BoosterHp;                 //체력 배열에 넣기
                i++;
            }
            i = 0;
            if (Char1 != null && Char1.tag == "Enemy")
            {
                if (Player.PlayerHp <= 0)  //체력 0이하 못가도록
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = Player.PlayerHp;               //체력 배열에 넣기
                i++;
            }
            if (Char2 != null && Char2.tag == "Enemy")
            {
                if (SonnyMove.SonnyHp <= 0)  //체력 0이하 못가도록
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = SonnyMove.SonnyHp;              //체력 배열에 넣기
                i++;
            }
            if (Char3 != null && Char3.tag == "Enemy")
            {
                if (BastionMove.BastionHp <= 0)  //체력 0이하 못가도록
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = BastionMove.BastionHp;                //체력 배열에 넣기
                i++;
            }
            if (Char4 != null && Char4.tag == "Enemy")
            {
                if (Shooter_Move.ShooterHp <= 0)  //체력 0이하 못가도록
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = Shooter_Move.ShooterHp;                //체력 배열에 넣기
                i++;
            }
            if (Char5 != null && Char5.tag == "Enemy")
            {
                if (HealerMove.HealerHp <= 0)  //체력 0이하 못가도록
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = HealerMove.HealerHp;               //체력 배열에 넣기
                i++;
            }
            if (Char6 != null && Char6.tag == "Enemy")
            {
                if (BoosterMove.BoosterHp <= 0)  //체력 0이하 못가도록
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = BoosterMove.BoosterHp;                //체력 배열에 넣기
                i++;
            }
        }
        else
        {
            int i = 0;
            if (char1 != null && char1.tag == "Team")  //팀이면
            {
                if (Player.PlayerHp <= 0)    //체력 0이하 못가도록
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";   //str HP 더해줌
                Player.Team_Hp[i] = Player.PlayerHp;               //체력 배열에 넣기
                i++;
            }
            if (char2 != null && char2.tag == "Team")
            {
                if (SonnyMove.SonnyHp <= 0)  //체력 0이하 못가도록
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";     //str HP 더해줌
                Player.Team_Hp[i] = SonnyMove.SonnyHp;                //체력 배열에 넣기
                i++;
            }
            if (char3 != null && char3.tag == "Team")
            {
                if (BastionMove.BastionHp <= 0)  //체력 0이하 못가도록
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";      //str HP 더해줌
                Player.Team_Hp[i] = BastionMove.BastionHp;                   //체력 배열에 넣기
                i++;
            }
            if (char4 != null && char4.tag == "Team")
            {
                if (Shooter_Move.ShooterHp <= 0)  //체력 0이하 못가도록
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";    //str HP 더해줌
                Player.Team_Hp[i] = Shooter_Move.ShooterHp;                 //체력 배열에 넣기
                i++;
            }
            if (char5 != null && char5.tag == "Team")
            {
                if (HealerMove.HealerHp <= 0)  //체력 0이하 못가도록
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";   //str HP 더해줌
                Player.Team_Hp[i] = HealerMove.HealerHp;               //체력 배열에 넣기
                i++;
            }
            if (char6 != null && char6.tag == "Team")
            {
                if (BoosterMove.BoosterHp <= 0)  //체력 0이하 못가도록
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";    //str HP 더해줌
                Player.Team_Hp[i] = BoosterMove.BoosterHp;                 //체력 배열에 넣기
                i++;
            }
            i = 0;
            if (Char1 != null && Char1.tag == "Enemy")
            {
                if (Player.PlayerHp <= 0)  //체력 0이하 못가도록
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = Player.PlayerHp;               //체력 배열에 넣기
                i++;
            }
            if (Char2 != null && Char2.tag == "Enemy")
            {
                if (SonnyMove.SonnyHp <= 0)  //체력 0이하 못가도록
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = SonnyMove.SonnyHp;              //체력 배열에 넣기
                i++;
            }
            if (Char3 != null && Char3.tag == "Enemy")
            {
                if (BastionMove.BastionHp <= 0)  //체력 0이하 못가도록
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = BastionMove.BastionHp;                //체력 배열에 넣기
                i++;
            }
            if (Char4 != null && Char4.tag == "Enemy")
            {
                if (Shooter_Move.ShooterHp <= 0)  //체력 0이하 못가도록
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = Shooter_Move.ShooterHp;                //체력 배열에 넣기
                i++;
            }
            if (Char5 != null && Char5.tag == "Enemy")
            {
                if (HealerMove.HealerHp <= 0)  //체력 0이하 못가도록
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = HealerMove.HealerHp;               //체력 배열에 넣기
                i++;
            }
            if (Char6 != null && Char6.tag == "Enemy")
            {
                if (BoosterMove.BoosterHp <= 0)  //체력 0이하 못가도록
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";    //str HP 더해줌
                Player.Enemy_Hp[i] = BoosterMove.BoosterHp;                //체력 배열에 넣기
                i++;
            }
        }
    }

    void OnGUI()
    {
        GUIStyle style;          //gui 두개 설정
        GUIStyle style2;
        Rect rect;
        Rect rect2;
        int w = Screen.width, h = Screen.height;    //텍스트 위치 및 크기 설정
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
        text = str;    //str 넣어줌

        string text2 = "";  //텍스트 2 비우기

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            text2 = "Team : ";                  //팀일때

            if (char1 != null)                  //캐릭터 있으면 넣어주기
                text2 += "Player ";
            if (char2 != null)
                text2 += "Sonny ";
            if (char3 != null)
                text2 += "Bastion ";
            if (char4 != null)
                text2 += "Shooter ";
            if (char5 != null)
                text2 += "Healer ";
            if (char6 != null)
                text2 += "Booster ";

            text2 += "\n";

            text2 += "Enemy : ";                //적일때

            if (Char1 != null)                  //캐릭터 있으면 넣어주기
                text2 += "Player ";
            if (Char2 != null)
                text2 += "Sonny ";
            if (Char3 != null)
                text2 += "Bastion ";
            if (Char4 != null)
                text2 += "Shooter ";
            if (Char5 != null)
                text2 += "Healer ";
            if (Char6 != null)
                text2 += "Booster ";

            text2 += "\n";
        }
        else
        {
            text2 = "Team : ";                    //팀일때

            if (char1 != null)                    //캐릭터 있으면 넣어주기
                text2 += "Player ";
            if (char2 != null)
                text2 += "Sonny ";
            if (char3 != null)
                text2 += "Bastion ";
            if (char4 != null)
                text2 += "Shooter ";
            if (char5 != null)
                text2 += "Healer ";
            if (char6 != null)
                text2 += "Booster ";

            text2 += "\n";
            text2 += "Enemy : ";                  //적일 때

            if (Char1 != null)                    //캐릭터 있으면 넣어주기
                text2 += "Player ";
            if (Char2 != null)
                text2 += "Sonny ";
            if (Char3 != null)
                text2 += "Bastion ";
            if (Char4 != null)
                text2 += "Shooter ";
            if (Char5 != null)
                text2 += "Healer ";
            if (Char6 != null)
                text2 += "Booster ";

            text2 += "\n";
        }

        GUI.Label(rect, text, style);
        GUI.Label(rect2, text2, style2);        //화면에 띄우기
    }
}