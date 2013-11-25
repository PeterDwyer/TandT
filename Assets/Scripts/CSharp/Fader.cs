using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour 
{
	public bool a;
	
	IEnumerator Start () 
	{
		yield return new WaitForSeconds(0.56f);
		a = true;
	}
	
	void Update () 
	{
		Color tmpCol;
		tmpCol = renderer.material.color;
		
		if(!a)
		{
			tmpCol.a += 0.05f;
			renderer.material.color = tmpCol;
		}
		else
		{
			tmpCol.a -= 0.05f;
			renderer.material.color = tmpCol;
		}
	}
}