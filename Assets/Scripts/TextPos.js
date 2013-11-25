#pragma strict

var x1:float;
var x2:float;
var w:float;
var h:float;
function Start () {
	w = Screen.width;
	h = Screen.height;
	x1 = w/h;
	x2 = 3.0/2.0;
	if(x1 < x2)
	{
		transform.position.x += 13*(3.0/2.0-w/h);
	}
}

function Update () {

}