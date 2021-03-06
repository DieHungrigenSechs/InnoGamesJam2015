﻿using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(InputManager))]
public class CharacterInput : Photon.MonoBehaviour
{
	[SerializeField] int action;
    protected CharacterMotor characterMotor;
	protected InputManager inputManager;
    public Texture2D crosshairTexture;

    public void OnGUI() {
        GUI.DrawTexture(new Rect(Input.mousePosition.x - 16, Screen.height - Input.mousePosition.y - 16, 32, 32), crosshairTexture, ScaleMode.ScaleToFit, true, 1.0f);
    }

    protected virtual void Awake()
    {
		inputManager = GetComponent<InputManager>();
		if(!inputManager)
		{
			inputManager = gameObject.AddComponent<InputManager>();
		}
        crosshairTexture = Resources.Load<Texture2D>("Crosshair");
        characterMotor = GetComponent<CharacterMotor>();
        if (!characterMotor) {
            Debug.LogError("CharacterMotor is missing!");
        }
        Cursor.visible = false;
    }

    protected void Update() {
        // Wweapon switching
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
            SelectWeapon(0); 
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SelectWeapon(1);
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SelectWeapon(2);
        }

        // Bomb
        if (Input.GetKeyDown(KeyCode.G)) {
            characterMotor.ThrowBomb();
        }

		action +=inputManager.SwitchGlitch;
		action =  Mathf.Clamp(action,0,3);
		if(inputManager.Action)
		{
			switch(action)
			{
			case 0:
				if(!gameObject.GetComponent<FlyMode>())
				{
					gameObject.AddComponent<FlyMode>();
				}
				break;
			case 1:
				if(!gameObject.GetComponent<BounceBug>())
				{
					gameObject.AddComponent<BounceBug>();
				}
				break;
				
			case 2:
				if(!gameObject.GetComponent<TeleportGlitch>())
				{
					gameObject.AddComponent<TeleportGlitch>();
				}
				break;
			}
		}
    }

    protected virtual void FixedUpdate() 
	{

		if (inputManager.Horizontal < 0) 
		{
			characterMotor.MoveLeft();
        }

		if (inputManager.Horizontal > 0) 
		{
			characterMotor.MoveRight();
        }

		if (inputManager.Jump != 0) 
		{
			characterMotor.Jump();
        }

		if (inputManager.Shoot) 
		{
            characterMotor.Attack();
        }

        // Change player direction depending on mouse position
		Vector2 input = Camera.main.ScreenToWorldPoint (inputManager.Position);
        // Threshold for direction change to prevent crazy direction flickering when cursor is close to player
        float distance = Mathf.Abs(input.x - transform.position.x);
        if (distance > 0.05f) 
		{
            characterMotor.IsTurnedToRight = (input.x > transform.position.x);
        }
    }

    protected void SelectWeapon(int weaponId) 
	{
        Weapon[] weapon = new Weapon[3];
        weapon[0] = GetComponent<Pistol>();
        weapon[1] = GetComponent<Machinegun>();
        weapon[2] = GetComponent<Rocketlauncher>();
        // Disable all unused weapons
        for (int i = 0; i < weapon.Length; i++) {
            if (weapon[i] != null && weapon[i].enabled && i != weaponId) {
                weapon[i].enabled = false;
            }
        } 
        // Enable new weapon
        if (weapon[weaponId] != null && weapon[weaponId].enabled == false) {
            weapon[weaponId].enabled = true;
        }
    }

	public int GetAction()
	{
		return action;
	}
}