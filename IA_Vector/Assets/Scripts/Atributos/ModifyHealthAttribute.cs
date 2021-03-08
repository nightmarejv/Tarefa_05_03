using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Modify Health")]
public class ModifyHealthAttribute : MonoBehaviour
{

	public bool destroyWhenActivated = false;
	public int healthChange = -1;

	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}

	private void OnCollisionEnter2D(Collision2D collisionData)
	{
		OnTriggerEnter2D(collisionData.collider);
	}

	private void OnTriggerEnter2D(Collider2D colliderData)
	{
		HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
		if(healthScript != null)
		{
			healthScript.ModifyHealth(healthChange);

			if(destroyWhenActivated)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
