using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
	[SerializeField] ObjectPooler pooler;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			PooledObject instance = pooler.GetPool();
			instance.transform.position = Random.insideUnitSphere * 10f;
		}
	}
}
