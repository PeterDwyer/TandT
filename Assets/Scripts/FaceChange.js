#pragma strict
var Faces:GameObject[];
var i:int;
var Change:boolean;
function Start () {
	Next();
}

function Update () {
	if(Change)
	{
		Faces[i].renderer.material.color.a -= Time.deltaTime*2;
		if(i<3)
		{
			Faces[i+1].renderer.material.color.a += Time.deltaTime*2;
			if(Faces[i+1].renderer.material.color.a > 0.999 && Faces[i].renderer.material.color.a<0.001)
			{
				i += 1;
				Change = false;
				Next();
			}
		}
		else if(i == 3)
		{
			Faces[0].renderer.material.color.a += Time.deltaTime*2;
			if(Faces[0].renderer.material.color.a > 0.999 && Faces[i].renderer.material.color.a<0.001)
			{
				i = 0;
				Change = false;
				Next();
			}
		}
	}
}
function Next()
{
	yield WaitForSeconds(1);
	Change = true;
}