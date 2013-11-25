using UnityEngine;
using System.Collections;

public class ActiveAfterYield : MonoBehaviour 
{	
	public float time;
	public GameObject obj;
	
	IEnumerator Start () 
	{
		yield return new WaitForSeconds(time);
	
		obj.SetActive(true);
		gameObject.SetActive(false);
	}
	
	void Update () 
	{
	
	}
}