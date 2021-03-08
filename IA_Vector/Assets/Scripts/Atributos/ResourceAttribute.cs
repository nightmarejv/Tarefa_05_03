using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Resource")]
[RequireComponent(typeof(SpriteRenderer))]
public class ResourceAttribute : MonoBehaviour
{
	public int resourceIndex = 0; 
	public int amount = 1;

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
		if(otherCollider.CompareTag("Player")
			|| otherCollider.CompareTag("Player2"))
		{
			if(userInterface != null)
			{
				userInterface.AddResource(resourceIndex, amount, GetComponent<SpriteRenderer>().sprite);
			}
			else
			{
				Debug.LogWarning("User Interface is not in the scene, so the resource cannot be displayed and put in the inventory.");
			}

			Destroy(gameObject);
		}
	}
}
