using UnityEngine;
using System.Collections;

public class TimeScaleGlitch : BugPhysics 
{
	[SerializeField] float slowFactor = 0.25f;
	private float newTimeScale;
	protected override void Start ()
	{
		base.Start ();
		SlowMotion(slowFactor);
	}

	private void SlowMotion(float value)
	{
		//calculate the new time scale  
		newTimeScale = Time.timeScale/value; 
		//assign the 'newTimeScale' to the current 'timeScale'  
		Time.timeScale = newTimeScale;  
		//proportionally reduce the 'fixedDeltaTime', so that the Rigidbody simulation can react correctly  
		Time.fixedDeltaTime = Time.fixedDeltaTime/value;  
		//The maximum amount of time of a single frame  
		Time.maximumDeltaTime = Time.maximumDeltaTime/value;
	}

	protected override void Reset ()
	{
		base.Reset (); 
		Time.timeScale = 1.0f;  
		Time.fixedDeltaTime = Time.fixedDeltaTime*slowFactor;  
		Time.maximumDeltaTime = Time.maximumDeltaTime*slowFactor;
	}

	private void OnDestroy()
	{
		Reset();
	}
}
