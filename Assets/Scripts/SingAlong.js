#pragma strict
var tim:boolean;
var topsy:boolean;
var Anim:int[];
var Tim:GameObject;
var Topsy:GameObject;
var groupPosition:Vector2;
var groupSize:Vector2;
var btnAmp:float;
var Button:Texture2D[];
var FoolowTopsy:GameObject;
var FoolowTim:GameObject;
var Mask:LayerMask;
var tt:boolean;
var hit:RaycastHit;
var target:GameObject;
var Maracas:GameObject;
var Clap:GameObject;
var Tambourine:GameObject;
var Stomp:GameObject;
var ray:Ray;
var theTouch1 : Touch;
var play:boolean;
var Select:GameObject;
var Intro:GameObject;
var End:GameObject;
function Start () {
	Intro.SetActive(false);
	Anim[0] = Random.Range(1,5);
	var Song:SelectSong = Select.GetComponent("SelectSong");
	if(Song.song == 1)
	{
		topsy = true;
	}
	if(Song.song == 2)
	{
		tim = true;
	}
	if(tim)
	{
		FoolowTim.SetActive(true);
		Tim.SendMessage("Change", Anim[0]);
		
	}
	if(topsy)
	{
		FoolowTopsy.SetActive(true);
		Topsy.SendMessage("Change", Anim[0]);
	}
	yield WaitForSeconds(2);
	Play();
}

function Update () {
	if(play)
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
						target.transform.localScale = Vector3(1.5,1.5,1.5);
					}
		}
		else if(tt)
		{


				if(target != null)
				{
						if(target == Maracas)
						{
							if(tim)
							{
								Topsy.SendMessage("Change", 1);
							}
							if(topsy)
							{
								Tim.SendMessage("Change", 1);
							}
						}
						if(target == Clap)
						{
							if(tim)
							{
								Topsy.SendMessage("Change", 2);
							}
							if(topsy)
							{
								Tim.SendMessage("Change", 2);
							}
						}
						if(target == Tambourine)
						{
							if(tim)
							{
								Topsy.SendMessage("Change", 3);
							}
							if(topsy)
							{
								Tim.SendMessage("Change", 3);
							}
						}
						if(target == Stomp)
						{
							if(tim)
							{
								Topsy.SendMessage("Change", 4);
							}
							if(topsy)
							{
								Tim.SendMessage("Change", 4);
							}
						}
					tt = false;
					target.transform.localScale = Vector3(1.625,1.625,1.625);
					target = null;
				}
		}
	}
}
function Play()
{
		play = true;
		yield WaitForSeconds(8);
		var i = 0;
		Anim[1] = Random.Range(1,5);
		while(i<1)
		{	
			if(Anim[1] == Anim[i])
			{
				i = 0;
				Anim[1] = Random.Range(1,5);
			}
			else
			{
				i += 1;
			}
		}
		i = 0;
		if(tim)
		{
			Tim.SendMessage("Change", Anim[1]);
		}
		if(topsy)
		{
			Topsy.SendMessage("Change", Anim[1]);
		}
		yield WaitForSeconds(8);
		Anim[2] = Random.Range(1,5);
		while(i<2)
		{
			
			if(Anim[2] == Anim[i])
			{
				i = 0;
				Anim[2] = Random.Range(1,5);
			}
			else
			{
				i += 1;
			}
		}
		i = 0;
		if(tim)
		{
			Tim.SendMessage("Change", Anim[2]);
		}
		if(topsy)
		{
			Topsy.SendMessage("Change", Anim[2]);
		}
		yield WaitForSeconds(8);
		Anim[3] = Random.Range(1,5);
		while(i<3)
		{

			if(Anim[3] == Anim[i])
			{
				i = 0;
				Anim[3] = Random.Range(1,5);
			}
			else
			{
				i += 1;
			}
		}
		i = 0;
		if(tim)
		{
			Tim.SendMessage("Change", Anim[3]);
			yield WaitForSeconds(6);
		}
		if(topsy)
		{
			Topsy.SendMessage("Change", Anim[3]);
			yield WaitForSeconds(10);
		}
		Topsy.SendMessage("Change", 10);
		Tim.SendMessage("Change", 10);
		gameObject.Find("SingletOn").SendMessage("dKe", 4);
		//END;
		//FADE
		End.SetActive(true);
		Camera.main.transform.position.y = 300;
	
}/*
function OnGUI()
{
		btnAmp = Screen.height/600.0;
		groupSize.x = Button[0].width * 3;
		groupSize.y = Button[0].width * 3;
		groupPosition.x = Screen.width/2 - groupSize.x/2;
		groupPosition.y = Screen.height * 0.1;
		GUI.BeginGroup(Rect(groupPosition.x, groupPosition.y, groupSize.x, groupPosition.y));
		if(tim)
		{
			GUI.Label(Rect(0, 0, Button[4].height,Button[4].width), Button[4]);
		}
		if(topsy)
		{
			GUI.Label(Rect((groupSize.x - (Button[5].width * btnAmp)/2), 0, Button[5].height,Button[5].width), Button[5]);
		}
		GUI.EndGroup();
}*/