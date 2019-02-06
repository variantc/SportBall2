using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Player[] team;
    public Player playerPrefab;

    int numPlayers = 5;

    Color playerColour = Color.red;
    Color selectColour = Color.blue;

    public Player selectedPlayer;

    Vector3 destination;
    public float forceStrength;

	// Use this for initialization
	void Start () {
        team = new Player[numPlayers];

        for (int i=0; i<numPlayers; i++)
        {
            team[i] = Instantiate(playerPrefab);
            team[i].transform.SetParent(this.transform);
            team[i].transform.position += new Vector3(Random.Range(-7f, 7f), Random.Range(-7f, 7f), 0f);
            team[i].GetComponent<Rigidbody2D>().freezeRotation = true;
        }
	}

    //private void FixedUpdate()
    //{
    //    foreach (GameObject go in team)
    //    {
    //        Debug.Log(go.GetComponent<Rigidbody2D>().velocity);
               
    //    }
    //}

    public void SwitchSelectPlayer(Player newSelectedPlayer)
    {
        UnSelectPlayer();
        selectedPlayer = newSelectedPlayer;
        selectedPlayer.SELECTED = true;
        selectedPlayer.SetColour(selectColour);
    }

    public void GiveDestination (Vector3 clickPos)
    {
        if (selectedPlayer != null)
        {
            destination = new Vector3(clickPos.x, clickPos.y, 0f);
            //selectedPlayer.transform.position = destination;
            //selectedPlayer.GetComponent<Rigidbody2D>().AddForce(forceStrength * (destination - selectedPlayer.transform.position).normalized);
            selectedPlayer.SetDestination(destination);
        }
    }

    public void UnSelectPlayer()
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.SetColour(playerColour);
            selectedPlayer.SELECTED = false;
            selectedPlayer = null;
        }
    }
}
