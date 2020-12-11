using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamestartbtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnStart()
    {
        SceneManager.LoadScene("Tut1"); //버튼 클릭시 씬을 변경
    }
}