using UnityEngine;
using System.Collections;

public class BugPhysics : MonoBehaviour 
{
	[SerializeField] protected float bugTime = 10f;
	protected SpriteRenderer renderer;

	protected virtual void Awake()
	{
		renderer = 	GetComponent<SpriteRenderer>();
	}

	protected virtual void Start()
	{
		StartCoroutine(TimeToDestroy(bugTime));
	}

	protected virtual void Update()
	{
		
	}

	protected float Flash(float value,float speed,float max)
	{
		if(speed != 0)
		{
			speed = Time.time * speed  * 2 * Mathf.PI;
			speed = Mathf.Cos( speed ) * max;
			value = speed;
		}
		return value;	
	}

	protected virtual void Reset()
	{
		Destroy(this);
	}

	private IEnumerator TimeToDestroy(float duration)
	{
		if(duration >= 0)
		{
			yield return new WaitForSeconds(duration);
			Reset();
		}
	}
}
