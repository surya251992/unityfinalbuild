using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class deathcount : MonoBehaviour {
	public Text dc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//dc.text = PlayerPrefs.GetInt ("DeathCount").ToString ();
		dc.text = Advertisement.isInitialized.ToString() + PlayerPrefs.GetInt ("DeathCount").ToString ()+ Advertisement.IsReady("video").ToString();
	}
}
