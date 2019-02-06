using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    PlayerController playerController;
    Ball ball;

    // Use this for initialization
    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (ball.PICKED_UP == false)
            {
                // see if clicked on player
                if (DoRayCast("Player") != null)
                {
                    // DoRayCast deals with gameObjects, so get the Player component
                    playerController.SwitchSelectPlayer(DoRayCast("Player").GetComponent<Player>());
                }
                // de-select player if click on non-player location
                else
                {
                    playerController.UnSelectPlayer();
                }
            }
            else if (ball.PICKED_UP == true)
            {
                ball.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerController.GiveDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    // General function for selecting any GameObject type
    private GameObject DoRayCast(string tag)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.transform != null)
        {
            if (hit.transform.tag == tag)
            {
                return hit.transform.gameObject;
            }
            else
                return null;
        }
        else
            return null;
    }
}