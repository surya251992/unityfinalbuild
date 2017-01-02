using UnityEngine;
using System.Collections;

public class backgroundimagechanger : MonoBehaviour {
	public SpriteRenderer sr;
	public Sprite[] spr;
	private int i = 0;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator changeImage()
	{
		sr.sprite = spr [i];
		i++;
		yield return new WaitForSeconds (1);
	}
}
