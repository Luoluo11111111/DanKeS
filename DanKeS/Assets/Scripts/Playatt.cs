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
        num -= Time.deltaTime;
        Player.Instance.attslider.value -= Time.deltaTime / 3;
        if (num < 0)
        {
            Player.Instance.attslider.value = 1;
            num = 3;
            Instantiate(att, Generatelocation);
        }
    }
}
