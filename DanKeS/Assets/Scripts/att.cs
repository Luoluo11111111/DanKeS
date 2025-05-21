 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class att : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject targetObj = GameObject.Find("GuaiWu(Clone)");   //获取场景中的对象

        if (targetObj != null)  //如果对象存在
        {
            transform.position = Vector2.MoveTowards(transform.position, targetObj.transform.position, 1f);
        }
        else
        {
            Debug.Log("物体不存在");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GuaiWu")
        {
            Destroy(gameObject);
        
            ObjGuaiWu.Instance.ReturnMonster(other.gameObject); //调用返回怪物的方法
        }
    }
}
