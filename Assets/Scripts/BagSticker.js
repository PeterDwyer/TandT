#pragma strict
var targetIco:GameObject;
var target:GameObject;
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
function Start () {

}
function ActiveWellDone()
{
	yield WaitForSeconds(1.39);
	text[2].SetActive(true);
	text[1].SetActive(false);
}
function Update () {
	if(co == 1)
	{
		Camera.main.SendMessage("SetStory", 4);
		i = 0;
		while(i<4)
		{
			text[i].SetActive(false);
			i += 1;
		}
		text[3].SetActive(false);
		text[1].SetActive(true);
		Camera.main.SendMessage("SetStory", 4);
		Next.SetActive(true);
		ActiveWellDone();
		co = 2;
	}
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			var theTouch : Touch = Input.GetTouch(0);
			var ray = Camera.main.ScreenPointToRay(theTouch.position);
			//var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
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
					while(i<6)
					{
						if(targetIco == Ico[i])
						{
							print("srh");
							Ico[i].SetActive(false);
							Item[i].SetActive(true);
							target = Item[i];
							n = i;
							i = 6;
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
					i = 0;
					while(i<4)
					{
						text[i].SetActive(false);
						i += 1;
					}
					text[0].SetActive(false);
					target.transform.position = Goal.transform.position;
					i = 0;
					while(i<6)
					{

							Ico[i].layer = 0;	
						i += 1;
					}
					text[1].SetActive(true);
					co += 1;
					PlayerPrefs.SetInt("stickerNum", n);
					if(n == 0)
					{
						//Ball
						PlayerPrefs.SetInt("playerSticker", 3);
					}
					if(n == 1)
					{
						//Butterfly
						PlayerPrefs.SetInt("playerSticker", 7);
					}
					if(n == 2)
					{
						//Dog
						PlayerPrefs.SetInt("playerSticker", 10);
					}
					if(n == 3)
					{
						//Bee
						PlayerPrefs.SetInt("playerSticker", 5);
					}
					if(n == 4)
					{
						//Baloon
						PlayerPrefs.SetInt("playerSticker", 4);
					}
					if(n == 5)
					{
						//Ladybird
						PlayerPrefs.SetInt("playerSticker", 13);
					}
					PlayerPrefs.Save();
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