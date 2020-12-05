using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BastionMoveFollowTarget : Node
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.BastionMoveFollowTarget();

    }
}

public class BastionMoveBackFollowTarget : Node
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.BastionMoveBackFollowTarget();

    }
}

public class FindEnemy : Node //LeftRight 클래스를 노드에 추가함
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.FindEnemy();

    }
}

public class BastionIsDead : Node
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.BastionIsDead();
    }
}

public class BastionOnAttack : Node
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.BastionAddBalloon();
    }
}