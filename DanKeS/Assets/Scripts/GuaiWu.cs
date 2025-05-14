using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuaiWu : MonoBehaviour
{
    public Transform transforms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transforms.position, transform.position )> 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, transforms.position, 0.1f);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RenWu")
        {
            Destroy(gameObject);
        }
    }
}
