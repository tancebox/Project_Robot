using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StageUI{
    StageMgr m_StageMgr = null;

    private GameObject m_MainMenuCanvas = null;
    private Text m_InputX = null;  //文字_X值
    private Text m_InputY = null;  //文字_Y值

    private Text m_AfterInputX = null;  //文字_X值
    private Text m_AfterInputY = null;  //文字_Y值

    public StageUI(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        init();
    }

    public void init()
    {
        m_MainMenuCanvas = UITool.FindCanvasObject("Canvas");
        //Main Menu Buttons
        m_InputX = UITool.GetUIComponent<Text>(m_MainMenuCanvas, "TxtDirX");
        m_InputY = UITool.GetUIComponent<Text>(m_MainMenuCanvas, "TxtDirY");

        m_AfterInputX = UITool.GetUIComponent<Text>(m_MainMenuCanvas, "TxtAfterDirX");
        m_AfterInputY = UITool.GetUIComponent<Text>(m_MainMenuCanvas, "TxtAfterDirY");

        m_InputX.text = "x";
        m_InputY.text = "y";
    }

    public void Update() {
        m_InputX.text = Input.GetAxis("Horizontal").ToString();
        m_InputY.text = Input.GetAxis("Vertical").ToString();


    }
}
