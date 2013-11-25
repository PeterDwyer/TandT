#pragma strict
var Pegs:Material[];
var n:int;
function Start () {
 n = PlayerPrefs.GetInt("stickerNum");
 renderer.material = Pegs[n];

}

function Update () {
}