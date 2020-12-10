using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class no : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void onStart()
    {
        SceneManager.LoadScene("lobby"); //스테이지1 씬 전환
    }

    // Update is called once per frame
    void Update()
    {

    }
}
