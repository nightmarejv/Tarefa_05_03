using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("Playground/Actions/Load Level")]
public class LoadLevelAction : Action
{
	public string levelName = SAME_SCENE;

	public const string SAME_SCENE = "0";
	

	public override bool ExecuteAction(GameObject dataObject)
	{
		if(levelName == SAME_SCENE)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
		}
		else
		{
			SceneManager.LoadScene(levelName, LoadSceneMode.Single);
		}

		return true;
	}
}