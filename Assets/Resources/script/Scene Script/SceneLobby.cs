using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneLobby : IGameScene
{   
    //來自繼承的
    //m_GameSceneMgr : 自己的SceneMgr
    private LobbyMgr m_LobbyMgr = null;

    public SceneLobby(GameSceneMgr SceneMgr):base(SceneMgr) {
        m_SceneName = "SceneLobby";
    }

    public override void SceneBegin()
    {
        //Lobby控制器
        LobbyMgr.Instance.init(this);//第一次呼叫必定由此處進入，確保傳入正確的Scene
        //m_LobbyMgr.init();
        Debug.Log("Success transfer to SceneLobby");
    }

    public void ChangeSceneToMap() {
        Debug.Log("SceneLobby Listen");
        m_GameSceneMgr.SetScene(new SceneMap(m_GameSceneMgr), "SceneMap");
    }

    public override void SceneUpdate()
    {
        base.SceneUpdate();
    }

    public override void SceneEnd()
    {
        base.SceneEnd();
        //m_LobbyMgr.LobbyMgrEnd();

    }


}
