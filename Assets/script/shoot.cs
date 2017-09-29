using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour 
{
	[SerializeField] private GameObject cannonbullet;
	[SerializeField] private GameObject pistolbullet;
	public float timeLeft = 0;
	private pickgun pickgun;
	private playermovement playermovement;
	private Vector3 position;

	private void Start()
	{
		pickgun = GetComponent<pickgun> ();
		playermovement = GetComponent<playermovement> ();
	}
	private void Update ()
	{
		if(playermovement.flipped)
		{
			position = new Vector3 (transform.position.x - 1,transform.position.y,transform.position.z);
		}
		else if(!playermovement.flipped)
		{
			position = new Vector3 (transform.position.x + 1,transform.position.y,transform.position.z);
		}
		timeLeft -= Time.deltaTime;
	}
	public void attack()
	{
		if (timeLeft < 0 && pickgun.holdinggun)
		{
			if (pickgun.Collision.gameObject.name == ("cannon"))
			{
				ShootCannon();
				timeLeft = 2;
			}
			else if (pickgun.Collision.gameObject.name == ("pistol"))
			{
				Shootpistol();
				timeLeft = 0.5f;
			}
		}
	}
	private void ShootCannon()
	{ 
		Instantiate(cannonbullet, position, pickgun.Collision.gameObject.transform.rotation);
	}
	private void Shootpistol()
	{
		Instantiate(pistolbullet, position, pickgun.Collision.gameObject.transform.rotation);
	}
}