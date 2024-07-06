using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class PoolManager : MonoBehaviour
{
    private Dictionary<string, ObjectPooler> poolDic = new Dictionary<string, ObjectPooler>();

	// 1. 오브젝트 풀 생성

    public void CreatePool(PooledObject prefab, int size)
	{
        GameObject poolGameObject = new GameObject($"Pool_{prefab.gameObject.name}");
        ObjectPooler objectPooler = poolGameObject.AddComponent<ObjectPooler>();
        objectPooler.CreatePool(prefab, size);

        poolDic.Add(prefab.gameObject.name, objectPooler);
    }

    // 2. 오브젝트 풀 제거

    public void RemovePool(PooledObject prefab)
    {
        ObjectPooler objectPooler = poolDic[prefab.gameObject.name];
        Destroy(objectPooler);

        poolDic.Remove(prefab.gameObject.name);
    }


    // 3. 오브젝트 풀에서 인스턴스 가져오기

    public PooledObject GetPool(PooledObject prefab, Vector3 position, Quaternion rotation)
    {
        return poolDic[prefab.gameObject.name].GetPool(position, rotation);
    }
}
