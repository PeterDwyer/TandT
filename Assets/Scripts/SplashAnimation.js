#pragma strict
var Textures:Texture2D[];
private var delta:float;
var Speed:float = 25;
var i:int;

function Awake()
{
	
}

function Start () {
	yield WaitForSeconds(5);
	Application.LoadLevel("StartScreen");
}

function Update () {
		delta += Time.deltaTime;
		if(i<74)
		{
			if(delta>1.0/Speed)
			{
				i += 1;
				delta = 0.0;
			}
			renderer.material.mainTexture = Textures[i];
		}	
}

