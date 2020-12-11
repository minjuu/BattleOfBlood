using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float wtimer; //타이머 시작 변수
    float etimer; //타이머 종료 변수

    // Start is called before the first frame update
    void Start()
    {
        float wtimer = 0; //타이머 시작 초기화
        etimer = wtimer + 1; //타이머 종료 시점 지정

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        wtimer += Time.deltaTime; //타이머 작동
        if (wtimer > etimer) // 일정 시간이 되면
        {
            Destroy(gameObject, 0.0f); // 물줄기 사라짐

        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube") // 물줄기가 큐브에 닿으면
        {
            Destroy(col.gameObject, 0.0f); //큐브 사라짐
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cube")  // 물줄기가 큐브에 닿으면
        {
            Destroy(col.gameObject, 0.0f);  //큐브 사라짐
        }
        if (col.gameObject.name == "Shooter")  // 물줄기가 캐릭터에 닿으면
        {
            Shooter_Move.ShooterHp -= 10; //캐릭터 체력 감소
            Destroy(gameObject, 0.0f); //물줄기 사라짐
        }
        if (col.gameObject.name == "Bastion") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            BastionMove.BastionHp -= 5; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Healer") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            HealerMove.HealerHp -= 10; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Booster") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            BoosterMove.BoosterHp -= 10; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Player") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            Player.PlayerHp -= 10; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Sonny") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            SonnyMove.SonnyHp -= 10; //캐릭터 체력 감소
        }


    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Cube") // 물줄기가 큐브에 닿으면
        {
            Destroy(col.gameObject, 0.0f); //큐브 사라짐
        }
        if (col.gameObject.name == "Shooter") // 물줄기가 캐릭터에 닿으면
        {

            Shooter_Move.ShooterHp -= 10; //캐릭터 체력 감소
            Destroy(gameObject, 0.0f); //물줄기 사라짐
        }
        if (col.gameObject.name == "Bastion") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            BastionMove.BastionHp -= 5; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Healer") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            HealerMove.HealerHp -= 10; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Booster") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            BoosterMove.BoosterHp -= 10; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Player") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            Player.PlayerHp -= 10; //캐릭터 체력 감소
        }
        if (col.gameObject.name == "Sonny") // 물줄기가 캐릭터에 닿으면
        {
            Destroy(gameObject, 0.0f); //물줄기 사라짐
            SonnyMove.SonnyHp -= 10; //캐릭터 체력 감소
        }


    }

}