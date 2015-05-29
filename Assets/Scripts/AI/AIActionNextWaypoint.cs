using UnityEngine;

/// <summary>
/// Eine AI Action, die dem KI-Spieler anweist, zu einem anderen Waypoint zu laufen.
/// </summary>
[AddComponentMenu("AI/AIAction/Next Waypoint")]
public class AIActionNextWaypoint : MonoBehaviour
{
    [SerializeField]
    private AIWaypoint waypoint;

    void OnTriggerAIAction()
    {
        AIPlayer.current.SetWaypoint(waypoint);
	}

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        if(!waypoint) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + Vector3.up * 0.2f, waypoint.transform.position);
        Gizmos.DrawLine(transform.position - Vector3.up * 0.2f, waypoint.transform.position);
    }
#endif
}
