using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage2 : MonoBehaviour
{
    float startt = 0;
    float endtt = 0;
    // Start is called before the first frame update
    void Start()
    {
        startt = Time.time;
        endtt = startt + 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        startt += Time.deltaTime;

        if (startt > endtt)
            SceneManager.LoadScene("lobby");

    }
}
