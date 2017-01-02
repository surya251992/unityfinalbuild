using UnityEngine;
using System.Collections;

public class bazookafire : MonoBehaviour {
	public Vector2 speed;
	Rigidbody2D rb;
	public float destroy;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = speed;
	}
}
