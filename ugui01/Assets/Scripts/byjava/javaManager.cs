using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// U3D����java
/// </summary>

public class javaManager : MonoBehaviour
{
    //�ı������������������
    public TMP_InputField input1;
    public TMP_InputField input2;
    
    public TMP_Text text;
    public Button button_Add;
    public Button button_Refresh;

    //u3d����java�Ĺ�����
    AndroidJavaClass jc = null;
    void Start()
    {
        jc = new AndroidJavaClass("com.example.combinejava.testsucc");   
    }

    //������ӵķ���
    public void Add()
    {
        if(input1.text !=""&& input2.text !="")
        {   //u3d��ķ���
            //int res =int.Parse( input1.text) + int.Parse(input2.text);
            //text.text ="Ans:"+ res.ToString();

            //����JAVA��add����
            text.text =jc.CallStatic<int>("Add",int.Parse(input1.text) ,int.Parse(input2.text)).ToString();
        }

    }
    //ˢ�µķ���
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
