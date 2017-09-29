using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shoot : MonoBehaviour 
{
	[SerializeField] private GameObject cannonbullet;
	[SerializeField] private GameObject pistolbullet;
    [SerializeField] private Text ammoText;
    public float timeLeft = 0;
	private pickgun pickgun;
	private playermovement playermovement;
	private Vector3 position;
    private int ammo = 0;

	private void Start()
	{
		pickgun = GetComponent<pickgun> ();
		playermovement = GetComponent<playermovement> ();
        ammoText.text = "ammo: " + ammo;
    }
	private void Update ()
	{
		if(playermovement.flipped && pickgun.holdinggun)
		{
			position = new Vector3 (transform.position.x - 1,transform.position.y + 0.5f, transform.position.z);
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
			if (pickgun.Collision.gameObject.name == ("cannon") && ammo > 0)
			{ 
                ShootCannon();
                ammo--;
                ammoText.text = "ammo: " + ammo;
                timeLeft = 2;
			}
			else if (pickgun.Collision.gameObject.name == ("pistol") && ammo > 0)
			{
				Shootpistol();
                ammo--;
                ammoText.text = "ammo: " + ammo;
                timeLeft = 0.5f;
			}
		}
	}
    public void newgun()
    {
        if (pickgun.Collision.gameObject.name == ("cannon"))
        {
            ammo = 2;
            ammoText.text = "ammo: " + ammo;
        }
        else if (pickgun.Collision.gameObject.name == ("pistol"))
        {
            ammo = 5;
            ammoText.text = "ammo: " + ammo;
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
    public void dropgun()
    {
        ammo = 0;
    }
}