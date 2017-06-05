using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class StartMenuControl{

    private StartMgr m_StartMgr = null;

    private bool DirControlEnable = true;
    private int DirControlCount = 0;//用來延遲方向輸入用
    private int DirInputDelay = 40;//用來延遲方向輸入用

    /*主選單階段操作*/
    public StartMenuControl(StartMgr StartMgr)
    {
        m_StartMgr = StartMgr;
    }

    // Update is called once per frame
    public void Update() {

        if (DirControlCount != 0)
            DirControlCount--;


        //<遊戲手把>方向鍵
        if (DirControlCount == 0)
        {
            //按"上"
            if (Input.GetAxis("Vertical") > 0.1)
            {
                PutDir(1);
                Debug.Log("put up");
                DirControlCount = DirInputDelay;
            }
            //按"下"
            if (Input.GetAxis("Vertical") < -0.1)
            {
                PutDir(-1);
                DirControlCount = DirInputDelay;
            }
                
        }
        //<遊戲手把>按"確認"
        if (Input.GetButtonDown("Btn1"))
            PutOK();
        if (Input.GetButtonDown("Btn2"))
            PutCancel();

        /*-----------鍵盤---------------*/
        //<鍵盤>方向鍵
        //按"上"
        if (Input.GetKeyDown(KeyCode.W))
        {
            PutDir(1);
            Debug.Log("put up");
            DirControlCount = 40;
        }
        //按"下"
        if (Input.GetKeyDown(KeyCode.S))
        {
            PutDir(-1);
            DirControlCount = 40;
        }
        //<鍵盤>按"確認"
        if (Input.GetKeyDown(KeyCode.Space))
            PutOK();
        if (Input.GetKeyDown(KeyCode.Escape))
            PutCancel();
    }

    //按下上下鈕時的處理
    void PutDir(int dir)
    {
        Debug.Log("PutDir="+ dir.ToString());
        m_StartMgr.StartMenuPutDir(dir);
    }
    void PutOK() {
        m_StartMgr.StartMenuPutOK();
    }
    void PutCancel()
    {
        m_StartMgr.StartMenuPutCancel();
    }
}
