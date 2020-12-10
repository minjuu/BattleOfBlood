using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    public static string str;



    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
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
            for (int i = 0; i < 2; i++)
            {
                if (Player.Team_array[i].name == "Player")
                {
                    if (Player.PlayerHp <= 0)
                        Player.PlayerHp = 0;
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                    Player.Team_Hp[i] = Player.PlayerHp;
                }
                else if (Player.Team_array[i].name == "Sonny")
                {
                    if (SonnyMove.SonnyHp <= 0)
                        SonnyMove.SonnyHp = 0;
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                    Player.Team_Hp[i] = SonnyMove.SonnyHp;
                }
                else if (Player.Team_array[i].name == "Bastion")
                {
                    if (BastionMove.BastionHp <= 0)
                        BastionMove.BastionHp = 0;
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                    Player.Team_Hp[i] = BastionMove.BastionHp;
                }
                else if (Player.Team_array[i].name == "Shooter")
                {
                    if (Shooter_Move.ShooterHp <= 0)
                        Shooter_Move.ShooterHp = 0;
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                    Player.Team_Hp[i] = Shooter_Move.ShooterHp;
                }
                else if (Player.Team_array[i].name == "Healer")
                {
                    if (HealerMove.HealerHp <= 0)
                        HealerMove.HealerHp = 0;
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                    Player.Team_Hp[i] = HealerMove.HealerHp;
                }
                else if (Player.Team_array[i].name == "Booster")
                {
                    if (BoosterMove.BoosterHp <= 0)
                        BoosterMove.BoosterHp = 0;
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                    Player.Team_Hp[i] = BoosterMove.BoosterHp;
                }

                if (Player.Enemy_array[i].name == "Player")
                {
                    if (Player.PlayerHp <= 0)
                        Player.PlayerHp = 0;
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                    Player.Enemy_Hp[i] = Player.PlayerHp;
                }
                else if (Player.Enemy_array[i].name == "Sonny")
                {
                    if (SonnyMove.SonnyHp <= 0)
                        SonnyMove.SonnyHp = 0;
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                    Player.Enemy_Hp[i] = SonnyMove.SonnyHp;
                }
                else if (Player.Enemy_array[i].name == "Bastion")
                {
                    if (BastionMove.BastionHp <= 0)
                        BastionMove.BastionHp = 0;
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                    Player.Enemy_Hp[i] = BastionMove.BastionHp;
                }
                else if (Player.Enemy_array[i].name == "Shooter")
                {
                    if (Shooter_Move.ShooterHp <= 0)
                        Shooter_Move.ShooterHp = 0;
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                    Player.Enemy_Hp[i] = Shooter_Move.ShooterHp;
                }
                else if (Player.Enemy_array[i].name == "Healer")
                {
                    if (HealerMove.HealerHp <= 0)
                        HealerMove.HealerHp = 0;
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                    Player.Enemy_Hp[i] = HealerMove.HealerHp;
                }
                else if (Player.Enemy_array[i].name == "Booster")
                {
                    if (BoosterMove.BoosterHp <= 0)
                        BoosterMove.BoosterHp = 0;
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                    Player.Enemy_Hp[i] = BoosterMove.BoosterHp;
                }
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                if (Player.Team_array[i].name == "Player")
                {
                    if (Player.PlayerHp <= 0)
                        Player.PlayerHp = 0;
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                    Player.Team_Hp[i] = Player.PlayerHp;
                }
                else if (Player.Team_array[i].name == "Sonny")
                {
                    if (SonnyMove.SonnyHp <= 0)
                        SonnyMove.SonnyHp = 0;
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                    Player.Team_Hp[i] = SonnyMove.SonnyHp;
                }
                else if (Player.Team_array[i].name == "Bastion")
                {
                    if (BastionMove.BastionHp <= 0)
                        BastionMove.BastionHp = 0;
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                    Player.Team_Hp[i] = BastionMove.BastionHp;
                }
                else if (Player.Team_array[i].name == "Shooter")
                {
                    if (Shooter_Move.ShooterHp <= 0)
                        Shooter_Move.ShooterHp = 0;
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                    Player.Team_Hp[i] = Shooter_Move.ShooterHp;
                }
                else if (Player.Team_array[i].name == "Healer")
                {
                    if (HealerMove.HealerHp <= 0)
                        HealerMove.HealerHp = 0;
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                    Player.Team_Hp[i] = HealerMove.HealerHp;
                }
                else if (Player.Team_array[i].name == "Booster")
                {
                    if (BoosterMove.BoosterHp <= 0)
                        BoosterMove.BoosterHp = 0;
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                    Player.Team_Hp[i] = BoosterMove.BoosterHp;
                }

                if (Player.Enemy_array[i].name == "Player")
                {
                    if (Player.PlayerHp <= 0)
                        Player.PlayerHp = 0;
                    str += "Player HP: " + Player.PlayerHp + "% \n";
                    Player.Enemy_Hp[i] = Player.PlayerHp;
                }
                else if (Player.Enemy_array[i].name == "Sonny")
                {
                    if (SonnyMove.SonnyHp <= 0)
                        SonnyMove.SonnyHp = 0;
                    str += "Sonny HP: " + SonnyMove.SonnyHp + "% \n";
                    Player.Enemy_Hp[i] = SonnyMove.SonnyHp;
                }
                else if (Player.Enemy_array[i].name == "Bastion")
                {
                    if (BastionMove.BastionHp <= 0)
                        BastionMove.BastionHp = 0;
                    str += "Bastion HP: " + BastionMove.BastionHp + "% \n";
                    Player.Enemy_Hp[i] = BastionMove.BastionHp;
                }
                else if (Player.Enemy_array[i].name == "Shooter")
                {
                    if (Shooter_Move.ShooterHp <= 0)
                        Shooter_Move.ShooterHp = 0;
                    str += "Shooter HP: " + Shooter_Move.ShooterHp + "% \n";
                    Player.Enemy_Hp[i] = Shooter_Move.ShooterHp;
                }
                else if (Player.Enemy_array[i].name == "Healer")
                {
                    if (HealerMove.HealerHp <= 0)
                        HealerMove.HealerHp = 0;
                    str += "Healer HP: " + HealerMove.HealerHp + "% \n";
                    Player.Enemy_Hp[i] = HealerMove.HealerHp;
                }
                else if (Player.Enemy_array[i].name == "Booster")
                {
                    if (BoosterMove.BoosterHp <= 0)
                        BoosterMove.BoosterHp = 0;
                    str += "Booster HP: " + BoosterMove.BoosterHp + "% \n";
                    Player.Enemy_Hp[i] = BoosterMove.BoosterHp;
                }

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
            text2 = "Team : " + Player.Team_array[0].name + ", " + Player.Team_array[1].name + "\n"
                   + "Enemy : " + Player.Enemy_array[0].name + ", " + Player.Enemy_array[1].name;
        else
            text2 = "Team : " + Player.Team_array[0].name + ", " + Player.Team_array[1].name + ", " + Player.Team_array[2].name +"\n"
                   + "Enemy : " + Player.Enemy_array[0].name + ", " + Player.Enemy_array[1].name + ", " + Player.Enemy_array[2].name + ", " + "\n";

        GUI.Label(rect, text, style);
        GUI.Label(rect2, text2, style2);
    }
}