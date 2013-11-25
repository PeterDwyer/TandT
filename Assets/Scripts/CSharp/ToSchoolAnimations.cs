using UnityEngine;
using System.Collections;

public class ToSchoolAnimations : MonoBehaviour 
{	
	public GameObject[] TTM;
	public GameObject[] Walkers;
	public GameObject[] Cars;
	public GameObject TnT;
	public GameObject res;
	public GameObject We;
	public float i;
	public bool InSchool;
	public bool end;
	
	IEnumerator Start() 
	{
		yield return new WaitForSeconds(10.0f);
		
		if(end)
		{
			Destroy(GameObject.Find("SingletOn"));
			//Destroy(TnT);
			//Destroy(this);
			 //We.SetActive(true);
			Application.LoadLevel("StartScreen");
		}
	}
	
	void Update () 
	{
		Vector3 tmpPos1;
		Vector3 tmpPos2;
		Vector3 tmpPos3;
		
		if(end)
		{
			tmpPos1 = Cars[2].transform.position;
			tmpPos1.x -= Time.deltaTime*50f;
			tmpPos1.y = Mathf.Sin(i*1.7f)*0.3f-4.37f;
			
			Cars[2].transform.position = tmpPos1;
			
			tmpPos1 = Cars[1].transform.position;
			tmpPos1.x += Time.deltaTime*30f;
			Cars[1].transform.position = tmpPos1;
			
			i += Time.deltaTime*10;
		}	
		else if(!InSchool)
		{
			tmpPos1 = TTM[0].transform.position;
			tmpPos2 = TTM[1].transform.position;
			tmpPos3 = TTM[2].transform.position;
			
			tmpPos1.x += Time.deltaTime*32f;
			tmpPos2.x += Time.deltaTime*32f;
			tmpPos3.x += Time.deltaTime*32f;
			
			TTM[0].transform.position = tmpPos1;
			TTM[1].transform.position = tmpPos2;
			TTM[2].transform.position = tmpPos3;
			
			tmpPos1 = Cars[0].transform.position;
			tmpPos2 = Cars[1].transform.position;
			
			tmpPos1.x += Time.deltaTime*50f;
			tmpPos2.x -= Time.deltaTime*20f;
			
			Cars[0].transform.position = tmpPos1;
			Cars[1].transform.position = tmpPos2;
			
			tmpPos1 = Walkers[0].transform.position;
			tmpPos2 = Walkers[1].transform.position;
			tmpPos3 = Walkers[2].transform.position;
			
			tmpPos1.x += Time.deltaTime*8f;
			tmpPos2.x += Time.deltaTime*10f;
			tmpPos3.x += Time.deltaTime*10f;
			
			Walkers[0].transform.position = tmpPos1;
			Walkers[1].transform.position = tmpPos2;
			Walkers[2].transform.position = tmpPos3;
			
			tmpPos1 = Camera.main.transform.position;
			tmpPos1.x += Time.deltaTime*27f;
			Camera.main.transform.position = tmpPos1;
			
			i += Time.deltaTime*10;
			
			tmpPos1 = TTM[0].transform.position;
			tmpPos2 = TTM[1].transform.position;
			tmpPos3 = TTM[2].transform.position;
			
			tmpPos1.y = Mathf.Sin(i)*0.5f-29.0f;
			tmpPos2.y = Mathf.Sin(i)*0.8f-29.0f;
			tmpPos3.y = Mathf.Sin(i)*1.1f-29.0f;
			
			TTM[0].transform.position = tmpPos1;
			TTM[1].transform.position = tmpPos2;
			TTM[2].transform.position = tmpPos3;
			
			tmpPos1 = Walkers[0].transform.position;
			tmpPos2 = Walkers[1].transform.position;
			tmpPos3 = Walkers[2].transform.position;
			
			tmpPos1.y = Mathf.Sin(i)*0.25f-29.0f;
			tmpPos2.y = Mathf.Sin(i)*0.4f-29.0f;
			tmpPos3.y = Mathf.Sin(i)*0.3f-29.0f;
			
			Walkers[0].transform.position = tmpPos1;
			Walkers[1].transform.position = tmpPos2;
			Walkers[2].transform.position = tmpPos3;
					
			tmpPos1 = Cars[0].transform.position;		
			tmpPos1.y = Mathf.Sin(i*1.7f)*0.3f-4.37f;
			
			Cars[0].transform.position = tmpPos1;
			
			if( TTM[0].transform.position.x > 550.0f )
			{
				GameObject.Find("SingletOn").SendMessage("dKe", 1);
				Application.LoadLevel("EnterSchool");
			}
		}
		else
		{
			i += Time.deltaTime*10f;
			
			tmpPos1 = TnT.transform.position;
			tmpPos1.y = Mathf.Sin(i*0.8f)*0.7f-18.43f;
			TnT.transform.position = tmpPos1;
		}
	}
}