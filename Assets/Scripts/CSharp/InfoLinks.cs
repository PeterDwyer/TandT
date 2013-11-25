using UnityEngine;
using System.Collections;

public class InfoLinks : MonoBehaviour 
{
	public bool tt;
	public GameObject target;
	public LayerMask Mask;
	public RaycastHit hit;
	public Ray ray;
	public string Link;
	public Touch theTouch1;
	
	void Start () 
	{
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
	
	void Update () 
	{

		//if(Input.touchCount > 0)
		if(Input.GetButton("Fire1"))
		{
			tt = true;
			//theTouch1 = Input.GetTouch(0);
			//ray = Camera.main.ScreenPointToRay(theTouch1.position);
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit,1000f,Mask))
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
}