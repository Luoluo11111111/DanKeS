using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hp = 100;     //����Ѫ��
    public Slider Hpslider; //����Ѫ��
    public Slider attslider; //���﹥����
    public Transform transforms; //����λ��

    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        hp = 100;
    }
}
