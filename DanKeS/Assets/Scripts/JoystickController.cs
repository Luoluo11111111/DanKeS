using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour,IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform joystickBackground;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float maxOffset = 50f; // ҡ�����ƫ����

    private Vector2 inputVector; // ��׼�����뷽��-1��1��

    public void OnDrag(PointerEventData eventData)
    {
        // ��ȡҡ�����λ��
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
        {
            // ����ҡ���ƶ���Χ
            localPoint = Vector2.ClampMagnitude(localPoint, maxOffset);
            handle.anchoredPosition = localPoint;

            // �����׼������
            inputVector = localPoint / maxOffset;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero; // �ɿ�ʱҡ�˸�λ
        inputVector = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData) { }

    // �������ű���ȡ���뷽��
    public Vector2 GetInputDirection() => inputVector;
}
