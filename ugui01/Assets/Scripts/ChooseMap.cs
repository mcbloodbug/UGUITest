using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMap : MonoBehaviour
{

    public void SwitchToScene1()
    {
        SceneManager.LoadScene("Map01");
    }
    public void SwitchToScene2()
    {
        SceneManager.LoadScene("Map02");
    }

    public void SwitchToScene3()
    {
        SceneManager.LoadScene("Map03");
    }
    public void SwitchToScene4()
    {
        SceneManager.LoadScene("Map04");
    }
} 
