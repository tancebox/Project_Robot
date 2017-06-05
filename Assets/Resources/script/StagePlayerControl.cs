using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class StagePlayerControl{

    private StageMgr m_StageMgr = null;
    private GameObject Stick = null;
    private Button BtnNormalAttack = null;
    private Button BtnSkill1 = null;
    private Button BtnSkill2 = null;
    private Button BtnSkill3 = null;

    private float speed = 0.3f;
    private float speedChange = 0.01f;
    private float speedMax = 0.3f;
    private float speedUp = 0.0f;
    private float speedDown = 0.0f;
    private float speedLeft = 0.0f;
    private float speedRight = 0.0f;
    private int ControlType = 1; //1:Pad 2:Keyroard

    public StagePlayerControl(StageMgr StageMgr)
    {
        m_StageMgr = StageMgr;
        Stick = GameObject.Find("Stick");
        //取得技能按鈕群
        GameObject SkillNode = UnityTool.FindGameObject("SkillBtnNode");
        BtnNormalAttack = UITool.GetUIComponent<Button>(SkillNode, "BtnNormalAttack");
        BtnSkill1 = UITool.GetUIComponent<Button>(SkillNode, "BtnSkill1");
        BtnSkill2 = UITool.GetUIComponent<Button>(SkillNode, "BtnSkill2");
        BtnSkill3 = UITool.GetUIComponent<Button>(SkillNode, "BtnSkill3");


        //註冊技能按鈕事件
        if (BtnNormalAttack != null)
            BtnNormalAttack.onClick.AddListener(() => OnSkillBtnClick("NormalAttack")); 
        if (BtnSkill1 != null)
            BtnSkill1.onClick.AddListener(() => OnSkillBtnClick("Skill_1"));
        if (BtnSkill2 != null)
            BtnSkill2.onClick.AddListener(() => OnSkillBtnClick("Skill_2"));
        if (BtnSkill3 != null)
            BtnSkill3.onClick.AddListener(() => OnSkillBtnClick("Skill_3"));


    }

    public void Update() {
        if (Input.anyKeyDown)//按下任何按鍵，切換為鍵盤輸入
            ControlType=2;

        if (ControlType==1)
            PadControl();
        else if(ControlType==2)
            KeyBoradControl();

    }

    void PadControl()//遊戲搖桿控制
    {
        // 移動相關
        Vector3 Dir = new Vector3();

        Dir.y = 0;
        Dir.x = Input.GetAxis("Horizontal");
        Dir.z = Input.GetAxis("Vertical");

        //claaulate the R angle
        double radians = 0;
        radians = Math.Atan2(Dir.z, Dir.x);
        //claculate the normalize Dir
        double FinalX = 1 * Math.Cos(radians);
        double FinalZ = 1 * Math.Sin(radians);

        Dir.x = (float)FinalX * speed;
        Dir.z = (float)FinalZ * speed;

        if (Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1 || Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1)
            m_StageMgr.MgrMoveCamera(Dir, true);
        else
        {
            Dir.x = 0.0f;
            Dir.z = 0.0f;
            m_StageMgr.MgrMoveCamera(Dir, false);
        }
    }

    

    void KeyBoradControl()//鍵盤控制
    {
        //滑鼠攻擊
        if (Input.GetMouseButtonDown(0))
        {
            m_StageMgr.MgrPlaySkill(0);
        }
        if (Input.GetMouseButtonDown(1))
        {
            m_StageMgr.MgrPlaySkill(1);
        }


        //鍵盤移動
        Vector3 Dir = new Vector3();

        Dir.y = 0;
        Dir.x = 0;
        Dir.z = 0;

        //是否有輸入
        bool isInput = false;

        //上
        if (Input.GetKey(KeyCode.W))
        {
            if (speedUp < speedMax)
                speedUp += speedChange;
            if (speedUp > speedMax)
                speedUp = speedMax;
            //Debug.Log("W:" + Dir.z.ToString());
            isInput = true;
        }
        else
        {
            if (speedUp > 0)
                speedUp -= speedChange;
            if(speedUp < 0)
                speedUp = 0.0f;
        }
        //下
        if (Input.GetKey(KeyCode.S))
        {
            if (speedDown < speedMax)
                speedDown += speedChange;
            if (speedDown > speedMax)
                speedDown = speedMax;
            //Debug.Log("S:" + Dir.z.ToString());
            isInput = true;
        }
        else
        {
            if (speedDown > 0)
                speedDown -= speedChange;
            if (speedDown < 0)
                speedDown = 0.0f;
        }
        //右
        if (Input.GetKey(KeyCode.D))
        {
            if (speedRight < speedMax)
                speedRight += speedChange;
            if (speedRight > speedMax)
                speedRight = speedMax;
            //Debug.Log("D:" + Dir.x.ToString());
            isInput = true;
        }
        else
        {
            if (speedRight > 0)
                speedRight -= speedChange;
            if (speedRight < 0)
                speedRight = 0.0f;
        }
        //左
        if (Input.GetKey(KeyCode.A))
        {
            if (speedLeft < speedMax)
                speedLeft += speedChange;
            if (speedLeft > speedMax)
                speedLeft = speedMax;
            //Debug.Log("A:" + Dir.x.ToString());
            isInput = true;
        }
        else
        {
            if (speedLeft > 0)
                speedLeft -= speedChange;
            if (speedLeft < 0)
                speedLeft = 0.0f;
        }

        Dir.x = speedRight - speedLeft;
        Dir.z = speedUp - speedDown;



        if (Dir.x != 0 || Dir.z != 0)
        {//claaulate the R angle
            double radians = 0;
            radians = Math.Atan2(Dir.z, Dir.x);
            //claculate the normalize Dir
            double FinalX = 1 * Math.Cos(radians);
            double FinalZ = 1 * Math.Sin(radians);

            Dir.x = (float)FinalX * speed;
            Dir.z = (float)FinalZ * speed;
            m_StageMgr.MgrMoveCamera(Dir, isInput);
        }
        else
        {
            Dir.x = 0.0f;
            Dir.z = 0.0f;
            m_StageMgr.MgrMoveCamera(Dir, isInput);
        }

    }
    //技能相關按鈕
    //按下測試按鈕(Btn4)
    void OnSkillBtnClick(string SkillType)
    {
        Debug.Log(SkillType);
    }


}
