using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectMng : MonoBehaviour
{
    public static int selectcount;
    public static int enemycount = 0;
    public static string sonny1;
    public static string bastion1;
    public static string shooter1;
    public static string healer1;
    public static string booster1;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    public GameObject character5;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "selectchar" || SceneManager.GetActiveScene().name == "selectchar2")
        {
            //character1.gameObject.tag = "Untagged";
            //character2.gameObject.tag = "Untagged";
            //character3.gameObject.tag = "Untagged";
            //character4.gameObject.tag = "Untagged";
            //character5.gameObject.tag = "Untagged";

            sonny1 = "";
            bastion1 = "";
            shooter1 = "";
            healer1 = "";
            booster1 = "";


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
