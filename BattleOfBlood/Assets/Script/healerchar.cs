using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class healerchar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    public GameObject enemycharacter1;
    public GameObject enemycharacter2;
    public GameObject enemycharacter3;
    public GameObject enemycharacter4;


    // Start is called before the first frame update
    public void onStart()
    {

        if (SceneManager.GetActiveScene().name == "selectchar")
        {
            character.gameObject.tag = "Team";
            enemycharacter1.gameObject.tag = "Enemy";
            enemycharacter2.gameObject.tag = "Enemy";
            enemycharacter3 = null;
            SelectMng.healer1 = "Team";
            SelectMng.shooter1 = "Enemy";
            SelectMng.bastion1 = "Enemy";
            SelectMng.sonny1 = "";
            SceneManager.LoadScene("SampleScene");
        }

        if (SceneManager.GetActiveScene().name == "selectchar2")
        {
            character.gameObject.tag = "Team";
            SelectMng.healer1 = "Team";
            SelectMng.selectcount++;

            SceneManager.LoadScene("selectchar3");

        }
        if (SceneManager.GetActiveScene().name == "selectchar3")
        {
            character.gameObject.tag = "Team";
            SelectMng.healer1 = "Team";
            SelectMng.selectcount++;

            //   if (SelectMng.selectcount == 2)
            //  {

            Debug.Log("end");
            if (enemycharacter1.gameObject.tag != "Team" && SelectMng.enemycount < 3)
            {
                enemycharacter1.gameObject.tag = "Enemy";
                SelectMng.shooter1 = "Enemy";
                SelectMng.enemycount++;
            }
            if (enemycharacter2.gameObject.tag != "Team" && SelectMng.enemycount < 3)
            {
                enemycharacter2.gameObject.tag = "Enemy";
                SelectMng.bastion1 = "Enemy";
                SelectMng.enemycount++;
            }
            if (enemycharacter3.gameObject.tag != "Team" && SelectMng.enemycount < 3)
            {
                enemycharacter3.gameObject.tag = "Enemy";
                SelectMng.sonny1 = "Enemy";
                SelectMng.enemycount++;
            }
            if (enemycharacter4.gameObject.tag != "Team" && SelectMng.enemycount < 3)
            {
                enemycharacter4.gameObject.tag = "Enemy";
                SelectMng.booster1 = "Enemy";
                SelectMng.enemycount++;
            }

            SceneManager.LoadScene("Stage2");
            //}
        }
    }
}
