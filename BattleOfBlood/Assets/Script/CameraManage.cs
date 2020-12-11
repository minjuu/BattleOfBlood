using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

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

    public static string str;



    void Start()
    {
        Player.PlayerHp = 100;
        Shooter_Move.ShooterHp = 100;
        HealerMove.HealerHp = 100;
        BoosterMove.BoosterHp = 100;
        BastionMove.BastionHp = 100;
        SonnyMove.SonnyHp = 100;

        for (int i = 0; i < 3; i++)
        {
            Player.Team_Hp[i] = 100;
            Player.Enemy_Hp[i] = 100;
        }

        mainCamera.enabled = true;
        subCamera.enabled = false;

        


        if (SelectMng.booster1 == "Team")
            GameObject.Find("Booster").tag = "Team";
        else if (SelectMng.booster1 == "Enemy")
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

    }



    void Update()
    {
        if (Player.PlayerHp <= 0)
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;
            if (GameObject.Find("Player") != null) 
                GameObject.Find("Player").active = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab) && mainCamera.enabled == false)
            {
                mainCamera.enabled = true;
                subCamera.enabled = false;
            }
            else if (Input.GetKeyDown(KeyCode.Tab) && mainCamera.enabled == true)
            {
                mainCamera.enabled = false;
                subCamera.enabled = true;
            }
        }

        //stage1 : 팀원이 다 죽으면 Lose 씬으로 이동 , 적이 다 죽으면 Win 씬으로 이동
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Player.Team_Hp[0] <= 0 && Player.Team_Hp[1] <= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
            else if (Player.Enemy_Hp[0] <= 0 && Player.Enemy_Hp[1] <= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        }
        //stage2 : 팀원이 다 죽으면 Lose2 씬으로 이동, 적이 다죽으면 Win2 씬으로 이동
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Stage2")
        {
            if (Player.Team_Hp[0] <= 0 && Player.Team_Hp[1] <= 0 && Player.Team_Hp[2] <= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
            else if (Player.Enemy_Hp[0] <= 0 && Player.Enemy_Hp[1] <= 0 && Player.Enemy_Hp[2] <= 0)
                UnityEngine.SceneManagement.SceneManager.LoadScene("Win2");
        }
        str = "";
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            int i = 0;
            if (char1 != null && char1.tag == "Team")
            {
                if (Player.PlayerHp <= 0)
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";
                Player.Team_Hp[i] = Player.PlayerHp;
                i++;
            }
            if (char2 != null && char2.tag == "Team")
            {
                if (SonnyMove.SonnyHp <= 0)
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                Player.Team_Hp[i] = SonnyMove.SonnyHp;
                i++;
            }
            if (char3 != null && char3.tag == "Team")
            {
                if (BastionMove.BastionHp <= 0)
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                Player.Team_Hp[i] = BastionMove.BastionHp;
                i++;
            }
            if (char4 != null && char4.tag == "Team")
            {
                if (Shooter_Move.ShooterHp <= 0)
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                Player.Team_Hp[i] = Shooter_Move.ShooterHp;
                i++;
            }
            if (char5 != null && char5.tag == "Team")
            {
                if (HealerMove.HealerHp <= 0)
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                Player.Team_Hp[i] = HealerMove.HealerHp;
                i++;
            }
            if (char6 != null && char6.tag == "Team")
            {
                if (BoosterMove.BoosterHp <= 0)
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                Player.Team_Hp[i] = BoosterMove.BoosterHp;
                i++;
            }
            i = 0;
            if (Char1 != null && Char1.tag == "Enemy")
            {
                if (Player.PlayerHp <= 0)
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";
                Player.Enemy_Hp[i] = Player.PlayerHp;
                i++;
            }
            if (Char2 != null && Char2.tag == "Enemy")
            {
                if (SonnyMove.SonnyHp <= 0)
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                Player.Enemy_Hp[i] = SonnyMove.SonnyHp;
                i++;
            }
            if (Char3 != null && Char3.tag == "Enemy")
            {
                if (BastionMove.BastionHp <= 0)
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                Player.Enemy_Hp[i] = BastionMove.BastionHp;
                i++;
            }
            if (Char4 != null && Char4.tag == "Enemy")
            {
                if (Shooter_Move.ShooterHp <= 0)
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                Player.Enemy_Hp[i] = Shooter_Move.ShooterHp;
                i++;
            }
            if (Char5 != null && Char5.tag == "Enemy")
            {
                if (HealerMove.HealerHp <= 0)
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                Player.Enemy_Hp[i] = HealerMove.HealerHp;
                i++;
            }
            if (Char6 != null && Char6.tag == "Enemy")
            {
                if (BoosterMove.BoosterHp <= 0)
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                Player.Enemy_Hp[i] = BoosterMove.BoosterHp;
                i++;
            }
        }
        else
        {
            int i = 0;
            if (char1 != null && char1.tag == "Team")
            {
                if (Player.PlayerHp <= 0)
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";
                Player.Team_Hp[i] = Player.PlayerHp;
                i++;
            }
            if (char2 != null && char2.tag == "Team")
            {
                if (SonnyMove.SonnyHp <= 0)
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                Player.Team_Hp[i] = SonnyMove.SonnyHp;
                i++;
            }
            if (char3 != null && char3.tag == "Team")
            {
                if (BastionMove.BastionHp <= 0)
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                Player.Team_Hp[i] = BastionMove.BastionHp;
                i++;
            }
            if (char4 != null && char4.tag == "Team")
            {
                if (Shooter_Move.ShooterHp <= 0)
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                Player.Team_Hp[i] = Shooter_Move.ShooterHp;
                i++;
            }
            if (char5 != null && char5.tag == "Team")
            {
                if (HealerMove.HealerHp <= 0)
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                Player.Team_Hp[i] = HealerMove.HealerHp;
                i++;
            }
            if (char6 != null && char6.tag == "Team")
            {
                if (BoosterMove.BoosterHp <= 0)
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                Player.Team_Hp[i] = BoosterMove.BoosterHp;
                i++;
            }
            i = 0;
            if (Char1 != null && Char1.tag == "Enemy")
            {
                if (Player.PlayerHp <= 0)
                    Player.PlayerHp = 0;
                str += "Player HP: " + Player.PlayerHp + "% \n";
                Player.Enemy_Hp[i] = Player.PlayerHp;
                i++;
            }
            if (Char2 != null && Char2.tag == "Enemy")
            {
                if (SonnyMove.SonnyHp <= 0)
                    SonnyMove.SonnyHp = 0;
                str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                Player.Enemy_Hp[i] = SonnyMove.SonnyHp;
                i++;
            }
            if (Char3 != null && Char3.tag == "Enemy")
            {
                if (BastionMove.BastionHp <= 0)
                    BastionMove.BastionHp = 0;
                str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                Player.Enemy_Hp[i] = BastionMove.BastionHp;
                i++;
            }
            if (Char4 != null && Char4.tag == "Enemy")
            {
                if (Shooter_Move.ShooterHp <= 0)
                    Shooter_Move.ShooterHp = 0;
                str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                Player.Enemy_Hp[i] = Shooter_Move.ShooterHp;
                i++;
            }
            if (Char5 != null && Char5.tag == "Enemy")
            {
                if (HealerMove.HealerHp <= 0)
                    HealerMove.HealerHp = 0;
                str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                Player.Enemy_Hp[i] = HealerMove.HealerHp;
                i++;
            }
            if (Char6 != null && Char6.tag == "Enemy")
            {
                if (BoosterMove.BoosterHp <= 0)
                    BoosterMove.BoosterHp = 0;
                str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                Player.Enemy_Hp[i] = BoosterMove.BoosterHp;
                i++;
            }
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
        {
            text2 = "Team : ";

            if (char1 != null)
                text2 += "Player, ";
            if (char2 != null)
                text2 += "Sonny, ";
            if (char3 != null)
                text2 += "Bastion, ";
            if (char4 != null)
                text2 += "Shooter, ";
            if (char5 != null)
                text2 += "Healer, ";
            if (char6 != null)
                text2 += "Booster, ";

            text2 += "\n";

            text2 += "Enemy : ";

            if (Char1 != null)
                text2 += "Player, ";
            if (Char2 != null)
                text2 += "Sonny, ";
            if (Char3 != null)
                text2 += "Bastion, ";
            if (Char4 != null)
                text2 += "Shooter, ";
            if (Char5 != null)
                text2 += "Healer, ";
            if (Char6 != null)
                text2 += "Booster, ";

            text2 += "\n";
        }
        else
        {
            text2 = "Team : ";

            if (char1 != null)
                text2 += "Player, ";
            if (char2 != null)
                text2 += "Sonny, ";
            if (char3 != null)
                text2 += "Bastion, ";
            if (char4 != null)
                text2 += "Shooter, ";
            if (char5 != null)
                text2 += "Healer, ";
            if (char6 != null)
                text2 += "Booster, ";

            text2 += "\n";
            text2 += "Enemy : ";

            if (Char1 != null)
                text2 += "Player, ";
            if (Char2 != null)
                text2 += "Sonny, ";
            if (Char3 != null)
                text2 += "Bastion, ";
            if (Char4 != null)
                text2 += "Shooter, ";
            if (Char5 != null)
                text2 += "Healer, ";
            if (Char6 != null)
                text2 += "Booster, ";

            text2 += "\n";
        }

        GUI.Label(rect, text, style);
        GUI.Label(rect2, text2, style2);
    }
}