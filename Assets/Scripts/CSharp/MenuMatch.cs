using UnityEngine;
using System.Collections;

public class MenuMatch : MonoBehaviour 
{
	public GameObject easy;
	public GameObject med;
	public GameObject hard;
	public float timeDif;
	public float LineWidth;
	public int n;
	public int D;
	public GameObject[] menuPlates;
	public GameObject[] facePegObj;
	public Vector3[] facePegPos;
	private float duration;
	public int[] ePlates;
	public int[] mPlates;
	public int[] hPlates;
	public GameObject[] eObject;
	public GameObject[] mObject;
	public GameObject[] hObject;
	public GameObject[] eCovers;
	public GameObject[] mCovers;
	public GameObject[] hCovers;
	public GameObject[] platesObj;
	public int[] rPlates;
	public int dif;
	public int i;
	public int iPlate;
	public int iFace;
	public bool Play;
	public GameObject DifScrp;
	public float stTime;
	public GameObject AllFaces;
	public int player;
	public Material[] allFood;
	public Material[] allFaces;
	public bool startScroll;
	public bool scrollBack;
	public GameObject First;
	public GameObject targetPlate;
	public GameObject targetFace;
	public int co;
	private bool disap;
	private bool setOld;
	private Vector3 OldTPos;
	private Vector3 OldFacesPos;
	private Ray ray;
	private bool tt;
	private bool liftCover;
	private bool liftCoverB;
	private bool liftMenu;
	private bool liftMenuB;
	private bool nullTargets;
	public LayerMask facePegMask;
	public LayerMask plateMask;
	public LayerMask faceMask;
	public Material blackHands;
	private RaycastHit hit;
	public Touch theTouch1;
	public Vector3 xPos;
	public GameObject txt;
	
	void Start () 
	{
		Difficulty Dif = (Difficulty) DifScrp.GetComponent("Difficulty");
		dif = Dif.dif;
		Play = false;
		stTime = Time.time+0.5f;
		AllFaces.SetActive(true);
		
		if(dif == 0)
		{
			easy.SetActive(true);
			timeDif = 3.25f;
			duration = 25;
			LineWidth = 4.0f*38.0f;
			n = 4;
			D = 4;
			while(D < 8)
			{
				facePegObj[D].SetActive(false);
				facePegObj[D] = null;
				D += 1;
			}
			player = Random.Range(0,4);
		}
		if(dif == 1)
		{
			duration = 25;
			med.SetActive(true);
			timeDif = 3.75f;
			LineWidth = 6.0f*38.0f;
			n = 6;
			D = 6;
			while(D < 8)
			{
				facePegObj[D].SetActive(false);
				facePegObj[D] = null;
				D += 1;
			}
			player = Random.Range(0,6);
		}
		if(dif == 2)
		{
			duration = 50;
			timeDif = 4.25f;
			hard.SetActive(true);
			LineWidth = 8.0f*38.0f;
			n = 8;
			player = Random.Range(0,8);
		}
		
		i = 3;
		int p = 0;
		i = 0;
		
		while(i<n)
		{
			p = Random.Range(1,9);
	
			int ii = 0;
			
			while(ii<n)
			{
					if(dif == 0)
					{
						if(p == ePlates[ii])
						{
							ii = n;
						}
						else if(ii == n-1)
						{
								ePlates[i] = p;
							i += 1;
						}
						ii += 1;
					}
					if(dif == 1)
					{
						if(p == mPlates[ii])
						{
							ii = n;
						}
						else if(ii == n-1)
						{
	
								mPlates[i] = p;
	
							i += 1;
						}
						ii += 1;
					}
					if(dif == 2)
					{
						if(p == hPlates[ii])
						{
							ii = n;
						}
						else if(ii == n-1)
						{
								hPlates[i] = p;
								
							i += 1;
						}
						ii += 1;
					}
			}
		}
		
		i = 0;
		
		while( i < n )
		{
			if(dif == 0)
			{
				p = Random.Range(0,4);
			}
			
			if(dif == 1)
			{
				p = Random.Range(0,6);
			}
			
			if(dif == 2)
			{
				p = Random.Range(0,8);
			}
			
			int ii = 0;
	
			while( ii < n )
			{
				if(dif == 0)
				{
					if(ePlates[p] == rPlates[ii])
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						rPlates[i] = ePlates[p];
						platesObj[p].renderer.material = allFood[ePlates[p]];
						menuPlates[p].renderer.material = allFood[ePlates[p]];
						facePegObj[p].renderer.material = allFaces[i+1];
						facePegPos[p] = facePegObj[i].transform.localPosition;
						
						if(i == 0 || i == 1)
						{
								facePegObj[p].transform.GetChild(0).gameObject.renderer.material = blackHands;
						}
						
						i += 1;
					}
					
					ii += 1;
				}
				
				if(dif == 1)
				{
					if(mPlates[p] == rPlates[ii] && mPlates[ii] != 0)
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						rPlates[i] = mPlates[p];
						platesObj[p].renderer.material = allFood[mPlates[p]];
						menuPlates[p].renderer.material = allFood[mPlates[p]];
						facePegObj[p].renderer.material = allFaces[i+1];
						facePegPos[p] = facePegObj[i].transform.localPosition;
						if(i == 0 || i == 1)
						{
								facePegObj[p].transform.GetChild(0).gameObject.renderer.material = blackHands;
						}
						i += 1;
					}
					ii += 1;
				}
				if(dif == 2)
				{
					if(hPlates[p] == rPlates[ii] && hPlates[ii] != 0)
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						rPlates[i] = hPlates[p];
						platesObj[p].renderer.material = allFood[hPlates[p]];
						menuPlates[p].renderer.material = allFood[hPlates[p]];
						facePegObj[p].renderer.material = allFaces[i+1];
						facePegPos[p] = facePegObj[i].transform.localPosition;
						if(i == 0 || i == 1)
						{
								facePegObj[p].transform.GetChild(0).gameObject.renderer.material = blackHands;
						}
						i += 1;
					}
					ii += 1;
				}
			}
		}
		
		i = 0;
		
		while(i<n)
		{
			if(dif == 0)
			{
				eObject[i].renderer.material = allFood[rPlates[i]];
			}
			if(dif == 1)
			{
				mObject[i].renderer.material = allFood[rPlates[i]];
			}
			if(dif == 2)
			{
				hObject[i].renderer.material = allFood[rPlates[i]];
			}
			i += 1;
		}
		StartCoroutine(St());
	}
	
	IEnumerator St()
	{
		yield return new WaitForSeconds(1.0f);
		startScroll = true;
		if(dif == 0)
		{
			yield return new WaitForSeconds(1.75f);
			startScroll = false;
			scrollBack = true;
			yield return new WaitForSeconds(3.0f);
			scrollBack = false;
		}
		if(dif == 1)
		{
			yield return new WaitForSeconds(3.25f);
			startScroll = false;
			scrollBack = true;
			yield return new WaitForSeconds(4.5f);
			scrollBack = false;
		}
		if(dif == 2)
		{
			yield return new WaitForSeconds(4.25f);
			startScroll = false;
			scrollBack = true;
			yield return new WaitForSeconds(5.0f);
			scrollBack = false;
		}
		targetFace = null;
		targetPlate = null;
		Play = true;
	}
	
	void Update()
	{
		Color tmpCol;
		Vector3 tmpPos;
		
		if(disap)
		{
			tmpCol = targetPlate.renderer.material.color;
			tmpCol.a -= Time.deltaTime*3f;
			targetPlate.renderer.material.color = tmpCol;
			
			tmpCol = targetPlate.transform.parent.renderer.material.color;
			tmpCol.a -= Time.deltaTime*3f;
			targetPlate.transform.parent.renderer.material.color = tmpCol;
			platesObj[iFace].SetActive(true);
		}
		
		if(liftCover)
		{
			targetPlate.transform.position = Vector3.Lerp(targetPlate.transform.position, new Vector3(targetPlate.transform.parent.position.x, targetPlate.transform.parent.position.y + 10f, targetPlate.transform.parent.position.z-5), 7.5f/50f);
		}
		
		if(liftMenu)
		{
			targetFace.transform.GetChild(0).position = Vector3.Lerp(targetFace.transform.GetChild(0).position, new Vector3(targetFace.transform.position.x, targetFace.transform.position.y - 4.5f, targetFace.transform.position.z), 7.5f/50f);
		}
		
		if(liftCoverB)
		{
			targetPlate.transform.position = Vector3.Lerp(targetPlate.transform.position, new Vector3(targetPlate.transform.parent.position.x, targetPlate.transform.parent.position.y , targetPlate.transform.parent.position.z-3f), 7.5f/50f);
		}
		
		if(liftMenuB)
		{
			targetFace.transform.GetChild(0).position = Vector3.Lerp(targetFace.transform.GetChild(0).position, new Vector3(targetFace.transform.position.x, targetFace.transform.position.y - 30f, targetFace.transform.position.z), 7.5f/50f);
		}
		
		if(nullTargets)
		{
			liftCoverB = false;
			liftMenuB = false;
			targetPlate = null;
			targetFace = null;
			Play = true;
			nullTargets = false;
		}
		
		if(startScroll)
		{
			AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-39.00f - (LineWidth - 3.0f*38.0f), AllFaces.transform.position.y, AllFaces.transform.position.z), (Time.time-stTime)/duration);
		}
		
		if(scrollBack)
		{
			AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-39.0f, AllFaces.transform.position.y, AllFaces.transform.position.z), ((Time.time-stTime)-timeDif)/duration);
		}
		
		/////// *** Controls ***
		//if(Input.touchCount > 0)
		if(Input.GetButton("Fire1"))
		{
			//Touch theTouch = Input.GetTouch(0);
			tt = true;
			if(setOld)
			{
				//OldTPos = Camera.main.ScreenToWorldPoint (new Vector3 (theTouch.position.x, theTouch.position.y, 10.0f));
				OldTPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
				OldFacesPos = AllFaces.transform.position;
				setOld = false;
			}

			//ray = Camera.main.ScreenPointToRay(theTouch.position);
			ray= Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit,1000f,facePegMask))
			{
				//xPos = Camera.main.ScreenToWorldPoint (new Vector3 (theTouch.position.x, theTouch.position.y, 10.0f));
				xPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
				Vector3 wantedPos;
				wantedPos.x = xPos.x - OldTPos.x;
			
				tmpPos = AllFaces.transform.position;
				tmpPos.x = OldFacesPos.x + wantedPos.x;
				AllFaces.transform.position = tmpPos;
				
			}
		}
		else
		{
			setOld = true;
		}
		
		if(Play)
		{
			//if(Input.touchCount > 0)
			if(Input.GetButton("Fire1"))
			{
				tt = true;
				//theTouch1 = Input.GetTouch(0);
				//ray = Camera.main.ScreenPointToRay(theTouch1.position);
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			}
			else if(tt)
			{
				if(OldFacesPos.x > AllFaces.transform.position.x-0.7 && OldFacesPos.x < AllFaces.transform.position.x+0.7)
				{
					if(targetPlate != null)
					{
						/////
					}
					else
					{
						if(Physics.Raycast(ray, out hit,1000f,plateMask))
						{
							print("targetPlate");
							targetPlate = hit.collider.gameObject;
							liftCover = true;
						}
					}
					if(targetFace != null)
					{
						/////
					}
					else
					{
						if(Physics.Raycast(ray,out hit, 1000f,faceMask))
						{
							print("targetFace");
							targetFace = hit.collider.gameObject;	
							liftMenu = true;				
						}
					}
				}
				tt = false;
			}
			
			if(targetPlate != null && targetFace != null)
			{
				////
				Play = false;
				i = 0;
				if(dif == 0)
				{
					while(i<n)
					{
						if(targetPlate.transform.parent.gameObject == eObject[i])
						{
							iPlate = i;
							i = n;
							print("iPlate: " + iPlate);
						}
						i += 1;
					}
					i = 0;
					while(i<n)
					{
						if(targetFace.gameObject == facePegObj[i])
						{
							iFace = i;
							i = n;
							print("iFace: " + iFace);
						}
						i += 1;
					}
					if(rPlates[iPlate] == ePlates[iFace])
					{
						print("yayyy");
						if(ePlates[iFace] == 3 || ePlates[iFace] == 2 || ePlates[iFace] == 6 || ePlates[iFace] == 8)
						{
							print("girl");
						}
						Play = false;
						StartCoroutine(Dst());
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						StartCoroutine(LiftB());
					}
				}
				if(dif == 1)
				{
					while(i<n)
					{
						if(targetPlate.transform.parent.gameObject == mObject[i])
						{
							iPlate = i;
							i = n;
							print("iPlate: " + iPlate);
						}
						i += 1;
					}
					i = 0;
					while(i<n)
					{
						if(targetFace.gameObject == facePegObj[i])
						{
							iFace = i;
							i = n;
							print("iFace: " + iFace);
						}
						i += 1;
					}
					if(rPlates[iPlate] == mPlates[iFace])
					{
						print("yayyy");
						if(mPlates[iFace] == 3 || mPlates[iFace] == 2 || mPlates[iFace] == 6 || mPlates[iFace] == 8)
						{
							print("girl");
						}
						Play = false;
						StartCoroutine(Dst());
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						StartCoroutine(LiftB());
					}
				}
				if(dif == 2)
				{
					while(i<n)
					{
						if(targetPlate.transform.parent.gameObject == hObject[i])
						{
							iPlate = i;
							i = n;
							print("iPlate: " + iPlate);
						}
						i += 1;
					}
					i = 0;
					while(i<n)
					{
						if(targetFace.gameObject == facePegObj[i])
						{
							iFace = i;
							i = n;
							print("iFace: " + iFace);
						}
						i += 1;
					}
					if(rPlates[iPlate] == hPlates[iFace])
					{
						print("yayyy");
						if(hPlates[iFace] == 3 || hPlates[iFace] == 2 || hPlates[iFace] == 6 || hPlates[iFace] == 8)
						{
							print("girl");
						}
						Play = false;
						StartCoroutine(Dst());
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						StartCoroutine(LiftB());
					}
				}
			}
		}
	}
	
	IEnumerator LiftB()
	{
		yield return new WaitForSeconds(1f);
		liftCover = false;
		liftMenu = false;
		liftCoverB = true;
		liftMenuB = true;
		yield return new WaitForSeconds(1f);
		liftCoverB = false;
		liftMenuB = false;
		nullTargets = true;
	}
	
	IEnumerator Dst()
	{
		yield return new WaitForSeconds(1.0f);
		liftCover = false;
		liftMenu = false;
		//EnableKidPlate
		disap = true;
		yield return new WaitForSeconds(1.0f);
		liftCoverB = true;
		liftMenuB = true;
		yield return new WaitForSeconds(1.0f);
		disap = false;
		liftCoverB = false;
		liftMenuB = false;
		targetFace.layer = 0;
		targetPlate.layer = 0;
		targetFace = null;
		targetPlate = null;
		co += 1;
		Play = true;
		
	}
	
	void LateUpdate()
	{
		Vector3 tmpPos;
		
		if(co == n)
		{
			//fade
			txt.SetActive(true);
			
			tmpPos = Camera.main.transform.position;
			tmpPos.y = 315.8f;
			Camera.main.transform.position = tmpPos;
		}
	
		if(First.transform.position.x + 39.0 < - (LineWidth - 3.0*38.0))
		{
			if((First.transform.position.x + 39.0) > - (LineWidth - 3.0*38.0)-0.8)
			{
				tmpPos = AllFaces.transform.position;
				tmpPos.x = -39.0f - (LineWidth - 3.0f*38.0f);
				AllFaces.transform.position = tmpPos;
			}
			else
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-39.0f - (LineWidth - 3.0f*38.0f), AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5f/50f);
			
			}
		}
		if(First.transform.position.x > -39.0)
		{
			if(First.transform.position.x < -38.0)
			{
				tmpPos = AllFaces.transform.position;
				tmpPos.x = -39.0f;
				AllFaces.transform.position = tmpPos;
			}
			else
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-39.5f, AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5f/50f);
			}
		}	
	}
}