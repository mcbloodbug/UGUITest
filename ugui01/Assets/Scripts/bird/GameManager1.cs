using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    //С��ķ���
    public static int score = 0;
    //�÷���ʾ���ı���
    public TMP_Text text;
    void Update() { 
        text.text ="Score:"+score;
    }
}
