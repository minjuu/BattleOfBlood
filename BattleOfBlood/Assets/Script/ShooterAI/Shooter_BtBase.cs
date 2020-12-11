using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public abstract class Node  //추상 클래스 노드
{
    public abstract bool Invoke();  //인보크
}
public class CompositeNode : Node
{
    public override bool Invoke()  //인보크
    {
        throw new NotImplementedException();
    }

    public void AddChild(Node node)   //자식 노드 생성
    {
        childrens.Push(node);         //자식 노드 푸쉬 
    }

    public Stack<Node> GetChildrens()    //자식 get
    {
        return childrens;
    }
    private Stack<Node> childrens = new Stack<Node>();
}

public class Selector : CompositeNode
{
    public override bool Invoke()
    {
        foreach (var node in GetChildrens())  //getchildren
        {
            if (node.Invoke())
            {

                return true;
            }
        }
        return false;
    }
}

public class Sequence : CompositeNode   //시퀀스
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

public class ShooterMove : Node   //슈터 무브 노드
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

public class ChangeGun : Node    //총알 바꾸는 노드
{
    public Shooter_Move Shooter
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.ChangeGun();

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

public class DetectPos : Node       //IsCollision 노드 추가함
{
    public Shooter_Move Shooter           //노드 내용
    {
        set { _Shooter = value; }
    }
    private Shooter_Move _Shooter;
    public override bool Invoke()
    {
        return _Shooter.DetectPos();
    }
}

public class IsDead : Node    //죽었을 때 노드
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

public class OnAttack : Node  //공격 노드
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