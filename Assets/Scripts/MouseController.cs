using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    PlayerController playerController;

    // Use this for initialization
    void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            // see if clicked on player
            if (DoRayCast("Player") != null)
            {
                playerController.SwitchSelectPlayer(DoRayCast("Player"));
            }
            // de-select player if click on non-player location
            else
                playerController.UnSelectPlayer();
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerController.GiveDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

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