#pragma strict
var MainMaterial:Material;
var ActiveMaterial:Material;
function Start () {

}

function Update () {
	
}
function Active()
{
	renderer.material = ActiveMaterial;
}
function Deactive()
{
	renderer.material = MainMaterial;
}