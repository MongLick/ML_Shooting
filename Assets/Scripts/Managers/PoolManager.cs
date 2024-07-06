using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, ObjectPooler> poolDic = new Dictionary<string, ObjectPooler>();

	// 1. ������Ʈ Ǯ ����

    public void CreatePool(PooledObject prefab, int size)
	{
        GameObject poolGameObject = new GameObject($"Pool_{prefab.gameObject.name}");
        ObjectPooler objectPooler = poolGameObject.AddComponent<ObjectPooler>();
        objectPooler.CreatePool(prefab, size);

        poolDic.Add(prefab.gameObject.name, objectPooler);
    }

    // 2. ������Ʈ Ǯ ����

    public void RemovePool(PooledObject prefab)
    {
        ObjectPooler objectPooler = poolDic[prefab.gameObject.name];
        Destroy(objectPooler);

        poolDic.Remove(prefab.gameObject.name);
    }


    // 3. ������Ʈ Ǯ���� �ν��Ͻ� ��������

    public PooledObject GetPool(PooledObject prefab, Vector3 position, Quaternion rotation)
    {
        return poolDic[prefab.gameObject.name].GetPool(position, rotation);
    }
}
