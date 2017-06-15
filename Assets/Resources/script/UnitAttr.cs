using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttr{

    private int m_HP;
    private int m_SP;
	// Use this for initialization
	void Start () {
		
	}
    //這邊之後要改成由表單讀取數值
    public UnitAttr()
    {
        m_HP = 100;
        m_SP = 100;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetHP()
    {
        return m_HP;
    }
    public void AddHp(int value)
    {
        m_HP = m_HP + value;
    }
}
