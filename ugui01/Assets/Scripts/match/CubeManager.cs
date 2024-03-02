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
        // 等待1秒
        yield return new WaitForSeconds(1f);

        // 获取所有的 Cube 对象
        cubes = FindObjectsOfType<Cube>().ToList();
        Debug.Log("获取到 cube 了");

        // 排列 Cube 对象
        ArrangeCubesByNum();
    }

    public void UpdateCubeOrder()
    {
        // 更新 Cube 对象的 num 值
        // 排列 Cube 对象
        ArrangeCubesByNum();
    }

    public void ArrangeCubesByNum()
    {
        // 根据 num 值进行降序排列
        cubes = cubes.OrderByDescending(cube => cube.GetNum()).ToList();

        // 重新排列 Cube 对象的位置
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].transform.SetSiblingIndex(i); // 使用 SetSiblingIndex 方法重新排列 Cube 对象的顺序
        }
    }
}