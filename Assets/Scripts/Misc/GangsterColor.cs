using UnityEngine;
using System.Collections;

public class GangsterColor : MonoBehaviour
{
    [SerializeField]
    private Color startColor = Color.white;
    [SerializeField]
    private SpriteRenderer[] renderers;

    void Start()
    {
        SetColor(startColor);
    }

    public void SetColor(Color c)
    {
        foreach(var r in renderers)
        {
            r.color = c;
        }
    }
}
