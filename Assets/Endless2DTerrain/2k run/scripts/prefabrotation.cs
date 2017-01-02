using UnityEngine;
using System.Collections;

public class prefabrotation : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		transform.localRotation = Quaternion.Euler (0, 270, 0);
	}
}
