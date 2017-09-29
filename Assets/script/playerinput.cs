using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinput : MonoBehaviour 
{
	private playermovement playermovement;
	private pickgun pickgun;
	private shoot shoot;

	private void Start () 
	{
		playermovement = GetComponent<playermovement> ();
		pickgun = GetComponent<pickgun> ();
		shoot = GetComponent<shoot> ();
	}
	private void Update () 
	{
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			playermovement.Jump ();
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			shoot.attack ();
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			pickgun.dropgun ();
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			playermovement.left = true;
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			playermovement.right = true;
		}
		if(Input.GetKeyDown(KeyCode.E))
		{
			pickgun.e = true;
		}
		if(Input.GetKeyUp(KeyCode.A))
		{
			playermovement.left = false;
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
			playermovement.right = false;
		}
		if(Input.GetKeyUp(KeyCode.E))
		{
			pickgun.e = false;
		}
	}
}