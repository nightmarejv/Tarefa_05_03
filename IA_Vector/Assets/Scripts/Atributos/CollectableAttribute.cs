using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Collectable")]
public class CollectableAttribute : MonoBehaviour
{
	public int pointsWorth = 1;
	
	private UIScript userInterface;

	private void Start()
	{
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}


	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}


	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		string playerTag = otherCollider.gameObject.tag;

		if(playerTag == "Player" || playerTag == "Player2")
		{
			if(userInterface != null)
			{
				int playerId = (playerTag == "Player") ? 0 : 1;
				userInterface.AddPoints(playerId, pointsWorth);
			}

			Destroy(gameObject);
		}
	}
}
