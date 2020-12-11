using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class MoveinMap : Node //쏘니 움직임 노드
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

public class SonnyIsDead : Node //쏘니 죽음 노드
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

public class SonnyOnAttack : Node //쏘니 공격 노드
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

public class Is_Collision : Node       //IsCollision 노드
{
    public SonnyMove Enemy
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.Is_Collision();
    }
}

public class DetectPosi : Node       //쏘니 위치 감지 노드
{
    public SonnyMove Enemy           //노드 내용
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.DetectPosi();
    }
}