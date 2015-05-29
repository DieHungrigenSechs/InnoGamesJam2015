using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update() {

        if (Input.GetKey(KeyCode.LeftArrow)) {
            characterController.MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            characterController.MoveRight();
        }

        if (Input.GetKey(KeyCode.Space)) {
            characterController.Jump();
        }

    }

}