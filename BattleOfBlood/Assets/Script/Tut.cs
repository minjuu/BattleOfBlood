using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 튜토리얼 씬1일 경우 Enter 키를 누르면 다음 튜토리얼 씬으로 넘어감
         * 튜토리얼 씬2일 경우 Enter 키를 누르면 다음 튜토리얼 씬으로 넘어감
         * 튜토리얼 씬3일 경우 Enter 키를 누르면 다음 튜토리얼 씬으로 넘어감
         * 튜토리얼 씬4일 경우 Enter 키를 누르면 캐릭터 선택 씬으로 넘어감
         * 
         */
        if (SceneManager.GetActiveScene().name == "Tut1")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Tut2");
            }
        }
        if (SceneManager.GetActiveScene().name == "Tut2")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Tut3");
            }
        }
        if (SceneManager.GetActiveScene().name == "Tut3")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Tut4");
            }
        }
        if (SceneManager.GetActiveScene().name == "Tut4")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("selectchar");
            }
        }

    }
}