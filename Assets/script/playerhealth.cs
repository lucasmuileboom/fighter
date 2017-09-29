using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour 
{
	private int playerhp = 100;
	[SerializeField]private Text HPText;

	void Start () 
	{
		HPText.text = "HP: " + playerhp;
	}
	public void takedamage(int damage)
	{
		playerhp -= damage;
		HPText.text = "HP: " + playerhp;
	}
}
