using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjGuaiWu : MonoBehaviour
{
    public Transform guaiwuPos;

    public static ObjGuaiWu Instance;

    [Header("怪物生成配置")]
    public GameObject monsterPrefab;   // 怪物预制体
    public int initialPoolSize = 10;   // 初始池容量
    public float spawnInterval = 2f;   // 生成间隔
    public Vector2 spawnArea = new Vector2(10f, 5f); // 生成区域范围
    public int maxActiveMonsters = 20; // 最大活跃怪物数量

    private Queue<GameObject> monsterPool = new Queue<GameObject>();
    GameObject monster;
    //public List<GameObject> monsterList = new List<GameObject>(); // 存储所有怪物的列表
    private void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void Start()
    {
        // 启动自动生成协程
        StartCoroutine(AutoSpawnMonsters());
    }

    // 初始化对象池
    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            monster = Instantiate(monsterPrefab, guaiwuPos);
            monster.SetActive(false);
            monsterPool.Enqueue(monster);
            //monsterList.Add(monster);
        }
    }

    // 从池中获取怪物
    public GameObject GetMonster()
    {
        if (monsterPool.Count == 0)
        {
            // 动态扩容
            ExpandPool(5);
        }

        GameObject monster = monsterPool.Dequeue();
        monster.SetActive(true);
        return monster;
    }

    // 回收怪物到池中
    public void ReturnMonster(GameObject monster)
    {
        monster.SetActive(false);
        monsterPool.Enqueue(monster);
   
    }

    // 动态扩容对象池
    private void ExpandPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject monster = Instantiate(monsterPrefab,guaiwuPos);
            monster.SetActive(false);
            monsterPool.Enqueue(monster);
        }
    }

    // 自动生成怪物协程
    private System.Collections.IEnumerator AutoSpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (GetActiveMonsterCount() < maxActiveMonsters)
            {
                SpawnMonster();
            }
        }
    }

    // 获取当前活跃的怪物数量
    private int GetActiveMonsterCount()
    {
        int count = 0;
        foreach (var monster in monsterPool)
        {
            if (monster.activeInHierarchy) count++;
        }
        return count;
    }

    // 生成单个怪物
    private void SpawnMonster()
    {
        GameObject monster = GetMonster();
        // 随机生成位置（根据需求调整逻辑）
        Vector2 spawnPos = new Vector2(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y)
        );
        monster.transform.position = spawnPos;
    }
}
