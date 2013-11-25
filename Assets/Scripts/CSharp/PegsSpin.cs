using UnityEngine;
using System.Collections;

public class PegsSpin : MonoBehaviour 
{
	public float delay = 0.0f;
	public float delayBack = 0.0f;
	public bool spin;
	public bool spinBack;
	public int dif;
	public bool Menu;
	public Vector3 pos;
	public bool faces;
	public float y;
	
	IEnumerator Start () 
	{
		if(faces)
		{
			y = 6.2f;
		}
		
		if(!Menu)
		{
			yield return new WaitForSeconds(delay);
			spin = true;
			Pegs Pgs = (Pegs) GameObject.Find("Manager").GetComponent("Pegs");
			dif = Pgs.dif;
			
			if(dif == 0)
			{
				delayBack -= 3.75f;
			}
			
			if(dif == 1)
			{
				delayBack -= 1.75f;
			}
			
			if(dif == 2)
			{
				delayBack += 0.25f;
			}
			
			yield return new WaitForSeconds(delayBack-delay);
			
			spin = false;
			spinBack = true;
			
			yield return new WaitForSeconds(1f);
			
			spinBack = false;
			Destroy(this);
		}
		else
		{
			pos = transform.position;
			
			yield return new WaitForSeconds(delay);
			
			spin = true;
			MenuMatch MM = (MenuMatch) GameObject.Find("Manager").GetComponent("MenuMatch");
			dif = MM.dif;
			
			if(dif == 0)
			{
				delayBack -= 2.75f;
			}
			
			if(dif == 1)
			{
				delayBack -= 1.75f;
			}
			
			if(dif == 2)
			{
				delayBack -= 0.25f;
			}
			
			yield return new WaitForSeconds(delayBack-delay);
			
			spin = false;
			spinBack = true;
			
			yield return new WaitForSeconds(1.3f);
			
			spinBack = false;
			Destroy(this);
		}
	}
	
	void Update () 
	{
		if(!Menu)
		{
			if(spin)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(90f, 360f, 0f)), Time.deltaTime * 3.5f);
			}
			
			if(spinBack)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(90f, 180f, 0f)), Time.deltaTime * 3.5f);
			}
		}
		else
		{
			if(spin)
			{
				transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, pos.y + 12 + y, transform.position.z), 5.5f/50f);
			}
			
			if(spinBack)
			{
				transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, pos.y, transform.position.z), 5.5f/50f);
			}
		}
	}
}