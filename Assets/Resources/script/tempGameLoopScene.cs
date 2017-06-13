using UnityEngine;
using System.Collections;

public class tempGameLoopScene : MonoBehaviour {

    GameSceneMgr SceneMgr = new GameSceneMgr(); 
	void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    
    // Use this for initialization
	void Start () {
        Debug.Log("開始遊戲");
        SceneMgr.SetScene(new SceneStart(SceneMgr),"");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SceneMgr.SceneUpdate();
    }
}
