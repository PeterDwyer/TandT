using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour 
{
	
	public GameObject targetIco;
	public GameObject target;
	public Transform[] GoalPos;
	public GameObject[] Ico;
	public GameObject[] Item;
	public LayerMask layerMask;
	public RaycastHit hit;
	public int n;
	public float Catch = 15.0f;
	public GameObject Goal;
	public GameObject[] text;
	public GameObject Next;
	public int i = 0;
	public int co = 0;
	public Material[] numbers;
	public GameObject Num;
	
	void Start () {
	
	}
	
	void Update () 
	{
		if(co > 0 && co < 4)
		{
			Num.renderer.material = numbers[co-1];
		}
		if(co == 3)
		{
			i = 0;
			
			while(i<6)
			{
				text[i].SetActive(false);
				i += 1;
			}
			//text[6].SetActive(false);
			text[5].SetActive(true);
			Next.SetActive(true);
			co = 4;
		}
			//if(Input.touchCount > 0)
			if(Input.GetButton("Fire1"))
			{
				//Touch theTouch = Input.GetTouch(0);
				//Ray  ray = Camera.main.ScreenPointToRay(theTouch.position);
				
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				
				if(target != null)
				{
					//Vector3 wantedPos = Camera.main.ScreenToWorldPoint ( new Vector3 (theTouch.position.x, theTouch.position.y, 1.0f));
					Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 1.0f));
					target.transform.position = wantedPos; 
					//target.transform.position.z = 1.0f; 
				}
				else
				{
					if( Physics.Raycast( ray, out hit,100f,layerMask ) )
					{
						targetIco = hit.collider.gameObject;	
						i = 0;
						
						while( i < 4 )
						{
							if( targetIco == Ico[i] )
							{
								print("srh");
								Ico[i].SetActive(false);
								Item[i].SetActive(true);
								target = Item[i];
								n = i;
								i = 4;
							}	
							i += 1;
						}
					}
				}
			}
			else if(target != null)
			{
				if(Vector3.Distance(target.transform.position, Goal.transform.position)<Catch)
				{
					if(n == 0)
					{
						i = 0;
					
						while(i<6)
						{
							text[i].SetActive(false);
							i += 1;
						}
					
						text[1].SetActive(true);
						Ico[n].SetActive(true);
						target.SetActive(false);
						target = null;
						targetIco = null;
					}
					else
					{
						i = 0;
					
						while(i<6)
						{
							text[i].SetActive(false);
							i += 1;
						}
					
						text[7].SetActive(false);
						target.transform.position = GoalPos[n-1].position;
						co += 1;
					
						if(co != 3)
						{
							text[n+1].SetActive(true);
						}
					}
				}
				else
				{
					Ico[n].SetActive(true);
					target.SetActive(false);
					target = null;
					targetIco = null;
				}
			
				target = null;
			}
		}
}