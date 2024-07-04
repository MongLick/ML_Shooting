using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] float hp;
	[SerializeField] Rigidbody rigid;

    public void TakeDamage(int damage)
	{
		hp -= damage;
		rigid.AddForce(Vector3.up * 3f, ForceMode.Impulse);
		if(hp <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
