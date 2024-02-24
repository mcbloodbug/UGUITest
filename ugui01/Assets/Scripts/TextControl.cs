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
        // ��ʼ���ı��������ʾ״̬
        parentObject.SetActive(isTextVisible);
        imageObject.SetActive(isImageVisible);

        // �󶨰�ť�ĵ���¼�
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
