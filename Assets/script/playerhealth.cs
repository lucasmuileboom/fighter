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
    private void Update()
    {
        if(playerhp <= 0)//gameover
        {
            print("gameover");            
        }
    }
    public void takedamage(int damage)
	{
		playerhp -= damage;
		HPText.text = "HP: " + playerhp;
	}
}
