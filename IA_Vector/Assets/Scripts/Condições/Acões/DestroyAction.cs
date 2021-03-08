using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Destroy Action")]
public class DestroyAction : Action
{
	public Enums.Targets target = Enums.Targets.ObjectThatCollided;
	public GameObject deathEffect;


	public override bool ExecuteAction(GameObject otherObject)
	{
		if(deathEffect != null)
		{
			GameObject newObject = Instantiate<GameObject>(deathEffect);
			
			Vector3 otherObjectPos = (otherObject == null) ? this.transform.position : otherObject.transform.position;
			newObject.transform.position = (target == Enums.Targets.ObjectThatCollided) ? otherObjectPos : this.transform.position;
		}

		if(target == Enums.Targets.ObjectThatCollided)
		{
			if(otherObject != null)
			{
				Destroy(otherObject);
			}
		}
		else
		{
			Destroy(gameObject);
		}

		return true; 
	}
}
