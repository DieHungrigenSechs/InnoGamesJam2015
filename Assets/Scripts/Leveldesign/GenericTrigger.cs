using UnityEngine;
using System.Collections;

/// <summary>
/// Löst OnTriggerAction auf dem eigenen GameObject aus,
/// wenn der Trigger von einer Spielfigur des spezifizierten Typs berührt wird.
/// </summary>
[AddComponentMenu("Generic Trigger")]
public class GenericTrigger : MonoBehaviour
{
    private enum InstigatorType
    {
        Player, AI, Any
    }
    [SerializeField]
    private InstigatorType instigator = InstigatorType.Any;
    private enum TriggerTimes
    {
        Once, Always
    }
    [SerializeField]
    private TriggerTimes triggerTimes;

    [SerializeField]
    private AIWaypoint mustBeAtWaypoint;

    public bool triggerable = true;


	void OnTriggerEnter2D(Collider2D c)
    {
        if(!triggerable) return;

        var trigger = false;

        switch(instigator)
        {
            case InstigatorType.Player:
                trigger = c.GetComponent<CharacterInput>();
                break;
            case InstigatorType.AI:
                trigger = c.GetComponent<AIPlayer>();
                break;
            case InstigatorType.Any:
                trigger = c.GetComponent<AIPlayer>() || c.GetComponent<CharacterInput>();
                break;
        }

        if(!trigger) return;

        if(mustBeAtWaypoint)
        {
            trigger = mustBeAtWaypoint == AIPlayer.current.lastWaypoint;
        }

        if(trigger)
        {
            SendMessage("OnTriggerAction", SendMessageOptions.DontRequireReceiver);
            if(triggerTimes == TriggerTimes.Once)
            {
                triggerable = false;
            }
        }
    }
}
