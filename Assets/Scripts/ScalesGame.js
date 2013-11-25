var targetItem:GameObject;
var target:Transform;
var e:GameObject[];

var t:int;

var used = new Array();

var corA:AudioClip;
var wrongA:AudioClip;

var match:GameObject;
var WrongItem:GameObject;
var Fade:GameObject;

var hit:RaycastHit;

var Dif:int;
var i:int;
var Am:float;
var left=5;
var lastT:int;
var OldPos:Vector3;
var PrevOldPos:Vector3;
var Selected:boolean;

var texts:GameObject[];

var layerMask:LayerMask;

function Start()
{
	var Diff : Difficulty = Camera.main.GetComponent("Difficulty");
	Dif = Diff.dif;

		i = Random.Range(0,5);
		match.renderer.material = e[i].renderer.material;
		match.name = e[i].name;
		used.Push(i);
}
function Update()
{
	if(t != lastT)
	{
		if(t != 0)
		{
			if(lastT == 0)
			{
				if(Dif == 0)
				{
					texts[3].SetActive(false);
				}
				if(Dif == 1)
				{
					texts[4].SetActive(false);
				}
				if(Dif == 2)
				{
					texts[5].SetActive(false);
				}
			}
			else
			{
				texts[lastT].SetActive(false);
			}
			texts[t].SetActive(true);
			lastT = t;
		}
		else
		{
			if(Dif == 0)
			{
				texts[3].SetActive(true);
			}
			if(Dif == 1)
			{
				texts[4].SetActive(true);
			}
			if(Dif == 2)
			{
				texts[5].SetActive(true);
			}
			texts[lastT].SetActive(false);
			lastT = t;
		}
	}
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
		if(Vector3.Distance(target.position, targetItem.transform.position)<7.0)
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



function en()
{
	 left -= 1;
	 if(left>0)
	 {

			var u:int = 0;
			while(u<used.length)
			{
				if(i == used[u])
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else if(e[i] == null)
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else{
					u += 1;
				}
			}
			match.renderer.material = e[i].renderer.material;
			match.name = e[i].name;
			gameObject.Find("CrossBar").SendMessage("Left");
			gameObject.Find("Basket1").SendMessage("Left");
			gameObject.Find("Basket2").SendMessage("Left");
	}
	else
	{
		//win
		Instantiate(Fade, Camera.main.transform.position, Camera.main.transform.rotation);
		Destroy(match);
		yield WaitForSeconds(0.55);
		Camera.main.transform.position.y = 200.0;
		gameObject.Find("Text2").audio.Play();
		
	}
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