using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Gameplay/Object Creator Area")]
[RequireComponent(typeof(BoxCollider2D))]
public class ObjectCreatorArea : MonoBehaviour
{
	[Header("Object creation")]

	public GameObject prefabToSpawn;

	[Header("Other options")]

	public float spawnInterval = 1;

	private BoxCollider2D boxCollider2D;

	void Start ()
	{
		boxCollider2D = GetComponent<BoxCollider2D>();

		StartCoroutine(SpawnObject());
	}
	
	IEnumerator SpawnObject ()
	{
		while(true)
		{
			float randomX = Random.Range (-boxCollider2D.size.x, boxCollider2D.size.x) *.5f;
			float randomY = Random.Range (-boxCollider2D.size.y, boxCollider2D.size.y) *.5f;

			GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
			newObject.transform.position = new Vector2(randomX + this.transform.position.x, randomY + this.transform.position.y);

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
