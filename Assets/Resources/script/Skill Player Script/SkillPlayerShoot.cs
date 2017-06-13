using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerShoot{

    private StageMgr m_StageMgr = null;

    private GameObject m_Bullet = null;

    private static SkillPlayerShoot _instance;
    public static SkillPlayerShoot Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SkillPlayerShoot();
            return _instance;
        }
    }

    public SkillPlayerShoot()
    {

    }

    public void init(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        m_Bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //技能更新
    public void SkillUpdate(GameObject Attacker, Animator Animator, int SkillID, int SkillStep)
    {
        AnimatorStateInfo AnimatorInfo = Animator.GetCurrentAnimatorStateInfo(0);
        if (AnimatorInfo.IsName("Walk"))
        {
            Debug.Log("Still Walk");
            return;
        }
        else if (SkillStep == m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer().getAttackPoint(SkillID) + 20)
        {
            m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().SetActionAttr("IsAttacking", false);
        }
        if (SkillStep == m_StageMgr.GetPlayerObj().GetComponent<StagePlayer>().GetSkillPlayer().getAttackPoint(SkillID))//攻擊點
        {
            Shoot();
        }
    }
    //發射
    void Shoot()
    {
        GameObject NewBullet = GameObject.Instantiate(m_Bullet,
            m_StageMgr.GetPlayerObj().transform.position + new Vector3(0.0f, 5.0f, 0.0f),
            Quaternion.identity);
        Vector3 PlayerDir = m_StageMgr.GetPlayerObj().transform.TransformDirection(Vector3.forward);
        NewBullet.gameObject.GetComponent<BulletAction>().StartShoot(PlayerDir, m_StageMgr, "EnemyUnit");

    }
}
