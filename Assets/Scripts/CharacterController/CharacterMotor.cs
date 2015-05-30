using System;
using UnityEngine;

public class CharacterMotor : Photon.MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 15f;

    [SerializeField]
    private float accelerationSpeed = 3f;

    [SerializeField]
    private float decelerationSpeed = 5f;

    [SerializeField]
    private float jumpPower = 10f;

    [SerializeField]
    private float turnSpeed = 10f;

    private Rigidbody2D rigidbodyObject;
    private BoxCollider2D colliderObject;
    private Animator animatorObject;

    private float currentSpeed;

    private float jumpPowerToApply;

    private bool accelerated;

	private FollowCamera camera;

	private Vector2 lastVelocity;

    private bool isNPC;

    protected virtual void Awake()
    {
        rigidbodyObject = GetComponent<Rigidbody2D>();
        colliderObject = GetComponent<BoxCollider2D>();
        animatorObject = GetComponentInChildren<Animator>();

        isNPC = (!GetComponent<CharacterInput>());

		camera = FindObjectOfType<FollowCamera>();
        if (camera) {
            camera.AddTarget(gameObject);
        }
    }

    protected virtual void FixedUpdate() 
	{
		IsGrounded = RaycastCollider (-Vector2.up);
        UpdateCharacterState();
    }

	protected virtual void OnDestroy() 
	{
		if(camera)
		{
			camera.RemoveTarget(gameObject);
		}
	}

	private bool RaycastCollider(Vector2 direction)
	{
        float length = colliderObject.size.y / 2f + 0.05f;
        var pos = transform.position;
        var layers = ~LayerMask.GetMask("Human", "Ignore Raycast");
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(pos.x, pos.y) + colliderObject.offset, direction.normalized, length, layers);
		return hit;
	}

    public void UpdateCharacterState()
    {
        // Movement X axis
        rigidbodyObject.AddForce(new Vector2(currentSpeed, 0f));
        if (accelerated) 
		{
            accelerated = false;
        } 
		else 
		{
            if (currentSpeed > 0f) 
			{
                currentSpeed = Mathf.Max(0f, currentSpeed - decelerationSpeed);
            } else if (currentSpeed < 0f) 
			{
                currentSpeed = Mathf.Min(0f, currentSpeed + decelerationSpeed);
            }
        }

        animatorObject.SetFloat("Speed", Mathf.Abs(currentSpeed));
        animatorObject.SetBool("Grounded", IsGrounded);

        // Turn to movement direction (NPCs only)
        if (isNPC && Math.Abs(currentSpeed) > turnSpeed) {
            IsTurnedToRight = (currentSpeed > 0f);
        }

        // Movement y axis
        if (jumpPowerToApply > 0f && IsGrounded) 
		{
            rigidbodyObject.AddForce(new Vector2(0f, jumpPowerToApply), ForceMode2D.Impulse);
            animatorObject.SetTrigger("Jump");
        }
        jumpPowerToApply = 0f;
    }

	public bool IsGrounded {get;set;}

    public void MoveLeft()
    {
		Move(-accelerationSpeed);
    }

    public void MoveRight() 
	{
		Move(accelerationSpeed);
    }

	public void Move(float accelerationSpeed)
	{
		accelerated = true;
		ChangeSpeed(accelerationSpeed);
	}

    private void ChangeSpeed(float change)
    {
        currentSpeed = Mathf.Clamp(currentSpeed + change, -maxSpeed, maxSpeed);
    }

	public Vector2 Velocity
	{
		get
		{
			return rigidbodyObject.velocity;
		}
		set
		{
			rigidbodyObject.velocity = value;
		}
	}

    public void Jump() 
	{
        if (rigidbodyObject.velocity.y <= 0f) 
		{
            jumpPowerToApply = jumpPower;
        }
    }

    public bool IsTurnedToRight
    {
        get
        {
            return (transform.localScale.x > 0);
        }
        set
        {
            Vector3 localScale = transform.localScale;
            if (value)
            {
                transform.localScale = new Vector3(Mathf.Abs(localScale.x), localScale.y, localScale.z);
            } else {
                transform.localScale = new Vector3(-Mathf.Abs(localScale.x), localScale.y, localScale.z);
            }
        }
    }

    public void Attack() {
        // REALLY DIRTY SHIT!!!11 try all weapons and fire the first existing and active one!
        Pistol pistol = GetComponent<Pistol>();
        if (pistol != null && pistol.isActiveAndEnabled) {
            pistol.Attack();
            return;
        }
        Machinegun machinegun = GetComponent<Machinegun>();
        if (machinegun != null && machinegun.isActiveAndEnabled) {
            machinegun.Attack();
            return;
        }
        Rocketlauncher rocketlauncher = GetComponent<Rocketlauncher>();
        if (rocketlauncher != null && rocketlauncher.isActiveAndEnabled) {
            rocketlauncher.Attack();
        }
    }

    public void ThrowBomb() {
        Bombthrower bombthrower = GetComponent<Bombthrower>();
        if (bombthrower != null) {
            bombthrower.Attack();
        }
    }

    public Vector3 GetTargetPosition() {
        return Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
}
