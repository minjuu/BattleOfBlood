using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private ShooterMove moveForTarget = new ShooterMove();
    private MoveBackFollowTarget moveBackForTarget = new MoveBackFollowTarget();
    private OnAttack m_OnAttack = new OnAttack();
    private IsDead m_IsDead = new IsDead();
    private IsCollision isCollision = new IsCollision(); //isCollision 추가

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
        moveBackForTarget.Shooter = m_Shooter;
        isCollision.Shooter = m_Shooter;  //isCollision Shooter추가
        m_OnAttack.Shooter = m_Shooter;
        m_IsDead.Shooter = m_Shooter;

        seqMovingAttack.AddChild(moveForTarget);
        seqMovingAttack.AddChild(m_OnAttack);
        seqMovingAttack.AddChild(moveBackForTarget);
        seqMovingAttack.AddChild(isCollision); //IsCollision 자식 노드 추가

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