using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour 
{
	public int scenenumber;

	public void OnClick()
	{
		SceneManager.LoadScene (scenenumber);
	}
	
}
