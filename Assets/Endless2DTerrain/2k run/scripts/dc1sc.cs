using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dc1sc : MonoBehaviour {
	public Image img;
	public Image home;
	public Image restart;
	public AudioSource reciept;

	public Text score;

	private int i = 1;
	// Use this for initialization
	void Start () {
		img.enabled = false;
		home.enabled = false;
		restart.enabled = false;
		score.enabled = false;
		StartCoroutine ("LoadImage");
	}

	IEnumerator LoadImage()
	{
		yield return new WaitForSeconds (2);
		img.enabled = true;
		home.enabled = true;
		restart.enabled = true;
		score.enabled = true;
		reciept.Play ();
	}

	/*void Update() {
		if (i == 1) {
			StartCoroutine ("waittime");
			i++;
		}
		
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			SceneManager.LoadScene (4);
		}
	}*/

		/*IEnumerator waittime()
		{
			yield return new WaitForSeconds (2.2f);
		}*/

}
