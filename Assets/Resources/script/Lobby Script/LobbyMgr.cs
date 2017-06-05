using UnityEngine;
using System.Collections;

public class LobbyMgr {

  

    private LobbyUI m_LobbyUI = null;
    private LobbyMachineUI m_LobbyMachineUI= null;
    private LobbyWorldUI m_LobbyWorldUI = null;
    private SceneLobby m_SceneLobby = null;
    //職業系統
    //private JobSystem m_JobSystem = null;

    private static LobbyMgr _instance;
    public static LobbyMgr Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LobbyMgr();
            return _instance;
        }
    }

    public LobbyMgr()
    {
        //m_LobbyUI = new LobbyUI(this);
        //m_SceneLobby = SceneLobby;
    }
    public void init(SceneLobby SceneLobby)
    {
        m_SceneLobby = SceneLobby;


        //初始化各系統
        JobSystem.Instance.init();//職業系統
        WorldSystem.Instance.init();//世界系統
        PlayerResource.Instance.init();//玩家物資系統

        //初始化各介面
        m_LobbyUI = new LobbyUI(this);
        m_LobbyUI.init();
        m_LobbyMachineUI = new LobbyMachineUI(this);
        m_LobbyMachineUI.init();
        m_LobbyWorldUI = new LobbyWorldUI(this);
        m_LobbyWorldUI.init();
        
    }

    //來自LobbyUI的點擊事件
    public void OnMapBtnClick() {
        Debug.Log("LobbyUI Click The Map Btn");
        m_SceneLobby.ChangeSceneToMap();
    }

    

    public void EnterSceneMap() {

    }
    //轉換Scene時釋放資源用,由SceneLobby呼叫
    public void LobbyMgrEnd()
    {

    }
    //Lobby介面用
    public int GetNowWorldID()//取得目前世界ID
    {
        int NowWorldID = WorldSystem.Instance.GetNowWorld();
        return NowWorldID;
    }
    public string GetNowWorldName()//取得目前世界名稱
    {
        string NowWorldName = WorldSystem.Instance.GetNowWorldName();
        return NowWorldName;
    }
    public void SetLobbyWorldTxt()//設定主介面世界字串
    {
        m_LobbyUI.SetNowWorldTxt();
    }
    //Machine介面用
    public void EnterMachineUI() {
        Debug.Log("LobbyMgr will call Machine UI");
        m_LobbyMachineUI.EnterMachineUI();
    }
    //World介面用
    public void EnterWorldUI()
    {
        Debug.Log("LobbyMgr will call World UI");
        m_LobbyWorldUI.EnterWorldUI();
    }
    //恢復主選單
    public void OpenLobbyUI()
    {
        m_LobbyUI.OpenLobbyUI();
    }

}
