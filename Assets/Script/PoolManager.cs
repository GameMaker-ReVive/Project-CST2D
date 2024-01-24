using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;
    // ������
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ��
    List<GameObject>[] pools;

    void Awake()
    {
        instance = this;

        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        int ran;
        GameObject select = null;

        // ������ Ǯ�� ��� (��Ȱ��ȭ ��) �ִ� ���� ������Ʈ ����
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                // �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ��� ������Ʈ ��� ���� �� (�� ã���� ��) ������Ʈ�� ���� �����ؼ� select ������ �Ҵ�
        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);
            // transform -> ������Ʈ ������ġ (= �θ� ������Ʈ -> �ڱ��ڽ�(PoolManager))

            // ������ ������Ʈ�� �ش� ������Ʈ Ǯ ����Ʈ�� �߰�
            pools[index].Add(select);
        }

        // ���� ����Ʈ
        switch(index)
        {
            case 0:
                select.transform.position = GameManager.instance.unitSpawnPoint[0].position;
                break;
            case 1:
                ran = Random.Range(1, 4);
                select.transform.position = GameManager.instance.unitSpawnPoint[ran].position;
                break;
        }

        return select;
    }
}
