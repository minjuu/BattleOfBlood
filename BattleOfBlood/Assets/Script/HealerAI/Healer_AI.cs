using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer_AI : MonoBehaviour
{
    private Sequence root = new Sequence();             // root 노드 생성
    private Selector selector = new Selector();         // 자식 노드들을 실행시키는 노드 생성
    private Sequence seqMoving = new Sequence();  // Enemy를 이동시키며 공격하는 기능을 하는 sequence 생성
    private Sequence seqDead = new Sequence();

    private MoveHealer moveHealer = new MoveHealer();    // MoveFollowTarget 클래스 변수를 생성
    private HealerObstacleDetect healerobstacleDetect = new HealerObstacleDetect();
    private HealerTeamHpDetect healerteamHpDetect = new HealerTeamHpDetect();
    private HealerMyHpDetect healermyHpDetect = new HealerMyHpDetect();
    private HealerIsDead healerIsDead = new HealerIsDead();

    private HealerMove m_Healer;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Healer = gameObject.GetComponent<HealerMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);         // seqDead 노드를 selector의 자식 노드로 연결
        selector.AddChild(seqMoving); // seqMovingAttack 노드를 selector의 자식 노드로 연결

        moveHealer.Healer = m_Healer;      // m_Enemy를 넣어 초기화시킴
        healerobstacleDetect.Healer = m_Healer;
        healerteamHpDetect.Healer = m_Healer;
        healermyHpDetect.Healer = m_Healer;
        healerIsDead.Healer = m_Healer;

        seqMoving.AddChild(moveHealer);    //seqMovingAttack 노드에 클래스 변수들을 자식으로 추가
        seqMoving.AddChild(healerobstacleDetect);
        seqMoving.AddChild(healerteamHpDetect);
        seqMoving.AddChild(healermyHpDetect);

        seqDead.AddChild(healerIsDead); //seqDead 노드에 클래스 변수를 자식으로 추가

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