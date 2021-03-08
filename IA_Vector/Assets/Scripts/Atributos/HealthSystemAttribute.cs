using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Health System")]
public class HealthSystemAttribute : MonoBehaviour
{
	public int health = 3;

	private UIScript ui;
	private int maxHealth;

	private int playerNumber;



	private void Start()
	{
		ui = GameObject.FindObjectOfType<UIScript>();

		switch(gameObject.tag)
		{
			case "Player":
				playerNumber = 0;
				break;
			case "Player2":
				playerNumber = 1;
				break;
			default:
				playerNumber = -1;
				break;
		}

		if(ui != null
			&& playerNumber != -1)
		{
			ui.SetHealth(health, playerNumber);
		}

		maxHealth = health; 
	}


	public void ModifyHealth(int amount)
	{
		if(health + amount > maxHealth)
		{
			amount = maxHealth - health;
		}
			
		health += amount;

		if(ui != null
			&& playerNumber != -1)
		{
			ui.ChangeHealth(amount, playerNumber);
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
