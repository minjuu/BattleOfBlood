using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Move : MonoBehaviour
{
    public Vector3 Dir;   //총알 방향
    public Vector3 n = new Vector3(0, 0, 0);
    void Start()
    {
        Destroy(gameObject, 5.0f);  //총알 5초뒤에 사라짐
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Dir * 0.2f;   //총알 나가게

    }

    void OnCollisionEnter(Collision col)  //충돌
    {
        if (col.gameObject.tag == "Cube") //큐브충돌시
        {
            Destroy(gameObject, 0.0f);     //총알 삭제
            Destroy(col.gameObject, 0.05f);  //큐브 삭제
        }
        if (col.gameObject.tag != Shooter_Move.ShooterTag)
        {
            if (col.gameObject.name == "Healer")        //힐러 충돌
                HealerMove.HealerHp -= Shooter_Move.ShooterAp;    //ap만큼 hp감소
            if (col.gameObject.name == "Sonny")                   //힐러 충돌
                SonnyMove.SonnyHp -= Shooter_Move.ShooterAp;             //ap만큼 hp감소
            if (col.gameObject.name == "Bastion")                    //힐러 충돌
                BastionMove.BastionHp -= Shooter_Move.ShooterAp;         //ap만큼 hp감소
            if (col.gameObject.name == "Booster")                //힐러 충돌
                BoosterMove.BoosterHp -= Shooter_Move.ShooterAp;          //ap만큼 hp감소
            if (col.gameObject.name == "Player")             //힐러 충돌
                Player.PlayerHp -= Shooter_Move.ShooterAp;           //ap만큼 hp감소
        }
    }
}