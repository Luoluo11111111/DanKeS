 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class att : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GuaiWu.instance.GuaiTran.transform.position, 1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GuaiWu")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
