using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentMoney : MonoBehaviour {
	public Text cash;
	void Start () {
		cash.text = "Rs." + PlayerPrefs.GetInt ("Money").ToString(); 
		}
}
