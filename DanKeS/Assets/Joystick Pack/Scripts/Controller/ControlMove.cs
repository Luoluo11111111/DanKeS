using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : MonoBehaviour
{
    private VariableJoystick variableJoystick;  //摇杆

    public float moveSpeed = 5;         //移动速度
    public Transform GameObj;         //角色
    public Transform Cameraed;          //相机

    // 摄像机与目标物体的偏移量
    public Vector3 offsetes = new Vector3(0, 2, -10);

    //public Rigidbody rb;//刚体

    private void Start()
    {
        //rb = transform.GetComponent<Rigidbody>();
        variableJoystick = transform.GetComponent<VariableJoystick>();
    }

    private void FixedUpdate()
    {
        //根据摇杆方向设置目标移动的方向
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

        //可以给刚体添加一个力使其向该方向移动
        //rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //或者直接控制目标位置信息来移动目标
        GameObj.position += direction * moveSpeed * Time.fixedDeltaTime;
    }

    void LateUpdate()
    {
        if (GameObj != null)
        {
            // 设置摄像机的位置为目标物体的位置加上偏移量
            Cameraed.position = GameObj.position + offsetes;
        }
    }
}

