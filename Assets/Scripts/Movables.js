#pragma strict
var additive:float = 0.0;
function Start()
{
	if((Screen.width*1.0)/(Screen.height*1.0)<1.7)
	{
		transform.position.x -= 9 + additive;
	}
	if((Screen.width*1.0)/(Screen.height*1.0)<1.5)
	{
		transform.position.x -= 8 + additive;
	}
}

function Update () {

}