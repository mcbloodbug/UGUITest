using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchmakingSystem : MonoBehaviour
{
    public GameObject cubePrefab; // 预制体，用于生成 Cube
    public Transform cubeContainer;
    public Text matchText; // 用于显示匹配信息的文本组件
    public Text resultText; // 用于显示胜利信息的文本组件

    private List<GameObject> cubes = new List<GameObject>();
    private List<int> usedNames = new List<int>(); // 用于存储已使用的名称

    private CubeManager cubeManager;
    List<Cube> validCubes = new List<Cube>();

    void Start()
    {
        cubeManager = GetComponent<CubeManager>(); // 获取CubeManager组件
        Init();
    }
    public void Init()
    {
        // 清除旧的cubes
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();
        usedNames.Clear();

        // 创建10个新的cube
        for (int i = 0; i < 10; i++)
        {
            GameObject cube = Instantiate(cubePrefab, cubeContainer);
            Cube cubeComponent = cube.GetComponent<Cube>();

            int randomName = GetUniqueRandomName(); // 获取唯一的随机名称
            cubeComponent.SetNum(Random.Range(1, 20)); // 设置随机的num
            cubeComponent.SetName(randomName);

            cubes.Add(cube);
        }
    }

    //确保cube名字不要重复
    private int GetUniqueRandomName()
    {
        int randomName = Random.Range(1, 100);
        while (usedNames.Contains(randomName))
        {
            randomName = Random.Range(1, 100);
        }
        usedNames.Add(randomName);
        return randomName;
    }
    public void StartMatching()
    { 
        matchText.text = "比赛进行中";

        // 清空之前的缓存
        validCubes.Clear();

        //if (cubes.Count < 2)
        //{
        //    matchText.text = "无法匹配";
        //    return;
        //}

        // 随机选择两个Cube对象
        int index1 = Random.Range(0, cubes.Count);
        int index2 = Random.Range(0, cubes.Count);

        // 确保index1和index2不相等
        while (index1 == index2)
        {
            index2 = Random.Range(0, cubes.Count);
        }

        GameObject cubeObject1 = cubes[index1];
        GameObject cubeObject2 = cubes[index2];

        // 获取Cube组件
        Cube cube1 = cubeObject1.GetComponent<Cube>();
        Cube cube2 = cubeObject2.GetComponent<Cube>();

        int numDiff = Mathf.Abs(cube1.GetNum() - cube2.GetNum());

        if (numDiff <= 10)
        {
            // 进行PVP比赛，这里只是一个随机的结果
            bool cube1Wins = Random.value < 0.5f;

            if (cube1Wins)
            {
                cube1.UpdateNum(cube1.GetNum() + 5);
                cube2.UpdateNum(cube2.GetNum() - 5);

                // 更新胜利信息文本
                resultText.text = cube1.GetName().ToString() + " 胜利";
            }
            else
            {
                cube1.UpdateNum(cube1.GetNum() - 5);
                cube2.UpdateNum(cube2.GetNum() + 5);

                // 更新胜利信息文本
                resultText.text = cube2.GetName().ToString() + " 胜利";
            }
        }
        else
        {
            matchText.text = "无法匹配";
            resultText.text = "分数差距较大，请再次匹配";
        }
    }
}