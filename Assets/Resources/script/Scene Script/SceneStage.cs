using UnityEngine;
using System.Collections;

public class SceneStage : IGameScene {

    public SceneStage(GameSceneMgr SceneMgr) :base(SceneMgr)
    {
        m_SceneName = "SceneStage";
        //SceneBegin();
    }

    public override void SceneBegin()
    {
        Debug.Log("Into Scene Stage");
        StageMgr.Instance.init(this);
    }

    public override void SceneUpdate()
    {
        base.SceneUpdate();
        StageMgr.Instance.Update();
    }

    public override void SceneEnd()
    {
        base.SceneEnd();

    }
	
}
