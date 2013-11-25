var FPosX:float; //First puzzle position
var FPosY:float;
var width:float;
var Catch:float = 8.0; //Catches puzzle at this distance
var cols:int;
var rows:int;
var number:int;
var targetItem:GameObject;
var DifScrp:GameObject;
var ePuzzlesPos:Vector3[];
var ePuz:GameObject[];
var eStart:Transform[];
var mPuzzlesPos:Vector3[];
var mPuz:GameObject[];
var mStart:Transform[];
var hPuzzlesPos:Vector3[];
var hPuz:GameObject[];
var hStart:Transform[];
var dif = 0;
private var start:boolean;
private var Play:boolean;
private var DisP:boolean;
private var EnP:boolean;
private var c:int = 0;
private var r:int = 0;
private var oldItem:GameObject;
private var hit:RaycastHit;
private var ReturnItem:boolean;
private var DispHard:boolean;
var layerMask:LayerMask;
private var placed:int;
var Fade:GameObject;
var fade:boolean;
var fadeIn:boolean;
var Text1:GameObject;
function Start()
{

	var Dif : Difficulty = DifScrp.GetComponent("Difficulty");
	dif = Dif.dif;
	if(dif == 0)
	{
		number = 4;
	}
	if(dif == 1)
	{
		number = 6;
	}
	if(dif == 2)
	{
		number = 9;
	}
	var i:int = 0;

	while(i<number)
	{
		if(dif == 0)
		{
			ePuzzlesPos[i] = ePuz[i].transform.position;
		}
		if(dif == 1)
		{
			mPuzzlesPos[i] = mPuz[i].transform.position;
		}
		if(dif == 2)
		{
			hPuzzlesPos[i] = hPuz[i].transform.position;
		}
		i +=1;
	}
	if(dif != 2)
	{
		yield WaitForSeconds(3);
			DisP = true;
		yield WaitForSeconds(1);
	}
	else{
		DispHard = true;
	}
	
	start = true;
}
function Stop()
{
	yield WaitForSeconds(1);
	start = false;
	Play = true;
}
function Done()
{
	audio.Play();
	yield WaitForSeconds(3);
	fade = true;
}
function Update()
{
	if(fade)
	{
		Fade.renderer.material.color.a += Time.deltaTime;
		if(Fade.renderer.material.color.a > 0.99)
		{
			Camera.main.transform.position.y = 273.6;
			fade = false;
			fadeIn = true;
			Text1.SetActive(true);
		}
	}
	if(fadeIn)
	{
		Fade.renderer.material.color.a -= Time.deltaTime;
		if(Fade.renderer.material.color.a < 0.01)
		{
			Fade.renderer.material.color.a = 0;
			fadeIn = false;
		}
	}
	if(ReturnItem && oldItem != null)
	{
		if(dif == 0)
		{
			if(Vector3.Distance(oldItem.transform.position, eStart[int.Parse(oldItem.name)-1].position)> 0.5)
			{
				oldItem.transform.position = Vector3.Lerp(oldItem.transform.position, eStart[int.Parse(oldItem.name)-1].position, 3.5/50);
			}
			else{
				ReturnItem = false;
			}
		}
		if(dif == 1)
		{
			if(Vector3.Distance(oldItem.transform.position, mStart[int.Parse(oldItem.name)-1].position)> 0.5)
			{
				oldItem.transform.position = Vector3.Lerp(oldItem.transform.position, mStart[int.Parse(oldItem.name)-1].position, 3.5/50);
			}
			else{
				ReturnItem = false;
			}
		}
		if(dif == 2)
		{
			if(Vector3.Distance(oldItem.transform.position, hStart[int.Parse(oldItem.name)-1].position)> 0.5)
			{
				oldItem.transform.position = Vector3.Lerp(oldItem.transform.position, hStart[int.Parse(oldItem.name)-1].position, 3.5/50);
			}
			else{
				ReturnItem = false;
			}
		}
	}
	if(DispHard)
	{
		gameObject.Find("hardPuz").renderer.material.color.a = 0;

			DispHard = false;
	}
	if(DisP)
	{
		if(dif == 0)
		{
			gameObject.Find("easyPuz").renderer.material.color.a -= Time.deltaTime * 2;
			if(gameObject.Find("easyPuz").renderer.material.color.a < 0.01)
			{
				DisP = false;
			}
		}
		if(dif == 1)
		{
			gameObject.Find("medPuz").renderer.material.color.a -= Time.deltaTime * 2;
			if(gameObject.Find("medPuz").renderer.material.color.a < 0.01)
			{
				DisP = false;
			}
		}
	}
	if(EnP)
	{
		if(dif == 0)
		{
			gameObject.Find("easyPuz").renderer.material.color.a += Time.deltaTime * 2;
			if(gameObject.Find("easyPuz").renderer.material.color.a > 0.99)
			{
				Done();

				EnP = false;
			}
		}
		if(dif == 1)
		{
			gameObject.Find("medPuz").renderer.material.color.a += Time.deltaTime * 2;
			if(gameObject.Find("medPuz").renderer.material.color.a > 0.99)
			{
				Done();
				EnP = false;
			}
		}
		if(dif == 2)
		{
			gameObject.Find("hardPuz").renderer.material.color.a += Time.deltaTime * 2;
			if(gameObject.Find("hardPuz").renderer.material.color.a > 0.99)
			{
				Done();
				EnP = false;
			}
		}
	}
	if(start)
	{
		Stop();
		var i = 0;
		while(i<number)
		{
			if(dif == 0)
			{
				ePuz[i].transform.position = Vector3.Lerp(ePuz[i].transform.position, eStart[i].position, 3.5/50);
			}
			if(dif == 1)
			{
				mPuz[i].transform.position = Vector3.Lerp(mPuz[i].transform.position, mStart[i].position, 3.5/50);
			}
			if(dif == 2)
			{
				hPuz[i].transform.position = Vector3.Lerp(hPuz[i].transform.position, hStart[i].position, 3.5/50);
			}
			i += 1;
		}
		i = 0;
	}
	if(Play)
	{
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			var theTouch : Touch = Input.GetTouch(0);
			var ray = Camera.main.ScreenPointToRay(theTouch.position);
			//var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(targetItem != null)
			{
				var wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
				//var wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
				var scr:JigsawSelected = targetItem.transform.GetChild(0).gameObject.GetComponent("JigsawSelected");
				targetItem.transform.GetChild(0).gameObject.renderer.material = scr.Selected;
				targetItem.transform.position = wantedPos; 
				targetItem.transform.position.z = -11; 
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

			targetItem.transform.position.z = -10;
			scr = targetItem.transform.GetChild(0).gameObject.GetComponent("JigsawSelected");
			targetItem.transform.GetChild(0).gameObject.renderer.material = scr.Original;
			if(dif == 0)
			{
				if(Vector3.Distance(ePuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position)<Catch || Vector3.Distance(ePuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position) == 0.0)
				{
					targetItem.layer = 0;
					targetItem.transform.position = ePuzzlesPos[int.Parse(targetItem.name)-1];
					Vector3.Distance(ePuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position);
					targetItem = null;
					oldItem = null;
					placed += 1;
					if(placed == number)
					{
						EnP = true;
					}
				}
				else
				{
					oldItem = targetItem;
					ReturnItem = true;
					oldItem.layer = 10;
				}
			}
			if(dif == 1)
			{
				if(Vector3.Distance(mPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position)<Catch || Vector3.Distance(mPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position) == 0.0)
				{
					targetItem.layer = 0;
					targetItem.transform.position = mPuzzlesPos[int.Parse(targetItem.name)-1];
					Vector3.Distance(mPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position);
					targetItem = null;
					oldItem = null;
					placed += 1;
					if(placed == number)
					{
						EnP = true;
					}
				}
				else
				{
					oldItem = targetItem;
					ReturnItem = true;
					oldItem.layer = 10;
				}
			}
			if(dif == 2)
			{
				if(Vector3.Distance(hPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position)<Catch || Vector3.Distance(hPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position) == 0.0)
				{
					targetItem.layer = 0;
					targetItem.transform.position = hPuzzlesPos[int.Parse(targetItem.name)-1];
					Vector3.Distance(hPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position);
					targetItem = null;
					oldItem = null;
					placed += 1;
					if(placed == number)
					{
						EnP = true;
					}
				}
				else
				{
					oldItem = targetItem;
					ReturnItem = true;
					oldItem.layer = 10;
				}
			}
			targetItem = null;
		}
	}
}
