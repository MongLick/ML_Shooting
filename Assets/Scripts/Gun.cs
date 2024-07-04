using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] Transform muzzlePoint;
	[SerializeField] float maxDistance;
	[SerializeField] int damage;
	[SerializeField] LayerMask layerMask;
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] ParticleSystem hitEffect;

	public void Fire()
	{
		muzzleFlash.Play();

		if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit hitInfo, maxDistance, layerMask))
		{
			Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * hitInfo.distance, Color.red, 0.1f); ;
			IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
			if (damageable != null)
			{
				damageable.TakeDamage(damage);
			}

			ParticleSystem effect = Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			effect.transform.parent = hitInfo.transform;

			Rigidbody rigid = hitInfo.collider.GetComponent<Rigidbody>();
			if(rigid != null)
			{
				rigid.AddForceAtPosition(-hitInfo.normal * 10f, hitInfo.point, ForceMode.Impulse);
			}
		}
		else
		{
			Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * maxDistance, Color.red, 0.1f); ;
		}
	}
}
