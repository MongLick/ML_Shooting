using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
	public PooledObject hitEffectPrefab;

	private void Start()
	{
		hitEffectPrefab = Resources.Load<PooledObject>("HitEffect");
		Manager.Pool.CreatePool(hitEffectPrefab, 20);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 pos = Random.insideUnitSphere;
			Quaternion rot = Random.rotation;
			Manager.Pool.GetPool(hitEffectPrefab, pos, rot);
		}
	}
}
