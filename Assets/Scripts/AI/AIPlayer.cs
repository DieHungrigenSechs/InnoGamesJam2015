using UnityEngine;

/// <summary>
/// Die Komponente, die Peters Bewegungsscript steuert.
/// </summary>
[RequireComponent(typeof(CharacterMotor))]
public class AIPlayer : MonoBehaviour
{
    public static AIPlayer current { private set; get; }
    private CharacterMotor motor;
    [SerializeField]
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
            var distance = currentWaypoint.transform.position - transform.position;
            distance.z = 0;

            var horizonralReachDistance = 0.2f;
            var verticalReachDistance = 0.5f;

            if(distance.x < -horizonralReachDistance)
            {
                motor.MoveLeft();
            }
            else if(distance.x > horizonralReachDistance)
            {
                motor.MoveRight();
            }
            else if(distance.y < verticalReachDistance)
            {
                var wp = currentWaypoint;
                currentWaypoint = null;
                wp.OnAIReached();
            }
        }
	}

    internal void SetWaypoint(AIWaypoint waypoint)
    {
        currentWaypoint = waypoint;
    }
}
