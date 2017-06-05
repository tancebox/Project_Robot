using UnityEngine;
using System.Collections;

public class PlayerAttr : IUnitAttr {

    private int m_LV;
    private int m_HP;

    public PlayerAttr() {
        m_LV = 1;
        m_HP = 100;
    }
}
