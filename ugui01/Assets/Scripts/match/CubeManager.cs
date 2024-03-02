using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private List<Cube> cubes = new List<Cube>();

    public void Sort()
    {
        StartCoroutine(OnStartCoroutine());
    }

    public IEnumerator OnStartCoroutine()
    {
        // �ȴ�1��
        yield return new WaitForSeconds(1f);

        // ��ȡ���е� Cube ����
        cubes = FindObjectsOfType<Cube>().ToList();
        Debug.Log("��ȡ�� cube ��");

        // ���� Cube ����
        ArrangeCubesByNum();
    }

    public void UpdateCubeOrder()
    {
        // ���� Cube ����� num ֵ
        // ���� Cube ����
        ArrangeCubesByNum();
    }

    public void ArrangeCubesByNum()
    {
        // ���� num ֵ���н�������
        cubes = cubes.OrderByDescending(cube => cube.GetNum()).ToList();

        // �������� Cube �����λ��
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.SetSiblingIndex(i); // ʹ�� SetSiblingIndex ������������ Cube �����˳��
        }
    }
}