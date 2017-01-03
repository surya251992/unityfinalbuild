using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour {
	
	public Light myLight;
	public GameObject dl;
	//public Light dirlight;

	int i;

	void Start () {
		
		myLight = GetComponent<Light> ();
	}

	public void startlight()
	{
		StartCoroutine ("flashlight");
	}



		IEnumerator flashlight()
		{
		//dirlight.enabled = false;
		myLight.enabled = true;
				for (i = 1; i < 4; i++) {
			        myLight.color = Color.blue;
					yield return new WaitForSeconds (0.09f);
					myLight.color = Color.cyan;
			        yield return new WaitForSeconds (0.09f);
			        myLight.color = Color.magenta;
			        yield return new WaitForSeconds (0.09f);
				}
		myLight.enabled = false;
		//dirlight.enabled = true;
			
		}
	
	}
