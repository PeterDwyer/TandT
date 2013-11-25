using UnityEngine;
using System.Collections;

public class LunchLineSizes : MonoBehaviour 
{
	public GameObject[] kids;
	public Transform[] positions;
	public int[] randomSeq;
	public GameObject Highest;
	public GameObject Smallest;
	public int t = 0;
	public bool setOld;
	public RaycastHit hit;
	public LayerMask layerMask;
	public GameObject target;
	public bool Play;
	public GameObject[] Cor;
	public GameObject[] Discor;
	public int part;
	public bool disappear;
	public float dist = 10000.0f;
	public GameObject[] Text;
	public int Pos;
	public float[] centres;
	public bool play;
	public bool a = true;
	public bool b = true;
	public bool st = true;
	
	
	void Start () 
	{
		Text[2].SetActive(true);
		int i = 1;
		int random = Random.Range(0,6);
		randomSeq[0] = random;
		Vector3 tmpPos;
		
		while(i<6)
		{
			random = Random.Range(0,6);
			int ii = 0;
			
			while(ii < 6)
			{
				t += 1;
				
				if(t>1000)
				{
					print(ii);
					print(i);
					ii = 10;
					i = 10;
				}
				
				if(randomSeq[ii] == random)
				{
						ii = 0;
						random = Random.Range(0,6);
				}	
				else if(ii == 5)
				{
					randomSeq[i] = random;
					ii += 1;
				}
				else
				{
				ii += 1;
				}
			}
			
			i += 1;
		}
		
		i = 0;
		
		while(i<6)
		{
			tmpPos = kids[i].transform.position;
			tmpPos.x = positions[randomSeq[i]].position.x;
			kids[i].transform.position = tmpPos;
			kids[i].name = randomSeq[i].ToString();
			centres[randomSeq[i]] = kids[i].transform.position.y;
			i += 1;
		}
		
		Play = true;
	}
	
	void Update () 
	{
		Color tmpCol;
		
		if(disappear)
		{
			int i = 0;
				
			while(i<6)
			{
				if(i < 2)
				{
					tmpCol = Cor[i].renderer.material.color;
					tmpCol.a -= Time.deltaTime*2;
					
					Cor[i].renderer.material.color = tmpCol;
				}
				
				tmpCol = Discor[i].renderer.material.color;
				tmpCol.a -= Time.deltaTime*2;
				
				Discor[i].renderer.material.color = tmpCol;
				
				if(Discor[5].renderer.material.color.a < 0.01f )
				{
					disappear = false;
					Disable();
				}
				
				i += 1;
			}
		}
		
		if(part == 0 || part == 1)
		{
			//if(Input.touchCount > 0)
			if(Input.GetButton("Fire1"))
			{
				if(Play)
				{
					Play = false;
					//Touch theTouch1 = Input.GetTouch(0);
					//Ray ray1 = Camera.main.ScreenPointToRay(theTouch1.position);
					Ray ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
					
					if(Physics.Raycast( ray1, out hit, 1000f, layerMask))
					{
						target = hit.collider.gameObject;
					}
				}
			}
			else
			{
				if(target != null)
				{
					Camera.main.audio.Stop();
					
					if(part == 0)
					{
						if(target == Highest)
						{
							Cor[0].SetActive(true);
							Text[0].SetActive(true);
							Text[1].SetActive(false);
							Text[2].SetActive(false);
							StartCoroutine(Correct());
						}
						else{
							if(target == Smallest)
							{
								target.transform.GetChild(1).gameObject.SetActive(true);
							}
							else
							{
								target.transform.GetChild(0).gameObject.SetActive(true);
							}
							
							Text[1].SetActive(true);
							Text[2 + part].SetActive(false);
						}
					}
					else if(part == 1)
					{
						if(target == Smallest)
						{
							Cor[1].SetActive(true);
							Text[0].SetActive(true);
							Text[1].SetActive(false);
							Text[3].SetActive(false);
					
							StartCoroutine(Correct());
						}
						else{
							if(target == Highest)
							{
								target.transform.GetChild(1).gameObject.SetActive(true);
							}
							else
							{
								target.transform.GetChild(0).gameObject.SetActive(true);
							}
							
							Text[1].SetActive(true);
							Text[2 + part].SetActive(false);
						}
					}
				}
				
				target = null;
				Play = true;
			}
		}
		
		if(part == 2)
		{
			Vector3 OldTPos = new Vector3();
			Vector3 OldPos = new Vector3();
			Vector3 tmpPos;
			
			if(Input.touchCount > 0)
			//if(Input.GetButton("Fire1"))
			{
				if(Play)
				{
					Touch theTouch = Input.GetTouch(0);
					Ray ray = Camera.main.ScreenPointToRay(theTouch.position);
					//public ray= Camera.main.ScreenPointToRay (Input.mousePosition);
					
						if(Physics.Raycast(ray, out hit,1000f,layerMask))
						{
							if(target == null)
							{
								print("hur");
								st = false;
								target = hit.collider.gameObject;
								target.SendMessage("Active");
							}
						
							if(setOld)
							{
								OldTPos = Camera.main.ScreenToWorldPoint (new Vector3 (theTouch.position.x, theTouch.position.y, 10.0f));
								//public OldTPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
								OldPos = target.transform.position;
							
								setOld = false;
							}
							Vector3 xPos = Camera.main.ScreenToWorldPoint ( new Vector3 (theTouch.position.x, theTouch.position.y, 10.0f));
							//public xPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
							
							Vector3 wantedPos = xPos - OldTPos;
							target.transform.position = OldPos + wantedPos;
						
							tmpPos = target.transform.position;
							tmpPos.z -= 6;
							target.transform.position = tmpPos;
						}
				}
			}
			else
			{
				setOld = true;
				if(target != null)
				{
					tmpPos = target.transform.position;
					tmpPos.z += 6;
					
					target.transform.position = tmpPos;
					target.SendMessage("Deactive");
				}
				if(target != null)
				{
					print("target !null");
					int i = 0;
					
					while(i<6)
					{
						if(Vector3.Distance(positions[i].position, target.transform.position)<dist)
						{
							print("LessDistance");
							dist = Vector3.Distance(positions[i].position, target.transform.position);
							Pos = i;
						}
						
						i += 1;
					}
					
					if(target.transform.position.x < positions[int.Parse(target.name)].position.x)
					{
						if(positions[Pos].position.x - target.transform.position.x < 0)
						{
							Pos += 1;
						}
						if(positions[Pos].position.x - target.transform.position.x > 0)
						{
							if(positions[Pos].position.x > target.transform.position.x)
							{
								int ii = 1;
								
								while(ii<int.Parse(target.name)+1-Pos)
								{
									int fPos = int.Parse(target.name) - ii;
									print(fPos);
									int n = fPos+1;
									GameObject.Find(fPos.ToString()).name = n.ToString();
									ii += 1;
								}
								target.name = Pos.ToString();
							}
						}
					}
					
					if(target.transform.position.x > positions[int.Parse(target.name)].position.x)
					{
						if(positions[Pos].position.x - target.transform.position.x > 0)
						{
							Pos -= 1;
						}
						if(positions[Pos].position.x - target.transform.position.x < 0)
						{
							if(positions[Pos].position.x < target.transform.position.x)
							{
								int ii = 1;
								
								while(ii<Pos - int.Parse(target.name) + 1)
								{
									int fPos = int.Parse(target.name) + ii;
									print(fPos);
									int n = fPos-1;
									GameObject.Find(fPos.ToString()).name = n.ToString();
									ii += 1;
								}
								
								target.name = Pos.ToString();
							};
						}
					}
				}
				dist = 100000;
				target = null;
				
			}
		}
	}
	
	void LateUpdate()
	{
		int i = 0;
		
		if(Input.GetButton("Fire1"))
		{
		}
		else{
			while(i<6)
			{
				GameObject.Find(i.ToString()).transform.position =  Vector3.Lerp(GameObject.Find(i.ToString()).transform.position, new Vector3(positions[i].position.x, GameObject.Find(i.ToString()).transform.position.y, GameObject.Find(i.ToString()).transform.position.z), 8.0f/50f);
				kids[i].transform.position =  Vector3.Lerp(kids[i].transform.position, new Vector3(kids[i].transform.position.x, centres[randomSeq[i]], kids[i].transform.position.z), 8.0f/50f);
				i +=1;
			}
		}
		if(play)
		{
			if(Highest.name == "0")
			{
				if(!st)
				{
					Text[0].SetActive(false);
					Text[1].SetActive(false);
					Text[2].SetActive(false);
					Text[3].SetActive(false);
					Text[4].SetActive(false);
					Text[6].SetActive(false);
					Text[5].SetActive(true);
				}
			}
			else if(Smallest.name == "5")
			{
				if(!st)
				{
					Text[0].SetActive(false);
					Text[1].SetActive(false);
					Text[2].SetActive(false);
					Text[3].SetActive(false);
					Text[4].SetActive(false);
					Text[5].SetActive(false);
					Text[6].SetActive(true);
				}
			}
			else
			{
				if(!st)
				{
					Text[0].SetActive(false);
					Text[1].SetActive(false);
					Text[2].SetActive(false);
					Text[3].SetActive(false);
					Text[4].SetActive(true);
					Text[6].SetActive(false);
					Text[5].SetActive(false);
				}
			}
		}
		i = 0;
		while(i<6)
		{
			if(kids[i].name == i.ToString())
			{
				i +=1;
				if(i == 6)
				{
					Text[0].SetActive(false);
					Text[1].SetActive(false);
					Text[2].SetActive(false);
					Text[3].SetActive(false);
					Text[4].SetActive(false);
					Text[5].SetActive(false);
					Text[6].SetActive(false);
					Text[7].SetActive(true);
					Play = false;
					StartCoroutine(TheEnd());
				}
			}
			else{
				i = 6;
			}
			
		}
	}
	
	IEnumerator TheEnd()
	{
		Vector3 tmpPos;
		
		yield return new WaitForSeconds(4.5f);
		Text[7].SetActive(false);
		Text[7].audio.enabled = false;
		play = false;
		
		tmpPos = Camera.main.transform.position;
		tmpPos.y = 132.84f;
		Camera.main.transform.position = tmpPos;
	}
	
	IEnumerator Disc()
	{
		Text[2 + part].SetActive(false);
		yield return new WaitForSeconds(2f);
		Text[1].SetActive(false);
		if(!Text[0].activeInHierarchy)
		{
			Text[2 + part].SetActive(true);
			Text[6].SetActive(false);
			Text[7].SetActive(false);
		}
	}
	
	IEnumerator Correct()
	{
		part += 3;
		yield return new WaitForSeconds(1f);
		disappear = true;
		yield return new WaitForSeconds(1f);
		part -= 3;
		Text[0].SetActive(false);
		part += 1;
		Text[2 + part].SetActive(true);
		Text[6].SetActive(false);
		Text[7].SetActive(false);
		if(Text[4].activeInHierarchy)
		{
			Play = true;
		}
	}
	
	void Disable()
	{
		int i = 0;
		Color tmpCol;
		
		while(i<6)
		{
			if(i < 2)
			{
				tmpCol = Cor[i].renderer.material.color;
				tmpCol.a = 1;
				Cor[i].renderer.material.color = tmpCol;
				Cor[i].SetActive(false);
			}
			tmpCol = Discor[i].renderer.material.color;
			tmpCol.a = 1;
			Discor[i].renderer.material.color = tmpCol;
			Discor[i].SetActive(false);
			i += 1;
		}
	}
}