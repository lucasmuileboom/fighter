using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickgun : MonoBehaviour 
{
	private bool collisionBool = false;
	public bool holdinggun = false;
	public bool e = false;
	public Collision2D Collision;
	private GameObject player;
	private shoot shoot;
	private playermovement playermovement;
	private bool flipped = false;

	private void Start()
	{
		playermovement = GetComponent<playermovement> ();
		shoot = GetComponent<shoot> ();
	}
	private void Update () 
	{
		if(holdinggun)
		{
			Collision.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			Collision.gameObject.transform.position = transform.position + new Vector3(0,0.5f,0);
			if (playermovement.flipped && !flipped) 
			{
				Collision.gameObject.transform.rotation = Quaternion.Euler (0,180,0);
				flipped = true;
			}
			else if (!playermovement.flipped && flipped) 
			{
				Collision.gameObject.transform.rotation = Quaternion.Euler (0,0,0);
				flipped = false;
			}
		}
		else if (collisionBool && e && !holdinggun) 
		{
			holdinggun = true;
		}
	}
	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "gun" && !holdinggun) 
		{
			Collision = coll;
			collisionBool = true;
		}
	}
	private void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "gun")
		{
			collisionBool = false;
		}
	}
	public void dropgun()
	{
		Destroy (Collision.gameObject);
		//Collision.gameObject.GetComponent<BoxCollider2D> ().enabled = true;
		holdinggun = false;
		shoot.timeLeft = 0;
	}
}
