using UnityEngine;
using System.Collections;



[AddComponentMenu("Playground/Movement/Wander")]
[RequireComponent(typeof(Rigidbody2D))]
public class Wander : Physics2DObject
{
	[Header("Movement")]
	public float speed = 1f;
	public float directionChangeInterval = 3f;
	public bool keepNearStartingPoint = true;

	[Header("Orientation")]
	public bool orientToDirection = false;
	
	public Enums.Directions lookAxis = Enums.Directions.Up;


	private Vector2 direction;
	private Vector3 startingPoint;


	
	private void Start()
	{
		
		if(directionChangeInterval < 0.1f)
		{
			directionChangeInterval = 0.1f;
		}
			
		
		startingPoint = transform.position;

		StartCoroutine(ChangeDirection());
	}




	
	private IEnumerator ChangeDirection()
	{
		while(true)
		{
			direction = Random.insideUnitCircle; 

			
			if(keepNearStartingPoint)
			{
				
				float distanceFromStart = Vector2.Distance(startingPoint, transform.position);
				if(distanceFromStart > 1f + (speed * 0.1f)) 
				{
					
					direction = (startingPoint - transform.position).normalized;
				}
			}


			
			if(orientToDirection)
			{
				Utils.SetAxisTowards(lookAxis, transform, direction);
			}


			
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}



	
	private void FixedUpdate()
	{
		rigidbody2D.AddForce(direction * speed);
	}
}