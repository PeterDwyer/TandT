using UnityEngine;
using System.Collections;

public class GamesMenu : MonoBehaviour 
{
	public Texture2D[] Icons;
	public float groupWidth;
	public float groupHeight;
	public float icoSize;
	public GUISkin skin;
	public GUISkin[] ItemsSkin;
		
	void Start () 
	{
		icoSize = Screen.height * 0.45f;
		
		groupWidth = ((icoSize)*3+2*(Screen.height*0.06f));
		groupHeight = ((icoSize)*2+Screen.height*0.06f);
		print(groupWidth);
	}
	
	void Update () 
	{
		icoSize = Screen.height * 0.45f;
		
		groupWidth = ((icoSize*0.70625f)*3f+2f*(Screen.height*0.06f));
		groupHeight = ((icoSize)*2f+Screen.height*0.07f);
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.BeginGroup (new Rect (Screen.width / 2f - groupWidth/2f, Screen.height / 2f - groupHeight/2f+Screen.height*0.02f, groupWidth, groupHeight));
		GUI.skin = ItemsSkin[0];
		
		if (GUI.Button(new Rect(0f,Screen.height*0.08f,icoSize*0.70625f,icoSize),""))
		{
			//PegPairs
			GameObject.Find("Logs").SendMessage("Log", "PEG_PAIRS");
			Application.LoadLevel("Pegs");
		}
		
		GUI.skin = ItemsSkin[1];
		
		if (GUI.Button(new Rect(icoSize*0.70625f+Screen.height*0.06f,Screen.height*0.08f,icoSize*0.70625f,icoSize),""))
		{
			//ScalesGame
			GameObject.Find("Logs").SendMessage("Log", "BALANCE_SCALES");
			Application.LoadLevel("ScalesGame");
		}
		
		GUI.skin = ItemsSkin[2];
		
		if (GUI.Button(new Rect(2f*(icoSize*0.70625f+Screen.height*0.06f),Screen.height*0.08f,icoSize*0.70625f,icoSize),""))
		{
			GameObject.Find("Logs").SendMessage("Log", "JIGSAW_PUZZLE");
			Application.LoadLevel("Jigsaw");
		}
		
		GUI.skin = ItemsSkin[3];
		
		if (GUI.Button(new Rect(0f,icoSize+Screen.height*0.07f,icoSize*0.70625f,icoSize),""))
		{
			//LineUp
			GameObject.Find("Logs").SendMessage("Log", "LUNCH_LINE");
			Application.LoadLevel("Line");
		}
		
		GUI.skin = ItemsSkin[4];
		
		if (GUI.Button(new Rect(icoSize*0.70625f+Screen.height*0.06f,icoSize+Screen.height*0.07f,icoSize*0.70625f,icoSize),""))
		{
			//MenuMatch
			GameObject.Find("Logs").SendMessage("Log", "MENU_MATCH");
			Application.LoadLevel("MenuMatch");
		}
		
		GUI.skin = ItemsSkin[5];
		
		if (GUI.Button(new Rect(2*(icoSize*0.70625f+Screen.height*0.06f),icoSize+Screen.height*0.07f,icoSize*0.70625f,icoSize),""))
		{
			//Sing
			GameObject.Find("Logs").SendMessage("Log", "SING_A_LONG");
			Application.LoadLevel("SingALong");
		}
		
		GUI.EndGroup();
	}
}