using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Money : MonoBehaviour {

	public Text score;

	// Use this for initialization
	void Start () {
		score.text = PlayerPrefs.GetInt ("Total Money").ToString(); 
	}
}
