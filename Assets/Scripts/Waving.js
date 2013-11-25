#pragma strict
var rotUp:float;
var rotDown:float;
var up:boolean;
var down:boolean;
var speed:float;
function Start () {

}

function Update () {
	if(up)
	{
		transform.rotation.eulerAngles.z += Time.deltaTime * speed;
		if(transform.rotation.eulerAngles.z > rotUp || transform.rotation.eulerAngles.z < rotDown)
		{
			up = false;
			down = true;
		}
	}
	if(down)
	{
		transform.rotation.eulerAngles.z -= Time.deltaTime * speed;
		if(transform.rotation.eulerAngles.z < rotDown || transform.rotation.eulerAngles.z > rotUp)
		{
			down = false;
			up = true;
		}
	}
}