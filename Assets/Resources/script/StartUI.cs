using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenuUI{

    StartMgr m_StartMgr = null;

    private GameObject m_MainMenuCanvas = null;
    private Button m_NewGameBtn = null;
    private Button m_ContinueBtn = null;
    private Image m_Arrow = null;

    //位置資訊
    private float BtmPosX = 0;
    private float BtmPosYBtn1 = 0;
    private float BtmPosYBtn2 = 0;

    //選單狀態資訊
    private int MenuState = 0;

    private int ArrowState = 0;

    public StartMenuUI(StartMgr StartMgr)
    {
        m_StartMgr = StartMgr;
        //init();
    }

    public void init()
    {
        //主選單畫布及按鈕
        m_MainMenuCanvas = UITool.FindCanvasObject("CanvasMainMenu");
        m_NewGameBtn = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "BTN_NEW_GAME");
        m_ContinueBtn = UITool.GetUIComponent<Button>(m_MainMenuCanvas, "BTN_CONTINUE");
        m_Arrow = UITool.GetUIComponent<Image>(m_MainMenuCanvas, "PIC_ARROW");

        //m_Arrow.transform.position.Set(m_NewGameBtn.transform.position.x - 10, m_NewGameBtn.transform.position.y, 0);
        //m_Arrow.transform.position.Set(0,200, 0);//這種寫法是沒用的

        BtmPosX = m_NewGameBtn.transform.position.x - m_MainMenuCanvas.transform.position.x;
        BtmPosYBtn1 = m_NewGameBtn.transform.position.y - m_MainMenuCanvas.transform.position.y;
        BtmPosYBtn2 = m_ContinueBtn.transform.position.y - m_MainMenuCanvas.transform.position.y;

        m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX-100, BtmPosYBtn1);

        //註冊事件
        if (m_NewGameBtn != null)//按下NEW按鈕
            m_NewGameBtn.onClick.AddListener(() => OnStartBtnClick());

    }

    private void OnStartBtnClick()
    {
        //Debug.Log("Clicked the Start Button,Begin to transfer to LobbyScene");
        m_StartMgr.OnStartGameBtnClick();
    }
    //接收到上下按鈕
    public void OnDirPut(int dir)
    {
        if (1 == dir) {
            if (MenuState == 0)
            {
                MenuState = 1;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 100, BtmPosYBtn2);
            }
            else {
                MenuState = 0;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 100, BtmPosYBtn1);
            }
        }
        else if (-1 == dir) {
            if (MenuState == 0)
            {
                MenuState = 1;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 100, BtmPosYBtn2);
            }
            else
            {
                MenuState = 0;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 100, BtmPosYBtn1);
            }
        }
    }
    public void setUIActive(bool act)
    {
        m_MainMenuCanvas.gameObject.SetActive(act);
    }
    //接收到OK鈕(Btn1)
    public void OnBtnOKPut()
    {
        if (MenuState == 0)
        {
            //m_StartMgr.OnStartGameBtnClick();
            m_StartMgr.SwitchState(1);
        }
            
    }
    //接收到Cancel鈕(Btn2)
    public void OnBtnCancelPut()
    {
        
    }

}

public class StartSlotUI
{

    StartMgr m_StartMgr = null;

    private GameObject m_SlotsCanvas = null;
    private Canvas m_Slot1 = null;
    private Canvas m_Slot2 = null;
    private Canvas m_Slot3 = null;
    private Image m_Arrow = null;

    private int SlotState = 0;

    private float BtmPosX = 0;
    private float BtmPosYBtn1 = 0;
    private float BtmPosYBtn2 = 0;
    private float BtmPosYBtn3 = 0;


    public StartSlotUI(StartMgr StartMgr)
    {
        m_StartMgr = StartMgr;
        //init();
    }

    public void init()
    {
        //Slots畫布及按鈕
        m_SlotsCanvas = UITool.FindCanvasObject("CanvasSaveSlots");

        m_Arrow = UITool.GetUIComponent<Image>(m_SlotsCanvas, "PIC_ARROW");
        m_Slot1 = UITool.GetUIComponent<Canvas>(m_SlotsCanvas, "NODE_SLOT_1");
        m_Slot2 = UITool.GetUIComponent<Canvas>(m_SlotsCanvas, "NODE_SLOT_2");
        m_Slot3 = UITool.GetUIComponent<Canvas>(m_SlotsCanvas, "NODE_SLOT_3");

        if (m_SlotsCanvas != null)
            ;// m_SlotsCanvas.SetActive(false);
        //小箭頭位置計算
        BtmPosX = m_Slot1.transform.position.x - m_SlotsCanvas.transform.position.x;
        BtmPosYBtn1 = m_Slot1.transform.position.y - m_SlotsCanvas.transform.position.y;
        BtmPosYBtn2 = m_Slot2.transform.position.y - m_SlotsCanvas.transform.position.y;
        BtmPosYBtn3 = m_Slot3.transform.position.y - m_SlotsCanvas.transform.position.y;

        m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn1);

    }

    public void setUIActive(bool act) {
        if (m_SlotsCanvas != null) {
            m_SlotsCanvas.SetActive(act);
        }
            
    }
    //接收到上下按鈕
    public void OnDirPut(int dir)
    {
        if (1 == dir)
        {
            if (SlotState == 0)
            {
                SlotState = 2;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn3);
            }
            else if(SlotState == 1)
            {
                SlotState = 0;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn1);
            }
            else if (SlotState == 2)
            {
                SlotState = 1;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn2);
            }
        }
        else if (-1 == dir)
        {
            if (SlotState == 0)
            {
                SlotState = 1;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn2);
            }
            else if(SlotState == 1)
            {
                SlotState = 2;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn3);
            }
            else if (SlotState == 2)
            {
                SlotState = 0;
                m_Arrow.rectTransform.anchoredPosition = new Vector2(BtmPosX - 320, BtmPosYBtn1);
            }
        }
    }
    //接收到OK鈕(Btn1)
    public void OnBtnOKPut()
    {
        m_StartMgr.OnStartGameBtnClick();
    }

}
