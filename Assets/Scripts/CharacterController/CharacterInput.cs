using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterInput : Photon.MonoBehaviour
{

    protected CharacterMotor characterMotor;

    protected virtual void Awake()
    {
        characterMotor = GetComponent<CharacterMotor>();
        if (!characterMotor) {
            Debug.LogError("CharacterMotor is missing!");
        }
    }

    protected virtual void FixedUpdate() 
	{

        if (Input.GetAxis("Horizontal") < 0) 
		{
			characterMotor.MoveLeft();
        }

		if (Input.GetAxis("Horizontal") > 0) 
		{
			characterMotor.MoveRight();
        }

        if (Input.GetAxis("Jump") != 0) 
		{
			characterMotor.Jump();
        }

        if (Input.GetAxis("Fire1") != 0) {
            characterMotor.Attack();
        }

        // Player direction
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        // Threshold for direction change to prevent crazy direction flickering when cursor is close to player
        float distance = Mathf.Abs(mouseWorldPosition.x - transform.position.x);
        if (distance > 0.05f) {
            characterMotor.IsTurnedToRight = (mouseWorldPosition.x > transform.position.x);
        }
    }
}