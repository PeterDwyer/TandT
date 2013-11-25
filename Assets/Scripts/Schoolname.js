
var Name:String;
var Name1:String;
var Pos:Vector2;
var btnAmplifier:float;
var skin:GUISkin;
var Enter:boolean;
var st:boolean;
var Mask:LayerMask;
var tt:boolean;
var ray:Ray;
var theTouch1 : Touch;
var hit:RaycastHit;
var target:GameObject;
var Next:GameObject;
var Text:GameObject;
var arrive:boolean;
function Start () {

		Pos.x = Screen.width/2;
		Pos.y = Screen.height / 2 ;
		btnAmplifier = Screen.height/10.0;
		Name = "";
		if(Text != null)
		{
			Text.guiText.text = PlayerPrefs.GetString("Name");
		}
}

function Update () {
		
		Pos.x = Screen.width/2 - (7.5*btnAmplifier)/2;
		Pos.y = Screen.height / 2 - btnAmplifier*0.95;
		btnAmplifier = Screen.height/10.0;
		if(Name != "")
		{
			Next.SetActive(true);
		}
}
function OnGUI()
{
	GUI.skin = skin;
	
	if(Enter)
	{
		
			Name = GUI.TextArea (Rect(Pos.x, Pos.y, 7.5*btnAmplifier, btnAmplifier), Name, 20);
		
		PlayerPrefs.SetString("Name", Name);
		PlayerPrefs.SetString("Name1", Name1);
	}
	if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			tt = true;
			theTouch1 = Input.GetTouch(0);
			ray = Camera.main.ScreenPointToRay(theTouch1.position);
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,hit,1000,Mask))
					{
						target = hit.collider.gameObject;
					}
		}
		else if(tt)
		{

				if(target != null)
				{
					target.SetActive(false);
					target = null;
				}
		}
		if(arrive)
		{
			
		}
}