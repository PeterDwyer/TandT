#pragma strict
var targetIco:GameObject;
var target:GameObject;
var GoalPos:Transform[];
var Ico:GameObject[];
var Item:GameObject[];
var layerMask:LayerMask;
var hit:RaycastHit;
var n:int;
var Catch:float = 15.0;
var Goal:GameObject;
var text:GameObject[];
var Next:GameObject;
var i:int = 0;
var co:int = 0;
var numbers:Material[];
var Num:GameObject;
function Start () {

}

function Update () {
	if(co > 0 && co < 4)
	{
		Num.renderer.material = numbers[co-1];
	}
	if(co == 3)
	{
		i = 0;
		while(i<6)
		{
			text[i].SetActive(false);
			i += 1;
		}
		//text[6].SetActive(false);
		text[5].SetActive(true);
		Next.SetActive(true);
		co = 4;
	}
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			var theTouch : Touch = Input.GetTouch(0);
			//var ray = Camera.main.ScreenPointToRay(theTouch.position);
			var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(target != null)
			{
				var wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 1.0));
				//var wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1.0));
				target.transform.position = wantedPos; 
				target.transform.position.z = 1; 
			}
			else
			{
				if(Physics.Raycast(ray,hit,100,layerMask))
				{
					targetIco = hit.collider.gameObject;	
					i = 0;
					while(i<4)
					{
						if(targetIco == Ico[i])
						{
							print("srh");
							Ico[i].SetActive(false);
							Item[i].SetActive(true);
							target = Item[i];
							n = i;
							i = 4;
						}	
						i += 1;
					}
				}
			}
		}
		else if(target != null)
		{
			if(Vector3.Distance(target.transform.position, Goal.transform.position)<Catch)
			{
				if(n == 0)
				{
					i = 0;
					while(i<6)
					{
						text[i].SetActive(false);
						i += 1;
					}
					text[1].SetActive(true);
					Ico[n].SetActive(true);
					target.SetActive(false);
					target = null;
					targetIco = null;
				}
				else
				{
					i = 0;
					while(i<6)
					{
						text[i].SetActive(false);
						i += 1;
					}
					text[7].SetActive(false);
					target.transform.position = GoalPos[n-1].position;
					co += 1;
					if(co != 3)
					{
						text[n+1].SetActive(true);
					}
				}
			}
			else
			{
				Ico[n].SetActive(true);
				target.SetActive(false);
				target = null;
				targetIco = null;
			}
			target = null;
		}
}