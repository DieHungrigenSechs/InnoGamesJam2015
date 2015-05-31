using UnityEngine;

public class TriggerSomethingElse : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectsToTrigger;

    void OnTriggerAction()
    {
	    foreach(var go in objectsToTrigger)
        {
            print("triggering " + go);
            go.SendMessage("OnTriggerAction");
        }
	}
}
