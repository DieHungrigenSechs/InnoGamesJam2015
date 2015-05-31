using UnityEngine;
using System;
using System.Collections;
using XInputDotNetPure;

public class InputManager : MonoBehaviour
{
	public PlayerIndex PlayerIndex { get; set; }
	GamePadState state;
	GamePadState prevState;

	private void Start()
	{
		state = GamePad.GetState(PlayerIndex);
	}

	private void Update()
	{
		prevState = state;
		state = GamePad.GetState(PlayerIndex);
	}

	public bool AcceptDown
	{
		get
		{
			return prevState.Buttons.A == ButtonState.Released && Accept;
		}
	}

	public bool Accept
	{
		get
		{
			return state.Buttons.A == ButtonState.Pressed;
		}
	}

	public bool PlayDown
	{
		get
		{
			return prevState.Buttons.Start == ButtonState.Released && Play;
		}
	}
	
	public bool Play
	{
		get
		{
			return	state.Buttons.Start == ButtonState.Pressed;
		}
	}

	public bool Pause
	{
		get
		{
			return state.Buttons.Back == ButtonState.Pressed;
		}
	}

	
	public bool Cancel
	{
		get
		{
			return state.Buttons.B == ButtonState.Pressed;
		}
	}

	public bool IsActive
	{
		get
		{
			return	state.IsConnected;
		}
	}

	public float Horizontal
	{
		get
		{
			return state.ThumbSticks.Left.X + Input.GetAxis("Horizontal");
		}
	}

	public float Vertical
	{
		get
		{
			return state.ThumbSticks.Left.Y;
		}
	}

	public float Jump
	{
		get
		{
			return Convert.ToInt32( state.Buttons.A == ButtonState.Pressed) + Input.GetAxis("Jump");
		}
	}

	public Vector2 Position
	{
		get
		{
			return new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}
	}

	public bool Action
	{
		get
		{
			return Input.GetKey(KeyCode.E) || Input.GetAxis("Fire1") != 0;
		}
	}

	public void StartVibration(Vector2 direction,float duration)
	{
		StartCoroutine(Vibration(direction,duration));
	}

	private IEnumerator Vibration(Vector2 direction,float duration)
	{
		GamePad.SetVibration(PlayerIndex,direction.x, direction.y);
		yield return new WaitForSeconds(duration);
		GamePad.SetVibration(PlayerIndex,0,0);
	}

	public void StopVibration()
	{
		StopCoroutine("Vibration");
	}
}
