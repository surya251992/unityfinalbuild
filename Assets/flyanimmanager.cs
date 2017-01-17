using UnityEngine;
using System.Collections;

public class flyanimmanager : MonoBehaviour {
	 Animation bird;
	// Use this for initialization
	void Start () {
		bird = bird.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(bird["birdfly"].speed != -1)
		bird["birdfly"].speed = -1;
		bird.Play("birdfly");
	}
}
