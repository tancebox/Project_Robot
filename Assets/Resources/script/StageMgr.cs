using UnityEngine;
using System.Collections;

public class StageMgr{

    private SceneStage          m_SceneStage = null;
    private StageUI             m_StageUI = null;
    private StagePlayerControl  m_StagePlayerControl = null;
    private StageCamera         m_StageCamera = null;
    private StagePlayerAction   m_StagePlayerAction = null;
    private SkillPlayer         m_SkillPlayer = null;
    //private StagePlayer         m_StagePlayer = null;

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
        //Player用Singloten宣告
        StagePlayer.Instance.init();
        //其他元件
        m_StageUI =             new StageUI(this);
        m_StagePlayerControl =  new StagePlayerControl(this);
        m_StageCamera =         new StageCamera(this);
        m_SkillPlayer =         new SkillPlayer();
        m_StagePlayerAction =   new StagePlayerAction(this);
        

    }
    public StageMgr()
    {

    }
	public void Update () {
        m_StagePlayerControl.Update();
        m_StagePlayerAction.Update();
        m_StageCamera.Update();
        m_StageUI.Update();
    }

    //由控制系統操作角色與攝影機
    public void MgrMoveCamera(Vector3 Dir,bool isInput)
    {
        m_StagePlayerAction.ReceiveMoveInput(Dir, isInput);
    }

    //由控制系統操作角色施展技能
    public void MgrPlaySkill(int SkillSlot)
    {
        m_StagePlayerAction.ReceiveSkillInput(SkillSlot);
    }

    public Vector3 MgrGetPlayerPos()
    {
        Vector3 Pos = StagePlayer.Instance.GetPlayerPos();
        return Pos;
    }
    //通知敵人被攻擊
    public void MgrAttackEnemy(GameObject Enemy,Vector3 Forward)
    {
        Debug.Log("Mgr Attack Enemy");
        Enemy.GetComponent<AI_Enemy_001>().BeAttack(Forward);
    }
}
