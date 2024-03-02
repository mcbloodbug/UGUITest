using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// U3D调用java
/// </summary>

public class javaManager : MonoBehaviour
{
    //文本输入框，用于输入数字
    public TMP_InputField input1;
    public TMP_InputField input2;
    
    public TMP_Text text;
    public Button button_Add;
    public Button button_Refresh;

    //u3d调用java的工具类
    AndroidJavaClass jc = null;
    void Start()
    {
        jc = new AndroidJavaClass("com.example.combinejava.testsucc");   
    }

    //两数相加的方法
    public void Add()
    {
        if(input1.text !=""&& input2.text !="")
        {   //u3d里的方法
            //int res =int.Parse( input1.text) + int.Parse(input2.text);
            //text.text ="Ans:"+ res.ToString();

            //调用JAVA的add方法
            text.text =jc.CallStatic<int>("Add",int.Parse(input1.text) ,int.Parse(input2.text)).ToString();
        }

    }
    //刷新的方法
    public void Refesh()
    {
        input1.text = "";
        input2.text = "";
        text.text = "Ans:";
    }
    void Update()
    {
        
    }
}
