using UnityEngine;
using System.Collections;

public class FaceManager : MonoBehaviour 
{
	public GameObject GirlPre;
	public GameObject GirlPre2;
	public GameObject BoyPre;
	public GameObject BoyPre2;
	public int Gender;
	
	void Start () 
	{
		Gender = PlayerPrefs.GetInt("Gender");
		
		if(Gender == 0)
		{
			BoyPre.SetActive(true);
			BoyPre2.SetActive(true);
		}
		else if(Gender == 1)
		{
			GirlPre.SetActive(true);
			GirlPre2.SetActive(true);
		}
	}
	
	void Update () 
	{
	
	}
}