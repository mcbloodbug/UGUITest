using UnityEngine;

public class bg_control : MonoBehaviour
{
    //背景移动的速度
    public float speed = 0.2f;
    //背景图片的宽度
    public float width = 2.88f;
    //是否重置管道的高度
    public bool IsResetH =false;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        //遍历背景
        foreach (Transform trans in transform)
        {
            //移动背景
            Vector3 v = trans.position;
            v.x -= Time.deltaTime * speed;

            //当第一张背景图片移动到最左边时，切换新位置
            if(v.x < -width)
            {
                v.x += width * 2;

                //重置管道父物体高度
                if(IsResetH)
                {
                    pipe_control pipe =trans.GetComponentInChildren<pipe_control>();
                    pipe.ResetHeight();
                }

            }
             
            //更新背景图片位置的修动
            trans.position = v;
        }
    }
}
