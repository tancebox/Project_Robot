using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjFuntion{

    /*public static ObjFuntion _instance = null;
    f
    public static ObjFuntion Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ObjFuntion();
            return _instance;
        }
    }

    public ObjFuntion()
    {
        
    }*/
    //轉向目標
    public static void TurnToObj(GameObject SelfObj, GameObject Target, bool isInverse)
    {
        Vector3 Dir = Target.transform.position - SelfObj.transform.position;
        //轉身
        Vector3 ZVector = new Vector3(0, 0, 1);
        float angle = Vector3.Angle(ZVector, Dir);
        if (Dir.x < 0)
            angle = angle * -1;
        Quaternion quate = Quaternion.identity;
        if(false == isInverse)
            quate.eulerAngles = new Vector3(0, angle, 0); // 表示設置x軸方向旋轉了angle度
                                                      //最後再把quate付給你要操作的Gameobject：
        else
            quate.eulerAngles = new Vector3(0, angle+180, 0);
        SelfObj.transform.rotation = quate;
    }
    //轉向指定方向
    public static void TurnToDir(GameObject SelfObj, Vector3 Dir, bool isInverse)
    {
        //轉身
        Vector3 ZVector = new Vector3(0, 0, 1);
        float angle = Vector3.Angle(ZVector, Dir);
        if (Dir.x < 0)
            angle = angle * -1;
        Quaternion quate = Quaternion.identity;
        if (false == isInverse)
            quate.eulerAngles = new Vector3(0, angle, 0); // 表示設置x軸方向旋轉了angle度
                                                          //最後再把quate付給你要操作的Gameobject：
        else
            quate.eulerAngles = new Vector3(0, angle + 180, 0);
        SelfObj.transform.rotation = quate;
    }
    //檢查目標是否在距離內
    public static bool CheckTargetInDis(GameObject SelfObj, GameObject Target, float Dis)//檢查視野內是否出現目標
    {
        Vector3 diff = SelfObj.transform.position - Target.transform.position;
        float curDistance = Vector3.Distance(SelfObj.transform.position, Target.transform.position);
        if (curDistance <= Dis)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
