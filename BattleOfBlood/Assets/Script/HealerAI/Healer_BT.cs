using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveHealer : Node
{
    public HealerMove Healer
    {
        set { _Healer = value; }
    }

    private HealerMove _Healer;
    public override bool Invoke()
    {
        return _Healer.MoveHealer();
    }
}

public class HealerObstacleDetect : Node     // revival 클래스 생성
{
    public HealerMove Healer
    {
        set { _Healer = value; }
    }

    private HealerMove _Healer;

    public override bool Invoke()
    {
        return _Healer.HealerObstacleDetect();
    }
}

public class HealerTeamHpDetect : Node     // revival 클래스 생성
{
    public HealerMove Healer
    {
        set { _Healer = value; }
    }

    private HealerMove _Healer;

    public override bool Invoke()
    {
        return _Healer.HealerTeamHpDetect();
    }
}

public class HealerMyHpDetect : Node     // revival 클래스 생성
{
    public HealerMove Healer
    {
        set { _Healer = value; }
    }

    private HealerMove _Healer;

    public override bool Invoke()
    {
        return _Healer.HealerMyHpDetect();
    }
}

public class HealerIsDead : Node
{
    public HealerMove Healer
    {
        set { _Healer = value; }
    }
    private HealerMove _Healer;
    public override bool Invoke()
    {
        return _Healer.HealerIsDead();
    }
}