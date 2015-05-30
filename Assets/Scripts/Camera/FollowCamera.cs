using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowCamera : BasicBehavior
{
	[SerializeField] List<GameObject> targets = new List<GameObject>();
	[SerializeField] Vector3 offset;
	[SerializeField] float minDistance = 2f;
	[SerializeField] float maxDistance = 5f;
	[SerializeField] float zoomSpeed = 1f;
	private Camera camera;

	protected override void Awake ()
	{
		base.Awake ();
		camera = GetComponent<Camera>();
	}

	protected override void Update ()
	{	
		base.Update ();
		GameObject[] targets = GetTarget();
		
		Vector3 position = CenterOf(targets);
		Vector3 velocity = VelocityOf(targets);
		Vector3 direction = velocity.normalized;
		
		float distance = DistanceTo(targets,position);
		float speed = Time.deltaTime * zoomSpeed;
		distance =  Mathf.Lerp(camera.orthographicSize,distance,speed);
		camera.orthographicSize = Mathf.Clamp(distance,minDistance,maxDistance);
		transform.position = new Vector3(position.x,position.y,transform.position.z) + offset;
	}
	
	private Vector3 CenterOf(GameObject[] targets)
	{
		Vector3 difference = Vector3.zero;
		
		foreach(GameObject target in targets)
		{
			difference += target.transform.position; 
		}
		
		return difference / targets.Length;
	}
	
	private float DistanceTo(GameObject[] targets,Vector3 position)
	{
		float distance = 0;
		foreach(GameObject target in targets)
		{
			distance += Vector3.Distance(position,target.transform.position);
		}
		
		return distance;
	}
	
	private Vector3 VelocityOf(GameObject[] targets)
	{
		Vector2 velocity = Vector2.zero;
		int count = 0;
		
		foreach(GameObject target in targets)
		{
			if(target.GetComponent<Rigidbody2D>())
			{
				velocity += target.GetComponent<Rigidbody2D>().velocity;
				count++;
			}
		}
		return velocity / count;
	}

	private GameObject[] GetTarget()
	{
		return targets.ToArray();
	}
	
	public void AddTarget(GameObject target)
	{
		targets.Add(target);
	}
	
	public void RemoveTarget(GameObject target)
	{
		targets.Remove(target);
	}
}


