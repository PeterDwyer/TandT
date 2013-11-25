#pragma strict
var time:float;
var object:GameObject;
function Start () {
print("I PRINT DIS");
	yield WaitForSeconds(time);
	print("I PRINT DAT");
	object.SetActive(true);
	gameObject.SetActive(false);
}

function Update () {

}