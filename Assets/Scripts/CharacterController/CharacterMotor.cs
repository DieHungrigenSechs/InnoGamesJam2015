using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 15f;

    [SerializeField]
    private float accelerationSpeed = 3f;

    [SerializeField]
    private float decelerationSpeed = 5f;

    [SerializeField]
    private float jumpPower = 5;

    private Rigidbody2D rigidbodyObject;

    private float currentSpeed;

    private float jumpPowerToApply;
    
    private bool onGround = false;

    private bool accelerated;

    private void Awake()
    {
        rigidbodyObject = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        UpdateCharacterState();
    }

    private void OnCollisionEnter() {
        onGround = true;
    }

    private void OnCollisionExit() {
        onGround = false;
    }

    public void UpdateCharacterState()
    {
        // On ground?
        //Transform transform = gameObject.transform;
        //Vector3 position = transform.position;
        //RaycastHit2D hit = Physics2D.Linecast(new Vector2(position.x, position.y) + new Vector2(0f, -(transform.localScale.y / 2f + 0.01f)), new Vector2(0, 0.1f));
        //onGround = (hit.collider != null);
        //Debug.Log(hit.collider);

        // Movement X axis
        rigidbodyObject.AddForce(new Vector2(currentSpeed, 0f));
        if (accelerated) {
            accelerated = false;
        } else {
            if (currentSpeed > 0f) {
                currentSpeed = Mathf.Max(0f, currentSpeed - decelerationSpeed);
            } else if (currentSpeed < 0f) {
                currentSpeed = Mathf.Min(0f, currentSpeed + decelerationSpeed);
            }
        }

        // Movement y axis
        if (jumpPowerToApply > 0f) { //&& onGround) {
            Debug.Log("jump");
            rigidbodyObject.AddForce(new Vector2(0f, jumpPowerToApply), ForceMode2D.Impulse);
        }
        jumpPowerToApply = 0f;
    }

    public void MoveLeft()
    {
        accelerated = true;
        ChangeSpeed(-accelerationSpeed);
    }

    public void MoveRight() {
        accelerated = true;
        ChangeSpeed(accelerationSpeed);
    }

    private void ChangeSpeed(float change)
    {
        currentSpeed = Mathf.Clamp(currentSpeed + change, -maxSpeed, maxSpeed);
    }

    public void Jump() {
        if (rigidbodyObject.velocity.y <= 0f) {
            jumpPowerToApply = jumpPower;
        }
    }

}
