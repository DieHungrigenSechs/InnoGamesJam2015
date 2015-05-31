using UnityEngine;
using System.Collections;

public class EnableComponents : MonoBehaviour
{
    [SerializeField]
    private Behaviour[] components;
    [SerializeField]
    private Renderer[] renderers;

    void OnTriggerAction()
    {
        foreach(var c in components)
        {
            c.enabled = true;
        }
        foreach(var r in renderers)
        {
            r.enabled = true;
        }
    }
}