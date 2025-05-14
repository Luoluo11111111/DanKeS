using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("�ƶ�����")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private JoystickController joystick;

    private Rigidbody2D rb;


    void Start() => rb = GetComponent<Rigidbody2D>();

    void FixedUpdate()
    {
        Vector2 inputDirection = joystick.GetInputDirection();

        // ����ҡ�������ƶ�
        rb.velocity = inputDirection * moveSpeed;

        /* ��ѡ��������ת�������Ҫ��ɫ�����ƶ�����
        if(inputDirection != Vector2.zero)
            transform.right = inputDirection;
        */

    }
}
