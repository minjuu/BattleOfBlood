using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBooster : Node //부스터 이동 노드
{
    public BoosterMove Booster
    {
        set { _Booster = value; }
    }

    private BoosterMove _Booster;
    public override bool Invoke()
    {
        return _Booster.MoveBooster();
    }
}

public class BoosterTeamPosDetect : Node //부스터 팀 위치 감지
{
    public BoosterMove Booster
    {
        set { _Booster = value; }
    }

    private BoosterMove _Booster;
    public override bool Invoke()
    {
        return _Booster.BoosterTeamPosDetect();
    }
}
public class BoosterEnemyPosDetect : Node //부스터 적 위치 감지
{
    public BoosterMove Booster
    {
        set { _Booster = value; }
    }

    private BoosterMove _Booster;
    public override bool Invoke()
    {
        return _Booster.BoosterEnemyPosDetect();
    }
}
public class BoosterIsDead : Node //부스터 죽음
{
    public BoosterMove Booster
    {
        set { _Booster = value; }
    }

    private BoosterMove _Booster;
    public override bool Invoke()
    {
        return _Booster.BoosterIsDead();
    }
}