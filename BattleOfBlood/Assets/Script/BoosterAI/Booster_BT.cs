using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveBooster : Node
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
public class BoosterObstacleDetect : Node
{
    public BoosterMove Booster
    {
        set { _Booster = value; }
    }

    private BoosterMove _Booster;
    public override bool Invoke()
    {
        return _Booster.BoosterObstacleDetect();
    }
}

public class BoosterTeamPosDetect : Node
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
public class BoosterEnemyPosDetect : Node
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
public class BoosterIsDead : Node
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