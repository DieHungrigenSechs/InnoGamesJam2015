using UnityEngine;

public class CharacterInput : Photon.MonoBehaviour
{

    protected CharacterMotor characterMotor;

    protected virtual void Awake()
    {
        characterMotor = GetComponent<CharacterMotor>();
    }

    protected virtual void FixedUpdate() 
	{

        if (Input.GetAxis("Horizontal") < 0) 
		{
			characterMotor.MoveLeft();
        }

		if (Input.GetAxis("Horizontal") > 0) 
		{
			characterMotor.MoveRight ();
        }

        if (Input.GetAxis("Jump") != 0) 
		{
			characterMotor.Jump ();
        }
    }
}