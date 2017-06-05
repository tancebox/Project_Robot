using UnityEngine;
using System.Collections;

public class StageCamera{

    private StageMgr m_StageMgr = null;
    private GameObject m_Camera;

    private Quaternion CameraDir;

    public StageCamera(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_Camera = UnityTool.FindGameObject("Main Camera");

        CameraDir = Quaternion.Euler(10f,0f,0f);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
        //攝影機位置
        Vector3 PlayerPos = m_StageMgr.MgrGetPlayerPos();
        Vector3 CameraPos = new Vector3();
        CameraPos.Set(PlayerPos.x, PlayerPos.y + 50, PlayerPos.z - 30);
        //move
        m_Camera.transform.position = CameraPos;
        //攝影機方向


    }

    public void MoveCamera(Vector3 Dir)
    {
        m_Camera.transform.Translate(Dir);
    }

}
