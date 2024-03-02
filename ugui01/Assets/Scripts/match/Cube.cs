using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    public int num =0;
    public string cubeName;
    public Text nameText;
    public Text scoreText;

    private void Start()
    { 
        UpdateNumText(); // 在 Start 方法中更新 numText 的显示
    }

    public void SetNum(int value)
    {
        num = value;
        UpdateNumText(); // 在 SetNum 方法中更新 numText 的显示
    }
    public void SetName(int value)
    {
        nameText.text = value.ToString() + "号"; 
    }


    public string GetName()
    {
        cubeName = nameText.text;
        return cubeName;
    }

    public int GetNum()
    {
        return num;
    }

    public void UpdateNum(int value)
    {
        num = value;
        UpdateNumText(); // 在 UpdateNum 方法中更新 numText 的显示
    }

    private void UpdateNumText()
    {
        scoreText.text = num.ToString(); // 将 num 的值转换为字符串并更新 numText 的文本内容
    }
   
}