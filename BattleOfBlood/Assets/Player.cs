using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int PlayerHp = 100;
    public static Vector3 PlayerPos;
    public GameObject WaterBalloon;
    public static float PlayerSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 Dir = new Vector3(Mathf.Sin(DirR / 180.0f * 3.14f), 0, Mathf.Cos(DirR / 180.0f * 3.14f));
       
        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerPos += transform.forward*PlayerSpeed ;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerPos += transform.forward * PlayerSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(0, -90, 0);
            PlayerPos += transform.forward * PlayerSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerPos += transform.forward * PlayerSpeed;
        }

        transform.position = PlayerPos;
        PlayerPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject balloon = GameObject.Instantiate(WaterBalloon)
                as GameObject;

            balloon.transform.parent = null;
            //balloon.gameObject.layer = LayerMask.NameToLayer("Player");
            balloon .transform.position = transform.position;
        }
    }

    void OnGUI()
    {
        GUIStyle style;
        Rect rect;
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 4 / 100);
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = Color.black;

        string text = "Player HP: " + PlayerHp + "% \n";
        GUI.Label(rect, text, style);
    }
}
