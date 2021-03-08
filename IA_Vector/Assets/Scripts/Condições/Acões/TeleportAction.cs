using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Teleport")]
public class TeleportAction : Action
{
	public GameObject objectToMove;
	public Vector2 newPosition;
	public bool stopMovements = true;



	public override bool ExecuteAction(GameObject dataObject)
	{
		Rigidbody2D rb2D;

		if(objectToMove != null)
		{
			objectToMove.transform.position = newPosition;
			rb2D = objectToMove.GetComponent<Rigidbody2D>();
		}
		else
		{
			transform.position = newPosition;
			rb2D = transform.GetComponent<Rigidbody2D>();
		}


		if(stopMovements
			&& rb2D != null)
		{
			rb2D.velocity = Vector3.zero;
			rb2D.angularVelocity = 0f;
		}

		return true;
	}
}
