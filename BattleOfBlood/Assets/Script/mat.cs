using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mat : MonoBehaviour
{
    Renderer AiColor;
    public GameObject ParObject;
    // Start is called before the first frame update
    void Start()
    {
        AiColor = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(ParObject.tag=="Enemy") //오브젝트의 태그가 적이면
        {
            AiColor.material.color = Color.red; //빨갛게 색을 바꿔줌
        }
   

    }
}
