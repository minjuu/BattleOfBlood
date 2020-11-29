using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class MoveinMap : Node
{
    public SonnyMove Enemy
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.MoveinMap();

    }
}


public class SonnyIsDead : Node
{
    public SonnyMove Enemy
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.SonnyIsDead();
    }
}

public class SonnyOnAttack : Node
{
    public SonnyMove Enemy
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.AddBalloon();
    }
}

public class FindingGoalPos : Node
{
    public SonnyMove Enemy
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.FindingGoalPos();

    }
}

public class FindBalloon : Node
{
    public SonnyMove Enemy
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.FindBalloon();

    }
}