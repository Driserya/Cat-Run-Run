using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//对象池管理器
public class ObjectPool : MonoBehaviour
{
    //对象池集合
    public List<GameObject> list = new List<GameObject>();

    //游戏预制体
    //private GameObject GoPrefabs;

    //对象池能保存的最大个数
    public int MaxCount = 100;

    //对象保存到对象池
    public void push(GameObject go)
    {
        if (list.Count < MaxCount)
        {
            list.Add(go);
        }
        else
        {
            Destroy(go);
        }
    }

    //从对象池取出一个对象
    //对cat伤害子弹
    public GameObject Pop(GameObject GoPrefabs)
    {
        if (list.Count > 0)
        {
            GameObject go = list[0];
            list.RemoveAt(0);
            return go;
        }

        return Instantiate(GoPrefabs);
    }

    //清空对象池
    public void Clear()
    {
        list.Clear();
    }
}
