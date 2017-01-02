using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTargetSceneButton : MonoBehaviour {

	public void LoadSceneNum(int num)
	{
		if (num < 0 || num >= SceneManager.sceneCountInBuildSettings) 
		{
			Debug.LogWarning ("cant load scene num" + num + ",scene manager only has" + SceneManager.sceneCountInBuildSettings + "scenes");
			return;
		}

		LoadingScreenManager.LoadScene (num);
	}
}
