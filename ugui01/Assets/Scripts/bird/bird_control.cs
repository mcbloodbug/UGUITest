using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_control : MonoBehaviour
{
    //����
    private Rigidbody2D rd;
    //���ϵ���
    public float Force = 2.0f;
    //����С�����ת���Ƕ�
    public float MaxAngle = 40.0f;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�����Ļ���ϵ���
        if(Input.GetMouseButton(0))
        {
            rd.velocity = new Vector2(0, Force);
        }
        //��ȡ����ǰ�Ƕ�
        Vector3 angle = transform.eulerAngles;

        //����С��z��
        angle.z += rd.velocity.y;

        //������������С���ŷ���ǶȲ���һ��
        angle.z -= 180;
        if(angle.z >0)
        {
            angle.z -= 180; 
        }
        else
        {
            angle.z += 180;
        }
         

        //����С����ת�Ƕ�
        angle.z =Mathf.Clamp(angle.z, -MaxAngle, MaxAngle);

        //����ŷ���ǵ��޸�
        transform.eulerAngles = angle;


    }
}
