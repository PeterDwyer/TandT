using UnityEngine;
using System.Collections;

public class Puzzles : MonoBehaviour 
{	
	public float FPosX; //First puzzle position
	public float FPosY;
	public float width;
	public float Catch = 8.0f; //Catches puzzle at this distance
	public int cols;
	public int rows;
	public int number;
	public GameObject targetItem;
	public GameObject DifScrp;
	public Vector3[] ePuzzlesPos;
	public GameObject[] ePuz;
	public Transform[] eStart;
	public Vector3[] mPuzzlesPos;
	public GameObject[] mPuz;
	public Transform[] mStart;
	public Vector3[] hPuzzlesPos;
	public GameObject[] hPuz;
	public Transform[] hStart;
	public int dif = 0;
	private bool start;
	private bool Play;
	private bool DisP;
	private bool EnP;
	private int c = 0;
	private int r = 0;
	private GameObject oldItem;
	private RaycastHit hit;
	private bool ReturnItem;
	private bool DispHard;
	public LayerMask layerMask;
	private int placed;
	public GameObject Fade;
	public bool fade;
	public bool fadeIn;
	public GameObject Text1;
	
	IEnumerator Start()
	{
	
		Difficulty Dif = (Difficulty) DifScrp.GetComponent("Difficulty");
		dif = Dif.dif;
		
		if(dif == 0)
		{
			number = 4;
		}
		
		if(dif == 1)
		{
			number = 6;
		}
		
		if(dif == 2)
		{
			number = 9;
		}
		
		int i = 0;
	
		while(i<number)
		{
			if(dif == 0)
			{
				ePuzzlesPos[i] = ePuz[i].transform.position;
			}
			if(dif == 1)
			{
				mPuzzlesPos[i] = mPuz[i].transform.position;
			}
			if(dif == 2)
			{
				hPuzzlesPos[i] = hPuz[i].transform.position;
			}
			i +=1;
		}
		
		if(dif != 2)
		{
			yield return new WaitForSeconds(3);
				DisP = true;
			yield return new WaitForSeconds(1);
		}
		else{
			DispHard = true;
		}
		
		start = true;
	}
	
	IEnumerator Stop()
	{
		yield return new WaitForSeconds(1);
		start = false;
		Play = true;
	}
	
	IEnumerator Done()
	{
		audio.Play();
		yield return new WaitForSeconds(3);
		fade = true;
	}
	
	void Update()
	{
		Vector3 tmpPos;
		Color tmpCol;
		
		if(fade)
		{
			tmpCol = Fade.renderer.material.color;
			tmpCol.a += Time.deltaTime; 
			Fade.renderer.material.color = tmpCol;
			
			if(Fade.renderer.material.color.a > 0.99)
			{
				tmpPos = Camera.main.transform.position;
				tmpPos.y = 273.6f;
				Camera.main.transform.position = tmpPos;
				fade = false;
				fadeIn = true;
				Text1.SetActive(true);
			}
		}
		
		if(fadeIn)
		{
			tmpCol = Fade.renderer.material.color;
			tmpCol.a -= Time.deltaTime;
			
			Fade.renderer.material.color = tmpCol;
			
			if(Fade.renderer.material.color.a < 0.01)
			{
				tmpCol.a = 0;
				Fade.renderer.material.color = tmpCol;
				fadeIn = false;
			}
		}
		
		if(ReturnItem && oldItem != null)
		{
			if(dif == 0)
			{
				if(Vector3.Distance(oldItem.transform.position, eStart[int.Parse(oldItem.name)-1].position)> 0.5)
				{
					oldItem.transform.position = Vector3.Lerp(oldItem.transform.position, eStart[int.Parse(oldItem.name)-1].position, 3.5f/50f);
				}
				else{
					ReturnItem = false;
				}
			}
			
			if(dif == 1)
			{
				if(Vector3.Distance(oldItem.transform.position, mStart[int.Parse(oldItem.name)-1].position)> 0.5)
				{
					oldItem.transform.position = Vector3.Lerp(oldItem.transform.position, mStart[int.Parse(oldItem.name)-1].position, 3.5f/50f);
				}
				else{
					ReturnItem = false;
				}
			}
			
			if(dif == 2)
			{
				if(Vector3.Distance(oldItem.transform.position, hStart[int.Parse(oldItem.name)-1].position)> 0.5)
				{
					oldItem.transform.position = Vector3.Lerp(oldItem.transform.position, hStart[int.Parse(oldItem.name)-1].position, 3.5f/50f);
				}
				else{
					ReturnItem = false;
				}
			}
		}
		
		if(DispHard)
		{
			tmpCol = GameObject.Find("hardPuz").renderer.material.color;
			tmpCol.a = 0;
			GameObject.Find("hardPuz").renderer.material.color = tmpCol;
	
			DispHard = false;
		}
		
		if(DisP)
		{
			if(dif == 0)
			{
				tmpCol = GameObject.Find("easyPuz").renderer.material.color;
				tmpCol.a -= Time.deltaTime * 2;
				
				GameObject.Find("easyPuz").renderer.material.color = tmpCol;
				
				if(GameObject.Find("easyPuz").renderer.material.color.a < 0.01)
				{
					DisP = false;
				}
			}
			if(dif == 1)
			{
				tmpCol = GameObject.Find("medPuz").renderer.material.color;
				tmpCol.a -= Time.deltaTime * 2;
				
				GameObject.Find("medPuz").renderer.material.color = tmpCol;
				if(GameObject.Find("medPuz").renderer.material.color.a < 0.01)
				{
					DisP = false;
				}
			}
		}
		
		if(EnP)
		{
			if(dif == 0)
			{
				tmpCol = GameObject.Find("easyPuz").renderer.material.color;
				tmpCol.a += Time.deltaTime * 2;
				
				GameObject.Find("easyPuz").renderer.material.color = tmpCol;
				if(GameObject.Find("easyPuz").renderer.material.color.a > 0.99)
				{
					StartCoroutine(Done());
	
					EnP = false;
				}
			}
			
			if(dif == 1)
			{
				tmpCol = GameObject.Find("medPuz").renderer.material.color;
				tmpCol.a += Time.deltaTime * 2;
				
				GameObject.Find("medPuz").renderer.material.color = tmpCol;
				if(GameObject.Find("medPuz").renderer.material.color.a > 0.99)
				{
					StartCoroutine(Done());
					EnP = false;
				}
			}
			
			if(dif == 2)
			{
				tmpCol = GameObject.Find("hardPuz").renderer.material.color;
				tmpCol.a += Time.deltaTime * 2;
				
				GameObject.Find("hardPuz").renderer.material.color = tmpCol;
				if(GameObject.Find("hardPuz").renderer.material.color.a > 0.99)
				{
					StartCoroutine(Done());
					EnP = false;
				}
			}
		}
		
		if(start)
		{
			StartCoroutine(Stop());
			int i = 0;
			
			while(i<number)
			{
				if(dif == 0)
				{
					ePuz[i].transform.position = Vector3.Lerp(ePuz[i].transform.position, eStart[i].position, 3.5f/50f);
				}
				
				if(dif == 1)
				{
					mPuz[i].transform.position = Vector3.Lerp(mPuz[i].transform.position, mStart[i].position, 3.5f/50f);
				}
				
				if(dif == 2)
				{
					hPuz[i].transform.position = Vector3.Lerp(hPuz[i].transform.position, hStart[i].position, 3.5f/50f);
				}
				
				i += 1;
			}
			
			i = 0;
		}
		
		if(Play)
		{
			//if(Input.touchCount > 0)
			if(Input.GetButton("Fire1"))
			{
				//Touch theTouch = Input.GetTouch(0);
				//Ray ray = Camera.main.ScreenPointToRay(theTouch.position);
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if(targetItem != null)
				{
				//	Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (theTouch.position.x, theTouch.position.y, 10.0f));
					Vector3 wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
					JigsawSelected scr = (JigsawSelected) targetItem.transform.GetChild(0).gameObject.GetComponent("JigsawSelected");
					targetItem.transform.GetChild(0).gameObject.renderer.material = scr.Selected;
					targetItem.transform.position = wantedPos; 
					
					tmpPos = targetItem.transform.position;
					tmpPos.z = -11; 
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
				tmpPos.z = -10;
				targetItem.transform.position = tmpPos;
				JigsawSelected scr = (JigsawSelected) targetItem.transform.GetChild(0).gameObject.GetComponent("JigsawSelected");
				targetItem.transform.GetChild(0).gameObject.renderer.material = scr.Original;
				if(dif == 0)
				{
					if(Vector3.Distance(ePuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position)<Catch || Vector3.Distance(ePuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position) == 0.0)
					{
						targetItem.layer = 0;
						targetItem.transform.position = ePuzzlesPos[int.Parse(targetItem.name)-1];
						Vector3.Distance(ePuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position);
						targetItem = null;
						oldItem = null;
						placed += 1;
						if(placed == number)
						{
							EnP = true;
						}
					}
					else
					{
						oldItem = targetItem;
						ReturnItem = true;
						oldItem.layer = 10;
					}
				}
				if(dif == 1)
				{
					if(Vector3.Distance(mPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position)<Catch || Vector3.Distance(mPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position) == 0.0)
					{
						targetItem.layer = 0;
						targetItem.transform.position = mPuzzlesPos[int.Parse(targetItem.name)-1];
						Vector3.Distance(mPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position);
						targetItem = null;
						oldItem = null;
						placed += 1;
						if(placed == number)
						{
							EnP = true;
						}
					}
					else
					{
						oldItem = targetItem;
						ReturnItem = true;
						oldItem.layer = 10;
					}
				}
				if(dif == 2)
				{
					if(Vector3.Distance(hPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position)<Catch || Vector3.Distance(hPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position) == 0.0)
					{
						targetItem.layer = 0;
						targetItem.transform.position = hPuzzlesPos[int.Parse(targetItem.name)-1];
						Vector3.Distance(hPuzzlesPos[int.Parse(targetItem.name)-1], targetItem.transform.position);
						targetItem = null;
						oldItem = null;
						placed += 1;
						if(placed == number)
						{
							EnP = true;
						}
					}
					else
					{
						oldItem = targetItem;
						ReturnItem = true;
						oldItem.layer = 10;
					}
				}
				targetItem = null;
			}
		}
	}
}