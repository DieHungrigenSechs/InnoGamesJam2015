using UnityEngine;
using System.Collections;

public class Door : BasicBehavior
{
	private enum Action { Open, Close }
	
	[SerializeField] private Action action;
	[SerializeField] GameObject open;
	[SerializeField] GameObject close;
	private Collider2D collider;

	protected override void Awake ()
	{
		base.Awake ();
		collider = GetComponent<Collider2D>();
	}
	protected override void Start ()
	{
		base.Start ();
		DoorAction(action);
	}

	protected override void OnCollisionEnter2D (Collision2D other)
	{
		if(other.transform.GetComponent<CharacterInput>())
		{
			base.OnCollisionEnter2D (other);
			DoorAction(Action.Open);
		}
	}

	protected override void OnTriggerExit2D (Collider2D other)
	{
		if(other.transform.GetComponent<CharacterInput>())
		{
			base.OnTriggerExit2D (other);
			DoorAction(Action.Close);
		}
	}

	private void DoorAction(Action action)
	{
		open.SetActive(action == Action.Open);
		collider.isTrigger = action == Action.Open;
		close.SetActive(action == Action.Close);

	}

}
