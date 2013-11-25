#pragma strict
var Materials:Material[];
var x:int;
var y:int;
var i:int;
var delta:float;
var Speed:float = 20.0;
var play:boolean;
var n:int;
var add:float;
function Start () {
	play = true;
}

function Update () {
	if(play)
	{
		//renderer.material = Materials[Anim];
		delta += Time.deltaTime;
		if(delta>1.0/Speed)
		{
			if(i == 0)
			{
				if(n == 0)
				{
					n = 1;
				}
				else if(n == 1)
				{
					n = 0;
				}
				Change();
			}
			i += 1;
			x += 1;
			delta = 0.0;
			if(y == 0 && x>0)
			{
				y = 1;
				x = 0;
			}
			if(x>2)
			{
				y += 1;
				x = 0;
				if(y>5)
				{
					y = 0;
				}
			}
			if(i>15)
			{
				i = 0;
			}
			if(y == 0)
			{
				add = 0.0015;
			}
			else{
				add = 0;
			}

		}
		renderer.material.SetTextureOffset ("_MainTex", Vector2((x)*0.332,-0.0013 -y*0.16642+add-add*0.0008*4));
	}
}
function Change()
{
	renderer.material = Materials[n];
	renderer.material.SetTextureOffset ("_MainTex", Vector2((x)*0.332,-0.0013 -y*0.16642+add-add*0.0008*4));
}