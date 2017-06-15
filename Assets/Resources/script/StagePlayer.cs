using UnityEngine;
using System.Collections;

public class StagePlayer : MonoBehaviour{

    GameObject m_PlayerObj = null;
    private StageMgr m_StageMgr = null;
    private UnitAttr m_UnitAttr = null;//單位數值
    private StagePlayerAction m_StagePlayerAction = null;//玩家行為與狀態機
    private SkillPlayer m_SkillPlayer = null;//玩家技能

    // Use this for initialization
    void Start()
    {

    }

    public void init(StageMgr StageMgr)
    {
        m_PlayerObj = this.gameObject;
        m_StageMgr = StageMgr;
        m_UnitAttr = new UnitAttr();
        m_StagePlayerAction = new StagePlayerAction(StageMgr);
        m_SkillPlayer = new SkillPlayer(StageMgr);
    }

    public void Update()
    {
    }

    public void PlayerUpdate()
    {
        CheckPlayerDeath();
        m_StagePlayerAction.Update();
    } 

    public Vector3 GetPlayerPos()
    {
        Vector3 Pos = m_PlayerObj.transform.position;
        return Pos;
    }

    void CheckPlayerDeath()
    {
        if (0 <= m_UnitAttr.GetHP())
        {
            Debug.Log("Game Over");
        }
    }

    //主角受擊
    public void PlayerBeAttack()
    {
        m_UnitAttr.AddHp(-50);
        Debug.Log("Player Be Attack " + m_UnitAttr.GetHP().ToString());
    }

    //取得StagePlayerAction
    public StagePlayerAction GetStagePlayerAction()
    {
        return m_StagePlayerAction;
    }

    //取得SkillPlayer
    public SkillPlayer GetSkillPlayer()
    {
        return m_SkillPlayer;
    }

    //設定狀態參數
    public void SetActionAttr(string type, bool value)
    {
        m_StagePlayerAction.SetAttr(type, value);
    }


}
