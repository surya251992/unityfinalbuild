using UnityEngine;
using System.Collections;

public class SoundBehavior : MonoBehaviour {
	public AudioSource[] pickup;
	//public AudioSource Spacebar;
	// Use this for initialization
	//public PlayerMovement pm;

	public void PlayAudio (int n) {
		pickup[n].Play ();
	}
}
