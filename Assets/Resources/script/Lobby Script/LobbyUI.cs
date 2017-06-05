using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyUI{

    LobbyMgr m_LobbyMgr = null;

    //UI Components
    private GameObject m_MainMenuCanvas = null;
    private GameObject m_ResourceCanvas = null;
    private Button m_Btn1 = null;
    private Button m_BtnOption = null;  //按鈕_設定介面
    private Button m_BtnMachine = null; //按鈕_機器人介面
    private Button m_BtnWorld = null;   //按鈕_選擇時空介面
    private Button m_BtnMap = null;     //按鈕_地圖介面
    private Text m_TxtNowWorld = null;  //文字_目前世界
    private Text m_TxtGold = null;  //文字_目前世界


    public LobbyUI(LobbyMgr LobbyMgr) {
        m_LobbyMgr = LobbyMgr;
    }

    public void init()
    {
        Debug.Log("start to read btn");
        m_MainMenuCanvas = UITool.FindCanvasObject("MainMenuCanvas");
        m_ResourceCanvas = UITool.FindCanvasObject("BARE_RESOURCE_BAR");
        //Main Menu Buttons
        m_Btn1 = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "Button1");
        m_BtnOption = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "BTN_OPTION");
        m_BtnMachine = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "BTN_MACHINE");
        m_BtnWorld = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "BTN_WOLRD");
        m_BtnMap = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "BTN_MAP");
        //資源介面元件
        m_TxtGold = UITool.GetUIComponent<Text>(m_ResourceCanvas, "TXT_GOLD_VALUE");

        m_TxtNowWorld = UITool.GetUIComponent<Text>(m_MainMenuCanvas, "TXT_NOW_WWOLRD");//目前世界字串

        //註冊按鈕事件
        if (m_BtnMap != null)
            m_BtnMap.onClick.AddListener(() => OnMapBtnClick());
        if (m_BtnMachine != null)//按下機器人鈕
            m_BtnMachine.onClick.AddListener(() => OnMachineBtnClick());
        if (m_BtnWorld != null)//按下世界按鈕
            m_BtnWorld.onClick.AddListener(() => OnWorldBtnClick());

        //初始化目前世界字串
        SetNowWorldTxt();
        //初始化資源字串
        SetResourceTxt();
    }

    //按下地圖按鈕
    void OnMapBtnClick() {
        LobbyMgr.Instance.OnMapBtnClick();
    }

    //按下機器人按鈕
    void OnMachineBtnClick()
    {
        Debug.Log("press Machine Btn;");
        m_LobbyMgr.EnterMachineUI();
        //隱藏主介面
        m_MainMenuCanvas.gameObject.SetActive(false);
    }

    //按下世界按鈕
    void OnWorldBtnClick()
    {
        Debug.Log("press World Btn;");
        m_LobbyMgr.EnterWorldUI();
        //隱藏主介面
        m_MainMenuCanvas.gameObject.SetActive(false);
    }

    public void OpenLobbyUI()
    {
        m_MainMenuCanvas.gameObject.SetActive(true);
    }

    //設定目前世界字串
    public void SetNowWorldTxt()
    {
        string WorldText = null;
        WorldText = m_LobbyMgr.GetNowWorldName();
        m_TxtNowWorld.text = WorldText;
    }
    //設定目前世界字串
    public void SetResourceTxt()
    {
        string GoldText = null;
        GoldText = PlayerResource.Instance.Gold.ToString();
        m_TxtGold.text = GoldText;
    }
}
