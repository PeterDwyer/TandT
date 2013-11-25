#pragma strict
var l:boolean;
var c:boolean;
var r:boolean;
var basket:boolean;
var speed:float;
var cor:AudioClip;
var dis:AudioClip;
function Start () {
		if(basket)
		{
			speed = 9.0;
		}
		else
		{
			speed = 3.0;
		}
}

function Update () {
	if(l)
	{
		//var angle : float = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 20.0, 50.0 * Time.deltaTime);
		//transform.eulerAngles = Vector3(0, 0, angle);	
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 18)), Time.deltaTime * speed);
	}
	if(c)
	{
		//angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 0.0, 50.0 * Time.deltaTime);
		//transform.eulerAngles = Vector3(0, 0, angle);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), Time.deltaTime * speed);
	}
	if(r)
	{
		//angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, -20.0, 50.0 * Time.deltaTime);
		//transform.eulerAngles = Vector3(0, 0, angle);
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -18)), Time.deltaTime * speed);
	}
}
function Center()
{
	c = true;
	l = false;
	r = false;
	if(!basket)
	{
		audio.clip = cor;
		audio.Play();
	}
}
function Right()
{
	c = false;
	l = false;
	r = true;
	if(basket)
	{
		c = true;
		l = false;
		r = false;
	}
	else
	{
		audio.clip = dis;
		audio.Play();
	}
}
function Left()
{
	c = false;
	l = true;
	r = false;
	if(basket)
	{
		c = true;
		l = false;
		r = false;
	}
}