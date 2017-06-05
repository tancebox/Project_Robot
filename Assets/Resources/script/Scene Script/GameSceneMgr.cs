using UnityEngine;
using System.Collections;

public class GameSceneMgr{

    private IGameScene m_GameScene = null;
    private bool m_bRunBegin = false;

    public GameSceneMgr() { }

    public void SetScene(IGameScene GameScene,string LoadSceneName) {
        Debug.Log("開始設定參數 at" + GameScene.m_SceneName);
        m_GameScene = GameScene;
        m_bRunBegin = false;
        //載入場景
        LoadScene(LoadSceneName);
        //通知前一Scene結束
        if (m_GameScene != null)
            m_GameScene.SceneEnd();
        //設定新的Scene
        m_GameScene = GameScene;
    }

    private void LoadScene(string LoadSceneName)
    {
        if (LoadSceneName == null || LoadSceneName.Length == 0)
            return;
        Debug.Log("StartLoadScene");
        Application.LoadLevel(LoadSceneName);
        
    }
	
	// 
	public void SceneUpdate () {
        //是否還在載入
        if (Application.isLoadingLevel) {
            return;
        }
        //State開始
        if (m_GameScene!=null && m_bRunBegin == false)
        {
            Debug.Log("LoadSceneDone at" + m_GameScene.m_SceneName);
            m_GameScene.SceneBegin();
            m_bRunBegin = true;
        }
        //下面還缺UPDATE的呼叫，若有需要加
        m_GameScene.SceneUpdate();

    }
}
