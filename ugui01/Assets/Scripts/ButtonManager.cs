using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject capsule;
    public Material material1;
    public Material material2;
    public Material material3;

    public void ChangeToMaterial1()
    {
        Renderer capsuleRenderer = capsule.GetComponent<Renderer>();
        capsuleRenderer.material = material1;
    }

    public void ChangeToMaterial2()
    {
        Renderer capsuleRenderer = capsule.GetComponent<Renderer>();
        capsuleRenderer.material = material2;
    }

    public void ChangeToMaterial3()
    {
        Renderer capsuleRenderer = capsule.GetComponent<Renderer>();
        capsuleRenderer.material = material3;
    }
}