using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject Cat;

    private QuaverCtrl quaverCtrl;

    public GameObject pauseMenu;

    public GameObject playUI;

    public GameObject pauseUI;

    public GameObject scoreUI;

    public GameObject DidUI;

    public GameObject BossUI;

    public GameObject Boss;

    public GameObject ObjectPool;

    public bool isPlay=false;

    public bool isOpenBGM=true;

    public bool isOpenFX=true;

    public Sprite openImage;
    
    public Sprite closeImage;

    public Image BGM;

    public Image FX;

    public AudioSource BGMaudioSource;

    public AudioSource FXaudioSource;

    public bool isclear = false;


    private void Update()
    {
        quaverCtrl=Cat.GetComponent<QuaverCtrl>();
    }

    //暂停游戏
    public void PauseGame()
    {
        scoreUI.SetActive(false);
        pauseUI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    //恢复游戏
    public void ResumGame()
    {
        scoreUI.SetActive(true);
        playUI.SetActive(false) ;
        pauseMenu.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 1;
    }

    //重新开始
    public void RestartGame()
    {
        isclear = true;
        isPlay=false;
        quaverCtrl.isDead=false;
        DidUI.SetActive(false);
        pauseMenu.SetActive(false);
        scoreUI.SetActive(false);
        pauseUI.SetActive(false);
        quaverCtrl.Again();
        //重启
        //SceneManager.LoadScene(0);
        //影响UI控制和音乐音效

        playUI.SetActive(true);
        Boss.SetActive(false);
        ObjectPool.SetActive(false);
        Time.timeScale = 1;
        isclear = false;
    }
    
    //开始游戏
    public void PlayGame()
    {
        isPlay = true;
        playUI.SetActive(false);
        pauseUI.SetActive(true);
        scoreUI.SetActive(true);
    }

    //打开死亡UI
    public void DidGame()
    {
        isPlay=false ;
        scoreUI.SetActive(false);
        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
        DidUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();//退出游戏
    }

    public void Did()
    {
        DidUI.SetActive(true);
        scoreUI.SetActive(false);
        pauseUI.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void FXClose()
    {
        isOpenFX=!isOpenFX;
        if(isOpenFX)
        {
            FX.sprite = openImage;
        }
        else
        {
            FX.sprite = closeImage;
        }
    }

    public void BGMClose()
    {
        isOpenBGM = !isOpenBGM;
        if(isOpenBGM)
        {
            BGM.sprite = openImage;          
        }
        else
        {
            BGM.sprite= closeImage;           
        }
    }

    public void BossUIOpen()
    {
        Time.timeScale = 0;
        scoreUI.SetActive(false);
        pauseUI.SetActive(false);
        BossUI.SetActive(true);
    }

    public void bossBegin()
    {
        Time.timeScale = 1;
        scoreUI.SetActive(true);
        pauseUI.SetActive(true);
        BossUI.SetActive(false);
        ObjectPool.SetActive(true);
    }
}
