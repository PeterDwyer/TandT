using UnityEngine;
using System.Collections;

public class ScalesHandler : MonoBehaviour 
{	
	public float groupWidth;
	public float groupHeight;
	public float icoSize;
	
	void Start () 
	{
		icoSize = Screen.height * 0.2f;
		groupWidth = ((icoSize)*5f+4f*(Screen.height*0.01f));
		groupHeight = ((icoSize)+Screen.height*0.01f);
		transform.position = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f - groupWidth/2f, Screen.height - groupHeight,0f)).GetPoint(5);
	}
	
	void Update () 
	{
		icoSize = Screen.height * 0.2f;
		groupWidth = ((icoSize)*5f+4f*(Screen.height*0.01f));
		groupHeight = ((icoSize)+Screen.height*0.01f);
		transform.position = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f - groupWidth/2f, Screen.height - groupHeight,0f)).GetPoint(5);
	}
}