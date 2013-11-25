
var groupWidth:float;
var groupHeight:float;
var icoSize:float;
function Start () {
icoSize = Screen.height * 0.2;
groupWidth = ((icoSize)*5+4*(Screen.height*0.01));
groupHeight = ((icoSize)+Screen.height*0.01);
transform.position = Camera.main.ScreenPointToRay(Vector3(Screen.width / 2 - groupWidth/2, Screen.height - groupHeight,0)).GetPoint(5);
}

function Update () {
icoSize = Screen.height * 0.2;
groupWidth = ((icoSize)*5+4*(Screen.height*0.01));
groupHeight = ((icoSize)+Screen.height*0.01);
transform.position = Camera.main.ScreenPointToRay(Vector3(Screen.width / 2 - groupWidth/2, Screen.height - groupHeight,0)).GetPoint(5);
}