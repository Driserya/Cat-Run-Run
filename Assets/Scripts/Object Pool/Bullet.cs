using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    //创建一个集合保存场景中存在的对象（不在对象池的对象）
    public List<GameObject> list = new List<GameObject>();

    //public List<GameObject> list2 = new List<GameObject>();

    private float tempTime = 0;

    private GameObject go;

    public GameObject Boss;

    public float x;

    public GameObject A;

    public GameObject B;

    public float firecont1;

    public float firecont2;


    void Update()
    {   
        if (Time.time - tempTime > 2)//发射子弹间隔
        {
            x = cont();
            if (firecont1 < x)
            {
                //从对象池中取出一个对象
                go = GetComponent<ObjectPool>().Pop(A);
                //发射子弹
                //fire.fired();
                Begin();

                list.Add(go);
                go.SetActive(true);
            }
            //if (firecont2 > x)
            //{
            //    //从对象池中取出一个对象
            //    go = GetComponent<ObjectPool>().Pop(B);
            //    //发射子弹
            //    //fire.fired();
            //    Begin();

            //    list2.Add(go);
            //    go.SetActive(true);
            //}
            tempTime = Time.time;
        }
    }


    private void Begin()
    {
        go.transform.position = Boss.transform.position;
    }

    public float cont()
    {
        x = Random.Range(0f, 1f);

        return x;//发射子弹概率
    }
}