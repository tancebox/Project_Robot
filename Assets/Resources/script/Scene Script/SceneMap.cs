using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneMap : IGameScene
{
    //以下為暫時程式碼，按鈕跳至STAGE SCENE
    private GameObject m_Canvas = null;
    private Button m_Btn = null;

    public SceneMap(GameSceneMgr SceneMgr):base(SceneMgr) {
        m_SceneName = "SceneMap";
    }

    public override void SceneBegin()
    {
        //base.SceneBegin();
        m_Canvas = UITool.FindCanvasObject("MapCanvas");
        m_Btn = UITool.GetUIComponent<Button>(m_Canvas, "Button");

        if (m_Btn != null)
            m_Btn.onClick.AddListener(() => OnBtnClick(m_Btn));
    }

    private void OnBtnClick(Button theButton)
    {
        Debug.Log("Clicked the Button,Begin to transfer to StageScene");
        m_GameSceneMgr.SetScene(new SceneStage(m_GameSceneMgr), "SceneStage");


    }
}