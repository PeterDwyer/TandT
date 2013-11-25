using UnityEngine;
using System.Collections;

public class DestroySingleton : MonoBehaviour 
{
	public GameObject SingletOn;
	
	void Start () 
	{
		SingletOn = GameObject.Find("SingletOn");
	
		if(SingletOn != null)
		{
			Destroy(SingletOn);
		}
	}
	
	void Update () 
	{
	
	}
}