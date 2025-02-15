using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
	[SerializeField] float hp;

	private void Die()
	{
		Destroy(gameObject);
	}

	public void TakeDamage(int damage)
	{
		hp -= damage;
		if(hp <= 0)
		{
			Die();
		}
	}
}
