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

public class Is_Collision : Node       //IsCollision 노드 추가함
{
    public SonnyMove Enemy           //노드 내용
    {
        set { _Enemy = value; }
    }
    private SonnyMove _Enemy;
    public override bool Invoke()
    {
        return _Enemy.Is_Collision();
    }
}

public class DetectPosi : Node       //IsCollision 노드 추가함
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