using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMng : MonoBehaviour
{
    public static int selectcount = 0;
    public static int enemycount = 0;
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;
    public GameObject character4;
    public GameObject character5;
    // Start is called before the first frame update
    void Start()
    {
        character1.gameObject.tag = "Untagged";
        character2.gameObject.tag = "Untagged";
        character3.gameObject.tag = "Untagged";
        character4.gameObject.tag = "Untagged";
        character5.gameObject.tag = "Untagged";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
