using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAIState{
    public bool m_BeAttackSignal = false;

    public IAIState() { }

    public virtual void Update() { }

    public void ReceiveBeAttackSignal() {
        m_BeAttackSignal = true;
    }

    //技能比較長用的
    public virtual void Start() { }
    public virtual void Reset() { }
    public virtual void End() { }
}
