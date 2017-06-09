using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour {

    private Vector3 m_Dir = new Vector3(0,0,0);
    private StageMgr m_StageMgr = null;

	void Start () {
		
	}

    public void StartShoot(Vector3 Dir, StageMgr StageMgr)
    {
        m_Dir = Dir;
        m_StageMgr = StageMgr;
        Debug.Log("Shoot");
    }
	
	// Update is called once per frame
	void Update () {
        BulletMove();
    }

    void BulletMove()
    {
        this.gameObject.transform.Translate(m_Dir, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject Enemy = null;
        if (other.gameObject.tag == "EnemyUnit")
        {
            Enemy = other.gameObject;
            m_StageMgr.MgrAttackEnemy(Enemy, m_Dir);
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }

        
    }
}
