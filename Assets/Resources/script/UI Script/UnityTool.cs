using UnityEngine;
using System.Collections;

public static class UnityTool{

	public static GameObject FindGameObject(string GameObjectName)
    {
        GameObject pTmpGameObj = GameObject.Find(GameObjectName);
        if (pTmpGameObj == null)
        {
            Debug.Log("[warning] can't find obj "+ GameObjectName + " in scene");
            return null;
        }
        Debug.Log("Find GameObj: " + GameObjectName);
        return pTmpGameObj;
    }

    //Get Child Obj
    public static GameObject FindChildGameObject( GameObject Container, string gameobjectName)
    {
        if (Container == null)
        {
            Debug.LogError("GetChildGameObject:Counter = null");
            return null;
        }

        Transform pGameObjectTF = null;
        //是不是Container本身
        if (Container.name == gameobjectName)
            pGameObjectTF = Container.transform;
        else
        {
            Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == gameobjectName)
                    pGameObjectTF = child;
                else
                {
                    //Debug.LogWarning("Countainer[" + Container.name + "]exist the same obj name [" + gameobjectName + "]");
                }
            }
        }
        if (pGameObjectTF == null)
        {
            Debug.LogError("Container[" + Container.name + "] can't find child object [" + gameobjectName + "]");
            return null;
        }

        Debug.Log("Find Object:" + gameobjectName);
        return pGameObjectTF.gameObject;

    }

}
