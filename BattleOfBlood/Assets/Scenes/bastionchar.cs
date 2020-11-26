﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bastionchar : MonoBehaviour
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
            SceneManager.LoadScene("SampleScene");
        }

        if (SceneManager.GetActiveScene().name == "selectchar2")
        {
            character.gameObject.tag = "Team";
            SelectMng.selectcount++;
            GetComponent<Button>().interactable = false;
            if (SelectMng.selectcount == 2)
            {
              
                Debug.Log("end");
                if (enemycharacter1.gameObject.tag != "Team"&&SelectMng.enemycount<3)
                {
                    enemycharacter1.gameObject.tag = "Enemy";
                    SelectMng.enemycount++;
                }
                if (enemycharacter2.gameObject.tag != "Team" && SelectMng.enemycount < 3)
                {
                    enemycharacter2.gameObject.tag = "Enemy";
                    SelectMng.enemycount++;
                }
                if (enemycharacter3.gameObject.tag != "Team" && SelectMng.enemycount < 3)
                {
                    enemycharacter3.gameObject.tag = "Enemy";
                    SelectMng.enemycount++;
                }
                if (enemycharacter4.gameObject.tag != "Team" && SelectMng.enemycount < 3)
                {
                    enemycharacter4.gameObject.tag = "Enemy";
                    SelectMng.enemycount++;
                }
               
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
