using UnityEngine;

/// <summary>
/// Die Komponente, die Peters Bewegungsscript steuert.
/// </summary>
public class AIPlayer : MonoBehaviour
{
    public static AIPlayer current { private set; get; }
    private AIWaypoint currentWaypoint;

	void Awake()
    {
        current = this;
	}
	
	void Update()
    {
	
	}

    internal void SetWaypoint(AIWaypoint waypoint)
    {
        currentWaypoint = waypoint;
    }
}
