using UnityEngine;

[AddComponentMenu("AI/AIAction/Jump")]
public class AIActionJump : MonoBehaviour
{
    void OnTriggerAction()
    {
        AIPlayer.current.GetComponent<CharacterMotor>().Jump();
	}

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector3.up * 2);
        Gizmos.DrawRay(transform.position + Vector3.up * 2, new Vector3(-0.5f, -0.5f, 0));
        Gizmos.DrawRay(transform.position + Vector3.up * 2, new Vector3( 0.5f, -0.5f, 0));
    }
#endif
}
