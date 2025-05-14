using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("移动参数")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private JoystickController joystick;

    private Rigidbody2D rb;


    void Start() => rb = GetComponent<Rigidbody2D>();

    void FixedUpdate()
    {
        Vector2 inputDirection = joystick.GetInputDirection();

        // 根据摇杆输入移动
        rb.velocity = inputDirection * moveSpeed;

        /* 可选：方向旋转（如果需要角色朝向移动方向）
        if(inputDirection != Vector2.zero)
            transform.right = inputDirection;
        */

    }
}
