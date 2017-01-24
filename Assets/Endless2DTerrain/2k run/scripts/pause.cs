using UnityEngine;
using System.Collections;


public class pause : MonoBehaviour {
	public bool pauseindicator = false;
	public AudioSource bgm;
	// Use this for initialization
	public void onClick () 
	{
		if (pauseindicator == false) 
		{
			Time.timeScale = 0;
			pauseindicator = true;
			bgm.Pause();
		} 

		else 
		{
			Time.timeScale = 1;
			pauseindicator = false;
			bgm.Play();
		}
	}
}
