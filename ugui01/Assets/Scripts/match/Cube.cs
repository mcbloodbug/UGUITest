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
        UpdateNumText(); // �� Start �����и��� numText ����ʾ
    }

    public void SetNum(int value)
    {
        num = value;
        UpdateNumText(); // �� SetNum �����и��� numText ����ʾ
    }
    public void SetName(int value)
    {
        nameText.text = value.ToString() + "��"; 
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
        UpdateNumText(); // �� UpdateNum �����и��� numText ����ʾ
    }

    private void UpdateNumText()
    {
        scoreText.text = num.ToString(); // �� num ��ֵת��Ϊ�ַ��������� numText ���ı�����
    }
   
}