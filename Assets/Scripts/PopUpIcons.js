#pragma strict
var i:float;
var timeDif:float;
var pop:boolean;
var old:Vector3;
var newScale:Vector3;
function Start () {
	old = transform.localScale;
	yield WaitForSeconds(timeDif*i);
	pop = true;
}

function Update () {
	if(pop)
	{
		transform.localScale = Vector3.Slerp(transform.localScale, newScale, Time.deltaTime * 6);
	}	
}