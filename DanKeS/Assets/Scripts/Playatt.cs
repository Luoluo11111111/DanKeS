using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playatt : MonoBehaviour
{
    private GameObject att; 
    float num = 3;
    public Transform Generatelocation;
    // Start is called before the first frame update
    void Start()
    {
        att = Resources.Load<GameObject>("att");
    }

    // Update is called once per frame
    void Update()
    {
        //Ѫ��
        num -= Time.deltaTime;
        Player.Instance.attslider.value -= Time.deltaTime / 3;

        GameObject targetObj = GameObject.Find("GuaiWu(Clone)");   //��ȡ�����еĶ���
        if (num < 0)
        {
            if (targetObj != null)  //����������
            {
                //for (int i = 0; i < ObjGuaiWu.Instance.monsterList.Count; i++)
                //{
                //    if (Vector3.Distance(transform.position, ObjGuaiWu.Instance.monsterList[i].transform.position) < 5f)
                //    {
                        
                //    }
                //}
                Debug.Log("����");
                Instantiate(att, Generatelocation); //��������
            }
            else
            {
                Debug.Log("���岻����");
            }
            Player.Instance.attslider.value = 1;
            num = 3;

        }
    }
}
