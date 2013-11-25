#pragma strict
var Icons:Texture2D[];
var groupWidth:float;
var groupHeight:float;
var icoSize:float;
var skin:GUISkin;
var ItemsSkin:GUISkin[];
function Start () {
icoSize = Screen.height * 0.45;

groupWidth = ((icoSize)*3+2*(Screen.height*0.06));
groupHeight = ((icoSize)*2+Screen.height*0.06);
print(groupWidth);
}

function Update () {
icoSize = Screen.height * 0.45;

groupWidth = ((icoSize*0.70625)*3+2*(Screen.height*0.06));
groupHeight = ((icoSize)*2+Screen.height*0.07);
}

function OnGUI()
{
	GUI.skin = skin;
	GUI.BeginGroup (new Rect (Screen.width / 2 - groupWidth/2, Screen.height / 2 - groupHeight/2+Screen.height*0.02, groupWidth, groupHeight));
	GUI.skin = ItemsSkin[0];
	if (GUI.Button(Rect(0,Screen.height*0.08,icoSize*0.70625,icoSize),""))
	{
		//PegPairs
		gameObject.Find("Logs").SendMessage("Log", "PEG_PAIRS");
		Application.LoadLevel("Pegs");
	}
	GUI.skin = ItemsSkin[1];
	if (GUI.Button(Rect(icoSize*0.70625+Screen.height*0.06,Screen.height*0.08,icoSize*0.70625,icoSize),""))
	{
		//ScalesGame
		gameObject.Find("Logs").SendMessage("Log", "BALANCE_SCALES");
		Application.LoadLevel("ScalesGame");
	}
	GUI.skin = ItemsSkin[2];
	if (GUI.Button(Rect(2*(icoSize*0.70625+Screen.height*0.06),Screen.height*0.08,icoSize*0.70625,icoSize),""))
	{
		gameObject.Find("Logs").SendMessage("Log", "JIGSAW_PUZZLE");
		Application.LoadLevel("Jigsaw");
	}
	GUI.skin = ItemsSkin[3];
	if (GUI.Button(Rect(0,icoSize+Screen.height*0.07,icoSize*0.70625,icoSize),""))
	{
		//LineUp
		gameObject.Find("Logs").SendMessage("Log", "LUNCH_LINE");
		Application.LoadLevel("Line");
	}
	GUI.skin = ItemsSkin[4];
	if (GUI.Button(Rect(icoSize*0.70625+Screen.height*0.06,icoSize+Screen.height*0.07,icoSize*0.70625,icoSize),""))
	{
		//MenuMatch
		gameObject.Find("Logs").SendMessage("Log", "MENU_MATCH");
		Application.LoadLevel("MenuMatch");
	}
	GUI.skin = ItemsSkin[5];
	if (GUI.Button(Rect(2*(icoSize*0.70625+Screen.height*0.06),icoSize+Screen.height*0.07,icoSize*0.70625,icoSize),""))
	{
		//Sing
		gameObject.Find("Logs").SendMessage("Log", "SING_A_LONG");
		Application.LoadLevel("SingALong");
	}
	GUI.EndGroup();
	
	
}