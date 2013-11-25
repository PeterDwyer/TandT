using UnityEngine;
using System.Collections;

public class PopUpIcons : MonoBehaviour 
{	
	public float i;
	public float timeDif;
	public bool pop;
	public Vector3 old;
	public Vector3 newScale;
	
	IEnumerator Start () 
	{
		old = transform.localScale;
		yield return new WaitForSeconds(timeDif*i);
		pop = true;
	}
	
	void Update () 
	{
		if( pop )
		{
			transform.localScale = Vector3.Slerp(transform.localScale, newScale, Time.deltaTime * 6);
		}	
	}
}