using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class fadescreenlogo : MonoBehaviour {

	public Image FadeImage;

	// Use this for initialization
	IEnumerator Start () {
		FadeImage.canvasRenderer.SetAlpha (0.0f);

		FadeIn ();
		yield return new WaitForSeconds(4f);
		FadeOut();
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("startscreen");
	}

	void FadeIn () 
	{
		FadeImage.CrossFadeAlpha (1.0f, 1.5f, false);
	
	}

	void FadeOut () 
	{
		FadeImage.CrossFadeAlpha (0.0f, 2.5f, false);

	}
}
