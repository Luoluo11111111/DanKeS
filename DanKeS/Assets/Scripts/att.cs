 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class att : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject targetObj = GameObject.Find("GuaiWu(Clone)");   //��ȡ�����еĶ���

        if (targetObj != null)  //����������
        {
            transform.position = Vector2.MoveTowards(transform.position, targetObj.transform.position, 1f);
        }
        else
        {
            Debug.Log("���岻����");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GuaiWu")
        {
            Destroy(gameObject);
        
            ObjGuaiWu.Instance.ReturnMonster(other.gameObject); //���÷��ع���ķ���
        }
    }
}
