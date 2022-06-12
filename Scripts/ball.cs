using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float stop_scale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void HitBall(Vector3 dir, float force)
    {
        rb2D.AddForce(dir * force);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Hero")
        {
            Vector3 cur_vec = rb2D.velocity;
            rb2D.velocity = cur_vec * -0.7f;

            if(rb2D.velocity.sqrMagnitude <= stop_scale)
            {
                Debug.Log("Stop");
                rb2D.bodyType = RigidbodyType2D.Static;
            }
        }
    }

    void OnColliderEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
    }
}
