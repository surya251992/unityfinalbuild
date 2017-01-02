using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	
    public Camera playerCamera;
	
    public float speed = 30.0F;
    public float jumpSpeed = 45.0F;
    public float gravity = 85.0F;

	public int whitemoney = 0;
	private int blackmoney = 0;

	public Text LightsCount;
	public Text blackmoneycount;

	public int boostcounter = 0;
	public int boostcounterfive = 0;

    private Vector3 moveDirection = Vector3.zero;

	public GameObject BoostLight;
	public GameObject BoostLightFive;
	public GameObject obstacle;
	public Image sc;

	private bool boost = false;
	private bool boostfive = false;
	private bool gamestart = true;

	public GameObject[] pinkboostindicator;
	public GameObject[] greenboostindicator;

	public flash fl;
	public SoundBehavior sb;

	public ParticleSystem lifeball;

    void Start()
    {
		//sc.enabled = false;
		LightsCount.text = "White Money : " + whitemoney.ToString ();
		blackmoneycount.text = "Black Money : " + blackmoney.ToString ();
		BoostLightFive.SetActive (false);
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
		if (!PlayerPrefs.HasKey ("Death Count") || PlayerPrefs.GetInt("Death Count") > 3) 
		{
			PlayerPrefs.SetInt ("Death Count", 0);
		}
		print (PlayerPrefs.GetInt("Death Count").ToString());

		StartCoroutine ("FirstRun");
        playerCamera.transparencySortMode = TransparencySortMode.Orthographic;
    }

    void Update()
    {    
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(1, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed; 
            }
            if (Input.touchCount > 0)
            {
                moveDirection.y = jumpSpeed;
            }
           
        }
        moveDirection.y -= gravity * Time.smoothDeltaTime;
        controller.Move(moveDirection * Time.smoothDeltaTime);
        //After we move, adjust the camera to follow the player
        playerCamera.transform.position = new Vector3(transform.position.x + 40, transform.position.y + 15, playerCamera.transform.position.z);
    }

	void OnTriggerEnter(Collider item)
	{
		if (item.tag == "kill" && boost == false && boostfive == false && gamestart == false) {
			PlayerPrefs.SetInt ("Money", whitemoney);
			PlayerPrefs.SetInt ("Total Money", PlayerPrefs.GetInt("Total Money") + whitemoney);
			PlayerPrefs.SetInt ("Death Count", (PlayerPrefs.GetInt ("Death Count") + 1));
			print (PlayerPrefs.GetInt("Death Count").ToString());
			if (PlayerPrefs.GetInt ("Death Count") >= 3) 
			{
				print ("Adunit entered");
				PlayerPrefs.SetInt ("Death Count", 0);
				if (Advertisement.IsReady())
				{
					Advertisement.Show ();
				}
			}
			Application.LoadLevel (5);
		} 

		else if (item.tag == "100"){
			sb.PlayAudio (0);
			whitemoney = whitemoney + 100;
			LightsCount.text = "White Money : " + whitemoney.ToString ();
			print (whitemoney);
		}
		else if (item.tag == "500"){
			sb.PlayAudio (1);
			if (boostfive == false && boost == false) {
				greenboostindicator [boostcounterfive].SetActive (true);
				boostcounterfive = boostcounterfive + 1;
			}
			whitemoney = whitemoney + 500;
			LightsCount.text = "White Money : " + whitemoney.ToString ();
			print (whitemoney);
			if (boostcounterfive == 4 && !boost && !boostfive) 
			{
				fl.startlight();
				StartCoroutine ("BoostTimeFive");
			}
		}
		else if (item.tag == "2000"){
			sb.PlayAudio (2);
			whitemoney = whitemoney + 2000;
			LightsCount.text = "White Money : " + whitemoney.ToString ();
			if (boostfive == false && boost == false) {
				pinkboostindicator [boostcounter].SetActive (true);
				boostcounter = boostcounter + 1;
			}
			if (boostcounter == 2 && !boost && !boostfive) 
			{
				if (blackmoney > 1000) 
				{
					blackmoney = blackmoney - 2000;
				} 

				else if (blackmoney == 1000) 
				{
					blackmoney = blackmoney - 1000;
				}

				blackmoneycount.text = "Black Money : " + blackmoney.ToString ();
				fl.startlight();
				StartCoroutine ("BoostTime");

 			}
			//print (whitemoney);
		}
		else if (item.tag == "1000" && boost == false && boostfive == false && gamestart == false){
			sb.PlayAudio (3);
			Handheld.Vibrate();
			if(blackmoney<3000)
			{
				blackmoney = blackmoney + 1000;
				blackmoneycount.text = "Black Money : " + blackmoney.ToString ();
				print (whitemoney);
			}
			else if(blackmoney >= 3000)
			{
				print ("entered");
				PlayerPrefs.SetInt ("Money", whitemoney);
				PlayerPrefs.SetInt ("Total Money", PlayerPrefs.GetInt("Total Money") + whitemoney);
				PlayerPrefs.SetInt ("Death Count", (PlayerPrefs.GetInt ("Death Count") + 1));
				print (PlayerPrefs.GetInt("Death Count").ToString());
				if (PlayerPrefs.GetInt ("Death Count") >= 3) 
				{
					print ("Adunit entered");
					PlayerPrefs.SetInt ("Death Count", 0);
					if (Advertisement.IsReady())
					{
						Advertisement.Show ();
					}
				}
				Application.LoadLevel (4);
			}
			Handheld.Vibrate();
		}
			
	}

	IEnumerator BoostTime(){
		lifeball.Play ();
		Handheld.Vibrate();
		Handheld.Vibrate();
		boost = true;
		BoostLight.SetActive (true);
		speed = speed + 30;
		yield return new WaitForSeconds(7);
		lifeball.Stop ();
		speed = speed - 30f;
		for (int i = 0; i < 3; i++) 
		{
			yield return new WaitForSeconds (0.2f);
			BoostLight.SetActive (false);
			yield return new WaitForSeconds (0.2f);
			BoostLight.SetActive (true);
		}
		yield return new WaitForSeconds (0.2f);
		BoostLight.SetActive (false);
		boostcounter = 0;
		boost = false;
		pinkboostindicator [0].SetActive (false);
		pinkboostindicator [1].SetActive (false);
	}

	IEnumerator BoostTimeFive(){
		lifeball.Play ();
		Handheld.Vibrate();
		Handheld.Vibrate();
		boostfive = true;
		BoostLightFive.SetActive (true);
		speed = speed + 20;
		yield return new WaitForSeconds(6);
		lifeball.Stop ();
		yield return new WaitForSeconds(1);
		BoostLightFive.SetActive (false);
		speed = speed - 20f;
		for (int i = 0; i < 3; i++) 
		{
			yield return new WaitForSeconds (0.2f);
			BoostLightFive.SetActive (false);
			yield return new WaitForSeconds (0.2f);
			BoostLightFive.SetActive (true);
		}
		yield return new WaitForSeconds (0.2f);
		BoostLightFive.SetActive (false);
		boostcounterfive = 0;
		boostfive = false;
		greenboostindicator [0].SetActive (false);
		greenboostindicator [1].SetActive (false);
		greenboostindicator [2].SetActive (false);
		greenboostindicator [3].SetActive (false);
	}

	IEnumerator FirstRun()
	{
		yield return new WaitForSeconds (3);
		gamestart = false;
		lifeball.Stop();
	}
		
}
