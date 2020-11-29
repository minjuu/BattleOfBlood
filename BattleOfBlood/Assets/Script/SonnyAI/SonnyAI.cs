using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonnyAI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private MoveinMap moveinmap = new MoveinMap();
    private SonnyOnAttack m_OnAttack = new SonnyOnAttack();
    private SonnyIsDead m_IsDead = new SonnyIsDead();
    private FindingGoalPos m_findinggoalpos = new FindingGoalPos();
    private FindBalloon m_balloon = new FindBalloon();
    private Is_Collision isCollision = new Is_Collision(); //isCollision 추가
    private DetectPosi detectPos = new DetectPosi();

    private SonnyMove m_Sonny;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Sonny = gameObject.GetComponent<SonnyMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMovingAttack);

        moveinmap.Enemy = m_Sonny;
        m_findinggoalpos.Enemy = m_Sonny; // 목표 지점 설정
        m_balloon.Enemy = m_Sonny;
        m_OnAttack.Enemy = m_Sonny;
        m_IsDead.Enemy = m_Sonny;
        isCollision.Enemy = m_Sonny;  
        detectPos.Enemy = m_Sonny;

        seqMovingAttack.AddChild(m_findinggoalpos);
        seqMovingAttack.AddChild(m_OnAttack);
        seqMovingAttack.AddChild(m_balloon);
        seqMovingAttack.AddChild(moveinmap);
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

