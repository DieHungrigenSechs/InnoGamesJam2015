using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour 
{
	[SerializeField] protected float damage = 1f;
	protected virtual void Awake() 
	{

	}
	protected virtual void OnCollisionEnter2D(Collision2D collision) 
	{
		PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
		if(health)
		{
			health.SetEnergy(-damage);
		}
		Destroy(gameObject);
	}
}
