using UnityEngine;
using System.Collections;

/// <summary>
/// Löst OnAIEnter auf dem eigenen GameObject aus,
/// wenn der Trigger von einer Spielfigur des spezifizierten Typs berührt wird.
/// </summary>
[AddComponentMenu("AI/AI Trigger")]
public class AITrigger : MonoBehaviour
{
    private enum InstigatorType
    {
        Player, AI
    }
    [SerializeField]
    private InstigatorType triggerType;
    private enum TriggerTimes
    {
        Once, Always
    }
    [SerializeField]
    private TriggerTimes triggerTimes;

    public bool triggerable = true;


	void OnTriggerEnter2D(Collider2D c)
    {
        if(!triggerable) return;

        var t = default(System.Type);

        switch(triggerType)
        {
            case InstigatorType.Player:
                //t = typeof()
                break;
            case InstigatorType.AI:
                t = typeof(AIPlayer);
                break;
        }

        if(c.GetComponent(t))
        {
            SendMessage("OnAIEnter", SendMessageOptions.DontRequireReceiver);
            if(triggerTimes == TriggerTimes.Once)
            {
                triggerable = false;
            }
        }
    }
}
