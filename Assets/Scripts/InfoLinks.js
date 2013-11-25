#pragma strict
var tt:boolean;
var target:GameObject;
var Mask:LayerMask;
var hit:RaycastHit;
var ray:Ray;
var Link:String;
var theTouch1: Touch;
function Start () {
	/*if(Application.platform == RuntimePlatform.IPhonePlayer)
	{
		renderer.material.mainTexture = textures[0];
	}
	if(Application.platform == RuntimePlatform.Android)
	{
		renderer.material.mainTexture = textures[0];
	}
	if(Application.platform == RuntimePlatform.IPhonePlayer)
	{
		renderer.material.mainTexture = textures[0];
	}
	if(Application.platform == RuntimePlatform.IPhonePlayer)
	{
		renderer.material.mainTexture = textures[0];
	}
	if(Application.platform == RuntimePlatform.IPhonePlayer)
	{
		renderer.material.mainTexture = textures[0];
	}*/
}

function Update () {

		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			tt = true;
			theTouch1 = Input.GetTouch(0);
			ray = Camera.main.ScreenPointToRay(theTouch1.position);
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,hit,1000,Mask))
					{
						if(hit.collider.gameObject.name == gameObject.name)
						{
							target = hit.collider.gameObject;
						}
					}	
		}
		else if(tt)
		{
			if(target != null)
			{
				//kviesti linka
				Application.OpenURL(Link);
				target = null;
				tt = false;
				}	
		}
}
