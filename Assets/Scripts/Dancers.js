#pragma strict
var Materials:Material[];
var x:int;
var y:int;
var i:int;
var delta:float;
var Speed:float = 20.0;
var play:boolean;
var Sounds:AudioClip[];
var m:int;
function Start () {
	yield WaitForSeconds(1.3);
	play = true;
}

function Update () {
	if(play)
	{
		//renderer.material = Materials[Anim];
		delta += Time.deltaTime;
		if(delta>1.0/Speed)
		{
			i += 1;
			x += 1;
			delta = 0.0;
			if(x>5)
			{
				y += 1;
				x = 0;
				if(y>3)
				{
					y = 0;
				}
			}

			if(i>23)
			{
				i = 0;
			}
			if(m != 4)
			{
				if(i == 17 || i == 5)
				{
					audio.Play();
				}	
			}
			else
			{
				if(i == 17)
				{
					audio.Play();
				}
			}
		}
		renderer.material.SetTextureOffset ("_MainTex", Vector2((x)*0.1666667,0.0005+1-y*0.25));
	}
}
function Change(n:int)
{
	if(n == 10)
	{
		play = false;
	}
	else
	{
		m = n;
		renderer.material = Materials[n];
		audio.clip = Sounds[n-1];
		renderer.material.SetTextureOffset ("_MainTex", Vector2((x)*0.1666667,0.0005+1-y*0.25));
	}
}