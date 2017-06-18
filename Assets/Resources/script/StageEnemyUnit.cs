using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnemyUnit : MonoBehaviour {

    private StageMgr m_StageMgr = null;
    private SkillEnemy m_SkillEnemy = null;
    private IAI m_AI = null;

	// Use this for initialization
	void Start () {
		
	}

    public void init(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_SkillEnemy = new SkillEnemy(StageMgr);
        m_AI = new AI_Enemy_001(this.gameObject, StageMgr);
    }
	
	// Update is called once per frame
	void Update () {
        m_AI.Update();
	}

    //Mgr通知單位被攻擊
    public void UnitBeAttack(Vector3 Forward)
    {
        m_AI.BeAttack(Forward);
    }

    //取得SkillEnemy
    public SkillEnemy GetSkillEnemy()
    {
        return m_SkillEnemy;
    }
    //設定AI的參數
    public void SetEnemySkillEnd()
    {
        m_AI.SkillEnd();
    }
}
