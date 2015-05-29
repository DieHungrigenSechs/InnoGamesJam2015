using UnityEngine;

/// <summary>
/// Die Komponente, die Peters Bewegungsscript steuert.
/// </summary>
[RequireComponent(typeof(CharacterMotor))]
public class AIPlayer : MonoBehaviour
{
    public static AIPlayer current { private set; get; }
    private CharacterMotor motor;
    private AIWaypoint currentWaypoint;

	void Awake()
    {
        current = this;
        motor = GetComponent<CharacterMotor>();
	}
	
	void FixedUpdate()
    {
	    if(currentWaypoint)
        {
            var horizontalDistance = currentWaypoint.transform.position.x - transform.position.x;

            var waypointReachDistance = 0.2f;

            if(horizontalDistance < -waypointReachDistance)
            {
                motor.MoveLeft();
            }
            else if(horizontalDistance > waypointReachDistance)
            {
                motor.MoveRight();
            }
        }
	}

    internal void SetWaypoint(AIWaypoint waypoint)
    {
        currentWaypoint = waypoint;
    }
}
