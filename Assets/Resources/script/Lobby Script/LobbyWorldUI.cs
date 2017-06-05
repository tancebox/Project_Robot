using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyWorldUI{

    LobbyMgr m_LobbyMgr = null;

    //宣告畫布(NODE)
    private GameObject m_WorldCanvas = null;
    //宣告按鈕
    private Button m_BtnWorld1 = null;//世界_中古
    private Button m_BtnWorld2 = null;//世界_海盜
    private Button m_BtnWorld3 = null;//世界_吸血鬼
    private Button m_BtnBack = null;//返回鈕

    public LobbyWorldUI(LobbyMgr LobbyMgr) {
        m_LobbyMgr = LobbyMgr;
    }

    public void init() {
        //設定各Canvas
        m_WorldCanvas = UITool.FindCanvasObject("WorldCanvas");
        //設定返回紐
        m_BtnBack = UITool.GetUIComponent<Button>(m_WorldCanvas, "BtnBack");
        //設定世界切換按鈕
        m_BtnWorld1 = UITool.GetUIComponent<Button>(m_WorldCanvas, "BTN_WORLD_1");
        m_BtnWorld2 = UITool.GetUIComponent<Button>(m_WorldCanvas, "BTN_WORLD_2");
        m_BtnWorld3 = UITool.GetUIComponent<Button>(m_WorldCanvas, "BTN_WORLD_3");
        //註冊按鈕事件-返回鈕
        if (m_BtnBack != null)
            m_BtnBack.onClick.AddListener(() => OnBtnBackClick());
        //註冊按鈕事件-職業切換按鈕
        if (m_BtnWorld1 != null)
            m_BtnWorld1.onClick.AddListener(() => OnWorldBtnClick(0));//世界_中古
        if (m_BtnWorld2 != null)
            m_BtnWorld2.onClick.AddListener(() => OnWorldBtnClick(1));//世界_海盜
        if (m_BtnWorld3 != null)
            m_BtnWorld3.onClick.AddListener(() => OnWorldBtnClick(2));//世界_吸血鬼

        //隱藏本介面
        m_WorldCanvas.gameObject.SetActive(false);
    }

    //開啟本介面
    public void EnterWorldUI()
    {
        Debug.Log("MachineUI receive call from LobbyMgr");
        //m_MachineCanvas.transform.position.Set(0,0,0);//不知為何無作用
        m_WorldCanvas.gameObject.SetActive(true);
    }

    //按下返回鈕
    void OnBtnBackClick()
    {
        Debug.Log("Press Back");
        //隱藏本屆面
        m_WorldCanvas.gameObject.SetActive(false);
        //顯示Lobby主選單
        m_LobbyMgr.OpenLobbyUI();
    }
    //選擇世界按鈕
    void OnWorldBtnClick(int WorldID)
    {
        WorldSystem.Instance.SetNowWorld(WorldID);
        m_LobbyMgr.SetLobbyWorldTxt();
    }
}
