using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuaiWu : MonoBehaviour
{
    private Slider playHp;  //����Ѫ��
    public Transform GuaiTran;  //����λ��
    public GameObject experiencePrefab; //����

    public static GuaiWu instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playHp = Player.Instance.Hpslider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Player.Instance.transform.position, transform.position )> 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.Instance.transform.position, 0.1f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "RenWu")
        {
            Player.Instance.hp -= 2f;
            playHp.value = Player.Instance.hp / 100;
            
        }
        if(other.tag == "att")
        {
            Vector2 spawnPosition = new Vector2(
              transform.position.x,
              transform.position.y
            );
            // �ڵ�ǰλ��ʵ��������Ԥ���壬ʹ��Ĭ�ϵ���ת�Ƕ�
            Instantiate(experiencePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
