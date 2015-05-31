using UnityEngine;

public class Projectiles : MonoBehaviour 
{
	[SerializeField] protected float damage = 1f;
	protected virtual void Awake() 
	{

	}

    void Start()
    {
        Destroy(gameObject, 20);
    }

	protected virtual void OnCollisionEnter2D(Collision2D collision) 
	{
		PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
		if(health)
		{
			Debug.Log(damage);
			health.SetEnergy(-damage);
		}
		Destroy(gameObject);
	}
}
