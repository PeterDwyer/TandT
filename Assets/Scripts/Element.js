#pragma strict
var dis:boolean;
var en:boolean;
var el:boolean;
function Start () {

}

function Update () {
	if(dis)
	{
		renderer.material.color.a -= Time.deltaTime;
		if(renderer.material.color.a < 0.01)
		{
			if(el)
			{
				Destroy(gameObject);
			}
			else{
				ChangeB();
				dis = false;
			}
		}
	}
	if(en)
	{
		renderer.material.color.a += Time.deltaTime;
		if(renderer.material.color.a > 0.99)
		{
			en = false;
		}
	}
}
function Change()
{
	yield WaitForSeconds(1);
	dis = true;
}
function ChangeB()
{
	yield WaitForSeconds(0.5);
	en = true;
	gameObject.Find("Manager").SendMessage("en");
}