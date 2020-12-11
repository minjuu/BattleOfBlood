using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float wtimer;
    float etimer;

    // Start is called before the first frame update
    void Start()
    {
        float wtimer = 0;
        etimer = wtimer + 1;

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

        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(col.gameObject, 0.0f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(col.gameObject, 0.0f);
        }
        if (col.gameObject.name == "Shooter")
        {
            Shooter_Move.ShooterHp -= 10;
            Destroy(gameObject, 0.0f);
        }
        if (col.gameObject.name == "Bastion")
        {
            Destroy(gameObject, 0.0f);
            BastionMove.BastionHp -= 5;
        }
        if (col.gameObject.name == "Healer")
        {
            Destroy(gameObject, 0.0f);
            HealerMove.HealerHp -= 10;
        }
        if (col.gameObject.name == "Booster")
        {
            Destroy(gameObject, 0.0f);
            BoosterMove.BoosterHp -= 10;
        }
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject, 0.0f);
            Player.PlayerHp -= 10;
        }
        if (col.gameObject.name == "Sonny")
        {
            Destroy(gameObject, 0.0f);
            SonnyMove.SonnyHp -= 10;
        }


    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(col.gameObject, 0.0f);
        }
        if (col.gameObject.name == "Shooter")
        {
            Shooter_Move.ShooterHp -= 10;
            Destroy(gameObject, 0.0f);
        }
        if (col.gameObject.name == "Bastion")
        {
            Destroy(gameObject, 0.0f);
            BastionMove.BastionHp -= 5;
        }
        if (col.gameObject.name == "Healer")
        {
            Destroy(gameObject, 0.0f);
            HealerMove.HealerHp -= 10;
        }
        if (col.gameObject.name == "Booster")
        {
            Destroy(gameObject, 0.0f);
            BoosterMove.BoosterHp -= 10;
        }
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject, 0.0f);
            Player.PlayerHp -= 10;
        }
        if (col.gameObject.name == "Sonny")
        {
            Destroy(gameObject, 0.0f);
            SonnyMove.SonnyHp -= 10;
        }


    }

}