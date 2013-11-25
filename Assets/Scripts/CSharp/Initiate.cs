using UnityEngine;
using System.Collections;

public class Initiate : MonoBehaviour 
{
	void Start () 
	{
		PlayerPrefs.SetInt("Init", 1);
	}
}