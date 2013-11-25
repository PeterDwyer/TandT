using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour 
{
	public Transform target;
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		transform.position = target.position;
		transform.rotation = target.rotation;
	}
}