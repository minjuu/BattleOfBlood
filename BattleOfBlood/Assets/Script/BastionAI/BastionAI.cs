using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BastionAI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private BastionMoveFollowTarget moveForTarget = new BastionMoveFollowTarget();
    private BastionMoveBackFollowTarget moveBackForTarget = new BastionMoveBackFollowTarget();
    private BastionOnAttack m_OnAttack = new BastionOnAttack();
    private FindEnemy m_FindEnemy = new FindEnemy(); //m_LeftRight를 생성
    private BastionIsDead m_IsDead = new BastionIsDead();

    private BastionMove m_Enemy;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Enemy = gameObject.GetComponent<BastionMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMovingAttack);

        moveForTarget.Enemy = m_Enemy;
        moveBackForTarget.Enemy = m_Enemy;
        m_OnAttack.Enemy = m_Enemy;
        m_FindEnemy.Enemy = m_Enemy; //m_LeftRight를 추가함
        m_IsDead.Enemy = m_Enemy;

        seqMovingAttack.AddChild(moveForTarget);
        seqMovingAttack.AddChild(m_OnAttack);
        seqMovingAttack.AddChild(moveBackForTarget);
        seqMovingAttack.AddChild(m_FindEnemy); //seqMovingAttack의 자식으로 m_LeftRight을 추가한다. 
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