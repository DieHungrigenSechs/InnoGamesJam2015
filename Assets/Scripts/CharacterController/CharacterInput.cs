using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    private CharacterMotor _characterMotor;

    void Start()
    {
        _characterMotor = GetComponent<CharacterMotor>();
    }

    void Update() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            _characterMotor.MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            _characterMotor.MoveRight();
        }

        if (Input.GetKey(KeyCode.Space)) {
            _characterMotor.Jump();
        }

    }

}