using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    SpriteRenderer sr;
    Vector3 dest;
    public float moveSpeed;

    float posTolerance = 0.2f;

	void Start ()
    {
        dest = this.transform.position;
        sr = GetComponent<SpriteRenderer>();
	}
	
	public void SetColour (Color colour)
    {
        sr.color = colour;
    }

    private void FixedUpdate()
    {
        if ((this.transform.position - dest).magnitude > posTolerance)
        {
            MoveTowardsDest();
        }
    }

    public void SetDestination(Vector3 destination)
    {
        dest = destination;
    }

    void MoveTowardsDest()
    {
        this.transform.position += Time.deltaTime * (dest - this.transform.position).normalized * moveSpeed;
    }
}
