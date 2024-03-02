using UnityEngine;
using UnityEngine.SceneManagement;

public class pipe_control : MonoBehaviour
{
    public bool IsCollision = false;
    //�Ƿ�ִ����ײ��⣬����������ײ���봥���� 
    void OnCollisionEnter2D(Collision2D collision)
    {
        //�������¹ܵ�ʵ����Ϸ������Ч��
        if (IsCollision)
        {
            Debug.Log("��Ϸ����");
            Invoke("ReStart", 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") { 
            //�÷�+1
            Debug.Log("�÷�+1");
            GameManager1.score++;
        }
    }

    //��Ϸ�����ķ���
    public void ReStart()
    {
        //�÷�����
        GameManager1.score = 0;
        //��Ϸ���¿�ʼ
        SceneManager.LoadScene("FlyBird");
         
    }

    //���ùܵ�λ��
    public void ResetHeight()
    {
        //ֻ��Թܵ��ĸ�����
        if (!IsCollision)
        {
            Vector2 v = transform.localPosition;
            v.y = Random.Range(1.5f, 3.5f);
            transform.localPosition = v;
        }
    }
}
