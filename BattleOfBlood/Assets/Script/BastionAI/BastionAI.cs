using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BastionAI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private BastionMoveFollowTarget moveForTarget = new BastionMoveFollowTarget();
    private BastionFindEnemy bastionfindEnemy = new BastionFindEnemy();
    private BastionOnAttack m_OnAttack = new BastionOnAttack();
    private IsBastionCol isBastion_Col = new IsBastionCol(); //isCollision 추가
    private BastionIsDead m_IsDead = new BastionIsDead();

    private BastionMove m_Enemy;
    private IEnumerator behaviorProcess;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Enemy = gameObject.GetComponent<BastionMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMovingAttack);

        moveForTarget.Enemy = m_Enemy;
        bastionfindEnemy.Enemy = m_Enemy;
        m_OnAttack.Enemy = m_Enemy;
        isBastion_Col.Enemy = m_Enemy;
        m_IsDead.Enemy = m_Enemy;

        seqMovingAttack.AddChild(moveForTarget);
        seqMovingAttack.AddChild(m_OnAttack);
        seqMovingAttack.AddChild(bastionfindEnemy);
        seqMovingAttack.AddChild(isBastion_Col);
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
    }
    // Update is called once per frame
    void Update()
    {
             

        if (SceneManager.GetActiveScene().name == "Stage2" && count == 0)
        {

             Debug.Log("Start Tree2");
            m_Enemy = gameObject.GetComponent<BastionMove>();
            root.AddChild(selector);
            selector.AddChild(seqDead);
            selector.AddChild(seqMovingAttack);

            moveForTarget.Enemy = m_Enemy;
            bastionfindEnemy.Enemy = m_Enemy;
            m_OnAttack.Enemy = m_Enemy;
            isBastion_Col.Enemy = m_Enemy;
            m_IsDead.Enemy = m_Enemy;

            seqMovingAttack.AddChild(moveForTarget);
            seqMovingAttack.AddChild(m_OnAttack);
            seqMovingAttack.AddChild(bastionfindEnemy);
            seqMovingAttack.AddChild(isBastion_Col);
            seqDead.AddChild(m_IsDead);

            behaviorProcess = BehaviorProcess();
            StartCoroutine(behaviorProcess);

            count++;
        }
    }
}