using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsCheck : MonoBehaviour
{
    public bool isGround;

    public float checkRaduis;

    public LayerMask groundLayer;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        //检测地面
        isGround = Physics2D.OverlapCircle(transform.position, checkRaduis, groundLayer);
    }
}
