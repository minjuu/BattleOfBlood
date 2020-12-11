using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveHealer : Node //힐러 움직임 노드
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

public class HealerTeamHpDetect : Node     // 힐러 같은팀 체력감지 노드
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

public class HealerMyHpDetect : Node     // 힐러 자기체력감지 노드
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

public class HealerIsDead : Node //힐러 죽음 노드
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