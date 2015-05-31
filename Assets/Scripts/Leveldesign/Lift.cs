using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Rigidbody2D))]
public class Lift : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector3 startPosition;
    [HideInInspector]
    [SerializeField]
    private Vector3 targetPosition;
    public float speed = 5;
    public float stayTime = 3;
    [SerializeField]
    private bool loopOnceActivated;

    //-1 = idle
    //0 = moving to target position
    //1 = waiting there
    //3 = moving back
    //4 = waiting to go there again
    private int phase = -1;
    private float waiting = 0;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void OnTriggerAction()
    {
        if(phase == -1)
            phase = 0;
	}

    void FixedUpdate()
    {
        if(phase == -1) return;

        if(phase == 1 || phase == 4)
        {
            waiting += Time.deltaTime;
            if(waiting >= stayTime)
            {
                phase++;
                if(phase == 5)
                    phase = 0;
            }
            else
            {
                return;
            }
        }

        var target = (phase == 0) ? targetPosition : startPosition;

        if(Vector3.Distance(transform.position, target) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            phase++;
            waiting = 0;
        }

        if(!loopOnceActivated && phase == 4)
        {
            phase = -1;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Lift))]
    public class LiftEditor : Editor
    {
        void OnSceneGUI()
        {
            var t = target as Lift;

            var newPosition = Handles.FreeMoveHandle(t.targetPosition, Quaternion.identity, 0.5f, Vector3.zero, Handles.RectangleCap);
            if(GUI.changed)
            {
                Undo.RecordObject(t, "Moved Lift Target Position.");
                t.targetPosition = newPosition;
                EditorUtility.SetDirty(target);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, targetPosition);
    }
#endif
}
