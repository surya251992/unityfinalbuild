//http://dreamlo.com/lb/uMRm45C1S0-yS_rPrOI-bwUz9XjrtPWUycjuSXrA_KHA
//private-uMRm45C1S0-yS_rPrOI-bwUz9XjrtPWUycjuSXrA_KHA
//public-582f1c4e8af6030c8c68f64f

using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	const string weburl = "http://dreamlo.com/lb/";
	const string privatecode = "uMRm45C1S0-yS_rPrOI-bwUz9XjrtPWUycjuSXrA_KHA";
	const string publiccode = "582f1c4e8af6030c8c68f64f";

	public Highscore[] highscoresList;

	void Awake()
	{
		AddNewHighScore ("surya", 5000);
		AddNewHighScore ("chandu", 2000);
		AddNewHighScore ("teja", 3000);
		DownloadHighScores ();
	}

	public void AddNewHighScore(string username,int score)
	{
		StartCoroutine (UploadNewHighScore(username,score));
	}

	IEnumerator UploadNewHighScore (string username,int score)
	{
		string finalurl = weburl + privatecode + "/add/" + WWW.EscapeURL (username) + "/" + score;
		WWW www = new WWW(weburl + privatecode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		print (finalurl);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("upload success");
		} 

		else {
			print (www.error);
		}
	}

	public void DownloadHighScores()
	{
		print ("dummy class");
		StartCoroutine ("DownloadHighScoresFromDB");
	}

	IEnumerator DownloadHighScoresFromDB()
	{
		print ("entered");
		WWW www = new WWW (weburl + publiccode + "/pipe/");
		yield return www;
		print (www.text);
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighScores (www.text);
		} else {
			print (www.error);
		}
	}

	 void FormatHighScores(string textStream){
		string[] entries = textStream.Split (new char[]{'\n'},System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];
		print ("entered");
		for (int i = 0; i < entries.Length; i++) 
		{
			string[] entryInfo = entries [i].Split (new char[] { '|' });
			string username = entryInfo [0];
			int score = int.Parse (entryInfo [1]);
			highscoresList [i] = new Highscore (username, score);
			print (highscoresList[i].username + ":" + highscoresList[i].score);
		}
	}

}

	public struct Highscore 
	{
		public string username;
		public int score;

		public Highscore(string _username,int _score)
		{
			username = _username;
			score = _score;

		}
	}

