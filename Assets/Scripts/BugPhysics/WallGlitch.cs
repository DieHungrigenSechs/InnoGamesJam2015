using UnityEngine;
using System.Collections;

public class WallGlitch : BugPhysics
{
	private Collider collider;
	protected override void Awake ()
	{
		base.Awake ();
		collider = GetComponent<Collider>();
	}

	protected override void Start ()
	{
		base.Start ();
		SetActive(false);
	}

	protected void SetActive(bool active)
	{
		collider.isTrigger = active;
	}

	protected override void Update ()
	{
		base.Update ();
		Color color = renderer.color;
		color.a = Flash(color.a,1f,1f);
		renderer.color = color;
	}

	private float Flash(float value,float speed,float max)
	{
		if(speed != 0)
		{
			speed = Time.time * speed  * 2 * Mathf.PI;
			speed = Mathf.Cos( speed ) * max;
			value = speed;
		}
		return value;	
	}
}
