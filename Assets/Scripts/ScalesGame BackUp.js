#pragma strict
private var icoSize:float;
private var groupWidth:float;
private var groupHeight:float;
private var targetItem:GameObject;
private var hit:RaycastHit;
var Catch:float = 7.0;
var match:GameObject;
var target:Transform;
var layerMask:LayerMask;
var easyIcons:Material[];
var medIcons:Material[];
var hardIcons:Material[];
var skin:GUISkin;
var easyElements:GameObject[];
var medElements:GameObject[];
var hardElements:GameObject[];
var Selected:boolean;
var OldPos:Vector3;
var PrevOldPos:Vector3;
var easy:boolean;
var med:boolean;
var hard:boolean;
var i:int;
var used = new Array();
var matchColour:Texture2D;
var matchShape:Texture2D;
var matchSC:Texture2D;
var Correct:Texture2D;
var Wrong:Texture2D;
var DifScrp:GameObject;
var left = 5;
private var enb:boolean;
private var WrongItem:GameObject;
var Am:float = 1;
var t = 0;
var fade:boolean;
private var fadeIn:boolean = true;
var Fade:GameObject;
var Intro:GameObject;
var colorA:AudioClip;
var shapeA:AudioClip;
var csA:AudioClip;
var corA:AudioClip;
var wrongA:AudioClip;
var endA:AudioClip;
var p:boolean; 
function Start () {
 Intro.SetActive(false);
	icoSize = Screen.height * 0.2;
	Am = Screen.height/226;
	groupWidth = ((icoSize)*5+4*(Screen.height*0.01));
	groupHeight = ((icoSize)+Screen.height*0.02);
	var Dif : Difficulty = DifScrp.GetComponent("Difficulty");
	if(Dif.dif == 0)
	{
		audio.clip = colorA;
		easy = true;
	}
	if(Dif.dif == 1)
	{
		audio.clip = shapeA;
		med = true;
	}
	if(Dif.dif == 2)
	{
		audio.clip = csA;
		hard = true;
	}
	audio.Play();
	if (easy)
	{
		i = Random.Range(0,5);
		match.renderer.material = easyIcons[i];
		match.name = easyElements[i].name;
		used.Push(i);
	}
	if (med)
	{
		i = Random.Range(0,5);
		match.renderer.material = medIcons[i];
		match.name = medElements[i].name;
		used.Push(i);
	}
	if (hard)
	{
		i = Random.Range(0,5);
		match.renderer.material = hardIcons[i];
		match.name = hardElements[i].name;
		used.Push(i);
	}
}
function en()
{
	 left -= 1;
	 if(left>0)
	 {
		if(easy)
		{
			var u:int = 0;
			while(u<used.length)
			{
				if(i == used[u])
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else if(easyElements[i] == null)
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else{
					u += 1;
				}
			}
			match.renderer.material = easyIcons[i];
			match.name = easyElements[i].name;
			gameObject.Find("CrossBar").SendMessage("Left");
			gameObject.Find("Basket1").SendMessage("Left");
			gameObject.Find("Basket2").SendMessage("Left");
		}
		if(med)
		{
			u = 0;
			while(u<used.length)
			{
				if(i == used[u])
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else if(medElements[i] == null)
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else{
					u += 1;
				}
			}
			match.renderer.material = medIcons[i];
			match.name = medElements[i].name;
			gameObject.Find("CrossBar").SendMessage("Left");
			gameObject.Find("Basket1").SendMessage("Left");
			gameObject.Find("Basket2").SendMessage("Left");
		}
		if(hard)
		{
			u = 0;
			while(u<used.length)
			{
				if(i == used[u])
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else if(hardElements[i] == null)
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else{
					u += 1;
				}
			}
			match.renderer.material = hardIcons[i];
			match.name = hardElements[i].name;
			gameObject.Find("CrossBar").SendMessage("Left");
			gameObject.Find("Basket1").SendMessage("Left");
			gameObject.Find("Basket2").SendMessage("Left");
		}
	}
	else
	{
		//win
		fade = true;
		Destroy(match);
	}
}
function Update()
{
	if(fade)
	{
		Fade.renderer.material.color.a += Time.deltaTime;
		t = 4;
		if(Fade.renderer.material.color.a > 0.99)
		{
			Camera.main.transform.position.y = 200.0;
		}
	}
	if(fadeIn)
	{
		Fade.renderer.material.color.a -= Time.deltaTime;
		if(Fade.renderer.material.color.a < 0.01)
		{
			fadeIn = false;
		}
	}
	if(left==0)
			{
				if(!p)
				{
					if(audio.isPlaying)
					{
						audio.Stop();
					}
					audio.clip = endA;
					audio.Play();
					p = true;
				}
			}
	Am = Screen.height/22;
	if(Input.touchCount > 0)
	//if(Input.GetButton("Fire1"))
	{
		var theTouch : Touch = Input.GetTouch(0);
		var ray = Camera.main.ScreenPointToRay(theTouch.position);
		//var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(targetItem != null)
		{
			if(!Selected)
			{
				OldPos = targetItem.transform.position;
				Selected = true;
			}
			var wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
			//var wantedPos = Camera.main.ScreenToWorldPoint (Vector3(Input.mousePosition.x, Input.mousePosition.y, 3.0));
			targetItem.transform.position = wantedPos; 
			targetItem.transform.position.z = 3; 
		}
		else
		{
			if(Physics.Raycast(ray,hit,100,layerMask))
			{
				targetItem = hit.collider.gameObject;	
			}
		}
	}
	else if(targetItem != null)
	{
		targetItem.transform.position.z = 4;
		if(Vector3.Distance(target.position, targetItem.transform.position)<Catch)
		{
			targetItem.layer = 0;
			targetItem.transform.position = target.position;
			targetItem.transform.position.z = 4;
			if(targetItem.name == match.name)
			{
				gameObject.Find("CrossBar").SendMessage("Center");
				gameObject.Find("Basket1").SendMessage("Center");
				gameObject.Find("Basket2").SendMessage("Center");
				targetItem.SendMessage("Change");
				match.SendMessage("Change");
				cor();
				
			}
			else
			{
				gameObject.Find("CrossBar").SendMessage("Right");
				gameObject.Find("Basket1").SendMessage("Right");
				gameObject.Find("Basket2").SendMessage("Right");
				WrongItem = targetItem;
				ReturnItem();
			}
				
				if(target.childCount > 0)
				{
					target.GetChild(0).position = PrevOldPos;
					target.GetChild(0).gameObject.layer = 8;
				}
			target.DetachChildren();
			targetItem.transform.parent = target;
			PrevOldPos = OldPos;
		}
		else
		{
			targetItem.transform.position = OldPos;
		}
		Selected = false;
		targetItem = null;
	}
	Am = Screen.height/82.0;
}
function ReturnItem()
{
	yield WaitForSeconds(2);
	audio.clip = wrongA;
	audio.Play();
	WrongItem.transform.position = PrevOldPos;
	WrongItem.layer = 8;
	gameObject.Find("CrossBar").SendMessage("Left");
	gameObject.Find("Basket1").SendMessage("Left");
	gameObject.Find("Basket2").SendMessage("Left");
	target.DetachChildren();
	t = 2;
	ChangeBack();
}
function cor()
{
	ChangeBack();
	yield WaitForSeconds(1);
	audio.clip = corA;
	audio.Play();
	t = 1;
	ChangeBack();
}
function ChangeBack()
{
	yield WaitForSeconds(2.5);
	
		t = 0;
	
}
function OnGUI()
{
	GUI.skin = skin;
	if(easy)
	{
		if(t == 0)
		{
			GUI.Label(Rect(4*Am, 5*Am, matchColour.height*Am, matchColour.width*Am), matchColour);
		}
	}
	if(med)
	{
		if(t == 0)
		{
			GUI.Label(Rect(4*Am, 5*Am, matchShape.height*Am, matchShape.width*Am), matchShape);
		}
	}
	if(hard)
	{
		if(t == 0)
		{
			GUI.Label(Rect(4*Am, 5*Am, matchSC.height*Am*2.2, matchSC.width*Am*2.2), matchSC);
		}
	}
	if(t == 1)
	{
		GUI.Label(Rect(4*Am, 5*Am, Correct.height*Am*0.4, Correct.width*Am*0.4), Correct);
	}
	if(t == 2)
	{
		GUI.Label(Rect(4*Am, 5*Am, Wrong.height*Am, Wrong.width*Am), Wrong);
	}
	GUI.BeginGroup (new Rect (Screen.width / 2 - groupWidth/2, Screen.height - groupHeight, groupWidth, groupHeight));

	GUI.EndGroup();
	
	
}