using UnityEngine;
using System.Collections;

public class GameLoopScene : MonoBehaviour {

    GameSceneMgr SceneMgr = new GameSceneMgr(); 
	void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        Application.targetFrameRate = 60;
    }
    
    // Use this for initialization
	void Start () {
        Debug.Log("開始遊戲");
        SceneMgr.SetScene(new SceneStart(SceneMgr),"");
	}
	
	// Update is called once per frame
	void Update () {
        SceneMgr.SceneUpdate();
    }
}
