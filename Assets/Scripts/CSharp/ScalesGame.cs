using UnityEngine;
using System.Collections;

public class ScalesGame : MonoBehaviour 
{	
	public GameObject targetItem;
	public Transform target;
	public GameObject[] e;
	
	public int t;
	
	public ArrayList used;
	
	public AudioClip corA;
	public AudioClip wrongA;
	
	public GameObject match;
	public GameObject WrongItem;
	public GameObject Fade;
	
	public RaycastHit hit;
	
	public int Dif;
	public int i;
	public float Am;
	public int left=5;
	public int lastT;
	public Vector3 OldPos;
	public Vector3 PrevOldPos;
	public bool Selected;
	
	public GameObject[] texts;
	
	public LayerMask layerMask;
	
	void  Start()
	{
		Difficulty Diff  = Camera.main.GetComponent<Difficulty>();
		Dif = Diff.dif;
	
		i = Random.Range(0,5);
		match.renderer.material = e[i].renderer.material;
		match.name = e[i].name;
		used.Add(i);
	}
	
	void Update()
	{
		Vector3 tmpPos;
		
		if(t != lastT)
		{
			if(t != 0)
			{
				if(lastT == 0)
				{
					if(Dif == 0)
					{
						texts[3].SetActive(false);
					}
					if(Dif == 1)
					{
						texts[4].SetActive(false);
					}
					if(Dif == 2)
					{
						texts[5].SetActive(false);
					}
				}
				else
				{
					texts[lastT].SetActive(false);
				}
				texts[t].SetActive(true);
				lastT = t;
			}
			else
			{
				if(Dif == 0)
				{
					texts[3].SetActive(true);
				}
				if(Dif == 1)
				{
					texts[4].SetActive(true);
				}
				if(Dif == 2)
				{
					texts[5].SetActive(true);
				}
				texts[lastT].SetActive(false);
				lastT = t;
			}
		}
		//if(Input.touchCount > 0)
		if(Input.GetButton("Fire1"))
		{
			//public theTouch : Touch = Input.GetTouch(0);
			//public ray = Camera.main.ScreenPointToRay(theTouch.position);
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if(targetItem != null)
			{
				if(!Selected)
				{
					OldPos = targetItem.transform.position;
					Selected = true;
				}
				//public wantedPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
				Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
				targetItem.transform.position = wantedPos; 
				
				tmpPos = targetItem.transform.position;
				tmpPos.z = 3;
				targetItem.transform.position = tmpPos; 
			}
			else
			{
				if(Physics.Raycast(ray,out hit,100f,layerMask))
				{
					targetItem = hit.collider.gameObject;	
				}
			}
		}
		else if(targetItem != null)
		{
			tmpPos = targetItem.transform.position;
			tmpPos.z = 4;
			targetItem.transform.position = tmpPos;
				
			if(Vector3.Distance(target.position, targetItem.transform.position) < 7.0f)
			{
				targetItem.layer = 0;
				
				tmpPos = targetItem.transform.position;
				tmpPos.z = 4;
				targetItem.transform.position = tmpPos;
				
				if(targetItem.name == match.name)
				{
					GameObject.Find("CrossBar").SendMessage("Center");
					GameObject.Find("Basket1").SendMessage("Center");
					GameObject.Find("Basket2").SendMessage("Center");
					targetItem.SendMessage("Change");
					match.SendMessage("Change");
					StartCoroutine(cor());
				}
				else
				{
					GameObject.Find("CrossBar").SendMessage("Right");
					GameObject.Find("Basket1").SendMessage("Right");
					GameObject.Find("Basket2").SendMessage("Right");
					WrongItem = targetItem;
					StartCoroutine(ReturnItem());
				}
				target.DetachChildren();
				targetItem.transform.parent = target;
				PrevOldPos = OldPos;
			}
			else
			{
				targetItem.transform.position = OldPos;
			}
			Selected = false;
			targetItem = null;
		}
		Am = Screen.height/82.0f;
	}
	
	
	
	IEnumerator en()
	{
		Vector3 tmpPos;
		
		left -= 1;
		 
		if(left>0)
		{
			int u = 0;
			
			while(u < used.Count)
			{
				if(i == (int) used[u])
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else if(e[i] == null)
				{
					i = Random.Range(0,5);
					u = 0;
				}
				else{
					u += 1;
				}
			}
			
			match.renderer.material = e[i].renderer.material;
			match.name = e[i].name;
			GameObject.Find("CrossBar").SendMessage("Left");
			GameObject.Find("Basket1").SendMessage("Left");
			GameObject.Find("Basket2").SendMessage("Left");
		}
		else
		{
			//win
			Instantiate(Fade, Camera.main.transform.position, Camera.main.transform.rotation);
			Destroy(match);
			yield return new WaitForSeconds(0.55f);
			
			tmpPos = Camera.main.transform.position;
			tmpPos.y = 200.0f;
			
			Camera.main.transform.position = tmpPos;
			GameObject.Find("Text2").audio.Play();
			
		}
	}
	
	
	IEnumerator ReturnItem()
	{
		yield return new WaitForSeconds(2f);
		audio.clip = wrongA;
		audio.Play();
		WrongItem.transform.position = PrevOldPos;
		WrongItem.layer = 8;
		GameObject.Find("CrossBar").SendMessage("Left");
		GameObject.Find("Basket1").SendMessage("Left");
		GameObject.Find("Basket2").SendMessage("Left");
		target.DetachChildren();
		t = 2;
		StartCoroutine(ChangeBack());
	}
	
	IEnumerator cor()
	{
		StartCoroutine(ChangeBack());
		yield return new WaitForSeconds(1f);
		audio.clip = corA;
		audio.Play();
		t = 1;
		StartCoroutine(ChangeBack());
	}
	
	IEnumerator ChangeBack()
	{
		yield return new WaitForSeconds(2.5f);
		
		t = 0;	
	}
}