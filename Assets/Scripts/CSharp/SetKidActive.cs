using UnityEngine;
using System.Collections;

public class SetKidActive : MonoBehaviour 
{	
	public Material MainMaterial;
	public Material ActiveMaterial;
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		
	}
	
	void Active()
	{
		renderer.material = ActiveMaterial;
	}
	
	void Deactive()
	{
		renderer.material = MainMaterial;
	}
}