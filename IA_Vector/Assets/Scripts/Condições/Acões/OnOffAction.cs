using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Actions/On-Off")]
public class OnOffAction : Action
{
	public GameObject objectToAffect;
	public bool justMakeInvisible;


	public override bool ExecuteAction(GameObject dataObject)
	{
		if(objectToAffect != null)
		{
			if(!justMakeInvisible)
			{
				objectToAffect.SetActive(!objectToAffect.activeSelf);
			}
			else
			{
				SpriteRenderer sr = objectToAffect.GetComponent<SpriteRenderer>();
				if(sr != null)
				{
					sr.enabled = !sr.enabled;					
				}
				else
				{
					return false;
				}
			}

			return true;
		}
		else
		{
			return false;
		}
	}
}
