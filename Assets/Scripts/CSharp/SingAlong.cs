using UnityEngine;
using System.Collections;

public class SingAlong : MonoBehaviour 
{	
	public bool tim;
	public bool topsy;
	public int[] Anim;
	public GameObject Tim;
	public GameObject Topsy;
	public Vector2 groupPosition;
	public Vector2 groupSize;
	public float btnAmp;
	public Texture2D[] Button;
	public GameObject FoolowTopsy;
	public GameObject FoolowTim;
	public LayerMask Mask;
	public bool tt;
	public RaycastHit hit;
	public GameObject target;
	public GameObject Maracas;
	public GameObject Clap;
	public GameObject Tambourine;
	public GameObject Stomp;
	public Ray ray;
	public Touch theTouch1;
	public bool play;
	public GameObject Select;
	public GameObject Intro;
	public GameObject End;
	
	IEnumerator Start () 
	{
		Intro.SetActive(false);
		Anim[0] = Random.Range(1,5);
		SelectSong Song = Select.GetComponent<SelectSong>();
		
		if(Song.song == 1)
		{
			topsy = true;
		}
		
		if(Song.song == 2)
		{
			tim = true;
		}
		
		if(tim)
		{
			FoolowTim.SetActive(true);
			Tim.SendMessage("Change", Anim[0]);
			
		}
		
		if(topsy)
		{
			FoolowTopsy.SetActive(true);
			Topsy.SendMessage("Change", Anim[0]);
		}
		
		yield return new WaitForSeconds(2);
		StartCoroutine(Play());
	}
	
	void Update () 
	{
		if(play)
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
							target = hit.collider.gameObject;
							target.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
						}
			}
			else if(tt)
			{
				if(target != null)
				{
					if(target == Maracas)
					{
						if(tim)
						{
							Topsy.SendMessage("Change", 1);
						}
						if(topsy)
						{
							Tim.SendMessage("Change", 1);
						}
					}
					
					if(target == Clap)
					{
						if(tim)
						{
							Topsy.SendMessage("Change", 2);
						}
						if(topsy)
						{
							Tim.SendMessage("Change", 2);
						}
					}
					
					if(target == Tambourine)
					{
						if(tim)
						{
							Topsy.SendMessage("Change", 3);
						}
						if(topsy)
						{
							Tim.SendMessage("Change", 3);
						}
					}
					
					if(target == Stomp)
					{
						if(tim)
						{
							Topsy.SendMessage("Change", 4);
						}
						if(topsy)
						{
							Tim.SendMessage("Change", 4);
						}
					}
					
					tt = false;
					target.transform.localScale = new Vector3(1.625f,1.625f,1.625f);
					target = null;
				}
			}
		}
	}
	
	IEnumerator Play()
	{
		Vector3 tmpPos;
		play = true;
		yield return new WaitForSeconds(8f);
		int i = 0;
		Anim[1] = Random.Range(1,5);
		
		while(i<1)
		{	
			if(Anim[1] == Anim[i])
			{
				i = 0;
				Anim[1] = Random.Range(1,5);
			}
			else
			{
				i += 1;
			}
		}
		
		i = 0;
		
		if(tim)
		{
			Tim.SendMessage("Change", Anim[1]);
		}
		
		if(topsy)
		{
			Topsy.SendMessage("Change", Anim[1]);
		}
		
		yield return new WaitForSeconds(8f);
		Anim[2] = Random.Range(1,5);
		
		while(i<2)
		{
			
			if(Anim[2] == Anim[i])
			{
				i = 0;
				Anim[2] = Random.Range(1,5);
			}
			else
			{
				i += 1;
			}
		}
		
		i = 0;
		
		if(tim)
		{
			Tim.SendMessage("Change", Anim[2]);
		}
		
		if(topsy)
		{
			Topsy.SendMessage("Change", Anim[2]);
		}
		
		yield return new WaitForSeconds(8f);
		Anim[3] = Random.Range(1,5);
		
		while(i<3)
		{

			if(Anim[3] == Anim[i])
			{
				i = 0;
				Anim[3] = Random.Range(1,5);
			}
			else
			{
				i += 1;
			}
		}
		
		i = 0;
		
		if(tim)
		{
			Tim.SendMessage("Change", Anim[3]);
			yield return new WaitForSeconds(6f);
		}
		
		if(topsy)
		{
			Topsy.SendMessage("Change", Anim[3]);
			yield return new WaitForSeconds(10);
		}
		
		Topsy.SendMessage("Change", 10);
		Tim.SendMessage("Change", 10);
		GameObject.Find("SingletOn").SendMessage("dKe", 4);
		//END;
		//FADE
		End.SetActive(true);
		tmpPos = Camera.main.transform.position;
		tmpPos.y = 300;
		Camera.main.transform.position = tmpPos;
	
	}/*
	function OnGUI()
	{
			btnAmp = Screen.height/600.0;
			groupSize.x = Button[0].width * 3;
			groupSize.y = Button[0].width * 3;
			groupPosition.x = Screen.width/2 - groupSize.x/2;
			groupPosition.y = Screen.height * 0.1;
			GUI.BeginGroup(Rect(groupPosition.x, groupPosition.y, groupSize.x, groupPosition.y));
			if(tim)
			{
				GUI.Label(Rect(0, 0, Button[4].height,Button[4].width), Button[4]);
			}
			if(topsy)
			{
				GUI.Label(Rect((groupSize.x - (Button[5].width * btnAmp)/2), 0, Button[5].height,Button[5].width), Button[5]);
			}
			GUI.EndGroup();
	}*/
}