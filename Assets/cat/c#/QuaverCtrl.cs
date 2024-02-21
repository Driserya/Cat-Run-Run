using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class QuaverCtrl : MonoBehaviour
{
    public float volume;

    public MicInput micInput;

    public float jumpForce = 20;

    public float speed;

    private Rigidbody2D rg;

    float tempTime=0;

    public bool isDead = false;

    public GameObject grounds;

    public Platform platform;

    public UnityEvent OnDie;

    public UnityEvent OnBoss;

    public GameObject UI;

    public UIManager UIManager;

    private float nextVolume=0;

    private AudioDefination audioDefination;

    public GameObject boss;

    public GameObject ObjectPool;

    public bool isBoss = false;

    void Start()
    {
        rg = this.gameObject.GetComponent<Rigidbody2D>();
        micInput = this.gameObject.GetComponent<MicInput>();
        UIManager = UI.gameObject.GetComponent<UIManager>();
        audioDefination = GetComponent<AudioDefination>();
        platform = grounds.GetComponent<Platform>();

    }

    private void Update()
    {
        if(!UIManager.isPlay)
        {
            rg.constraints = ~RigidbodyConstraints2D.FreezePositionY;
        }
        if(UIManager.isPlay)
        {
            rg.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if(platform.score ==30&&isBoss==false)
        {
            isBoss = true;
            OnBoss?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        volume = micInput.volume*10;

        if(UIManager.isPlay)
        {
            if (volume > 0.6)
            {
                rg.constraints = RigidbodyConstraints2D.FreezeRotation;
                MoveForward();
            }
            if (volume > 1.5)
            {
                rg.constraints = RigidbodyConstraints2D.FreezeRotation;
                //Jump();
                if (Time.time - tempTime > 0.15)
                {
                    Jump();
                    tempTime = Time.time;
                }
            }
            if (volume < 0.6)
            {
                //rg.velocity = new Vector2(0,rg.velocity.y);
                rg.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            }

            //死亡
            if (isDead)
            {
                OnDie?.Invoke();
            }
        }
        else
        {
            rg.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void Jump()
    {
        if (volume >= nextVolume)
        { 
            rg.AddForce(Vector2.up * jumpForce);
            if(UIManager.isOpenFX)
                audioDefination.PlayAudioClip();
        }
        nextVolume=volume;
    }

    private void MoveForward()
    {
        rg.velocity = new Vector2(speed*Time.deltaTime, rg.velocity.y);
    }

    //死亡
    public void CatDead()
    {
        UIManager.isPlay=false;
        rg.constraints = RigidbodyConstraints2D.FreezeAll;
        UIManager.Did();
    }

    public void BossOpen()
    {
        boss.SetActive(true);

        UIManager.BossUIOpen();
    }

    public void Again()
    {
        platform.CleanTileMap();
        platform.contx = 0;
        platform.GenerateTileMap(0,0);
        transform.position = new Vector3(0, -1, 0);  
        platform.score = 0;
        platform.ColliderAgain();
        isBoss=false;
    }

}
