using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector3 carriedOffset;
    Vector3 dest;
    Collision2D carrierCollision;
    public bool PICKED_UP = false;
    public bool CAUGHT = false;
    bool SHOT = false;
    public float shotSpeed;
    float posTolerance = 0.2f;
    float colliderDelay = 0.5f;
    PlayerController pc;

    private void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        carrierCollision = collision;
        if (collision.gameObject.transform.tag == "Player")
        {
            Debug.Log("collided with " + carrierCollision.gameObject.name);
            carriedOffset = carrierCollision.gameObject.transform.position - this.transform.position;
            PICKED_UP = true;
            this.GetComponent<Collider2D>().enabled = false;
        }
        if (carrierCollision.gameObject.GetComponent<Player>().SELECTED == false)
        {
            pc.SwitchSelectPlayer(carrierCollision.gameObject.GetComponent<Player>());
        }
    }

    private void FixedUpdate()
    {
        if (PICKED_UP)
        {
            BeCarried();
        }
        if (SHOT)
        {
            if ((this.transform.position - dest).magnitude < colliderDelay)
            {
                this.GetComponent<Collider2D>().enabled = true;
            }
            if ((this.transform.position - dest).magnitude > posTolerance)
            {
                MoveTowardsDest();
            }
            else
            {
                SHOT = false;
            }
        }
    }

    void BeCarried()
    {
        this.transform.position = carrierCollision.gameObject.transform.position + carriedOffset / 2f;
    }

    public void Shoot(Vector3 shootTarget)
    {
        PICKED_UP = false;
        SHOT = true;
        dest = new Vector3(shootTarget.x, shootTarget.y, 0f);
        Debug.Log("Shoot to : " + dest);
    }

    void MoveTowardsDest()
    {
        this.transform.position += Time.deltaTime * (dest - this.transform.position).normalized * shotSpeed;
    }
}
