using UnityEngine;
using System.Collections;

public class IGameScene{

    public string m_SceneName = "ISceneName";

    public string SceneName {
        get { return m_SceneName; }
        set{ m_SceneName = value; }
    }

    protected GameSceneMgr m_GameSceneMgr = null;

    public IGameScene(GameSceneMgr SceneMgr) {
        m_GameSceneMgr = SceneMgr;
    }

    public virtual void SceneBegin() {
    }
    public virtual void SceneUpdate() {
    }
    public virtual void SceneEnd() {
    }

}
