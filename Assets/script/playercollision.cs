using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollision : MonoBehaviour 
{
	private playermovement playermovement;
	private playerhealth playerhealth;

	private void Start () 
	{
		playermovement = GetComponent<playermovement> ();
		playerhealth = GetComponent<playerhealth> ();
	}
	private void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			playermovement.isjumping = false;
		}
		else if(coll.gameObject.tag == "bullet")
		{
			if(coll.gameObject.name == "pistolbullet(Clone)")
			{
				playerhealth.takedamage (10);
			}
			else if(coll.gameObject.name == "cannonball(Clone)")
			{
				playerhealth.takedamage (30);
			}
			Destroy (coll.gameObject);
		}
	}
	private void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "floor")
		{
			playermovement.isjumping = true;
		}
	}
}