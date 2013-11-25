using UnityEngine;
using System.Collections;

public class ScalesDif : MonoBehaviour 
{	
	public GameObject Mng;
	public GameObject element1;
	public GameObject element2;
	public GameObject element3;
	public GameObject element4;
	public GameObject element5;
	
	void Start () 
	{
	//	Mng = GameObject.Find("Manager");
		ScalesGame MngScript = Mng.GetComponent<ScalesGame>();
		
		MngScript.e[0] = element1;
		MngScript.e[1] = element2;
		MngScript.e[2] = element3;
		MngScript.e[3] = element4;
		MngScript.e[4] = element5;
		Mng.SetActive(true);
	}
	
	void Update () 
	{
	
	}
}