using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour 
{
	private Rigidbody2D _Rigidbody;
	private Vector2 move;
	private int jumpforce = 1500;
	private int movespeed = 10;
	public bool isjumping = false;
	public bool left = false;
	public bool right = false;
	public bool flipped = false;

	private void Start () 
	{
		_Rigidbody = GetComponent<Rigidbody2D> ();
		_Rigidbody.gravityScale = 8;
	}
	private void Update()
	{
		if(!left && right)
		{
			flipped = false;
		}
		else if(left && !right)
		{
			flipped = true;
		}
	}
	private void FixedUpdate()
	{
		if (left && !right && transform.position.x > -11)//left
		{  
			if (!isjumping)//left grond 
			{
				_Rigidbody.velocity = new Vector2 (-movespeed, _Rigidbody.velocity.y);
			} 
			else if (isjumping) //left air
			{
				_Rigidbody.velocity = new Vector2 (-movespeed / 2, _Rigidbody.velocity.y);
			}
		}
		else if (!left && right && transform.position.x < 11) //right
		{ 
			if (!isjumping) //right grond
			{
				_Rigidbody.velocity = new Vector2 (movespeed, _Rigidbody.velocity.y);
			}
			else if (isjumping) //right air
			{
				_Rigidbody.velocity = new Vector2 (movespeed / 2, _Rigidbody.velocity.y);
			}
		}
		else if (transform.position.x < -11.5 || transform.position.x > 11.5 || !left && !right || left && right)//outside map , idle
		{
			_Rigidbody.velocity = new Vector2 (0, _Rigidbody.velocity.y);
		}
	}
	public void Jump()
	{
		if(!isjumping)
		{
			_Rigidbody.AddForce (new Vector2(0,jumpforce),ForceMode2D.Force);
			isjumping = true;
		}
	}
}