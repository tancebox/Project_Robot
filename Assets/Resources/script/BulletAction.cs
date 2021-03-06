﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour {

    private Vector3 m_Dir = new Vector3(0,0,0);
    private StageMgr m_StageMgr = null;
    private string m_TargetType = "";

	void Start () {
		
	}

    public void StartShoot(Vector3 Dir, StageMgr StageMgr, string TargetType)
    {
        m_Dir = Dir;
        m_StageMgr = StageMgr;
        m_TargetType = TargetType;
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
        if (other.gameObject.tag == m_TargetType && m_TargetType == "EnemyUnit")
        {
            GameObject Enemy = null;
            Enemy = other.gameObject;
            m_StageMgr.MgrAttackEnemy(Enemy, m_Dir);
            Destroy(this.gameObject);
            Debug.Log("Hit");
        }

        if (other.gameObject.tag == m_TargetType && m_TargetType == "Player")
        {
            GameObject Target = null;
            Target = other.gameObject;
            m_StageMgr.MgrAttackPlayer(Target, m_Dir);
            Destroy(this.gameObject);
            Debug.Log("Hit Player");
        }


    }
}
