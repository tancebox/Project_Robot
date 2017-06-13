using UnityEngine;
using System.Collections;

public class StageMgr {

    private SceneStage m_SceneStage = null;
    private StageUI m_StageUI = null;
    private StagePlayerControl m_StagePlayerControl = null;
    private StageCamera m_StageCamera = null;
    private GameObject m_PlayerObj = null;
    private GameObject[] m_Enemys;

    private static StageMgr _instance;
    public static StageMgr Instance
    {
        get
        {
            if (_instance == null)
                _instance = new StageMgr();
            return _instance;
        }
    }
    public void init(SceneStage SceneStage)
    {
        m_SceneStage = SceneStage;
        //玩家物件初始化
        m_PlayerObj = GameObject.FindGameObjectWithTag("Player");
        m_PlayerObj.GetComponent<StagePlayer>().init(this);
        //其他元件
        m_StageUI = new StageUI(this);
        m_StagePlayerControl = new StagePlayerControl(this);
        m_StageCamera = new StageCamera(this);
        //初始化敵人Obj
        m_Enemys = GameObject.FindGameObjectsWithTag("EnemyUnit");
        foreach (GameObject Enemy in m_Enemys)
        {
            Enemy.GetComponent<StageEnemyUnit>().init(this);
        }

    }
    public StageMgr()
    {

    }
    public void Update() {
        m_StagePlayerControl.Update();
        m_PlayerObj.GetComponent<StagePlayer>().PlayerUpdate();
        m_StageCamera.Update();
        m_StageUI.Update();
    }

    //由控制系統操作角色與攝影機
    public void MgrMoveCamera(Vector3 Dir, bool isInput)
    {
        m_PlayerObj.GetComponent<StagePlayer>().GetStagePlayerAction().ReceiveMoveInput(Dir, isInput);
    }

    //由控制系統操作角色施展技能
    public void MgrPlaySkill(int SkillSlot)
    {
        m_PlayerObj.GetComponent<StagePlayer>().GetStagePlayerAction().ReceiveSkillInput(SkillSlot);
    }

    public Vector3 MgrGetPlayerPos()
    {
        Vector3 Pos = m_PlayerObj.GetComponent<StagePlayer>().GetPlayerPos();
        return Pos;
    }
    //通知敵人被攻擊
    public void MgrAttackEnemy(GameObject Enemy, Vector3 Forward)
    {
        Debug.Log("Mgr Attack Enemy");
        Enemy.GetComponent<StageEnemyUnit>().UnitBeAttack(Forward);
    }
    //取得玩家Obj
    public GameObject GetPlayerObj()
    {
        return m_PlayerObj;
    }
    //播放音效
    public void PlayAudio()
    {

    }
}
