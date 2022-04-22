using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detruit : MonoBehaviour {

	public float lifeTime = 5.0f;
	public UnityEngine.Events.UnityEvent onDestroy; 

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(lifeTime);
		onDestroy.Invoke();
		Destroy(gameObject);
	}
}
