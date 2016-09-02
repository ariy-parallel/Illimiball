using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    public string activeTag;
    public float force;
    public bool fallIn { get; private set; }

    private bool isActivetag(Collider other)
    {
        return other.gameObject.tag == activeTag;
    }

    void OnTriggerEnter (Collider other)
    {
        if (isActivetag(other))
        {
            fallIn = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (isActivetag(other))
        {
            fallIn = false;
        }
    }

    void OnTriggerStay (Collider other)
    {
        var direction = transform.position - other.gameObject.transform.position;
        direction.Normalize();

        var r = other.gameObject.GetComponent<Rigidbody> ();
        if (isActivetag(other))
        {
            r.velocity *= 0.9f;
            r.AddForce (direction * r.mass * force);
        }
        else
        {
            r.AddForce (- direction * r.mass * 80.0f);
        }
    }
}