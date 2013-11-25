using UnityEngine;
using System.Collections;

public class FaceChange : MonoBehaviour 
{
	public GameObject[] Faces;
	public int i = 0;
	public bool Change = false;
	
	void Start () 
	{
		Debug.Log("Staring");
		StartCoroutine(Next());
	}
	
	void Update () 
	{
		Color tmpCol;
		//Debug.Log( Change );
		if(Change)
		{	
			tmpCol = Faces[i].renderer.material.color;
			tmpCol.a -= Time.deltaTime*2;
			
			Faces[i].renderer.material.color = tmpCol;
			
	//		Debug.Log( Faces[i].renderer.material.color.a );
			
			if( i < 3 )
			{
				tmpCol = Faces[i+1].renderer.material.color;
				tmpCol.a += Time.deltaTime * 2;
				
				Faces[i+1].renderer.material.color = tmpCol;
				
				if(Faces[i+1].renderer.material.color.a > 0.999f && Faces[i].renderer.material.color.a < 0.001f)
				{
					i += 1;
					Change = false;
					StartCoroutine(Next());
				}
			}
			else if(i == 3)
			{
				tmpCol = Faces[0].renderer.material.color;
				tmpCol.a += Time.deltaTime * 2;
				
				Faces[0].renderer.material.color = tmpCol;
				
				if(Faces[0].renderer.material.color.a > 0.999f && Faces[i].renderer.material.color.a < 0.001f)
				{
					i = 0;
					Change = false;
					StartCoroutine(Next());
				}
			}
		}
	}
	
	IEnumerator Next()
	{
		//Debug.Log( "In Next" );
		yield return new WaitForSeconds(1f);
		Change = true;
	}
}