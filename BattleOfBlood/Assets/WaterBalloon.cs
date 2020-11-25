using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBalloon : MonoBehaviour
{

    float wtimer;
    float etimer;
    public GameObject water = null;
    Vector3 water_pos;
    // Start is called before the first frame update
    void Start()
    {
        float wtimer = Time.time;
        etimer = wtimer+1.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {

        wtimer += Time.deltaTime;
        if (wtimer > etimer)
        {
            Destroy(gameObject, 0.0f);
            GameObject Water = GameObject.Instantiate(water);
            water_pos.x = transform.position.x; // 구멍의 x 위치 = 아이템 공의 x 위치
            water_pos.z = transform.position.z; // 구멍의 z 위치 = 아이템 공의 z 위치
            water_pos.y = 0.35f; // 구멍의 x 위치 = 아이템 공의 x 위치
            Water.transform.position = water_pos; // Water 오브젝트의 위치 저장
            Water.transform.parent = null;  //위치 독립
        }
    }
}
