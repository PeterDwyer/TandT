using UnityEngine;
using System.Collections;

public class SelectSong : MonoBehaviour 
{	
	public GameObject ExitToMain;
	public LayerMask Mask;
	public bool tt;
	public RaycastHit hit;
	public GameObject target;
	public int song;
	public GameObject Manager;
	public GameObject Song1;
	public GameObject Song2;
	public GameObject LoadMenu;
	public GameObject Restart;
	public GameObject Story;
	public GameObject BeginStory;
	public GameObject ChooseAGame;
	public GameObject Next;
	public GameObject Back;
	public GameObject Bag;
	public GameObject Stickers;
	public GameObject PlayPegs;
	public int text = 0;
	public Ray ray;
	public Touch theTouch1;
	public GameObject Text1;
	public GameObject Text2;
	public GameObject Text3;
	public GameObject Text4;
	public GameObject Text5;
	public GameObject Tap;
	public int storyI;
	public GameObject Animations;
	public GameObject tnt;
	public GameObject[] Coats;
	public Material[] CoatsMat;
	public GameObject BackInGame;
	public GameObject ExitGame;
	public GameObject Info;
	public bool Active = true;
	public GameObject Fader;
	
	void Awake()
	{
		
	}
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
	    if (Application.platform == RuntimePlatform.Android)
        {
			if(Application.loadedLevel != 1)
			{
				if (Input.GetKey(KeyCode.Escape))
				{
					GameObject.Find("SingletOn").SendMessage("dKe", 0);
					Application.LoadLevel("StartScreen");
	 
					return;
				}
			}
			else{
				if (Input.GetKey(KeyCode.Escape))
				{
					GameObject.Find("Logs").SendMessage("End");
					Application.Quit();
	 
					return;
				}
			}
		}
		
		if(Active)
		{
			//if(Input.touchCount > 0)
			if(Input.GetButton("Fire1"))
			{
				tt = true;
				//theTouch1 = Input.GetTouch(0);
				//ray = Camera.main.ScreenPointToRay(theTouch1.position);
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if(Physics.Raycast(ray,out hit,1000f,Mask))
				{
					target = hit.collider.gameObject;
					if(target == Song1 || target == Song2)
					{
						target.transform.localScale = new Vector3(3.13f,2.484f,0.621f);
					}
					else if(target == Info)
					{
						target.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
					}
					else if(target == Restart)
					{
						if(storyI == 26)
						{
							target.transform.localScale = new Vector3(4.12f,1f,0.82f);
						}
						else{
							target.transform.localScale = new Vector3(3.64f,3.7f,0.81f);
						}
					}
					else if(target == PlayPegs)
					{
						if(storyI == 17)
						{
							target.transform.localScale = new Vector3(5.2f,0.001f,0.747f);
						}
						else if(storyI != 24)
						{
							target.transform.localScale = new Vector3(4.0f,0.001f,0.63f);
						}

						else
						{
							
						}
					}
					else if(target == ExitGame || target == ExitToMain)
					{
						target.transform.localScale = new Vector3(0.756f,1.2f,0.756f);
					}
					else if(target == LoadMenu)
					{
						target.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
					}
					else if(target == Manager)
					{
						target.transform.localScale = new Vector3(3.7f,1.2f,3.7f);
					}
					else if(target == Story)
					{
						target.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
					}
					else if(target == Next)
					{
						target.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
					}
					else if(target == Back)
					{
						target.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
					}
					else if(target == BackInGame)
					{
						target.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
					}
					else if(target == Text5)
					{
						if(storyI == 16)
						{
							target.transform.localScale = new Vector3(4.8f,1.2f,0.5f);
						}
						if(storyI == 20)
						{
							target.transform.localScale = new Vector3(4.8f,1.2f,0.65f);
						}
						if(storyI == 21)
						{
							target.transform.localScale = new Vector3(4.3f,1.2f,0.65f);
						}
						if(storyI == 22)
						{
							target.transform.localScale = new Vector3(4.0f,1.2f,0.65f);
						}
					}
				}
				else
				{
					if(target != null)
					{
						if(target == Song1 || target == Song2)
						{
							target.transform.localScale = new Vector3(3.464291f,2.7f,0.690841f);
						}
						else if(target == Restart)
						{
							if(storyI == 26)
							{
								target.transform.localScale = new Vector3(4.58f,1f,0.9f);
							}
							else{
								target.transform.localScale = new Vector3(4.06f,1f,0.9f);
							}
						}
						else if(target == PlayPegs)
						{
							if(storyI == 17)
							{
								target.transform.localScale = new Vector3(5.8f,0.001f,0.83f);
							}
							else if(storyI != 24)
							{
								target.transform.localScale = new Vector3(4.2f,0.001f,0.65f);
							}
							else
							{
								
							}
						}
						else if(target == ExitGame || target == ExitToMain)
						{
							target.transform.localScale = new Vector3(0.84f,1.2f,0.84f);
						}
						else if(target == LoadMenu)
						{
							target.transform.localScale = new Vector3(1.28f,1.28f,1.28f);
						}
						else if(target == Story)
						{
							target.transform.localScale = new Vector3(1.28f,1.28f,1.28f);
						}
						else if(target == Next)
						{
							target.transform.localScale = new Vector3(1.28f,1.28f,1.28f);
						}
						else if(target == Back)
						{
							target.transform.localScale = new Vector3(1.28f,1.28f,1.28f);
						}
						else if(target == BackInGame)
						{
							target.transform.localScale = new Vector3(1.28f,1.28f,1.28f);
						}
						else if(target == Text5)
						{
							if(storyI == 16)
							{
								target.transform.localScale = new Vector3(5.0f,1.2f,0.648f);
							}
							if(storyI == 20)
							{
								target.transform.localScale = new Vector3(5.0f,1.2f,0.68f);
							}
							if(storyI == 21)
							{
								target.transform.localScale = new Vector3(4.48f,1.2f,0.68f);
							}
							if(storyI == 22)
							{
								target.transform.localScale = new Vector3(4.2f,1.2f,0.68f);
							}
						}
						else if(target == Manager)
						{
							target.transform.localScale = new Vector3(4.17f,1.2f,4.17f);
						}
						else if(target == Info)
						{
							target.transform.localScale = new Vector3(0.8413f,0.8f,0.8413f);
						}
					}
				}
			}
			else if(tt)
			{
	
				//CallFunkc
				Active = false;
				StartCoroutine(Scene());
			}
		}
	}
	
	IEnumerator Scene()
	{
		Vector3 tmpPos;
		Color tmpCol;
		
		if(target != null)
		{
			if(target == ExitToMain)
			{
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
				yield return new WaitForSeconds(0.5f);
				GameObject.Find("SingletOn").SendMessage("dKe", (int) 0);
				Application.LoadLevel("StartScreen");
			}
			if(target == ExitGame)
			{
				if(storyI == 26)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("StartScreen");
				}
				else if(storyI == 50)
				{
					if(PlayerPrefs.GetInt("Story") == 1)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield return new WaitForSeconds(0.5f);
						Application.LoadLevel("Bell");
					}
					else{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield return new WaitForSeconds(0.5f);
						Application.LoadLevel("menu");
					}
				}
				else if(PlayerPrefs.GetString("Prev") == "Bell")
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("Bell");
				}
				else if(Application.loadedLevelName == "SingAlong")
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 2);
					Application.LoadLevel(Application.loadedLevel);
				}
				else
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel(Application.loadedLevel);
				}
			}
			if(target == Song1)
			{
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
				yield return new WaitForSeconds(0.5f);
				Manager.SetActive(true);
				GameObject.Find("SingletOn").SendMessage("dKe", 5);
				
				tmpPos = Camera.main.transform.position;
				tmpPos.y = 1;
				Camera.main.transform.position = tmpPos;
				song = 1;
				GameObject.Find("Logs").SendMessage("Log", "FOLLOW_TOPSY");
			}
			if(target == Song2)
			{
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
				Manager.SetActive(true);
				GameObject.Find("SingletOn").SendMessage("dKe", 6);
				tmpPos = Camera.main.transform.position;
				tmpPos.y = 1;
				Camera.main.transform.position = tmpPos;
				song = 2;
				GameObject.Find("Logs").SendMessage("Log", "FOLLOW_TIM");
			}
			if(target == LoadMenu)
			{
				if(PlayerPrefs.GetInt("Story") == 1)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					if(Application.loadedLevelName == "Pegs" || Application.loadedLevelName == "Jigsaw")
					{
						GameObject.Find("SingletOn").SendMessage("dKe", 1);
					}
					
					if(Application.loadedLevelName == "Line")
					{
						GameObject.Find("SingletOn").SendMessage("dKe", 2);
					//	Application.LoadLevel("MenuMatchIntro");
					}
					
					if(Application.loadedLevelName == "MenuMatch")
					{
						GameObject.Find("SingletOn").SendMessage("dKe", 4);
					}
					
					if(Application.loadedLevelName == "SingAlong")
					{
						GameObject.Find("SingletOn").SendMessage("dKe", 1);
					}
					
					if(Application.loadedLevelName == "ScalesGame")
					{
						GameObject.Find("SingletOn").SendMessage("dKe", 4);
					}
					
					Application.LoadLevel(PlayerPrefs.GetString("Next"));
				}
				else
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					GameObject.Find("Logs").SendMessage("Log", "CHOOSE_GAME");
					Application.LoadLevel("menu");
				}
			}
			if(target == Restart)
			{
				if(storyI == 26)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 0);
					Application.LoadLevel("StartScreen");
				}
				else
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("Logs").SendMessage("Log", "PLAY_AGAIN");
					Application.LoadLevel(Application.loadedLevel);
				}
			}
			if(target == Story)
			{
				if(storyI == 11)
				{
					Story.SetActive(false);
					Manager.SetActive(false);
					BeginStory.SetActive(true);
					Next.SetActive(true);
				}
				else if(storyI == 10)
				{}
				else if(storyI == 9)
				{}
				else
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetInt("Story", 1);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					GameObject.Find("Logs").SendMessage("Log", "BEGIN_STORY");
					Application.LoadLevel("Story");

				}
			}
			if(target == tnt)
			{
				if(storyI == 11)
				{
					tnt.SetActive(false);
					Manager.SetActive(false);
					Text3.SetActive(false);
					Text4.SetActive(false);
					Text5.SetActive(true);
					BeginStory.SetActive(true);
					Next.SetActive(true);
					GameObject.Find("Logs").SendMessage("Log", "FIND_TOPSYTIM");
				}
			}
			if(target == Info)
			{
				// Take us to the info about charm.
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
				yield return new WaitForSeconds(0.5f);
				Application.LoadLevel("StartScrInfo");
			}
			if(target == Text5)
			{
				if(storyI == 16)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetString("Prev", "NewClass");
					PlayerPrefs.SetString("Next", "JigsawIntro");
					PlayerPrefs.Save();
					GameObject.Find("Logs").SendMessage("Log", "BALANCE_SCALES_STORY");
					Application.LoadLevel("ScalesGame");
				}
				if(storyI == 20)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetString("Prev", "Bell");
					PlayerPrefs.SetString("Next", "MenuMatchIntro");
					PlayerPrefs.Save();
					GameObject.Find("Logs").SendMessage("Log", "LUNCH_LINE");
					Application.LoadLevel("Line");
				}
				if(storyI == 21)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetString("Prev", "MenuMatchIntro");
					PlayerPrefs.SetString("Next", "SingALongIntro");
					PlayerPrefs.Save();
					GameObject.Find("Logs").SendMessage("Log", "MENU_MATCH_STORY");
					Application.LoadLevel("MenuMatch");
				}
				if(storyI == 22)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetString("Prev", "SingALongIntro");
					PlayerPrefs.SetString("Next", "GoHome");
					PlayerPrefs.Save();
					GameObject.Find("Logs").SendMessage("Log", "SING_A_LONG_STORY");
					Application.LoadLevel("SingAlong");
				}
				
			}
			if(target == tnt || target == Tap)
			{
				if(storyI == 24)
				{
					Text1.SetActive(false);
					Text2.SetActive(true);
				}
			}
			if(target == PlayPegs)
			{
				if(storyI == 17)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetString("Prev", "JigsawIntro");
					PlayerPrefs.SetString("Next", "Bell");
					PlayerPrefs.Save();
					GameObject.Find("Logs").SendMessage("Log", "JIGSAW_PUZZLE_STORY");
					Application.LoadLevel("Jigsaw");
				}
				else if(storyI == 24)
				{
					GameObject.Find("Logs").SendMessage("Log", "FIND_PEG");
					Text1.SetActive(false);
					Text2.SetActive(false);
					Text3.SetActive(false);
					Manager.SetActive(false);
					Text4.SetActive(true);
					
					tmpCol = Tap.renderer.material.color;
					tmpCol.a = 0.7f;
					PlayPegs.renderer.material.color = tmpCol;
					
					tmpCol = PlayPegs.renderer.material.color;
					tmpCol.a = 0.7f;
					Tap.renderer.material.color = tmpCol;
					
					tmpCol = tnt.renderer.material.color;
					tmpCol.a = 0.7f;
					tnt.renderer.material.color = tmpCol;
					
					PlayPegs.layer = 0;
					Tap.layer = 0;
					tnt.layer = 0;
					Coats[0].renderer.material = CoatsMat[0];
					Coats[1].renderer.material = CoatsMat[1];
					StartCoroutine(GoOut());
				}
				else
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					PlayerPrefs.SetString("Prev", "PegsIntro");
					PlayerPrefs.SetString("Next", "NewClass");
					PlayerPrefs.Save();
					GameObject.Find("Logs").SendMessage("Log", "PEG_PAIRS_STORY");
					Application.LoadLevel("Pegs");
					PlayerPrefs.Save();
				}
			}
			else if(target == BackInGame)
			{
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
				yield return new WaitForSeconds(0.5f);
				if(PlayerPrefs.GetInt("Story") == 1)
				{
					Application.LoadLevel(PlayerPrefs.GetString("Prev"));
				}
				else{
					PlayerPrefs.SetInt("Story", 0);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					GameObject.Find("Logs").SendMessage("Log", "CHOOSE_GAME");
					Application.LoadLevel("menu");
				}
			}
			if(target == BeginStory)
			{
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
				PlayerPrefs.SetInt("Story", 1);
				GameObject.Find("Logs").SendMessage("Log", "BEGIN_STORY");
				Application.LoadLevel("Story");
			}
			if(target == ChooseAGame)
			{
				Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
				PlayerPrefs.SetInt("Story", 0);
				GameObject.Find("SingletOn").SendMessage("dKe", 4);
				GameObject.Find("Logs").SendMessage("Log", "CHOOSE_GAME");
				Application.LoadLevel("menu");
			}
			if(target == Back)
			{
				if(storyI == 0)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", (int) 0 );
					Application.LoadLevel("StartScreen");
				}
				if(storyI == 1)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("Logs").SendMessage("Log", "BEGIN_STORY");
					Application.LoadLevel("Story");
				}
				if(storyI == 2)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel(Application.loadedLevel);
				}
				if(storyI == 3)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					Application.LoadLevel("Character");
				}
				if(storyI == 4)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel(Application.loadedLevel);
				}
				if(storyI == 5)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("SchoolBag");
				}
				if(storyI == 6)
				{
					storyI = 5;
					Text1.SetActive(true);
					Text2.SetActive(false);
					Tap.SetActive(false);
					Next.SetActive(true);
				}
				if(storyI == 7)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					storyI = 5;
					GameObject.Find("SingletOn").SendMessage("dKe", 2);
					Application.LoadLevel("ToSchool");
				}
				if(storyI == 8)
				{
					storyI = 7;
					Text1.SetActive(true);
					Text2.SetActive(false);
				}
				if(storyI == 9)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					storyI = 8;
					Application.LoadLevel("EnterSchool");
				}
				if(storyI == 10)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					storyI = 9;
					Application.LoadLevel("EnterSchool");
				}
				if(storyI == 11)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					storyI = 10;
					
					Application.LoadLevel("EnterSchool");
				}
				if(storyI == 12)
				{
					storyI = 11;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					Application.LoadLevel("InSchool");
				}
				if(storyI == 13)
				{
					storyI = 12;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					Application.LoadLevel("InSchool");
				}
				if(storyI == 14)
				{
					storyI = 13;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					Application.LoadLevel("PegsIntro");
				}
				if(storyI == 15)
				{
					storyI = 14;
					Text1.SetActive(true);
					Animations.SetActive(true);
					Text2.SetActive(false);
					Text4.SetActive(false);
					
					tmpPos = tnt.transform.position;
					tmpPos.x -= 13.0f;
					tmpPos.y -= 3.0f;
					tnt.transform.position = tmpPos;
				}
				if(storyI == 16)
				{
					storyI = 15;
					Text3.SetActive(false);
					Text5.SetActive(false);
					Text1.SetActive(false);
					Animations.SetActive(false);
					Text2.SetActive(true);
					Text4.SetActive(true);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
				}
				if(storyI == 17)
				{
					storyI = 16;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("NewClass");
				}
				else if(storyI == 18)
				{
					storyI = 17;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					Application.LoadLevel("JigsawIntro");
				}
				else if(storyI == 19)
				{
					storyI = 18;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("JigsawIntro");
				}
				else if(storyI == 20)
				{
					storyI = 19;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("Bell");
				}
				else if(storyI == 21)
				{
					storyI = 20;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					Application.LoadLevel("Bell");	
				}
				else if(storyI == 22)
				{
					storyI = 21;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 2);
					Application.LoadLevel("MenuMatchIntro");	
				}
				else if(storyI == 23)
				{
					storyI = 22;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					Application.LoadLevel("SingALongIntro");	
				}
				else if(storyI == 24)
				{
					storyI = 23;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("GoHome");	
				}
				else if(storyI == 25)
				{
					storyI = 24;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("PickCoat");	
				}

			}
			if(target == Next)
			{
				if(storyI == 0)
				{
					if(text == 0)
					{
						text = 1;
						Text1.SetActive(false);
						Text2.SetActive(true);
						Text3.SetActive(true);
					}
					else if(text == 1)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield return new WaitForSeconds(0.5f);
						Application.LoadLevel("Character");
					}
				}
				if(storyI == 2)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 2);
					GameObject.Find("Logs").SendMessage("Log", "CREATE_FACE");
					Application.LoadLevel("SchoolBag");
				}
				else if(storyI == 3)
				{
					GameObject.Find("Logs").SendMessage("Log", "SCHOOL_BAG");
					Bag.SetActive(false);
					Stickers.SetActive(true);
					Next.SetActive(false);
					storyI = 4;
				}
				else if(storyI == 4)
				{
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("Logs").SendMessage("Log", "STICKER_CHOSEN");
					Application.LoadLevel("ToSchool");
				}
				else if(storyI == 5)
				{
					storyI = 6;
					Text1.SetActive(false);
					Text2.SetActive(true);
					Tap.SetActive(true);
					Next.SetActive(false);
				}
				else if(storyI == 6)
				{
					storyI = 7;
					Text1.SetActive(false);
					Text2.SetActive(false);
					Tap.SetActive(false);
					Next.SetActive(false);
					Back.SetActive(false);
					Animations.SetActive(true);
					GameObject.Find("SingletOn").SendMessage("dKe", 3);
					GameObject.Find("Logs").SendMessage("Log", "SCHOOL_NAME");
				}
				else if(storyI == 7)
				{
					storyI = 8;
					Text1.SetActive(false);
					Text2.SetActive(true);	
				}
				else if(storyI == 8)
				{
					storyI = 9;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("InSchool");	
				}
				else if(storyI == 9)
				{
					storyI = 10;
					Text1.SetActive(false);
					Text2.SetActive(true);	
				}
				else if(storyI == 10)
				{
					storyI = 11;
					Text2.SetActive(false);
					Text3.SetActive(true);	
					Text4.SetActive(true);	
					Animations.SetActive(true);	
					Next.SetActive(false);
				}
				else if(storyI == 11)
				{
					storyI = 12;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					//GameObject.Find("SingletOn").SendMessage("Log", "dKe", 4);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					Application.LoadLevel("PegsIntro");	
				}
				else if(storyI == 12)
				{
					storyI = 13;
					Text1.SetActive(false);
					Text2.SetActive(true);
					PlayPegs.SetActive(true);
				}
				else if(storyI == 13)
				{
					storyI = 14;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					Application.LoadLevel("NewClass");	
				}
				else if(storyI == 14)
				{
					storyI = 15;
					Text1.SetActive(false);
					Animations.SetActive(false);
					Text2.SetActive(true);
					Text4.SetActive(true);
					
					tmpPos = tnt.transform.position;
					tmpPos.x += 13.0f;
					tmpPos.y += 3.0f;

					tnt.transform.position = tmpPos;
				}
				else if(storyI == 15)
				{
					storyI = 16;
					GameObject.Find("SingletOn").SendMessage("dKe", 2);
					Text2.SetActive(false);
					Text3.SetActive(true);
					Text5.SetActive(true);
				}
				else if(storyI == 16)
				{
					storyI = 17;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					Application.LoadLevel("JigsawIntro");	
				}
				else if(storyI == 17)
				{
					storyI = 18;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("Bell");	
				}
				else if(storyI == 18)
				{
					storyI = 19;
					Text1.SetActive(false);
					Text2.SetActive(true);
				}
				else if(storyI == 19)
				{
					storyI = 20;
					Text2.SetActive(false);
					Text3.SetActive(true);
					Text5.SetActive(true);
				}
				else if(storyI == 20)
				{
					storyI = 21;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 2);
					Application.LoadLevel("MenuMatchIntro");	
				}
				else if(storyI == 21)
				{
					GameObject.Find("SingletOn").SendMessage("dKe", 4);
					storyI = 22;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("SingALongIntro");	
				}
				else if(storyI == 22)
				{
					storyI = 23;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 1);
					Application.LoadLevel("GoHome");	
				}
				else if(storyI == 23)
				{
					storyI = 24;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("PickCoat");	
				}
				else if(storyI == 24)
				{
					storyI = 25;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					Application.LoadLevel("End");	
				}
				else if(storyI == 25)
				{
					storyI = 26;
					Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
					yield return new WaitForSeconds(0.5f);
					GameObject.Find("SingletOn").SendMessage("dKe", 3);
					Application.LoadLevel("EndScreen");	
				}
			}
		}
		
		tt = false;
		Active = true;
		target = null;
	}
	
	void SetStory( int a )
	{
		storyI = a;
	}
	
	IEnumerator GoOut()
	{
		yield return new WaitForSeconds(3.5f);
		//fade
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("Exit");
	}
}