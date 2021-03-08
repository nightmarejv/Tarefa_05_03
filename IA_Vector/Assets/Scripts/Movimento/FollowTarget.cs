using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Follow Target")]
[RequireComponent(typeof(Rigidbody2D))]
public class FollowTarget : Physics2DObject
{
	public Transform target;

	[Header("Movement")]
	public float speed = 1f;

	public bool lookAtTarget = false;

	public Enums.Directions useSide = Enums.Directions.Up;
	
	void FixedUpdate ()
	{
		if(target == null)
			return;

		if(lookAtTarget)
		{
			Utils.SetAxisTowards(useSide, transform, target.position - transform.position);
		}
		
		rigidbody2D.MovePosition(Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed));

	}
}
