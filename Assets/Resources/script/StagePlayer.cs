using UnityEngine;
using System.Collections;

public class StagePlayer {

    GameObject m_PlayerObj = null;

    private static StagePlayer _instance;
    public static StagePlayer Instance
    {
        get
        {
            if (_instance == null)
                _instance = new StagePlayer();
            return _instance;
        }
    }

    public StagePlayer()
    {
        m_PlayerObj = UnityTool.FindGameObject("Player");
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void init()
    {

    }

    public GameObject GetPlayerObj()
    {
        return m_PlayerObj;
    }

    public Vector3 GetPlayerPos()
    {
        Vector3 Pos = m_PlayerObj.transform.position;
        return Pos;
    }
}
