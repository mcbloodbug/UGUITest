using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchmakingSystem : MonoBehaviour
{
    public GameObject cubePrefab; // Ԥ���壬�������� Cube
    public Transform cubeContainer;
    public Text matchText; // ������ʾƥ����Ϣ���ı����
    public Text resultText; // ������ʾʤ����Ϣ���ı����

    private List<GameObject> cubes = new List<GameObject>();
    private List<int> usedNames = new List<int>(); // ���ڴ洢��ʹ�õ�����

    private CubeManager cubeManager;
    List<Cube> validCubes = new List<Cube>();

    void Start()
    {
        cubeManager = GetComponent<CubeManager>(); // ��ȡCubeManager���
        Init();
    }
    public void Init()
    {
        // ����ɵ�cubes
        foreach (GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes.Clear();
        usedNames.Clear();

        // ����10���µ�cube
        for (int i = 0; i < 10; i++)
        {
            GameObject cube = Instantiate(cubePrefab, cubeContainer);
            Cube cubeComponent = cube.GetComponent<Cube>();

            int randomName = GetUniqueRandomName(); // ��ȡΨһ���������
            cubeComponent.SetNum(Random.Range(1, 20)); // ���������num
            cubeComponent.SetName(randomName);

            cubes.Add(cube);
        }
    }

    //ȷ��cube���ֲ�Ҫ�ظ�
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
        matchText.text = "����������";

        // ���֮ǰ�Ļ���
        validCubes.Clear();

        //if (cubes.Count < 2)
        //{
        //    matchText.text = "�޷�ƥ��";
        //    return;
        //}

        // ���ѡ������Cube����
        int index1 = Random.Range(0, cubes.Count);
        int index2 = Random.Range(0, cubes.Count);

        // ȷ��index1��index2�����
        while (index1 == index2)
        {
            index2 = Random.Range(0, cubes.Count);
        }

        GameObject cubeObject1 = cubes[index1];
        GameObject cubeObject2 = cubes[index2];

        // ��ȡCube���
        Cube cube1 = cubeObject1.GetComponent<Cube>();
        Cube cube2 = cubeObject2.GetComponent<Cube>();

        int numDiff = Mathf.Abs(cube1.GetNum() - cube2.GetNum());

        if (numDiff <= 10)
        {
            // ����PVP����������ֻ��һ������Ľ��
            bool cube1Wins = Random.value < 0.5f;

            if (cube1Wins)
            {
                cube1.UpdateNum(cube1.GetNum() + 5);
                cube2.UpdateNum(cube2.GetNum() - 5);

                // ����ʤ����Ϣ�ı�
                resultText.text = cube1.GetName().ToString() + " ʤ��";
            }
            else
            {
                cube1.UpdateNum(cube1.GetNum() - 5);
                cube2.UpdateNum(cube2.GetNum() + 5);

                // ����ʤ����Ϣ�ı�
                resultText.text = cube2.GetName().ToString() + " ʤ��";
            }
        }
        else
        {
            matchText.text = "�޷�ƥ��";
            resultText.text = "�������ϴ����ٴ�ƥ��";
        }
    }
}