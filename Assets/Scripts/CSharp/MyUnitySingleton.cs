using UnityEngine;
using System.Collections;

public class MyUnitySingleton : MonoBehaviour 
{
	private static MyUnitySingleton instance;
	
    public static MyUnitySingleton GetInstance() 
	{
    	return instance;
    }
     
	public AudioClip[] music;
	
    void Awake() 
	{
		audio.loop = true;
		
		if (instance != null && instance != this) 
		{
			Destroy(this.gameObject);
			return;
		} 
		else 
		{
			instance = this;
		}
		
		DontDestroyOnLoad(this.gameObject);
    }
	void Start()
	{
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.Landscape;
	}
	void dKe( int i )
	{
		audio.Stop();
		audio.clip = music[i];
		audio.Play();
	}
	void sto()
	{
		audio.Pause();
	}
	void sta()
	{
		audio.Play();
	}
}