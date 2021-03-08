using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Area")]
public class ConditionArea : ConditionBase
{
	
	public float frequency = 1f;


	[Header("Type of Event")]
	public ColliderEventTypes eventType = ColliderEventTypes.Enter;



	private float lastTimeTriggerStayCalled;


	void Start()
	{
		lastTimeTriggerStayCalled = -frequency;
	}


	private void Reset()
	{
		Utils.Collider2DDialogWindow(this.gameObject, true);
	}
	


	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(eventType == ColliderEventTypes.Enter)
		{

			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(otherCollider.gameObject);
			}
		}
	}



	void OnTriggerStay2D(Collider2D otherCollider)
	{
		if(eventType == ColliderEventTypes.StayInside
			&& Time.time >= lastTimeTriggerStayCalled + frequency) 
		{
			
			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(otherCollider.gameObject);
				lastTimeTriggerStayCalled = Time.time;
			}
		}
	}



	private void OnTriggerExit2D(Collider2D otherCollider)
	{
		if(eventType == ColliderEventTypes.Exit)
		{

			if(otherCollider.CompareTag(filterTag)
				|| !filterByTag)
			{
				ExecuteAllActions(otherCollider.gameObject);
			}
		}
	}



	public enum ColliderEventTypes
	{
		Enter,
		Exit,
		StayInside
	}



}
