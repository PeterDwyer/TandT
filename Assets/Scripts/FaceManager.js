#pragma strict
var GirlPre:GameObject;
var GirlPre2:GameObject;
var BoyPre:GameObject;
var BoyPre2:GameObject;
var Gender:int;
function Start () {
	Gender = PlayerPrefs.GetInt("Gender");
	if(Gender == 0)
	{
		BoyPre.SetActive(true);
		BoyPre2.SetActive(true);
	}
	else if(Gender == 1)
	{
		GirlPre.SetActive(true);
		GirlPre2.SetActive(true);
	}
}

function Update () {

}