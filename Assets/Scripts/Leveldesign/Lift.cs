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

    //0 = moving to target position
    //1 = waiting there
    //3 = moving back
    //4 = idle again
    private int phase = 4;
    private float waiting = 0;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void OnTriggerAction()
    {
        phase = 0;
	}

    void FixedUpdate()
    {
        if(phase == 4) return;

        if(phase == 1)
        {
            waiting += Time.deltaTime;
            if(waiting >= stayTime)
            {
                phase = 2;
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
