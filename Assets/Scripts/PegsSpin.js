#pragma strict
var delay:float = 0.0;
var delayBack:float = 0.0;
var spin:boolean;
var spinBack:boolean;
var dif:int;
var Menu:boolean;
var pos:Vector3;
var faces:boolean;
var y:float;
function Start () {
if(faces)
{
	y = 6.2;
}
	if(!Menu)
	{
		yield WaitForSeconds(delay);
		spin = true;
		var Pgs:Pegs = gameObject.Find("Manager").GetComponent("Pegs");
		dif = Pgs.dif;
		if(dif == 0)
		{
			delayBack -= 3.75;
		}
		if(dif == 1)
		{
			delayBack -= 1.75;
		}
		if(dif == 2)
		{
			delayBack += 0.25;
		}
		yield WaitForSeconds(delayBack-delay);
		spin = false;
		spinBack = true;
		yield WaitForSeconds(1);
		spinBack = false;
		Destroy(this);
	}
	else{
		pos = transform.position;
		yield WaitForSeconds(delay);
		spin = true;
		var MM:MenuMatch = gameObject.Find("Manager").GetComponent("MenuMatch");
		dif = MM.dif;
		if(dif == 0)
		{
			delayBack -= 2.75;
		}
		if(dif == 1)
		{
			delayBack -= 1.75;
		}
		if(dif == 2)
		{
			delayBack -= 0.25;
		}
		yield WaitForSeconds(delayBack-delay);
		spin = false;
		spinBack = true;
		yield WaitForSeconds(1.3);
		spinBack = false;
		Destroy(this);
	}
}

function Update () {
	if(!Menu)
	{
		if(spin)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(90, 360, 0)), Time.deltaTime * 3.5);
		}
		if(spinBack)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(90, 180, 0)), Time.deltaTime * 3.5);
		}
	}
		else{
			if(spin)
			{
				transform.position = Vector3.Lerp(transform.position, Vector3(transform.position.x, pos.y + 12 + y, transform.position.z), 5.5/50);
			}
			if(spinBack)
			{
				transform.position = Vector3.Lerp(transform.position, Vector3(transform.position.x, pos.y, transform.position.z), 5.5/50);
			}
		}
}