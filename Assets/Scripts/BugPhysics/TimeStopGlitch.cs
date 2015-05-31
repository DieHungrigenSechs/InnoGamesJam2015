using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(Collider2D))]
public class TimeStopGlitch : BugPhysics
{
	[SerializeField] SpriteRenderer renderer;
	[SerializeField]
	float offTime = 2f;
	[SerializeField]
	float onTime = 2f;
	Dictionary<GameObject, Vector2> rigidbodies;
	int value = 0;
	Collider2D collider;

	protected override void Awake ()
	{
		base.Awake ();
		collider = GetComponent<Collider2D>();

		collider.isTrigger = true;
	}
	protected override void Start ()
	{
		base.Start ();
		rigidbodies = new Dictionary<GameObject, Vector2>();
		StartCoroutine(AutomaticTimeChanger(onTime));
	}

	protected override void Reset ()
	{
		base.Reset ();
		RemoveAll();
	}

	IEnumerator AutomaticTimeChanger(float duration)
	{
		
		yield return new WaitForSeconds(duration);
		if(collider.enabled)
		{
			if(renderer)
			{
				renderer.enabled = false;
			}
			collider.enabled = false;
			StartCoroutine(AutomaticTimeChanger(offTime));
			RemoveAll();

		}
		else
		{
			if(renderer)
			{
				renderer.enabled = true;
			}
			collider.enabled = true;
			StartCoroutine(AutomaticTimeChanger(onTime));
		}

	}

	protected virtual void OnTriggerEnter2D(Collider2D other) 
	{
		Add (other.GetComponent<Rigidbody2D>());
	}

	protected virtual void OnTriggerExit2D(Collider2D other) 
	{
		Remove (other.GetComponent<Rigidbody2D>());
	}


	private void Add (Rigidbody2D rigidbody)
	{
		if (rigidbody) 
		{
			if (!rigidbodies.ContainsKey (rigidbody.gameObject)) 
			{
				rigidbodies.Add (rigidbody.gameObject, rigidbody.velocity);
				rigidbody.velocity = Vector2.zero;
				rigidbody.isKinematic = true;
			}
		}
	}
	private void RemoveAll ()
	{
		foreach (KeyValuePair<GameObject, Vector2> pair in rigidbodies)
		{
			//Dirty way
			try
			{
				GameObject go = pair.Key;
				Rigidbody2D body = go.GetComponent<Rigidbody2D>();
				body.isKinematic = false;
				body.velocity = pair.Value;
				rigidbodies = new Dictionary<GameObject, Vector2>();
			}
			catch
			{

			}
		}
	}

	private void SetKinematic(Rigidbody2D rigidbody,bool active)
	{
		rigidbody.isKinematic = active;
	}


	private void Remove (Rigidbody2D rigidbody)
	{
		if (rigidbody) 
		{
			if (rigidbodies.ContainsKey (rigidbody.gameObject)) 
			{
				Vector2 velocity = rigidbodies [rigidbody.gameObject];
				rigidbodies.Remove (rigidbody.gameObject);
				rigidbody.isKinematic = false;
				rigidbody.velocity = velocity;
			}
		}
	}

	protected virtual void OnDrawGizmos() 
	{
		CircleCollider2D circle = collider as CircleCollider2D;
		if(circle)
		{
			Gizmos.DrawWireSphere(transform.position,circle.radius);
		}
	}

    protected void Update() {
        if (renderer && renderer.enabled) {
            renderer.color = new Color(1f, 1f, 1f, Random.value);
        }
    }

}
