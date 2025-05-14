using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float maxOffset = 50f; // 摇杆最大偏移量

    private Vector2 inputVector; // 标准化输入方向（-1到1）

    public void OnDrag(PointerEventData eventData)
    {
        // 获取摇杆相对位置
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
        {
            // 限制摇杆移动范围
            localPoint = Vector2.ClampMagnitude(localPoint, maxOffset);
            handle.anchoredPosition = localPoint;

            // 计算标准化输入
            inputVector = localPoint / maxOffset;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero; // 松开时摇杆复位
        inputVector = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData) { }

    // 供其他脚本获取输入方向
    public Vector2 GetInputDirection() => inputVector;
}
