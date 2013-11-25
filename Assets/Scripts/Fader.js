#pragma strict
var a:boolean;
function Start () {
	yield WaitForSeconds(0.56);
	a = true;
}

function Update () {
	if(!a)
	{
		renderer.material.color.a += 0.05;
	}
	else
	{
		renderer.material.color.a -= 0.05;
	}
}