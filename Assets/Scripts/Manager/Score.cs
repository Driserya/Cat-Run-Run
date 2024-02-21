using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//引入unity的UI编辑库

public class UIScore : MonoBehaviour
{
    public Platform platform;

    public Text ScoreUI;//定义要修改的Text

    private void Update()
    {
        int scores = platform.score;
        ScoreUI.text = scores.ToString();//让UI显示的分数等于score的值，这里有String类型的转换
    }
}
