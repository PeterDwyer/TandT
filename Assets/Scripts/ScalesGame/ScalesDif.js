#pragma strict
var Mng:GameObject;
var element1:GameObject;
var element2:GameObject;
var element3:GameObject;
var element4:GameObject;
var element5:GameObject;
function Start () {
	Mng = gameObject.Find("Manager");
	var MngScript : ScalesGame = Mng.GetComponent("ScalesGame");
	MngScript.e[0] = element1;
	MngScript.e[1] = element2;
	MngScript.e[2] = element3;
	MngScript.e[3] = element4;
	MngScript.e[4] = element5;
}

function Update () {

}