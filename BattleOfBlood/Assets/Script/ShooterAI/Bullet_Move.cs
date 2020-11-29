using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    public Vector3 Dir;
    public Vector3 n = new Vector3(0, 0, 0);
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Dir * 0.2f;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cube")
        {
            Destroy(gameObject, 0.0f);
            Destroy(col.gameObject, 0.05f);
        }
        if (col.gameObject.tag != Shooter_Move.ShooterTag)
        {
            Debug.Log("물총 충돌");
            if (col.gameObject.name == "Healer")
                HealerMove.HealerHp -= 10;
            if (col.gameObject.name == "Sonny")
                SonnyMove.SonnyHp -= 10;
            if (col.gameObject.name == "Bastion")
                BastionMove.BastionHp -= 10;
            if (col.gameObject.name == "Booster")
                BoosterMove.BoosterHp -= 10;
            if (col.gameObject.name == "Player")
                Player.PlayerHp -= 10;
        }
    }
}