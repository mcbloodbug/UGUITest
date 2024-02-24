using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Text textComponent; 
    public GameObject parentObject;
    public GameObject imageObject;

    private bool isTextVisible = false;
    private bool isImageVisible = false;
    private int count = 0;

    private void Start()
    {
        // 初始化文本组件的显示状态
        parentObject.SetActive(isTextVisible);
        imageObject.SetActive(isImageVisible);

        // 绑定按钮的点击事件
        buttonA.onClick.AddListener(ButtonAClicked);
        buttonB.onClick.AddListener(ButtonBClicked);
        buttonC.onClick.AddListener(ButtonCClicked);
    }

    private void ButtonCClicked()
    { 
        isImageVisible = !isImageVisible;
        imageObject.SetActive(isImageVisible);
    }

    private void ButtonAClicked()
    {
        if (isTextVisible)
        {
            count++;
            textComponent.text = count.ToString();
        }
    }

    private void ButtonBClicked()
    {
        isTextVisible = !isTextVisible;
        parentObject.SetActive(isTextVisible);
    }
}
