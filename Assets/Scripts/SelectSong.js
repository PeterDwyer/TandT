#pragma strict
var ExitToMain:GameObject;
var Mask:LayerMask;
var tt:boolean;
var hit:RaycastHit;
var target:GameObject;
var song:int;
var Manager:GameObject;
var Song1:GameObject;
var Song2:GameObject;
var LoadMenu:GameObject;
var Restart:GameObject;
var Story:GameObject;
var BeginStory:GameObject;
var ChooseAGame:GameObject;
var Next:GameObject;
var Back:GameObject;
var Bag:GameObject;
var Stickers:GameObject;
var PlayPegs:GameObject;
var text:int = 0;
var ray:Ray;
var theTouch1 : Touch;
var Text1:GameObject;
var Text2:GameObject;
var Text3:GameObject;
var Text4:GameObject;
var Text5:GameObject;
var Tap:GameObject;
var storyI:int;
var Animations:GameObject;
var tnt:GameObject;
var Coats:GameObject[];
var CoatsMat:Material[];
var BackInGame:GameObject;
var ExitGame:GameObject;
var Info:GameObject;
var Active:boolean = true;
var Fader:GameObject;
function Awake()
{
	
}
function Start () {
	
}

function Update () {
    if (Application.platform == RuntimePlatform.Android)
            {
				if(Application.loadedLevel != 1)
				{
					if (Input.GetKey(KeyCode.Escape))
					{
						gameObject.Find("SingletOn").SendMessage("dKe", 0);
						Application.LoadLevel("StartScreen");
		 
						return;
					}
				}
				else{
					if (Input.GetKey(KeyCode.Escape))
					{
						gameObject.Find("Logs").SendMessage("End");
						Application.Quit();
		 
						return;
					}
				}
			}
	if(Active)
	{
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			tt = true;
			theTouch1 = Input.GetTouch(0);
			ray = Camera.main.ScreenPointToRay(theTouch1.position);
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,hit,1000,Mask))
					{
						target = hit.collider.gameObject;
						if(target == Song1 || target == Song2)
						{
							target.transform.localScale = Vector3(3.13,2.484,0.621);
						}
						else if(target == Info)
						{
							target.transform.localScale = Vector3(0.8,0.8,0.8);
						}
						else if(target == Restart)
						{
							if(storyI == 26)
							{
								target.transform.localScale = Vector3(4.12,1,0.82);
							}
							else{
								target.transform.localScale = Vector3(3.64,3.7,0.81);
							}
						}
						else if(target == PlayPegs)
						{
							if(storyI == 17)
							{
								target.transform.localScale = Vector3(5.2,0.001,0.747);
							}
							else if(storyI != 24)
							{
								target.transform.localScale = Vector3(4.0,0.001,0.63);
							}

							else
							{
								
							}
						}
						else if(target == ExitGame || target == ExitToMain)
						{
							target.transform.localScale = Vector3(0.756,1.2,0.756);
						}
						else if(target == LoadMenu)
						{
							target.transform.localScale = Vector3(1.2,1.2,1.2);
						}
						else if(target == Manager)
						{
							target.transform.localScale = Vector3(3.7,1.2,3.7);
						}
						else if(target == Story)
						{
							target.transform.localScale = Vector3(1.2,1.2,1.2);
						}
						else if(target == Next)
						{
							target.transform.localScale = Vector3(1.2,1.2,1.2);
						}
						else if(target == Back)
						{
							target.transform.localScale = Vector3(1.2,1.2,1.2);
						}
						else if(target == BackInGame)
						{
							target.transform.localScale = Vector3(1.2,1.2,1.2);
						}
						else if(target == Text5)
						{
							if(storyI == 16)
							{
								target.transform.localScale = Vector3(4.8,1.2,0.5);
							}
							if(storyI == 20)
							{
								target.transform.localScale = Vector3(4.8,1.2,0.65);
							}
							if(storyI == 21)
							{
								target.transform.localScale = Vector3(4.3,1.2,0.65);
							}
							if(storyI == 22)
							{
								target.transform.localScale = Vector3(4.0,1.2,0.65);
							}
						}
					}
				else
				{
					if(target != null)
					{
						if(target == Song1 || target == Song2)
						{
							target.transform.localScale = Vector3(3.464291,2.7,0.690841);
						}
						else if(target == Restart)
						{
							if(storyI == 26)
							{
								target.transform.localScale = Vector3(4.58,1,0.9);
							}
							else{
								target.transform.localScale = Vector3(4.06,1,0.9);
							}
						}
						else if(target == PlayPegs)
						{
							if(storyI == 17)
							{
								target.transform.localScale = Vector3(5.8,0.001,0.83);
							}
							else if(storyI != 24)
							{
								target.transform.localScale = Vector3(4.2,0.001,0.65);
							}
							else
							{
								
							}
						}
						else if(target == ExitGame || target == ExitToMain)
						{
							target.transform.localScale = Vector3(0.84,1.2,0.84);
						}
						else if(target == LoadMenu)
						{
							target.transform.localScale = Vector3(1.28,1.28,1.28);
						}
						else if(target == Story)
						{
							target.transform.localScale = Vector3(1.28,1.28,1.28);
						}
						else if(target == Next)
						{
							target.transform.localScale = Vector3(1.28,1.28,1.28);
						}
						else if(target == Back)
						{
							target.transform.localScale = Vector3(1.28,1.28,1.28);
						}
						else if(target == BackInGame)
						{
							target.transform.localScale = Vector3(1.28,1.28,1.28);
						}
						else if(target == Text5)
						{
							if(storyI == 16)
							{
								target.transform.localScale = Vector3(5.0,1.2,0.648);
							}
							if(storyI == 20)
							{
								target.transform.localScale = Vector3(5.0,1.2,0.68);
							}
							if(storyI == 21)
							{
								target.transform.localScale = Vector3(4.48,1.2,0.68);
							}
							if(storyI == 22)
							{
								target.transform.localScale = Vector3(4.2,1.2,0.68);
							}
						}
						else if(target == Manager)
						{
							target.transform.localScale = Vector3(4.17,1.2,4.17);
						}
						else if(target == Info)
						{
							target.transform.localScale = Vector3(0.8413,0.8,0.8413);
						}
					}
				}
		}
		else if(tt)
		{

			//CallFunkc
			Active = false;
			Scene();
		}
	}
}
function Scene()
{
			if(target != null)
				{
					if(target == ExitToMain)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield WaitForSeconds(0.5);
						gameObject.Find("SingletOn").SendMessage("dKe", 0);
						Application.LoadLevel("StartScreen");
					}
					if(target == ExitGame)
					{
						if(storyI == 26)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("StartScreen");
						}
						else if(storyI == 50)
						{
							if(PlayerPrefs.GetInt("Story") == 1)
							{
								Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
								yield WaitForSeconds(0.5);
								Application.LoadLevel("Bell");
							}
							else{
								Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
								yield WaitForSeconds(0.5);
								Application.LoadLevel("menu");
							}
						}
						else if(PlayerPrefs.GetString("Prev") == "Bell")
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("Bell");
						}
						else if(Application.loadedLevelName == "SingAlong")
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 2);
							Application.LoadLevel(Application.loadedLevel);
						}
						else
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel(Application.loadedLevel);
						}
					}
					if(target == Song1)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
						Manager.SetActive(true);
						gameObject.Find("SingletOn").SendMessage("dKe", 5);
						Camera.main.transform.position.y = 1;
						song = 1;
						gameObject.Find("Logs").SendMessage("Log", "FOLLOW_TOPSY");
					}
					if(target == Song2)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
						Manager.SetActive(true);
						gameObject.Find("SingletOn").SendMessage("dKe", 6);
						Camera.main.transform.position.y = 1;
						song = 2;
						gameObject.Find("Logs").SendMessage("Log", "FOLLOW_TIM");
					}
					if(target == LoadMenu)
					{
						if(PlayerPrefs.GetInt("Story") == 1)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							if(Application.loadedLevelName == "Pegs" || Application.loadedLevelName == "Jigsaw")
							{
								gameObject.Find("SingletOn").SendMessage("dKe", 1);
							}
							if(Application.loadedLevelName == "Line")
							{
								gameObject.Find("SingletOn").SendMessage("dKe", 2);
							//	Application.LoadLevel("MenuMatchIntro");
							}
							if(Application.loadedLevelName == "MenuMatch")
							{
								gameObject.Find("SingletOn").SendMessage("dKe", 4);
							}
							if(Application.loadedLevelName == "SingAlong")
							{
								gameObject.Find("SingletOn").SendMessage("dKe", 1);
							}
							if(Application.loadedLevelName == "ScalesGame")
							{
								gameObject.Find("SingletOn").SendMessage("dKe", 4);
							}
							Application.LoadLevel(PlayerPrefs.GetString("Next"));
						}
						else{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							gameObject.Find("Logs").SendMessage("Log", "CHOOSE_GAME");
							Application.LoadLevel("menu");
						}
					}
					if(target == Restart)
					{
						if(storyI == 26)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 0);
							Application.LoadLevel("StartScreen");
						}
						else{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("Logs").SendMessage("Log", "PLAY_AGAIN");
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
						else{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							PlayerPrefs.SetInt("Story", 1);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							gameObject.Find("Logs").SendMessage("Log", "BEGIN_STORY");
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
							gameObject.Find("Logs").SendMessage("Log", "FIND_TOPSYTIM");
						}
					}
					if(target == Info)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield WaitForSeconds(0.5);
						Application.LoadLevel("StartScrInfo");
					}
					if(target == Text5)
					{
						if(storyI == 16)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							PlayerPrefs.SetString("Prev", "NewClass");
							PlayerPrefs.SetString("Next", "JigsawIntro");
							PlayerPrefs.Save();
							gameObject.Find("Logs").SendMessage("Log", "BALANCE_SCALES_STORY");
							Application.LoadLevel("ScalesGame");
						}
						if(storyI == 20)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							PlayerPrefs.SetString("Prev", "Bell");
							PlayerPrefs.SetString("Next", "MenuMatchIntro");
							PlayerPrefs.Save();
							gameObject.Find("Logs").SendMessage("Log", "LUNCH_LINE");
							Application.LoadLevel("Line");
						}
						if(storyI == 21)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							PlayerPrefs.SetString("Prev", "MenuMatchIntro");
							PlayerPrefs.SetString("Next", "SingALongIntro");
							PlayerPrefs.Save();
							gameObject.Find("Logs").SendMessage("Log", "MENU_MATCH_STORY");
							Application.LoadLevel("MenuMatch");
						}
						if(storyI == 22)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							PlayerPrefs.SetString("Prev", "SingALongIntro");
							PlayerPrefs.SetString("Next", "GoHome");
							PlayerPrefs.Save();
							gameObject.Find("Logs").SendMessage("Log", "SING_A_LONG_STORY");
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
							yield WaitForSeconds(0.5);
							PlayerPrefs.SetString("Prev", "JigsawIntro");
							PlayerPrefs.SetString("Next", "Bell");
							PlayerPrefs.Save();
							gameObject.Find("Logs").SendMessage("Log", "JIGSAW_PUZZLE_STORY");
							Application.LoadLevel("Jigsaw");
						}
						else if(storyI == 24)
						{
							gameObject.Find("Logs").SendMessage("Log", "FIND_PEG");
							Text1.SetActive(false);
							Text2.SetActive(false);
							Text3.SetActive(false);
							Manager.SetActive(false);
							Text4.SetActive(true);
							PlayPegs.renderer.material.color.a = 0.7;
							Tap.renderer.material.color.a = 0.7;
							tnt.renderer.material.color.a = 0.7;
							PlayPegs.layer = 0;
							Tap.layer = 0;
							tnt.layer = 0;
							Coats[0].renderer.material = CoatsMat[0];
							Coats[1].renderer.material = CoatsMat[1];
							GoOut();
						}
						else{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield WaitForSeconds(0.5);
						PlayerPrefs.SetString("Prev", "PegsIntro");
						PlayerPrefs.SetString("Next", "NewClass");
						PlayerPrefs.Save();
						gameObject.Find("Logs").SendMessage("Log", "PEG_PAIRS_STORY");
						Application.LoadLevel("Pegs");
						PlayerPrefs.Save();
						}
					}
					else if(target == BackInGame)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
						yield WaitForSeconds(0.5);
						if(PlayerPrefs.GetInt("Story") == 1)
						{
							Application.LoadLevel(PlayerPrefs.GetString("Prev"));
						}
						else{
							PlayerPrefs.SetInt("Story", 0);
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							gameObject.Find("Logs").SendMessage("Log", "CHOOSE_GAME");
							Application.LoadLevel("menu");
						}
					}
					if(target == BeginStory)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
						PlayerPrefs.SetInt("Story", 1);
						gameObject.Find("Logs").SendMessage("Log", "BEGIN_STORY");
						Application.LoadLevel("Story");
					}
					if(target == ChooseAGame)
					{
						Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
						PlayerPrefs.SetInt("Story", 0);
						gameObject.Find("SingletOn").SendMessage("dKe", 4);
						gameObject.Find("Logs").SendMessage("Log", "CHOOSE_GAME");
						Application.LoadLevel("menu");
					}
					if(target == Back)
					{
						if(storyI == 0)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 0);
							Application.LoadLevel("StartScreen");
						}
						if(storyI == 1)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("Logs").SendMessage("Log", "BEGIN_STORY");
							Application.LoadLevel("Story");
						}
						if(storyI == 2)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel(Application.loadedLevel);
						}
						if(storyI == 3)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							Application.LoadLevel("Character");
						}
						if(storyI == 4)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel(Application.loadedLevel);
						}
						if(storyI == 5)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("SchoolBag");
						}
						if(storyI == 6)
						{
							storyI = 5;
							Text1.SetActive(true);
							Text2.SetActive(false);
							Text3.SetActive(false);
							Tap.SetActive(false);
							Next.SetActive(true);
						}
						if(storyI == 7)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							storyI = 5;
							gameObject.Find("SingletOn").SendMessage("dKe", 2);
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
							yield WaitForSeconds(0.5);
							storyI = 8;
							Application.LoadLevel("EnterSchool");
						}
						if(storyI == 10)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							storyI = 9;
							Application.LoadLevel("EnterSchool");
						}
						if(storyI == 11)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							storyI = 10;
							
							Application.LoadLevel("EnterSchool");
						}
						if(storyI == 12)
						{
							storyI = 11;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							Application.LoadLevel("InSchool");
						}
						if(storyI == 13)
						{
							storyI = 12;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							Application.LoadLevel("InSchool");
						}
						if(storyI == 14)
						{
							storyI = 13;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							Application.LoadLevel("PegsIntro");
						}
						if(storyI == 15)
						{
							storyI = 14;
							Text1.SetActive(true);
							Animations.SetActive(true);
							Text2.SetActive(false);
							Text4.SetActive(false);
							tnt.transform.position.x -= 13.0;
							tnt.transform.position.y -= 3.0;
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
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
						}
						if(storyI == 17)
						{
							storyI = 16;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("NewClass");
						}
						else if(storyI == 18)
						{
							storyI = 17;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							Application.LoadLevel("JigsawIntro");
						}
						else if(storyI == 19)
						{
							storyI = 18;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("JigsawIntro");
						}
						else if(storyI == 20)
						{
							storyI = 19;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("Bell");
						}
						else if(storyI == 21)
						{
							storyI = 20;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							Application.LoadLevel("Bell");	
						}
						else if(storyI == 22)
						{
							storyI = 21;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 2);
							Application.LoadLevel("MenuMatchIntro");	
						}
						else if(storyI == 23)
						{
							storyI = 22;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							Application.LoadLevel("SingALongIntro");	
						}
						else if(storyI == 24)
						{
							storyI = 23;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("GoHome");	
						}
						else if(storyI == 25)
						{
							storyI = 24;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
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
								yield WaitForSeconds(0.5);
								Application.LoadLevel("Character");
							}
						}
						if(storyI == 2)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 2);
							gameObject.Find("Logs").SendMessage("Log", "CREATE_FACE");
							Application.LoadLevel("SchoolBag");
						}
						else if(storyI == 3)
						{
							gameObject.Find("Logs").SendMessage("Log", "SCHOOL_BAG");
							Bag.SetActive(false);
							Stickers.SetActive(true);
							Next.SetActive(false);
							storyI = 4;
						}
						else if(storyI == 4)
						{
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("Logs").SendMessage("Log", "STICKER_CHOSEN");
							Application.LoadLevel("ToSchool");
						}
						else if(storyI == 5)
						{
							storyI = 6;
							Text1.SetActive(false);
							Text2.SetActive(true);
							Text3.SetActive(true);
							Tap.SetActive(true);
							Next.SetActive(false);
						}
						else if(storyI == 6)
						{
							storyI = 7;
							Text1.SetActive(false);
							Text2.SetActive(false);
							Text3.SetActive(false);
							Tap.SetActive(false);
							Next.SetActive(false);
							Back.SetActive(false);
							Animations.SetActive(true);
							gameObject.Find("SingletOn").SendMessage("dKe", 3);
							gameObject.Find("Logs").SendMessage("Log", "SCHOOL_NAME");
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
							yield WaitForSeconds(0.5);
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
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("Log", "dKe", 4);
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
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							Application.LoadLevel("NewClass");	
						}
						else if(storyI == 14)
						{
							storyI = 15;
							Text1.SetActive(false);
							Animations.SetActive(false);
							Text2.SetActive(true);
							Text4.SetActive(true);
							tnt.transform.position.x += 13.0;
							tnt.transform.position.y += 3.0;
						}
						else if(storyI == 15)
						{
							storyI = 16;
							gameObject.Find("SingletOn").SendMessage("dKe", 2);
							Text2.SetActive(false);
							Text3.SetActive(true);
							Text5.SetActive(true);
						}
						else if(storyI == 16)
						{
							storyI = 17;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							Application.LoadLevel("JigsawIntro");	
						}
						else if(storyI == 17)
						{
							storyI = 18;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
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
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 2);
							Application.LoadLevel("MenuMatchIntro");	
						}
						else if(storyI == 21)
						{
							gameObject.Find("SingletOn").SendMessage("dKe", 4);
							storyI = 22;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("SingALongIntro");	
						}
						else if(storyI == 22)
						{
							storyI = 23;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 1);
							Application.LoadLevel("GoHome");	
						}
						else if(storyI == 23)
						{
							storyI = 24;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("PickCoat");	
						}
						else if(storyI == 24)
						{
							storyI = 25;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							Application.LoadLevel("End");	
						}
						else if(storyI == 25)
						{
							storyI = 26;
							Instantiate(Fader, Camera.main.transform.position, Camera.main.transform.rotation);
							yield WaitForSeconds(0.5);
							gameObject.Find("SingletOn").SendMessage("dKe", 3);
							Application.LoadLevel("EndScreen");	
						}
					}
				}
					tt = false;
					Active = true;
					target = null;
}
function SetStory(a:int)
{
	storyI = a;
}
function GoOut()
{
	yield WaitForSeconds(3.5);
	//fade
	yield WaitForSeconds(1);
	Application.LoadLevel("Exit");
}