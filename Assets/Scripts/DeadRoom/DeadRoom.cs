using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class DeadRoom : MonoBehaviour
{
    public GameObject Cat;

    private QuaverCtrl QuaverCtrl;

    private void Start()
    {
        QuaverCtrl=Cat.GetComponent<QuaverCtrl>();
    }
    private void Update()
    {
        transform.position = new Vector3(Cat.transform.position.x, transform.position.y);//死亡触发器，x跟随cat，y不变；

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.name=="Cat")
        {
            catDead();
        }
    }
    private void catDead()
    {
        QuaverCtrl.isDead=true;
    }
}
