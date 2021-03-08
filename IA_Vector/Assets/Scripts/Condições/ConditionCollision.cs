using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Collision")]
[RequireComponent(typeof(Collider2D))]
public class ConditionCollision : ConditionBase
{

	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, false);
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag(filterTag)
			|| !filterByTag)
		{
			ExecuteAllActions(collision.gameObject);
		}
	}
}
