#pragma strict
var Mask:LayerMask;
var tt:boolean;
var hit:RaycastHit;
var target:GameObject;
var BoyManager:GameObject;
var GirlManager:GameObject;
var Boy:GameObject;
var Girl:GameObject;
var BoyB:GameObject;
var GirlB:GameObject;
var Next:GameObject;
var ray:Ray;
var theTouch1 : Touch;
var T1:GameObject;
function Start () {

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
							target = hit.collider.gameObject;
						if(target == GirlB)
						{
							target.transform.localScale = Vector3(4.068,4.714213,4.564);
						}
						if(target == BoyB)
						{
							target.transform.localScale = Vector3(4.0014,4.714213,4.995);
						}
					}
		}
		else if(tt)
		{


				if(target != null)
				{
					if(target == BoyB)
					{
						Boy.SetActive(true);
						BoyManager.SetActive(true);
						Next.SetActive(true);
						T1.SetActive(true);
						Camera.main.SendMessage("SetStory", 2);
						
					}
					if(target == GirlB)
					{
						Girl.SetActive(true);
						GirlManager.SetActive(true);
						Next.SetActive(true);
						T1.SetActive(true);
						Camera.main.SendMessage("SetStory", 2);
					}
					
				//	target.transform.localScale = Vector3(4.701441,5.015121,4.896067);
				target = null;
				gameObject.SetActive(false);
				}
		}
}