using UnityEngine;

public class bg_control : MonoBehaviour
{
    //�����ƶ����ٶ�
    public float speed = 0.2f;
    //����ͼƬ�Ŀ��
    public float width = 2.88f;
    //�Ƿ����ùܵ��ĸ߶�
    public bool IsResetH =false;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        //��������
        foreach (Transform trans in transform)
        {
            //�ƶ�����
            Vector3 v = trans.position;
            v.x -= Time.deltaTime * speed;

            //����һ�ű���ͼƬ�ƶ��������ʱ���л���λ��
            if(v.x < -width)
            {
                v.x += width * 2;

                //���ùܵ�������߶�
                if(IsResetH)
                {
                    pipe_control pipe =trans.GetComponentInChildren<pipe_control>();
                    pipe.ResetHeight();
                }

            }
             
            //���±���ͼƬλ�õ��޶�
            trans.position = v;
        }
    }
}
