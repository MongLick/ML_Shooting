using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPooler pooler;
	[SerializeField] bool autoRelease;
	[SerializeField] float releaseTime;
	Coroutine releaseRoutine;

	public void OnEnable()
	{
		if(autoRelease)
		{
			releaseRoutine = StartCoroutine(ReleaseRoutine());
		}
	}

	public void OnDisable()
	{
		StopCoroutine(releaseRoutine);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			Release();
		}
	}

	IEnumerator ReleaseRoutine()
	{
		yield return new WaitForSeconds(releaseTime);
		Release();
	}

	public void Release()
    {
		if(pooler != null)
		{
			pooler.ReturnPool(this);
		}
		else
		{
			Destroy(gameObject);
		}
    }
}
