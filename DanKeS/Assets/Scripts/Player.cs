using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hp = 100;     //人物血量
    public Slider Hpslider; //人物血条
    public Slider attslider; //人物攻击条
    public Transform transform; //人物位置

    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        hp = 100;
    }
    public void Update()
    {
        
        if (Vector2.Distance(transform.position, GuaiWu.instance.GuaiTran.transform.position) < 3)
        {
            transform.LookAt(GuaiWu.instance.GuaiTran.transform.position);
        }
    }
}
