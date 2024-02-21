using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 视差效果
/// </summary>

public class ParallaxGround : MonoBehaviour
{
    private Transform camTF;

    private Vector3 lastFrameCameraPos;//记录上一帧摄像机的位置；

    public float textureUnitSizeX;

    public float fx;

    public GameObject UI;

    private UIManager UIManager;

    [SerializeField] private Vector2 parallaxFacotr;

    //public float offsetX;绑定角色

    private void Start()
    {
        UIManager = UI.GetComponent<UIManager>();

        camTF =Camera.main.transform;

        lastFrameCameraPos = camTF.position;

        Sprite sprite = this.GetComponent<SpriteRenderer>().sprite;

        textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;

        //offsetX = camTF.position.x - transform.position.x;//如果初始位置不在图片中间，要加上偏移量；//绑定角色
    }

    private void Update()
    {
        Vector2 deltaMovement = camTF.position -lastFrameCameraPos;

        transform.position = transform.position+new Vector3(deltaMovement.x * parallaxFacotr.x , deltaMovement.y * parallaxFacotr.y);

        lastFrameCameraPos = camTF.position;

        if( camTF.position.x - transform.position.x >= textureUnitSizeX)
        {
            float offsetX = camTF.position.x - transform.position.x;//如果初始位置不在图片中间，要加上偏移量；

            transform.position = new Vector3(camTF.position.x + offsetX,transform.position.y); //如果绑定角色用加
        }

        if (UIManager.isPlay == false)
        {

            transform.position = new Vector3(0f, fx, 0f);
        }
    }
    //public void MapClear()
    //{
    //    Debug.Log(fx);
    //    transform.position = new Vector3(0f, fx, 0f);
    //    Debug.Log(fx);
    //}
}
