using UnityEngine;
using System.Collections;

public class Waving : MonoBehaviour 
{	
	public float rotUp;
	public float rotDown;
	public bool up;
	public bool down;
	public float speed;
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		Vector3 tmpPos;
		Quaternion qRotation;
		if(up)
		{
			qRotation = transform.rotation;
			tmpPos = transform.rotation.eulerAngles;
			tmpPos.z  += Time.deltaTime * speed;
			qRotation.eulerAngles = tmpPos;
			
			transform.rotation = qRotation;
			
			if(transform.rotation.eulerAngles.z > rotUp || transform.rotation.eulerAngles.z < rotDown)
			{
				up = false;
				down = true;
			}
		}
		
		if(down)
		{
			qRotation = transform.rotation;
			tmpPos = transform.rotation.eulerAngles;
			tmpPos.z  -= Time.deltaTime * speed;
			qRotation.eulerAngles = tmpPos;
			
			transform.rotation = qRotation;
			
			if(transform.rotation.eulerAngles.z < rotDown || transform.rotation.eulerAngles.z > rotUp)
			{
				down = false;
				up = true;
			}
		}
	}
}