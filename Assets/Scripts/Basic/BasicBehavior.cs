using UnityEngine;

public class BasicBehavior : MonoBehaviour 
{
	#region Enable
	/// <summary>
	//Awake is called when the script instance is being loaded.
	///Awake is used to initialize any variables or game state before the game starts. 
	///Awake is called only once during the lifetime of the script instance. 
	///Awake is called after all objects are initialized so you can safely speak to other objects or query them using eg. GameObject.FindWithTag. #
	///Each GameObject's Awake is called in a random order between objects. 
	///Because of this, you should use Awake to set up references between scripts, and use Start to pass any information back and forth. 
	///Awake is always called before any Start functions. 
	///This allows you to order initialization of scripts. Awake can not act as a coroutine.
	/// </summary>
	protected virtual void Awake()
	{

	}
	/// <summary>
	///Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	///Like the Awake function, Start is called exactly once in the lifetime of the script. However, Awake is called when the script object is initialised, regardless of whether or not the script is enabled. Start may not be called on the same frame as Awake if the script is not enabled at initialisation time.
	///The Awake function is called on all objects in the scene before any object's Start function is called. 
	///This fact is useful in cases where object A's initialisation code needs to rely on object B's already being initialised;
	///B's initialisation should be done in Awake while A's should be done in Start.
	/// </summary>
	protected virtual void Start()
	{
	
	}
	/// <summary>
	///This function is called when the object becomes enabled and active.
	/// </summary>
	protected virtual void OnEnable() 
	{
		
	}
	#endregion

	#region Disable
	/// <summary>
	///This function is called when the MonoBehaviour will be destroyed.
	///OnDestroy will only be called on game objects that have previously been active.
	/// </summary>
	protected virtual void OnDestroy() 
	{

	}
	/// <summary>
	///This function is called when the behaviour becomes disabled () or inactive.	
	///This is also called when the object is destroyed and can be used for any cleanup code. 
	///When scripts are reloaded after compilation has finished, OnDisable will be called, followed by an OnEnable after the script has been loaded.
	/// </summary>
	protected virtual void OnDisable() 
	{
		
	}

	#endregion

	#region Update
	/// <summary>
	///Update is called every frame, if the MonoBehaviour is enabled.
	///Update is the most commonly used function to implement any kind of game behaviour.
	/// </summary>
	protected virtual void Update() 
	{
	
	}
	/// <summary>
	///This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	///FixedUpdate should be used instead of Update when dealing with Rigidbody. 
	///For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside FixedUpdate instead of every frame inside Update.
	/// </summary>
	protected virtual void FixedUpdate()
	{

	}
	/// <summary>
	///LateUpdate is called every frame, if the Behaviour is enabled.
	///LateUpdate is called after all Update functions have been called. 
	///This is useful to order script execution. 
	///For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
	/// </summary>
	protected virtual void LateUpdate()
	{

	}

	#endregion

	#region Debug
	/// <summary>
	///Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	///This allows you to quickly pick important objects in your scene.
	///Note that OnDrawGizmos will use a mouse position that is relative to the Scene View.
	/// </summary>
	protected virtual void OnDrawGizmos() 
	{

	}
	/// <summary>
	///Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected.
	///Gizmos are drawn only when the object is selected. 
	///Gizmos are not pickable. This is used to ease setup. 
	///For example an explosion script could draw a sphere showing the explosion radius.
	/// </summary>
	protected virtual void OnDrawGizmosSelected()
	{

	}
	#endregion

	#region Collision 3D
	/// <summary>
	///OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	///In contrast to OnTriggerEnter, OnCollisionEnter is passed the Collision class and not a Collider. 
	///The Collision class contains information about contact points, impact velocity etc. 
	///If you don't use collisionInfo in the function, leave out the collisionInfo parameter as this avoids unneccessary calculations. 
	///Notes: Collision events are only sent if one of the colliders also has a non-kinematic rigidbody attached. 
	///Collision events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnCollisionEnter(Collision other) 
	{
		print(this.name + " enter the collision with " + other.transform.name );
	}
	/// <summary>
	///OnCollisionStay is called once per frame for every collider/rigidbody that is touching rigidbody/collider.
	///In contrast to OnTriggerStay, OnCollisionStay is passed the Collision class and not a Collider. 
	///The Collision class contains information about contact points, impact velocity etc. 
	///If you don't use collisionInfo in the function, leave out the collisionInfo parameter as this avoids unneccessary calculations.
	///Notes: Collision events are only sent if one of the colliders also has a non-kinematic rigidbody attached. 
	///Collision events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions. 
	///Collision stay events are not sent for sleeping Rigidbodies.
	/// </summary>
	protected virtual void OnCollisionStay(Collision other) 
	{

	}
	/// <summary>
	///OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
	///In contrast to OnTriggerExit, OnCollisionExit is passed the Collision class and not a Collider. 
	///The Collision class contains information about contact points, impact velocity etc. 
	///If you don't use collisionInfo in the function, leave out the collisionInfo parameter as this avoids unneccessary calculations. 
	///Notes: Collision events are only sent if one of the colliders also has a non-kinematic rigidbody attached. 
	///Collision events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnCollisionExit(Collision other) 
	{
		print(this.name + " exit the collision with " + other.transform.name );
	}
	
	#endregion
	
	#region Trigger 3D
	/// <summary>
	///OnTriggerEnter is called when the Collider other enters the trigger.
	///This message is sent to the trigger collider and the rigidbody (or the collider if there is no rigidbody) that touches the trigger. 
	///Notes: Trigger events are only sent if one of the colliders also has a rigidbody attached. 
	///Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnTriggerEnter(Collider other) 
	{
		print(this.name + " enter the collision with " + other.transform.name );
	}
	/// <summary>
	///OnTriggerStay is called once per frame for every Collider other that is touching the trigger.	
	///This message is sent to the trigger and the collider that touches the trigger. 
	///Notes: Trigger events are only sent if one of the colliders also has a rigidbody attached. 
	///Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnTriggerStay(Collider other) 
	{

	}
	/// <summary>
	///OnTriggerExit is called when the Collider other has stopped touching the trigger.	
	///This message is sent to the trigger and the collider that touches the trigger. 
	///Notes: Trigger events are only sent if one of the colliders also has a rigidbody attached. 
	///Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnTriggerExit(Collider other) 
	{
		print(this.name + " exit the collision with " + other.transform.name );
	}

	#endregion
	
	#region Collision 2D
	/// <summary>
	///Sent when an incoming collider makes contact with this object's collider (2D physics only).	
	///Further information about the collision is reported in the Collision2D parameter passed during the call. 
	///If you don't need this information then you can declare OnCollisionEnter2D without the parameter.
	///Notes: Collision events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnCollisionEnter2D(Collision2D other) 
	{
		print(this.name + " enter the collision with " + other.transform.name );
	}
	/// <summary>
	///Sent each frame where a collider on another object is touching this object's collider (2D physics only).
	///Further information about the objects involved is reported in the Collision2D parameter passed during the call. 
	///If you don't need this information then you can declare OnCollisionStay2D without the parameter.
	//Notes: Collision events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnCollisionStay2D(Collision2D other) 
	{

	}
	/// <summary>
	///Sent when a collider on another object stops touching this object's collider (2D physics only).	
	///Further information about the objects involved is reported in the Collision2D parameter passed during the call. 
	///If you don't need this information then you can declare OnCollisionExit2D without the parameter.
	///Notes: Collision events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnCollisionExit2D(Collision2D other) 
	{
		print(this.name + " exit the collision with " + other.transform.name );
	}
	
	#endregion
	
	#region Trigger 2D
	/// <summary>
	///Sent when another object enters a trigger collider attached to this object (2D physics only).
	///Further information about the other collider is reported in the Collider2D parameter passed during the call.
	///Notes: Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnTriggerEnter2D(Collider2D other) 
	{
		print(this.name + " enter the collision with " + other.transform.name );
	}
	/// <summary>
	///Sent each frame where another object is within a trigger collider attached to this object (2D physics only).
	///Further information about the other collider is reported in the Collider2D parameter passed during the call.
	///Notes: Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnTriggerStay2D(Collider2D other) 
	{

	}
	/// <summary>
	///Sent when another object leaves a trigger collider attached to this object (2D physics only).
	///Further information about the other collider is reported in the Collider2D parameter passed during the call.
	///Notes: Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
	/// </summary>
	protected virtual void OnTriggerExit2D(Collider2D other) 
	{
		print(this.name + " exit the collision with " + other.transform.name );
	}

	#endregion

	#region Collision Character Controller
	/// <summary>
	///OnControllerColliderHit is called when the controller hits a collider while performing a Move.
	///This can be used to push objects when they collide with the character.
	/// </summary>
	protected virtual void OnControllerColliderHit(ControllerColliderHit other) 
	{
		print(this.name + " enter the collision with " + other.transform.name );	
	}

	#endregion
}
