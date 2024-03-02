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

    //Toast�ı���Ϣ�����
    public TMP_InputField Toast;

    //C#����jar����
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

        //��ȡ��ǰ�������е�Unity����
        unityplayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityplayer.GetStatic<AndroidJavaObject>("currentActivity");

    }
    
    //��־�������ã���ȡ

    //������־��
    public void SetLog()
    {
        jc.CallStatic("SetLOG",setinputlog.text);
    }
    public void SetLog_field()
    {
        jo.SetStatic<string>("LOG",setinputlog.text) ;
    }
    //��ȡ��־���ķ���
    public void GetLog()
    {
        getlog.text = jc.CallStatic<string>("GetLOG");
       
    }
    public void GetLog_Field()
    {
        getlog.text = jo.GetStatic<string>("LOG");
    }

    //����name
    public void Setname()
    {
        jo.Call("Setname",setinputname.text);
    }
    public void Setname_field()
    {
        jo.Set<string>("name", setinputname.text);
    }

    //��ȡname
    public void GetName()
    {
        getname.text = jo.Call<string>("Getname");
    }
    public void GetName_field()
    {
        getname.text = jo.Get<string>("name");
    }
    //����Toast��ʾ��Ϣ
    public void SetMsg1()
    {
        jo.Call("ShowMsg", Toast.text);
    }
    public void SetMsg2()
    {
        jo.Call("ShowMsg",currentActivity, Toast.text);
    }

}
