using UnityEngine;
using System.Collections;

public class BounceBug : BugPhysics
{
	[SerializeField] float bounciness = 1f;
	Collider2D collider;
	PhysicsMaterial2D tempMaterial;
	Rigidbody2D rigidbody;
	protected override void Awake ()
	{
		base.Awake ();
		collider = GetComponent<Collider2D>();
		rigidbody = GetComponent<Rigidbody2D>();
	}

	protected override void Start ()
	{
		base.Start ();
		tempMaterial = collider.sharedMaterial;
		AddBounce(bounciness,0);
	}

	private void AddBounce(float bounce,float friction)
	{
		PhysicsMaterial2D material = new PhysicsMaterial2D("Bounce");
		material.bounciness = bounce;
		material.friction = friction;
		collider.sharedMaterial = material;
	}

	protected override void Reset ()
	{
		base.Reset ();
		collider.sharedMaterial = tempMaterial;
	}

}
