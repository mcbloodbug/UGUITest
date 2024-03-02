using UnityEngine;
using UnityEngine.SceneManagement;

public class pipe_control : MonoBehaviour
{
    public bool IsCollision = false;
    //是否执行碰撞检测，用于区分碰撞体与触发器 
    void OnCollisionEnter2D(Collision2D collision)
    {
        //对于上下管道实行游戏结束的效果
        if (IsCollision)
        {
            Debug.Log("游戏结束");
            Invoke("ReStart", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 
            //得分+1
            Debug.Log("得分+1");
            GameManager1.score++;
        }
    }

    //游戏结束的方法
    public void ReStart()
    {
        //得分重置
        GameManager1.score = 0;
        //游戏重新开始
        SceneManager.LoadScene("FlyBird");
         
    }

    //重置管道位置
    public void ResetHeight()
    {
        //只针对管道的父物体
        if (!IsCollision)
        {
            Vector2 v = transform.localPosition;
            v.y = Random.Range(1.5f, 3.5f);
            transform.localPosition = v;
        }
    }
}
