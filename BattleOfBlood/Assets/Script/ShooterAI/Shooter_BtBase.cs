﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public abstract class Node
{
    public abstract bool Invoke();
}
public class CompositeNode : Node
{
    public override bool Invoke()
    {
        throw new NotImplementedException();
    }

    public void AddChild(Node node)
    {
        childrens.Push(node);
    }

    public Stack<Node> GetChildrens()
    {
        return childrens;
    }
    private Stack<Node> childrens = new Stack<Node>();
}

public class Selector : CompositeNode
{
    public override bool Invoke()
    {
        foreach (var node in GetChildrens())
        {
            if (node.Invoke())
            {

                return true;
            }
        }
        return false;
    }
}

public class Sequence : CompositeNode
{
    public override bool Invoke()
    {
        bool p = false;
        foreach (var node in GetChildrens())
        {
            if (node.Invoke() == false)
            {
                p = true;
            }
        }
        return !p;
    }
}

public class ShooterMove : Node
{
    public Shooter_Move Shooter
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.ShooterMove();

    }
}

public class MoveBackFollowTarget : Node
{
    public Shooter_Move Shooter
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.MoveBackFollowTarget();

    }
}
public class IsCollision : Node       //IsCollision 노드 추가함
{
    public Shooter_Move Shooter           //노드 내용
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.IsCollision();
    }
}
public class IsDead : Node
{
    public Shooter_Move Shooter
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.IsDead();
    }
}

public class OnAttack : Node
{
    public Shooter_Move Shooter
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.AddBullet();
    }
}

