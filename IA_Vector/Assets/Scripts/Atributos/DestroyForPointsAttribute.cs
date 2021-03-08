using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Destroy For Points")]
public class DestroyForPointsAttribute : MonoBehaviour
{
	public int pointsWorth = 1;

	private UIScript userInterface;

	private void Start()
	{
		userInterface = GameObject.FindObjectOfType<UIScript>();
	}
	

	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, false);
	}
	
	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		OnTriggerEnter2D(collisionData.collider);
	}

	private void OnTriggerEnter2D(Collider2D collisionData)
	{
		if(collisionData.gameObject.CompareTag("Bullet"))
		{
			if(userInterface != null)
			{
				BulletAttribute b = collisionData.gameObject.GetComponent<BulletAttribute>();
				if(b != null)
				{
					userInterface.AddPoints(b.playerId, pointsWorth);
				}
				else
				{
					Debug.Log("Use a BulletAttribute on one of the objects involved in the collision if you want one of the players to receive points for destroying the target.");
				}
			}
			else
			{
				Debug.Log("There is no UI in the scene, hence points can't be displayed.");
			}

			Destroy(gameObject);
		}
	}
}
