using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour 
{

	public bool dis;
	public bool en;
	public bool el;
	
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		Color tmpCol;
		
		if(dis)
		{
			tmpCol = renderer.material.color;
			tmpCol.a -= Time.deltaTime;
			renderer.material.color = tmpCol;
			
			if(renderer.material.color.a < 0.01)
			{
				if(el)
				{
					Destroy(gameObject);
				}
				else{
					StartCoroutine(ChangeB());
					dis = false;
				}
			}
		}
		
		if(en)
		{
			tmpCol = renderer.material.color;
			tmpCol.a += Time.deltaTime;
			renderer.material.color = tmpCol;
			
			if(renderer.material.color.a > 0.99)
			{
				en = false;
			}
		}
	}
	
	IEnumerator Change()
	{
		yield return new WaitForSeconds(1);
		dis = true;
	}
	
	IEnumerator ChangeB()
	{
		yield return new WaitForSeconds(0.5f);
		en = true;
		GameObject.Find("Manager").SendMessage("en");
	}
}