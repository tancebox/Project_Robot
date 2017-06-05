using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy_001 : MonoBehaviour
    {
    private StageMgr m_StageMgr = null;
    private GameObject m_Player = null;
    private StagePlayer m_StagePlayer = null;
    private GameObject m_PlayerModel = null;
    private Animator m_Animator = null;
    private Vector3 PlayerDir;

    //技能相關
    private SkillPlayer m_SkillPlayer = null;
    private int m_SkillStep = 0;

    //狀態相關
    private int m_State = 1; //1:Idle 2:Run 3.BeAttack
    private bool m_IsMoving = false;
    private bool m_IsAttacking = false;


    // Use this for initialization
    void Start()
    {
        m_Animator = this.gameObject.GetComponentInChildren<Animator>();
        m_State = 1;
        //m_Animator.SetInteger("state",1);

    }

    // Update is called once per frame
    public void Update()
    {
        //判斷
        
        //執行
        switch (m_State)
        {
            case 1:
                IdleUpdate();
                break;
            case 2:
                RunUpdate();
                break;
            case 3:
                BeAttackUpdate();
                break;
        }
    }

    private void IdleUpdate()
    {

    }
    private void RunUpdate()
    {

    }
    private void BeAttackUpdate()
    {
        AnimatorStateInfo AnimatorInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        if (AnimatorInfo.IsName("Idle"))
        {
            Debug.Log("Still Idle");
            return;
        }
            
        if (AnimatorInfo.normalizedTime >= 0.9f)
        {
            m_State = 1;
            m_Animator.SetInteger("state", 1);
            Debug.Log("return idle");
        }
    }

    public void BeAttack(Vector3 Forward)
    {
        Debug.Log("AI Be Attack!");
        m_Animator.SetInteger("state", 3);

        //旋轉至面對玩家
        Vector3 ZVector = new Vector3(0, 0, 1);
        float angle = Vector3.Angle(ZVector, Forward);
        if (Forward.x < 0)
            angle = angle * -1;
        Quaternion quate = Quaternion.identity;
        quate.eulerAngles = new Vector3(0, angle+180, 0); // 表示設置x軸方向旋轉了angle度
                                                      //最後再把quate付給你要操作的Gameobject：
        this.gameObject.transform.rotation = quate;

        m_State = 3;
    }

}
