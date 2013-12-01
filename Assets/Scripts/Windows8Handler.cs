using UnityEngine;
using System.Collections;

public class Windows8Handler : MonoBehaviour 
{
	private static GameObject pauseBanner;

	public static void PauseGame(bool p)
	{
		Vector3 pos ;
		GameObject camera = GameObject.Find("Main Camera");

		if(p)
		{
			if(Screen.width < 1024)
			{
				if( pauseBanner == null )
				{
					pauseBanner = (GameObject) Instantiate( Resources.Load("Paused") ) ;
					pos = pauseBanner.transform.position;
					pos.x = camera.transform.position.x;
					pos.y = camera.transform.position.y;

					pauseBanner.transform.position = pos;
				}
				else
				{
					pos = pauseBanner.transform.position;
					pos.x = camera.transform.position.x;
					pos.y = camera.transform.position.y;
					pos.z = camera.transform.position.z + 5;
					
					pauseBanner.transform.position = pos;

					pauseBanner.SetActive( true );
				}

				Time.timeScale = 0.0f;
				AudioListener.pause = true;
			}
		}
		else
		{
			if( pauseBanner == null )
			{
				pauseBanner = (GameObject) Instantiate( Resources.Load("Paused") ) ;
				pos = pauseBanner.transform.position;
				pos.x = camera.transform.position.x;
				pos.y = camera.transform.position.y;
				pos.z = camera.transform.position.z + 5;

				pauseBanner.transform.position = pos;
			}
			else
			{
				pos = pauseBanner.transform.position;
				pos.x = camera.transform.position.x;
				pos.y = camera.transform.position.y;
				
				pauseBanner.transform.position = pos;

				pauseBanner.SetActive( false );
			}

			Time.timeScale = 1.0f;
			AudioListener.pause = false;
		}
	}

	public static void ShowSettings( bool settings )
	{

	}
}
