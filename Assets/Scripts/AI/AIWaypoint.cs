using UnityEngine;

/// <summary>
/// Ein Waypoint, auf den ein KI-Spieler zulaufen kann.
/// </summary>
[AddComponentMenu("AI/AI Waypoint")]
public class AIWaypoint : AITrigger
{
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.4f);
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
#endif
}
