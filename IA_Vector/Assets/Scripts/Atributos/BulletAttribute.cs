using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Bullet")]
public class BulletAttribute : MonoBehaviour
{
	[HideInInspector]
	public int playerId;

	
	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}
}
