using UnityEngine;
using System.Collections;

public class FlyMode : BugPhysics 
{
	private Rigidbody2D rigidbody;
	private CharacterMotor characterMotor;
	[SerializeField] float speed = 500f;
	float tempGravity;

	protected override void Awake ()
	{
		base.Awake ();
		rigidbody = GetComponent<Rigidbody2D>(); 
		characterMotor = GetComponent<CharacterMotor>();

	}

	protected override void Start ()
	{
		bugTime = Random.Range(3,20);
		base.Start ();
		
		tempGravity = rigidbody.gravityScale;
		SetGravity(0);
	}

	private void SetGravity(float value)
	{
		rigidbody.gravityScale = value;
	}

	protected void FixedUpdate ()
	{
		float speed = this.speed * Time.deltaTime;
		Vector2 direction = Vector2.up * Input.GetAxis("Vertical");
		rigidbody.AddForce(direction * speed);
	}

	protected override void Reset ()
	{
		base.Reset ();
		SetGravity(tempGravity);
	}
}
