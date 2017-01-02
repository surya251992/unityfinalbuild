using UnityEngine;
using System.Collections;

public class rotategrass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		transform.localRotation = Quaternion.Euler (-90, 0, 0);
}
}
