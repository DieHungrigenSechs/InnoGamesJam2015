using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Eine AI Action, die dem KI-Spieler anweist, rumzuglitchen.
/// </summary>
[AddComponentMenu("AI/AIAction/Glitch")]
public class AIActionGlitch : MonoBehaviour
{
    private enum GlitchType
    {
        Teleport,
        FlyMode,
        Bounce
    }

    [SerializeField]
    private GlitchType glitch;

    private static Dictionary<GlitchType, System.Type> glitchDict;
    static AIActionGlitch()
    {
        glitchDict = new Dictionary<GlitchType, System.Type>();
        glitchDict.Add(GlitchType.Teleport, typeof(TeleportGlitch));
        glitchDict.Add(GlitchType.FlyMode, typeof(FlyMode));
        glitchDict.Add(GlitchType.Bounce, typeof(BounceBug));
    }

    void OnTriggerAction()
    {
        AIPlayer.current.gameObject.AddComponent(glitchDict[glitch]);
    }
}
