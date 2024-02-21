using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Boss;

    private Rigidbody2D rb;

    public float speed;

    public GameObject ObjectPool;

    public GameObject Cat;

    private QuaverCtrl quaverCtrl;

    private Bullet bullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet = ObjectPool.GetComponent<Bullet>();
        quaverCtrl =Cat.GetComponent<QuaverCtrl>();
    }

    private void FixedUpdate()
    {
        fired();
    }

    private void Update()
    {
        if(quaverCtrl.isBoss==false)
            clear();
    }
    public void fired()
    {
        rb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
    }

    //关闭对象池对象
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "LeftRoom" || other.name == ("Cat"))
        {
            if(other.name == ("Cat"))
                quaverCtrl.isDead = true;
            //放入对象池
            //判断保存场景中对象的list是否为空
            clear();
        }
    }

    public void clear()
    {
        if (bullet.list.Count > 0)
        {
            ObjectPool.GetComponent<ObjectPool>().push(bullet.list[0]);
            bullet.list[0].SetActive(false);
            bullet.list.RemoveAt(0);
        }
    }
}
