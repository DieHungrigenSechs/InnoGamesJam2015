using UnityEngine;

public class Bullet:MonoBehaviour {

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}

