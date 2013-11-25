using UnityEngine;
using System.Collections;

public class Sticker : MonoBehaviour 
{	
	public Material[] Pegs;
	public int n;
	
	void Start () 
	{
	 	n = PlayerPrefs.GetInt("stickerNum");
	 	renderer.material = Pegs[n];
	}
	
	void Update () 
	{
	}
}