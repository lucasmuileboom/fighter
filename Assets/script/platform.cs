using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour 
{
	private GameObject Player;

	private void Start () 
	{
		Player = GameObject.FindWithTag("Player");
	}

	private void Update () 
	{
		if(Player.transform.position.y - 1 > transform.position.y + 0.25)
		{
			GetComponent<BoxCollider2D> ().enabled = true;
		}
		else if(Player.transform.position.y - 0.5f < transform.position.y + 0.25)
		{
			GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
