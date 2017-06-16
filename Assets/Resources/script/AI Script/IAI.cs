using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAI{

    public GameObject m_UnitObj = null;
    public GameObject m_PlayerObj = null;

    public IAI()
    {
    }

    public virtual void Update(){}

    //由Mgr通知單位受攻擊
    public virtual void BeAttack(Vector3 Forward){}

    public virtual void SetAIAttr(string type, bool value) { }

    public virtual void SetState(int NewStateID) { }

    public virtual GameObject GetUnitObj() { return m_UnitObj; }

    public virtual GameObject GetPlayerObj() { return m_PlayerObj; }
}
