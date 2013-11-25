using UnityEngine;
using System.Collections;

public class SplashAnimation : MonoBehaviour 
{	
    float delta;
    float Speed = 24f;
	int i;
    //public Texture2D[] Textures;
	
    void Start () 
	{
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.orientation = ScreenOrientation.AutoRotation;
		//yield return new WaitForSeconds(3.9f);
		Application.LoadLevel("StartScreen");
	}
	
	void Update () 
	{
		/*delta += Time.deltaTime;
		
		if(i<74)
		{
			if(delta>1.0f/Speed)
			{
				i += 1;
				delta = 0.0f;
			}
			
			renderer.material.mainTexture = Textures[i];
		}*/	
	}
}