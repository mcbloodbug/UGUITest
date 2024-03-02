using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    //小鸟的分数
    public static int score = 0;
    //得分显示的文本框
    public TMP_Text text;
    void Update() { 
        text.text ="Score:"+score;
    }
}
