using UnityEngine;
using System.Collections;

public class StartMgr{

    private SceneStart m_SceneStart = null;
    //介面
    private StartMenuUI m_StartMenuUI = null;
    private StartSlotUI m_StartSlotUI = null;
    //控制
    private StartMenuControl m_StartMenuControl = null;

    private int count=0;

    //狀態參數(0:Menu 1:Slot 2:Option)
    private int nowState = 0;//

    private static StartMgr _instance;
    public static StartMgr Instance
    {
        get
        {
            if (_instance == null)
                _instance = new StartMgr();
            return _instance;
        }
    }

    public StartMgr()
    {

    }

    public void init(SceneStart SceneStart)
    {
        m_SceneStart = SceneStart;
        //介面元件
        m_StartMenuUI = new StartMenuUI(this);
        m_StartMenuUI.init();
        m_StartSlotUI = new StartSlotUI(this);
        m_StartSlotUI.init();
        //控制元件
        m_StartMenuControl = new StartMenuControl(this);
        //初始化參數
        nowState = 0;

    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
        m_StartMenuControl.Update();

        if (count < 1)//延遲一下下讓介面順利隱藏
            count++;
        else if (count == 1)
        {
           m_StartSlotUI.setUIActive(false);
            count++;
        }
           


    }
    /*目前狀態切換*/
    public void SwitchState(int inputState) {
        Debug.Log("State:" + inputState.ToString());
        if (1 == inputState)//切換到Solt狀態
        {
            m_StartMenuUI.setUIActive(false);
            m_StartSlotUI.setUIActive(true);
            nowState = 1;
        }
        else if (0 == inputState)//切換到Menu狀態
        {
            m_StartMenuUI.setUIActive(true);
            m_StartSlotUI.setUIActive(false);
            nowState = 0;
        }
    }

    /*來自StartUI的點擊事件*/
    public void OnStartGameBtnClick()//這邊之後要改成開啟存檔格
    {
        Debug.Log("LobbyUI Click The Map Btn");
        m_SceneStart.ChangeSceneToStage();
    }

    //來自StartMenuControl的命令
    public void StartMenuPutDir(int dir) {
        if (nowState == 0)
            m_StartMenuUI.OnDirPut(dir);
        else if (nowState == 1)
            m_StartSlotUI.OnDirPut(dir);
    }
    public void StartMenuPutOK()
    {
        if (nowState == 0)
            m_StartMenuUI.OnBtnOKPut();
        else if (nowState == 1)
            m_StartSlotUI.OnBtnOKPut();
    }
    public void StartMenuPutCancel()
    {
        if (nowState == 0)
            ;
        else if (nowState == 1)
            SwitchState(0);
    }
}
