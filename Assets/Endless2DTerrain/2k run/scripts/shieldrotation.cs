using UnityEngine;
using System.Collections;

public class shieldrotation : MonoBehaviour {


		void Start () 
		{
			transform.localRotation = Quaternion.Euler (0, 180, 0);
		}

}
