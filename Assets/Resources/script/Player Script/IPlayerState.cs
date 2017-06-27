using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayerState
{
    public bool m_BeAttackSignal = false;
    public bool m_StartDone = false;

    public IPlayerState() { }

    public virtual void Update() { }

    public void ReceiveBeAttackSignal()
    {
        m_BeAttackSignal = true;
    }

    //技能比較長用的
    public virtual void Start() { }
    public virtual void Reset() { m_StartDone = false; }
    public virtual void End() { }
}
