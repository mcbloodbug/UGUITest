using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UseJar : MonoBehaviour
{
    public TMP_InputField setinputlog;
    public TMP_InputField getlog;
    public TMP_InputField setinputname;
    public TMP_InputField getname;

    public Button btn_setfield_log;

    //Toast文本信息输入框
    public TMP_InputField Toast;

    //C#调用jar的类
    AndroidJavaClass jc = null;
    AndroidJavaObject jo= null;
     
    AndroidJavaClass unityplayer = null;
    AndroidJavaObject currentActivity = null;
    private void Awake()
    {
        btn_setfield_log.onClick.AddListener(SetLog_field);
    }
    void Start()
    { 
        jc = new AndroidJavaClass("com.example.exportjar2.Test"); 
        jo = new AndroidJavaObject("com.example.exportjar2.Test");

        //获取当前正在运行的Unity场景
        unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");

    }
    
    //日志名，设置，获取

    //设置日志名
    public void SetLog()
    {
        jc.CallStatic("SetLOG",setinputlog.text);
    }
    public void SetLog_field()
    {
        jo.SetStatic<string>("LOG",setinputlog.text) ;
    }
    //获取日志名的方法
    public void GetLog()
    {
        getlog.text = jc.CallStatic<string>("GetLOG");
       
    }
    public void GetLog_Field()
    {
        getlog.text = jo.GetStatic<string>("LOG");
    }

    //设置name
    public void Setname()
    {
        jo.Call("Setname",setinputname.text);
    }
    public void Setname_field()
    {
        jo.Set<string>("name", setinputname.text);
    }

    //获取name
    public void GetName()
    {
        getname.text = jo.Call<string>("Getname");
    }
    public void GetName_field()
    {
        getname.text = jo.Get<string>("name");
    }
    //设置Toast提示信息
    public void SetMsg1()
    {
        jo.Call("ShowMsg", Toast.text);
    }
    public void SetMsg2()
    {
        jo.Call("ShowMsg",currentActivity, Toast.text);
    }

}
