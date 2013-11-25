using UnityEngine;
using System.Collections;

public class Movables : MonoBehaviour 
{
	public float additive = 0.0f;
	
	void Start()
	{
		Vector3 tmpPos;
		
		if((Screen.width*1.0)/(Screen.height*1.0)<1.7)
		{
			tmpPos = transform.position;
			tmpPos.x -= 9 + additive; 
			transform.position = tmpPos;
		}
		if((Screen.width*1.0)/(Screen.height*1.0)<1.5)
		{
			tmpPos = transform.position;
			tmpPos.x -= 8 + additive;
			transform.position = tmpPos;
		}
	}
	
	void Update () 
	{
	
	}
}