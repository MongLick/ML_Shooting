using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] PooledObject prefab;
    [SerializeField] int poolSize;

    private Stack<PooledObject> objectPool;

	public void CreatePool(PooledObject prefab, int size)
	{
        objectPool = new Stack<PooledObject>(poolSize);
        for(int i = 0; i < poolSize; i++)
        {
            PooledObject instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            instance.pooler = this;
            instance.transform.parent = transform;
            objectPool.Push(instance);
        }
    }

    public PooledObject GetPool(Vector3 position, Quaternion rotation)
	{
        if (objectPool.Count > 0)
        {
			PooledObject instance = objectPool.Pop();
			instance.gameObject.SetActive(true);
            instance.transform.parent = null;
			return instance;
		}
        else
        {
            PooledObject instance = Instantiate(prefab);
            instance.pooler = this;
            return instance;
        }
    }

    public void ReturnPool(PooledObject instance)
    {
        if(objectPool.Count < poolSize)
        {
			instance.gameObject.SetActive(false);
			objectPool.Push(instance);
		}
        else
        {
            Destroy(instance.gameObject);
        }
    }
}
