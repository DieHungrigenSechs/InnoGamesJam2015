using UnityEngine;
using System;
using System.Collections;

public class InputManager : MonoBehaviour
{

	private void Start()
	{

	}

	private void Update()
	{

	}

	public float Horizontal
	{
		get
		{
			return  Input.GetAxis("Horizontal");
		}
	}

	public float Vertical
	{
		get
		{
			return Input.GetAxis("Vertical");
		}
	}

	public float Jump
	{
		get
		{
			return Input.GetAxis("Jump");
		}
	}

	public Vector2 Position
	{
		get
		{
			return new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		}
	}

	public bool Shoot
	{
		get
		{
			return Input.GetAxis("Fire1") != 0;
		}
	}

	public bool Action
	{
		get
		{
			return Input.GetAxis("Fire2") != 0;
		}
	}
}
