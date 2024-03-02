using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_control : MonoBehaviour
{
    //刚体
    private Rigidbody2D rd;
    //向上的力
    public float Force = 2.0f;
    //限制小鸟的旋转最大角度
    public float MaxAngle = 40.0f;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //点击屏幕向上的力
        if(Input.GetMouseButton(0))
        {
            rd.velocity = new Vector2(0, Force);
        }
        //获取到当前角度
        Vector3 angle = transform.eulerAngles;

        //控制小鸟z轴
        angle.z += rd.velocity.y;

        //调整面板参数与小鸟的欧拉角度参数一致
        angle.z -= 180;
        if(angle.z >0)
        {
            angle.z -= 180; 
        }
        else
        {
            angle.z += 180;
        }
         

        //限制小鸟旋转角度
        angle.z =Mathf.Clamp(angle.z, -MaxAngle, MaxAngle);

        //更新欧拉角的修改
        transform.eulerAngles = angle;


    }
}
