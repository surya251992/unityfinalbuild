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
		if(pl.speed < 41)
		while(true)
		{
			pl.speed = pl.speed + 1f;
			yield return new WaitForSeconds (40.0f);
		}
	}
	
}
