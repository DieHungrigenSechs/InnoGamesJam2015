using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    private CharacterMotor characterMotor;

    void Start()
    {
        characterMotor = GetComponent<CharacterMotor>();
    }

    void FixedUpdate() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            characterMotor.MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            characterMotor.MoveRight();
        }

        if (Input.GetKey(KeyCode.Space)) {
            characterMotor.Jump();
        }

    }

}