using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rotateanimation : MonoBehaviour {
	public GameObject avatar;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine ("rotateanim");
	}

	IEnumerator rotateanim()
	{
		transform.localRotation = Quaternion.Euler (0, 0, 20);
		yield return new WaitForSeconds (1f);
		transform.localRotation = Quaternion.Euler (0, 0, -20);
		yield return new WaitForSeconds (1f);
	}
}
