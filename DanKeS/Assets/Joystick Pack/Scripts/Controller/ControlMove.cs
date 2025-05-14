using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMove : MonoBehaviour
{
    private VariableJoystick variableJoystick;  //ҡ��

    public float moveSpeed = 5;         //�ƶ��ٶ�
    public Transform GameObj;         //��ɫ
    public Transform Cameraed;          //���

    // �������Ŀ�������ƫ����
    public Vector3 offsetes = new Vector3(0, 2, -10);

    //public Rigidbody rb;//����

    private void Start()
    {
        //rb = transform.GetComponent<Rigidbody>();
        variableJoystick = transform.GetComponent<VariableJoystick>();
    }

    private void FixedUpdate()
    {
        //����ҡ�˷�������Ŀ���ƶ��ķ���
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

        //���Ը��������һ����ʹ����÷����ƶ�
        //rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //����ֱ�ӿ���Ŀ��λ����Ϣ���ƶ�Ŀ��
        GameObj.position += direction * moveSpeed * Time.fixedDeltaTime;
    }

    void LateUpdate()
    {
        if (GameObj != null)
        {
            // �����������λ��ΪĿ�������λ�ü���ƫ����
            Cameraed.position = GameObj.position + offsetes;
        }
    }
}

