using UnityEngine;
using System.Collections;

public class WallGlitch : BugPhysics
{
	[SerializeField] float flashSpeed = 2f;
	[SerializeField] float flashDuration = 2f;
	private Collider2D collider;
	private Color baseColor;
	protected override void Awake ()
	{
		base.Awake ();
		collider = GetComponent<Collider2D>();
	}

	protected override void Start ()
	{
		base.Start ();
		baseColor = renderer.color;
		SetActive(false);
	}

	protected void SetActive(bool active)
	{
		collider.isTrigger = !active;
	}

	protected override void Update ()
	{
		base.Update ();
		Color color = renderer.color;
		color.a = Flash(color.a,Random.Range(0f,flashDuration),flashSpeed);
		renderer.color = color;
	}

	protected override void Reset ()
	{
		renderer.color = baseColor;
		SetActive(true);
		base.Reset ();
	}
}
