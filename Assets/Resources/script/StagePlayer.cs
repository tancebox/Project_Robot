using UnityEngine;
using System.Collections;

public class StagePlayer{

    GameObject m_PlayerObj = null;
    private StageMgr m_StageMgr = null;
    private UnitAttr m_UnitAttr = null;//單位數值
    private StagePlayerAction m_StagePlayerAction = null;//玩家行為與狀態機
    private SkillPlayer m_SkillPlayer = null;//玩家技能
    

    private static StagePlayer _instance;
    public static StagePlayer Instance
    {
        get
        {
            if (_instance == null)
                _instance = new StagePlayer();
            return _instance;
        }
    }

    public StagePlayer()
    {
        m_PlayerObj = UnityTool.FindGameObject("Player");
        //m_StagePlayerAction = new StagePlayerAction(this);
    }

    public void init(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_StagePlayerAction = new StagePlayerAction(StageMgr);
        m_SkillPlayer = new SkillPlayer(StageMgr);
        // m_PlayerObj = UnityTool.FindGameObject("Player");
        //m_PlayerObj = this.gameObject;
    }

    public void Update()
    {
        m_StagePlayerAction.Update();
    } 

    public GameObject GetPlayerObj()
    {
        return m_PlayerObj;
    }

    public Vector3 GetPlayerPos()
    {
        Vector3 Pos = m_PlayerObj.transform.position;
        return Pos;
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

}
