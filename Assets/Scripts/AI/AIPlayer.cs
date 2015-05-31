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
    private AIWaypoint _currentWaypoint;
    public AIWaypoint currentWaypoint { get { return _currentWaypoint; } }
    public AIWaypoint lastWaypoint { private set; get; }
    //public AIWaypoint currentOrLastWaypoint { get { return _currentWaypoint ?? _lastWaypoint; } }


	void Awake()
    {
        current = this;
        motor = GetComponent<CharacterMotor>();
	}
	
	void FixedUpdate()
    {
        if(_currentWaypoint)
        {
            var targetPosition = _currentWaypoint.transform.position;
            targetPosition.y -= 1;
            var distance = targetPosition - transform.position;
            distance.z = 0;

            var horizonralReachDistance = 0.2f;
            var verticalReachDistance = 0.2f;

            if(distance.x < -horizonralReachDistance)
            {
                motor.MoveLeft();
            }
            else if(distance.x > horizonralReachDistance)
            {
                motor.MoveRight();
            }
            else if(Mathf.Abs(distance.y) < verticalReachDistance)
            {
                var wp = _currentWaypoint;
                lastWaypoint = _currentWaypoint;
                _currentWaypoint = null;
                wp.OnAIReached();
            }
        }
	}

    internal void SetWaypoint(AIWaypoint waypoint)
    {
        _currentWaypoint = waypoint;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if(!_currentWaypoint) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, _currentWaypoint.transform.position);
    }
#endif
}
