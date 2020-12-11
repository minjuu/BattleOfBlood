using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SonnyAI : MonoBehaviour
{
    private Sequence root = new Sequence();             // root 노드 생성
    private Selector selector = new Selector();        // 자식 노드들을 실행시키는 노드 생성
    private Sequence seqMovingAttack = new Sequence();  // 이동시키는 기능을 하는 sequence 생성
    private Sequence seqDead = new Sequence();  // 죽는 기능을 하는 sequence 생성

    private MoveinMap moveinmap = new MoveinMap();
    private SonnyOnAttack m_OnAttack = new SonnyOnAttack();
    private SonnyIsDead m_IsDead = new SonnyIsDead();
    private Is_Collision isCollision = new Is_Collision(); //isCollision 추가
    private DetectPosi detectPos = new DetectPosi();

    private SonnyMove m_Sonny;    // 클래스 변수를 생성
    private IEnumerator behaviorProcess;

    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Start Tree");
        m_Sonny = gameObject.GetComponent<SonnyMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);         // seqDead 노드를 selector의 자식 노드로 연결
        selector.AddChild(seqMovingAttack);// seqMovingAttack 노드를 selector의 자식 노드로 연결

        moveinmap.Enemy = m_Sonny;      // m_Enemy를 넣어 초기화시킴
        m_OnAttack.Enemy = m_Sonny;
        isCollision.Enemy = m_Sonny;
        detectPos.Enemy = m_Sonny;
        m_IsDead.Enemy = m_Sonny;

        seqMovingAttack.AddChild(m_OnAttack);

        seqMovingAttack.AddChild(moveinmap);    //seqMovingAttack 노드에 클래스 변수들을 자식으로 추가
        seqMovingAttack.AddChild(isCollision);
        seqMovingAttack.AddChild(detectPos);

        seqDead.AddChild(m_IsDead); //seqDead 노드에 클래스 변수를 자식으로 추가

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
        if (SceneManager.GetActiveScene().name == "Stage2" && count == 0) //스테이지2이면 트리 재시작
        {
            Debug.Log("Start Tree2");
            m_Sonny = gameObject.GetComponent<SonnyMove>();
            root.AddChild(selector);
            selector.AddChild(seqDead);
            selector.AddChild(seqMovingAttack);

            moveinmap.Enemy = m_Sonny;
            m_OnAttack.Enemy = m_Sonny;
            isCollision.Enemy = m_Sonny;
            detectPos.Enemy = m_Sonny;
            m_IsDead.Enemy = m_Sonny;

            seqMovingAttack.AddChild(m_OnAttack);

            seqMovingAttack.AddChild(moveinmap);
            seqMovingAttack.AddChild(isCollision);
            seqMovingAttack.AddChild(detectPos);

            seqDead.AddChild(m_IsDead);

            behaviorProcess = BehaviorProcess();
            StartCoroutine(behaviorProcess);

            count++;
        }
    }
}
