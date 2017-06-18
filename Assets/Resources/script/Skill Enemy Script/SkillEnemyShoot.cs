using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnemyShoot{

    private StageMgr m_StageMgr = null;

    private GameObject m_Bullet = null;

    private static SkillEnemyShoot _instance;
    public static SkillEnemyShoot Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SkillEnemyShoot();
            return _instance;
        }
    }

    public SkillEnemyShoot()
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
        int AttPoint = Attacker.GetComponent<StageEnemyUnit>().GetSkillEnemy().getAttackPoint(SkillID);
        if (AnimatorInfo.IsName("Move"))
        {
            return;
        }
        else if (SkillStep == AttPoint + 20)
        {
            Attacker.GetComponent<StageEnemyUnit>().SetEnemySkillEnd();

        }
        else if (SkillStep < AttPoint)
        {
            ObjFuntion.TurnToObj(Attacker, m_StageMgr.GetPlayerObj(), false);
        }
        if (SkillStep == AttPoint)//攻擊點
        {
            Debug.Log("Shoot!");
            Shoot(Attacker);
        }
    }
    //發射
    void Shoot(GameObject Attacker)
    {
        GameObject NewBullet = GameObject.Instantiate(m_Bullet,
            Attacker.transform.position + new Vector3(0.0f, 5.0f, 0.0f),
            Quaternion.identity);
        Vector3 Dir = Attacker.transform.TransformDirection(Vector3.forward);
        NewBullet.gameObject.GetComponent<BulletAction>().StartShoot(Dir, m_StageMgr, "Player");

    }
}
