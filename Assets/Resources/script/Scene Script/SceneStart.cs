using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneStart : IGameScene{
    /*
    m_GameSceneMgr :來自IGameScene的參數,是目前的SceneMgr;
    目前Scene名稱: Scene
    */
    private GameObject m_Canvas = null;
    private Button m_StartBtn = null;
    public SceneStart(GameSceneMgr SceneMgr) :base(SceneMgr)
    {
        m_SceneName = "SceneStart";
        SceneBegin();//Scene StartSceneBegin,因為不是從其他地方過來的
    }

    public override void SceneBegin() {
        Debug.Log("Scene Start Begin");
        StartMgr.Instance.init(this);
    }

    public override void SceneUpdate()
    {
        base.SceneUpdate();
        StartMgr.Instance.Update();
    }

    public override void SceneEnd()
    {
        base.SceneEnd();
        
    }

    private void OnStartBtnClick(Button theButton)
    {
        Debug.Log("Clicked the Start Button,Begin to transfer to LobbyScene");
        m_GameSceneMgr.SetScene(new SceneLobby(m_GameSceneMgr),"SceneLobby");
        

    }

    public void ChangeSceneToStage()
    {
        Debug.Log("Clicked the Start Button,Begin to transfer to StageScene");
        m_GameSceneMgr.SetScene(new SceneStage(m_GameSceneMgr), "SceneStage");


    }
}
