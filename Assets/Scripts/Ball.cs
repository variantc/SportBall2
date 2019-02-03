using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector3 carriedOffset;
    Collision2D carrier;
    bool PICKED_UP = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        carrier = collision;
        if (collision.gameObject.transform.tag == "Player")
        {
            Debug.Log("collieded with " + carrier.gameObject.name);
            carriedOffset = carrier.gameObject.transform.position - this.transform.position;
            PICKED_UP = true;
        }
    }

    private void FixedUpdate()
    {
        if (PICKED_UP)
        {
            BeCarried();
        }
    }

    void BeCarried()
    {
        this.transform.position = carrier.gameObject.transform.position + carriedOffset;
    }
}
