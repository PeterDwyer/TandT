using UnityEngine;
using System.Collections;

public class Difficulty : MonoBehaviour 
{
	public float camPos = 0.0f;
	public bool setDif = true;
	public int dif;
	public GUISkin skin;
	public GameObject easy;
	public GameObject med;
	public GameObject hard;
	public Texture2D easyI;
	public Texture2D medI;
	public Texture2D hardI;
	public Vector2 groupPosition;
	public float btnAmplifier;
	public float space;
	public float[] btnScale;
	public LayerMask layerMask;
	public GUISkin btn1;
	public GUISkin btn2;
	public GUISkin btn3;
	public GameObject manager;
	private RaycastHit hit;
	public bool scales;
	public bool jigsaw;
	public bool pegs;
	public bool menu;
	public GameObject faces;
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		if(scales)
		{
			groupPosition.x = Screen.width/2f+Screen.width/4.5f;
			groupPosition.y = Screen.height / 2f - Screen.height/2.5f;
			btnAmplifier = Screen.height/4.0f / 380.0f;
			space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2;
		}
		if(jigsaw)
		{
			groupPosition.x = Screen.width/2f-(easyI.width * 2f * btnAmplifier + space*2f + medI.width* btnAmplifier)/2f;
			groupPosition.y = Screen.height / 3.5f;
			btnAmplifier = Screen.height/4.0f / 380.0f;
			space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2;
		}
		if(pegs)
		{
			space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2f;
			groupPosition.x = Screen.width/2f - (medI.width*btnAmplifier)/2f;
			groupPosition.y = Screen.height -(space/4f * 3f + (medI.height*btnAmplifier)*3f);
			btnAmplifier = Screen.height/4.0f / 380.0f;
		}
		if(menu)
		{
			space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2f;
			groupPosition.x = Screen.width/2f - (medI.width*btnAmplifier)/2f;
			groupPosition.y = Screen.height -(space/2f * 6f + (medI.height*btnAmplifier)*3f);
			btnAmplifier = Screen.height/4.0f / 380.0f;
		}
		/*//if(Input.touchCount > 0)
		if(Input.GetButton("Fire1"))
		{
			//public theTouch : Touch = Input.GetTouch(0);
			//public ray = Camera.main.ScreenPointToRay(theTouch.position);
			public ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,hit,500,layerMask))
			{
				print("sth");
				if(hit.collider.gameObject.name == "btn1")
				{
					hit.collider.gameObject.transform.localScale = Vector3(1.9, 1, 0.7);
				}
			}
		}
		else if(Input.GetButtonUp("Fire1"))
		{
			
		}*/
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		Vector3 tempPos;
		
		if(setDif)
		{
			if(scales)
			{
				GUI.BeginGroup(new Rect(groupPosition.x, groupPosition.y, medI.width * btnAmplifier, medI.height * btnAmplifier * 3f + (space)*3f));
				GUI.skin = btn1;
				
				if(GUI.Button(new Rect(space,0f, easyI.width * btnAmplifier*btnScale[0], easyI.height* btnAmplifier*btnScale[0]*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "EASY");
					btnScale[0] = 0.8f;
					dif = 0;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					//manager.SetActive(true);
					easy.SetActive(true);
					setDif = false;
				}
				
				GUI.skin = btn2;
				
				if(GUI.Button(new Rect(0f,medI.height * btnAmplifier + space, medI.width * btnAmplifier, medI.height* btnAmplifier*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "MEDIUM");
					dif = 1;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					med.SetActive(true);
					
					setDif = false;
				}
				
				GUI.skin = btn3;
				
				if(GUI.Button(new Rect(space,(medI.height * btnAmplifier + space)*2, easyI.width * btnAmplifier, easyI.height* btnAmplifier*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "HARD");
					dif = 2;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					hard.SetActive(true);
					setDif = false;
				}
				
				GUI.EndGroup();
			}
			
			if(jigsaw)
			{
				GUI.BeginGroup(new Rect(groupPosition.x, groupPosition.y, medI.width * 3 * btnAmplifier, medI.height * btnAmplifier));
				GUI.skin = btn1;
			
				if(GUI.Button(new Rect(0f,0f, easyI.width * btnAmplifier*btnScale[0], easyI.height* btnAmplifier*btnScale[0]*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "EASY");
					btnScale[0] = 0.8f;
					dif = 0;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					easy.SetActive(true);
					setDif = false;
				}
				
				GUI.skin = btn2;
				
				if(GUI.Button(new Rect(easyI.width* btnAmplifier + space ,0f, medI.width * btnAmplifier, medI.height* btnAmplifier*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "MEDIUM");
					dif = 1;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					med.SetActive(true);
					
					setDif = false;
				}
				
				GUI.skin = btn3;
				
				if(GUI.Button(new Rect(easyI.width* btnAmplifier + space*2f + medI.width* btnAmplifier ,0f, easyI.width * btnAmplifier, easyI.height* btnAmplifier*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "HARD");
					dif = 2;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					hard.SetActive(true);
					setDif = false;
				}
				
				GUI.EndGroup();
			}
			
			if(pegs || menu)
			{
				GameObject.Find("Logs").SendMessage("Log", "EASY");
				GUI.BeginGroup(new Rect(groupPosition.x, groupPosition.y, medI.width * btnAmplifier, medI.height * btnAmplifier * 3f + (space)*3f));
				GUI.skin = btn1;
			
				if(GUI.Button(new Rect(space,0f, easyI.width * btnAmplifier, easyI.height* btnAmplifier*1.1f), ""))
				{
					dif = 0;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					setDif = false;
				}
				
				GUI.skin = btn2;
				
				if(GUI.Button(new Rect(0f,medI.height * btnAmplifier-space/4f, medI.width * btnAmplifier, medI.height* btnAmplifier*1.1f), ""))
				{
					GameObject.Find("Logs").SendMessage("Log", "MEDIUM");
					dif = 1;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);
					
					setDif = false;
				}
				
				GUI.skin = btn3;
				
				if(GUI.Button(new Rect(space,(medI.height * btnAmplifier)*2f-space/4f, hardI.width * btnAmplifier, hardI.height* btnAmplifier*1.1f), ""))
				{	
					GameObject.Find("Logs").SendMessage("Log", "HARD");
					dif = 2;
					tempPos = transform.position;
					tempPos.y = camPos;
					transform.position = tempPos;
					manager.SetActive(true);;
					setDif = false;
				}
				
				GUI.EndGroup();
			}
			
		}
	}
}