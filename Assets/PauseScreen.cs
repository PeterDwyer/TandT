using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour 
{
	GameObject pauseScreen;
	// Use this for initialization
	void Start () 
	{
		pauseScreen = GameObject.Find("Pause");

		GameObject.DontDestroyOnLoad( pauseScreen );
		pauseScreen.SetActive( false );
	}
}
