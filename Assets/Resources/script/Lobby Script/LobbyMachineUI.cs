using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyMachineUI{

    LobbyMgr m_LobbyMgr = null;
    //宣告畫布(NODE)
    private GameObject m_MachineCanvas = null;
    private GameObject m_JobInfoBarCanvas = null;
    //宣告職業按鈕
    private Button m_BtnJob1 = null;//職業_劍士
    private Button m_BtnJob2 = null;//職業_工程師
    private Button m_BtnJob3 = null;//職業_炮術士
    private Button m_BtnBack = null;//返回鈕

    //宣告職業資訊BAR元件
    private Text m_JobName = null;
    private Text m_JobLv = null;

    public LobbyMachineUI(LobbyMgr LobbyMgr)
    {
        m_LobbyMgr = LobbyMgr;
    }

    public void init()
    {
        Debug.Log("start to read btn Machine");
        //設定各Canvas
        m_MachineCanvas = UITool.FindCanvasObject("MachineMainCanvas");
        m_JobInfoBarCanvas = UITool.FindCanvasObject("NODE_JOB_INFO_BAR");
        //設定返回紐
        m_BtnBack = UITool.GetUIComponent<Button>(m_MachineCanvas, "BtnBack");
        //設定職業切換按鈕
        m_BtnJob1 = UITool.GetUIComponent<Button>(m_MachineCanvas, "BTN_JOB_1");
        m_BtnJob2 = UITool.GetUIComponent<Button>(m_MachineCanvas, "BTN_JOB_2");
        m_BtnJob3 = UITool.GetUIComponent<Button>(m_MachineCanvas, "BTN_JOB_3");
        //設定職業資訊Bar元件
        m_JobName = UITool.GetUIComponent<Text>(m_JobInfoBarCanvas, "TXT_NAME");
        m_JobLv = UITool.GetUIComponent<Text>(m_JobInfoBarCanvas, "TXT_LV_VALUE");
        //註冊按鈕事件-返回鈕
        if (m_BtnBack != null)
            m_BtnBack.onClick.AddListener(() => OnBtnBackClick());
        //註冊按鈕事件-職業切換按鈕
        if (m_BtnJob1 != null)
            m_BtnJob1.onClick.AddListener(() => LoadJobInfoToUI(0));//劍士
        if (m_BtnJob2 != null)
            m_BtnJob2.onClick.AddListener(() => LoadJobInfoToUI(1));//工程師
        if (m_BtnJob3 != null)
            m_BtnJob3.onClick.AddListener(() => LoadJobInfoToUI(2));//砲術士

        //隱藏本介面
        m_MachineCanvas.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
	
	}

    //開啟本介面
    public void EnterMachineUI() {
        Debug.Log("MachineUI receive call from LobbyMgr");
        //m_MachineCanvas.transform.position.Set(0,0,0);//不知為何無作用
        m_MachineCanvas.gameObject.SetActive(true);
    }
	
	//按下返回鈕
	void OnBtnBackClick() {
        Debug.Log("Press Back");
        //隱藏本屆面
        m_MachineCanvas.gameObject.SetActive(false);
        //顯示Lobby主選單
        m_LobbyMgr.OpenLobbyUI();
    }

    //按下職業按鈕時讀取職業資訊
    void LoadJobInfoToUI(int JobID) {
        m_JobName.text = JobSystem.Instance.getJobName(JobID);
        m_JobLv.text = JobSystem.Instance.getJobLv(JobID).ToString();
    }
}
