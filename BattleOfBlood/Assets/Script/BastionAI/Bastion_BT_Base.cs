using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BastionMoveFollowTarget : Node //바스티온이 움직이도록 하는 노드 추가
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

public class BastionFindEnemy : Node //바스티온이 적을 찾는 노드 추가
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.BastionFindEnemy();

    }
}


public class IsBastionCol : Node  //바스티온의 충돌여부를 확인하는 노드 추가
{
    public BastionMove Enemy
    {
        set { _Enemy = value; }
    }
    private BastionMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.IsBastionCol();

    }
}

public class BastionIsDead : Node //바스티온이 죽는 노드 추가
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

public class BastionOnAttack : Node //바스티온이 공격하는 노드추가
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