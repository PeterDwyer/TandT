using UnityEngine;
using System.Collections;

public class Windows8Handler : MonoBehaviour {
	public static void PauseGame(bool p)
	{
		if(p)
		{
			if(Screen.width < 1024)
			{
				Time.timeScale = 0.0f;
				AudioListener.pause = true;
			}
		}
		else
		{
			Time.timeScale = 1.0f;
			AudioListener.pause = false;
		}
	}

	public static void ShowSettings( bool settings )
	{

	}
}
