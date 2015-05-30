﻿using System;
using UnityEngine;

public class CharacterMotor : Photon.MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 15f;
    [SerializeField]
    private float acceleration = 3f;
    [SerializeField]
    private float airAcceleration = 3f;

    [SerializeField]
    private float horizontalDrag = 5f;

    [SerializeField]
    private float jumpPower = 10f;

    private Rigidbody2D rigidbodyObject;
    private BoxCollider2D colliderObject;
    private Animator animatorObject;

    private float inputHorizontal;
    private bool inputJump;

	private FollowCamera camera;
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

        var v = rigidbodyObject.velocity;
        if(inputHorizontal == 0)
		{
            v.x = Mathf.MoveTowards(v.x, 0, horizontalDrag * Time.deltaTime);
        }
        else
        {
            var acc = inputHorizontal * (IsGrounded ? acceleration : airAcceleration);
            v.x += acc;
        }
        v.x = Mathf.Clamp(v.x, -maxSpeed, maxSpeed);

        if (inputJump && IsGrounded) 
		{
            v.y += jumpPower;
            animatorObject.SetTrigger("Jump");
        }

        rigidbodyObject.velocity = v;

        animatorObject.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        animatorObject.SetBool("Grounded", IsGrounded);

        // Turn to movement direction (NPCs only)
        if (isNPC) {
            IsTurnedToRight = (inputHorizontal > 0f);
        }

        inputHorizontal = 0;
        inputJump = false;
    }

	public bool IsGrounded {get;set;}

    public void MoveLeft()
    {
		Move(-airAcceleration);
    }

    public void MoveRight() 
	{
		Move(airAcceleration);
    }

	public void Move(float accelerationSpeed)
	{
		ChangeSpeed(accelerationSpeed);
	}

    private void ChangeSpeed(float change)
    {
        inputHorizontal = change;
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
            inputJump = true;
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
