using UnityEngine;

public class CharacterMotor : MonoBehaviour, ICharacterMotor
{
    private float currentSpeed = 0.1f;

    private bool onGround = false;

    private void Start()
    {
        
    }

    private void Update() {
        UpdateCharacterState();
    }

    public void UpdateCharacterState() {
    }

    public void MoveLeft() {
        transform.localPosition -= new Vector3(currentSpeed, 0, 0);
    }

    public void MoveRight() {
        transform.localPosition -= new Vector3(-currentSpeed, 0, 0);
    }

    public void Jump() {
        JumpMockup();
    }

    //Mockup von Sascha
    private void JumpMockup()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
    }

}
