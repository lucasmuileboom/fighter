using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour 
{
	private float bulletSpeed;
	private Rigidbody2D _rigidbody2D;
	private GameObject player;
	private bool flipped;
	private Vector2 move;

	private void Start ()
	{
		_rigidbody2D = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Player");
		if (gameObject.name == "cannonbullet(Clone)")
		{
			bulletSpeed = 10;
		}
		else if (gameObject.name == "pistolbullet(Clone)")
		{
			bulletSpeed = 5;
		}
		if(player.GetComponent<playermovement>().flipped)
		{
			move = new Vector2 (-1, 0) * bulletSpeed;
		}
		else if(!player.GetComponent<playermovement>().flipped)
		{
			move = new Vector2 (1, 0) * bulletSpeed;
		}
	}
	private void FixedUpdate()
	{
		_rigidbody2D.velocity = move * bulletSpeed;
        if (transform.position.x < -11.5 || transform.position.x > 11.5)
        {
            Destroy(gameObject);
        }
	}
}