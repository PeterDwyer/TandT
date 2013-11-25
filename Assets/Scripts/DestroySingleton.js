#pragma strict
var SingletOn:GameObject;
function Start () {
	SingletOn = gameObject.Find("SingletOn");
	if(SingletOn != null)
	{
		Destroy(SingletOn);
	}
}

function Update () {

}