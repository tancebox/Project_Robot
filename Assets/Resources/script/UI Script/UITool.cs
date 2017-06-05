using UnityEngine;
using System.Collections;

public class UITool{

    private static GameObject m_CanvasObj = null;

    //取得畫布
    public static GameObject FindCanvasObject(string CanvasName)
    {
        m_CanvasObj = UnityTool.FindGameObject(CanvasName);
        if (m_CanvasObj == null)
        {
            return null;
        }
        Debug.Log("Find Canvas:" + CanvasName);
        return m_CanvasObj;

    }

    //取得畫布下的UO介面
    /*public static GameObject FindUIGameObject(string UIName) {
        if ( m_CanvasObj == null) {
            m_CanvasObj = UnityTool.FindGameObject("Canvas");
        }

        if (m_CanvasObj == null)
        {
            return null;
        }


        return UnityTool.FindChildGameObject(m_CanvasObj,UIName);
    }*/

    //取得UI元件
    public static T GetUIComponent<T>(GameObject Container,string UIName)where T : UnityEngine.Component
    {
        GameObject ChileGameObject = UnityTool.FindChildGameObject(Container, UIName);
        if (ChileGameObject == null)
            return null;
        T tempObj = ChileGameObject.GetComponent<T>();
        if( tempObj == null)
        {
            Debug.LogWarning("元件[" + UIName + "]不是"+typeof(T)+"]");
            return null;
        }
        return tempObj;
    }



}
