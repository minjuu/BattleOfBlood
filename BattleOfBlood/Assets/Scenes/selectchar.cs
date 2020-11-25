using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class selectchar : MonoBehaviour
{
    // Start is called before the first frame update

    public void onStart()
    {
        SceneManager.LoadScene("SampleScene"); //스테이지2 씬 로드
    }
}
