using UnityEngine;
using System.Collections;

public class CrossBar : MonoBehaviour 
{
	public bool l;
	public bool c;
	public bool r;
	public bool basket;
	public float speed;
	public AudioClip cor;
	public AudioClip dis;
	
	void Start () 
	{
			if(basket)
			{
				speed = 9.0f;
			}
			else
			{
				speed = 3.0f;
			}
	}
	
	void Update () 
	{
		if(l)
		{
			//float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 20.0, 50.0 * Time.deltaTime);
			//transform.eulerAngles = Vector3(0, 0, angle);	
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, 18f)), Time.deltaTime * speed);
		}
		if(c)
		{
			//angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 0.0, 50.0 * Time.deltaTime);
			//transform.eulerAngles = Vector3(0, 0, angle);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, 0f)), Time.deltaTime * speed);
		}
		if(r)
		{
			//angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, -20.0, 50.0 * Time.deltaTime);
			//transform.eulerAngles = Vector3(0, 0, angle);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, -18f)), Time.deltaTime * speed);
		}
	}
	
	void Center()
	{
		c = true;
		l = false;
		r = false;
		
		if(!basket)
		{
			audio.clip = cor;
			audio.Play();
		}
	}
	
	void Right()
	{
		c = false;
		l = false;
		r = true;
		
		if(basket)
		{
			c = true;
			l = false;
			r = false;
		}
		else
		{
			audio.clip = dis;
			audio.Play();
		}
	}
	
	void Left()
	{
		c = false;
		l = true;
		r = false;
		
		if(basket)
		{
			c = true;
			l = false;
			r = false;
		}
	}
}