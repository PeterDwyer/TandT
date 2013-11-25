
var camPos:float = 0.0;
var setDif : boolean = true;
var dif:int;
var skin:GUISkin;
var easy:GameObject;
var med:GameObject;
var hard:GameObject;
var easyI:Texture2D;
var medI:Texture2D;
var hardI:Texture2D;
var groupPosition:Vector2;
var btnAmplifier:float;
var space:float;
var btnScale:float[];
var layerMask:LayerMask;
var btn1:GUISkin;
var btn2:GUISkin;
var btn3:GUISkin;
var manager:GameObject;
private var hit:RaycastHit;
var scales:boolean;
var jigsaw:boolean;
var pegs:boolean;
var menu:boolean;
var faces:GameObject;
function Start () {

}

function Update () {
	if(scales)
	{
		groupPosition.x = Screen.width/2+Screen.width/4.5;
		groupPosition.y = Screen.height / 2 - Screen.height/2.5;
		btnAmplifier = Screen.height/4.0 / 380.0;
		space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2;
	}
	if(jigsaw)
	{
		groupPosition.x = Screen.width/2-(easyI.width * 2 * btnAmplifier + space*2 + medI.width* btnAmplifier)/2;
		groupPosition.y = Screen.height / 3.5;
		btnAmplifier = Screen.height/4.0 / 380.0;
		space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2;
	}
	if(pegs)
	{
		space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2;
		groupPosition.x = Screen.width/2 - (medI.width*btnAmplifier)/2;
		groupPosition.y = Screen.height -(space/4 * 3 + (medI.height*btnAmplifier)*3);
		btnAmplifier = Screen.height/4.0 / 380.0;
	}
	if(menu)
	{
		space = (medI.width * btnAmplifier - easyI.width * btnAmplifier)/2;
		groupPosition.x = Screen.width/2 - (medI.width*btnAmplifier)/2;
		groupPosition.y = Screen.height -(space/2 * 6 + (medI.height*btnAmplifier)*3);
		btnAmplifier = Screen.height/4.0 / 380.0;
	}
	/*//if(Input.touchCount > 0)
	if(Input.GetButton("Fire1"))
	{
		//var theTouch : Touch = Input.GetTouch(0);
		//var ray = Camera.main.ScreenPointToRay(theTouch.position);
		var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
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

function OnGUI()
{
	GUI.skin = skin;
	if(setDif)
	{
		if(scales)
		{
			GUI.BeginGroup(Rect(groupPosition.x, groupPosition.y, medI.width * btnAmplifier, medI.height * btnAmplifier * 3 + (space)*3));
			GUI.skin = btn1;
			if(GUI.Button(Rect(space,0, easyI.width * btnAmplifier*btnScale[0], easyI.height* btnAmplifier*btnScale[0]*1.1), ""))
			{
	//			gameObject.Find("Logs").SendMessage("Log", "EASY");
				btnScale[0] = 0.8;
				dif = 0;
				transform.position.y = camPos;
				manager.SetActive(true);
				easy.SetActive(true);
				setDif = false;
				gameObject.Find("Text1").audio.Stop();
			}
			GUI.skin = btn2;
			if(GUI.Button(Rect(0,medI.height * btnAmplifier + space, medI.width * btnAmplifier, medI.height* btnAmplifier*1.1), ""))
			{
				//gameObject.Find("Logs").SendMessage("Log", "MEDIUM");
				dif = 1;
				transform.position.y = camPos;
				manager.SetActive(true);
				med.SetActive(true);
				setDif = false;
				gameObject.Find("Text1").audio.Stop();
			}
			GUI.skin = btn3;
			if(GUI.Button(Rect(space,(medI.height * btnAmplifier + space)*2, easyI.width * btnAmplifier, easyI.height* btnAmplifier*1.1), ""))
			{
				//gameObject.Find("Logs").SendMessage("Log", "HARD");
				dif = 2;
				transform.position.y = camPos;
				manager.SetActive(true);
				hard.SetActive(true);
				setDif = false;
				gameObject.Find("Text1").audio.Stop();
			}
			GUI.EndGroup();
		}
		if(jigsaw)
		{
			GUI.BeginGroup(Rect(groupPosition.x, groupPosition.y, medI.width * 3 * btnAmplifier, medI.height * btnAmplifier));
			GUI.skin = btn1;
			if(GUI.Button(Rect(0,0, easyI.width * btnAmplifier*btnScale[0], easyI.height* btnAmplifier*btnScale[0]*1.1), ""))
			{
				//gameObject.Find("Logs").SendMessage("Log", "EASY");
				btnScale[0] = 0.8;
				dif = 0;
				transform.position.y = camPos;
				manager.SetActive(true);
				easy.SetActive(true);
				setDif = false;
			}
			GUI.skin = btn2;
			if(GUI.Button(Rect(easyI.width* btnAmplifier + space ,0, medI.width * btnAmplifier, medI.height* btnAmplifier*1.1), ""))
			{
				//gameObject.Find("Logs").SendMessage("Log", "MEDIUM");
				dif = 1;
				transform.position.y = camPos;
				manager.SetActive(true);
				med.SetActive(true);
				
				setDif = false;
			}
			GUI.skin = btn3;
			if(GUI.Button(Rect(easyI.width* btnAmplifier + space*2 + medI.width* btnAmplifier ,0, easyI.width * btnAmplifier, easyI.height* btnAmplifier*1.1), ""))
			{
				//gameObject.Find("Logs").SendMessage("Log", "HARD");
				dif = 2;
				transform.position.y = camPos;
				manager.SetActive(true);
				hard.SetActive(true);
				setDif = false;
			}
			GUI.EndGroup();
		}
		if(pegs || menu)
		{
			//gameObject.Find("Logs").SendMessage("Log", "EASY");
			GUI.BeginGroup(Rect(groupPosition.x, groupPosition.y, medI.width * btnAmplifier, medI.height * btnAmplifier * 3 + (space)*3));
			GUI.skin = btn1;
			if(GUI.Button(Rect(space,0, easyI.width * btnAmplifier, easyI.height* btnAmplifier*1.1), ""))
			{
				dif = 0;
				transform.position.y = camPos;
				manager.SetActive(true);
				setDif = false;
			}
			GUI.skin = btn2;
			if(GUI.Button(Rect(0,medI.height * btnAmplifier-space/4, medI.width * btnAmplifier, medI.height* btnAmplifier*1.1), ""))
			{
				//gameObject.Find("Logs").SendMessage("Log", "MEDIUM");
				dif = 1;
				transform.position.y = camPos;
				manager.SetActive(true);
				
				setDif = false;
			}
			GUI.skin = btn3;
			if(GUI.Button(Rect(space,(medI.height * btnAmplifier)*2-space/4, hardI.width * btnAmplifier, hardI.height* btnAmplifier*1.1), ""))
			{	
				//gameObject.Find("Logs").SendMessage("Log", "HARD");
				dif = 2;
				transform.position.y = camPos;
				manager.SetActive(true);;
				setDif = false;
			}
			GUI.EndGroup();
		}
		
	}
}