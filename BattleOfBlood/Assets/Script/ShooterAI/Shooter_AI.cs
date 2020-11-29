﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private ShooterMove moveForTarget = new ShooterMove();
    private ChangeGun changeGun = new ChangeGun();
    private OnAttack m_OnAttack = new OnAttack();
    private IsDead m_IsDead = new IsDead();
    private IsCollision isCollision = new IsCollision(); //isCollision 추가
    private DetectPos detectPos = new DetectPos();

    private Shooter_Move m_Shooter;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        m_Shooter = gameObject.GetComponent<Shooter_Move>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMovingAttack);

        moveForTarget.Shooter = m_Shooter;
        changeGun.Shooter = m_Shooter;
        isCollision.Shooter = m_Shooter;  //isCollision Shooter추가
        detectPos.Shooter = m_Shooter;
        m_OnAttack.Shooter = m_Shooter;
        m_IsDead.Shooter = m_Shooter;

        seqMovingAttack.AddChild(moveForTarget);
        seqMovingAttack.AddChild(m_OnAttack);
        seqMovingAttack.AddChild(changeGun);
        seqMovingAttack.AddChild(isCollision); //IsCollision 자식 노드 추가
        seqMovingAttack.AddChild(detectPos);

        seqDead.AddChild(m_IsDead);

        behaviorProcess = BehaviorProcess();
        StartCoroutine(behaviorProcess);
    }
    public IEnumerator BehaviorProcess()
    {
        while (root.Invoke())
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject, 0.0f);
        Debug.Log("behavior process exit");
    }
    // Update is called once per frame
    void Update()
    {

    }
}