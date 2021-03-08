using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/Create Object")]
public class CreateObjectAction : Action
{
	public GameObject prefabToCreate;
	public Vector2 newPosition;
	public bool relativeToThisObject;
		
	public override bool ExecuteAction(GameObject dataObject)
	{
		if(prefabToCreate != null)
		{
			GameObject newObject = Instantiate<GameObject>(prefabToCreate);

			Vector2 finalPosition = newPosition;
			if (relativeToThisObject)
			{
				finalPosition = (Vector2)transform.position + newPosition;
			}

			newObject.transform.position = finalPosition;
			return true;
		}
		else
		{
			Debug.LogWarning("There is no Prefab assigned to this CreateObjectAction, so a new object can't be created.");
			return false;
		}
	}

}
