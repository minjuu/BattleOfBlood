using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster_AI : MonoBehaviour
{
    private Sequence root = new Sequence();             // root 노드 생성
    private Selector selector = new Selector();         // 자식 노드들을 실행시키는 노드 생성
    private Sequence seqMoving = new Sequence();  // Enemy를 이동시키며 공격하는 기능을 하는 sequence 생성
    private Sequence seqDead = new Sequence();

    private MoveBooster moveBooster = new MoveBooster();    // MoveFollowTarget 클래스 변수를 생성
    private BoosterObstacleDetect boosterobstacleDetect = new BoosterObstacleDetect();
    private BoosterTeamPosDetect boosterTeamPosDetect = new BoosterTeamPosDetect();
    private BoosterEnemyPosDetect boosterEnemyPosDetect = new BoosterEnemyPosDetect();
    private BoosterIsDead boosterIsDead = new BoosterIsDead();         // IsDead 클래스 변수를 생성

    private BoosterMove m_Booster;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Booster = gameObject.GetComponent<BoosterMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);         // seqDead 노드를 selector의 자식 노드로 연결
        selector.AddChild(seqMoving); // seqMovingAttack 노드를 selector의 자식 노드로 연결

        moveBooster.Booster = m_Booster;      // m_Enemy를 넣어 초기화시킴
        boosterobstacleDetect.Booster = m_Booster;
        boosterTeamPosDetect.Booster = m_Booster;
        boosterEnemyPosDetect.Booster = m_Booster;
        boosterIsDead.Booster = m_Booster;

        seqMoving.AddChild(moveBooster);    //seqMovingAttack 노드에 클래스 변수들을 자식으로 추가       
        seqMoving.AddChild(boosterobstacleDetect);
        seqMoving.AddChild(boosterTeamPosDetect);
        seqMoving.AddChild(boosterEnemyPosDetect);

        seqDead.AddChild(boosterIsDead); //seqDead 노드에 클래스 변수를 자식으로 추가

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