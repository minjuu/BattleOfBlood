using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yes2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void onStart()
    {
        SceneManager.LoadScene("SampleScene"); //스테이지1 씬 전환
    }

    // Update is called once per frame
    void Update()
    {

    }
}
