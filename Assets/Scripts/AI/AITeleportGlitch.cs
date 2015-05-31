using UnityEngine;
using System.Collections;

public class AITeleportGlitch : MonoBehaviour
{
	void Start()
    {
        var pos = AIPlayer.current.currentWaypoint.transform.position;
        pos.z = transform.position.z;
        transform.position = pos;
        try
        {
            PostProcessPixelate.instance.Animate();
        }
        catch { }
        Destroy(this);
	}
}
