using UnityEngine;
using System.Collections;

public class Speedautoincrement : MonoBehaviour {
	
	public PlayerMovement pl;

	// Use this for initialization
	void Start () {
		pl = GetComponent<PlayerMovement> ();
		StartCoroutine ("Increment");
	}

	IEnumerator Increment()
	{
			while (pl.speed < 44) 
		{
				pl.speed = pl.speed + 1f;
				yield return new WaitForSeconds (25.0f);
		}
	}
	
}
