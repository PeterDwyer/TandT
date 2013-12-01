using UnityEngine;
using System.Collections;

public class Pegs : MonoBehaviour 
{
	public GameObject Intro;
	public GameObject End;
	public int dif;
	public int n;
	public int[] rPegs;
	public GameObject easy;
	public GameObject med;
	public GameObject hard;
	public GameObject[] eCards;
	public GameObject[] mCards;
	public GameObject[] hCards;
	public GameObject[] fPegs;
	public GameObject[] facePegObj;
	public Vector3[] facePegPos;
	public int[] ePegs;
	public int[] mPegs;
	public int[] hPegs;
	public int player;
	public Material[] allPegs;
	public Material[] allFaces;
	public GameObject targetPeg;
	public GameObject targetFace;
	private RaycastHit hit;
	public bool rotatePeg;
	public bool rotateFace;
	public bool rotatePegB;
	public bool rotateFaceB;
	public bool nullTargets;
	public LayerMask pegMask;
	public LayerMask faceMask;
	public LayerMask facePegMask;
	public int iPeg;
	public int iFace;
	private int D;
	public int i;
	public bool Play = true;
	public int add;
	public bool Fit;
	public bool Change;
	public int co;
	public float LineWidth;
	public GameObject First;
	public GameObject AllFaces;
	public Vector3 OldFacesPos;
	public Vector3 OldTPos;
	public bool setOld;
	public Vector3 wantedPos;
	public Vector3 xPos;
	public bool spin;
	public bool startScroll = false;
	public bool scrollBack = false;
	public float timeDif;
	public bool disap;
	public float duration;
	public float stTime;
	public GameObject DifScrp;
	public bool tt;
	public Touch theTouch1;
	public Ray ray;
	public GameObject Sticker;
	public int stickerNum;
	public Material[] stickersMat;
	public AudioClip cor;
	public AudioClip dis;
	
	void Start () 
	{
		Intro.SetActive(false);
		player = PlayerPrefs.GetInt("playerSticker");
		stickerNum = PlayerPrefs.GetInt("stickerNum");
		
		if(player == 0)
		{
			//print("some is nulis");
			player = 13;
			stickerNum = 5;
		}
		
		Sticker.renderer.material = stickersMat[stickerNum];
		Difficulty Dif = (Difficulty) DifScrp.GetComponent("Difficulty");
		dif = Dif.dif;
		Play = false;
		StartCoroutine(St());
		stTime = Time.time;
		AllFaces.SetActive(true);
		
		if(dif == 0)
		{
			easy.SetActive(true);
			timeDif = 1.0f;
			LineWidth = 4.0f*26.0f;
			n = 4;
			D = 4;
			
			while(D < 12)
			{
				facePegObj[D].SetActive(false);
				facePegObj[D] = null;
				D += 1;
			}
		}
		
		if(dif == 1)
		{
			duration = 40;
			med.SetActive(true);
			timeDif = 3.0f;
			LineWidth = 8.0f*26.0f;
			n = 8;
			D = 8;
			
			while(D < 12)
			{
				facePegObj[D].SetActive(false);
				facePegObj[D] = null;
				D += 1;
			}
		}
		
		if(dif == 2)
		{
			duration = 70;
			timeDif = 4.0f;
			hard.SetActive(true);
			LineWidth = 12.0f*26.0f;
			n = 12;
		}
		
		i = 3;
		int p = 0;
		ePegs[0] = player;
		mPegs[0] = player;
		hPegs[0] = player;
		fPegs[0].renderer.material = allPegs[player];
		facePegPos[0] = facePegObj[0].transform.localPosition;
		facePegPos[1] = facePegObj[1].transform.localPosition;
		facePegPos[2] = facePegObj[2].transform.localPosition;
	
		while(i<n)
		{
			p = Random.Range(1,17);
			int ii = 0;
			
			while(ii<n)
			{
				if(dif == 0)
				{
					if(p == ePegs[ii])
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						ePegs[i] = p;
						fPegs[i].renderer.material = allPegs[p];
						facePegObj[i].renderer.material = allFaces[p];
						facePegPos[i] = facePegObj[i].transform.localPosition;
						i += 1;
					}
					ii += 1;
				}
				
				if(dif == 1)
				{
					if(p == mPegs[ii])
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						mPegs[i] = p;
						fPegs[i].renderer.material = allPegs[p];
						facePegObj[i].renderer.material = allFaces[p];
						facePegPos[i] = facePegObj[i].transform.localPosition;
						i += 1;
					}
					ii += 1;
				}
				
				if(dif == 2)
				{
					if(p == hPegs[ii])
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						hPegs[i] = p;
						fPegs[i].renderer.material = allPegs[p];
						facePegObj[i].renderer.material = allFaces[p];
						facePegPos[i] = facePegObj[i].transform.localPosition;
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
				p = Random.Range(0,4);
			}
			
			if(dif == 1)
			{
				p = Random.Range(0,8);
			}
			
			if(dif == 2)
			{
				p = Random.Range(0,12);
			}
			
			int ii = 0;
			
			while(ii<n)
			{
				if(dif == 0)
				{
					if(ePegs[p] == rPegs[ii] && ePegs[ii] != 0)
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						rPegs[i] = ePegs[p];
						i += 1;
					}
					ii += 1;
				}
				
				if(dif == 1)
				{
					if(mPegs[p] == rPegs[ii] && mPegs[ii] != 0)
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						rPegs[i] = mPegs[p];
						i += 1;
					}
					ii += 1;
				}
				
				if(dif == 2)
				{
					if(hPegs[p] == rPegs[ii] && hPegs[ii] != 0)
					{
						ii = n;
					}
					else if(ii == n-1)
					{
						rPegs[i] = hPegs[p];
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
				eCards[i].renderer.material = allPegs[rPegs[i]];
			}
			
			if(dif == 1)
			{
				mCards[i].renderer.material = allPegs[rPegs[i]];
			}
			
			if(dif == 2)
			{
				hCards[i].renderer.material = allPegs[rPegs[i]];
			}
			
			i += 1;
		}
	}
	
	IEnumerator St()
	{
		yield return new WaitForSeconds(0.25f);
		startScroll = true;
		
		if(dif == 0)
		{
			yield return new WaitForSeconds(1.0f);
			yield return new WaitForSeconds(2.0f);
			facePegObj[0].transform.rotation = Quaternion.Euler(90.0f, 180.0f, 0f);
		}
		
		if(dif == 1)
		{
			yield return new WaitForSeconds(2.0f);
			startScroll = false;
			scrollBack = true;
			yield return new WaitForSeconds(3.0f);
			scrollBack = false;
		}
		
		if(dif == 2)
		{
			yield return new WaitForSeconds(3.0f);
			startScroll = false;
			scrollBack = true;
			yield return new WaitForSeconds(4.0f);
			scrollBack = false;
		}
		Play = true;
	}
	
	IEnumerator RotB()
	{
		yield return new WaitForSeconds(2f);
		audio.clip = dis;
		audio.Play();
		rotatePeg = false;
		rotateFace = false;
		rotatePegB = true;
		rotateFaceB = true;
		yield return new WaitForSeconds(1.0f);
		nullTargets = true;
	}
	
	IEnumerator Dst()
	{
		yield return new WaitForSeconds(1.0f);
		audio.clip = cor;
		audio.Play();
		rotatePeg = false;
		rotateFace = false;
		disap = true;
		yield return new WaitForSeconds(0.8f);
		disap = false;
		Destroy(targetPeg);
		Destroy(targetFace);
		targetFace = null;
		targetPeg = null;
		co += 1;
		Fit = true;
		Play = true;
		LineWidth -= 26.0f;
		Change = true;
		
	}
	
	void Update () 
	{
		Vector3 tmpPos;
		
		if(disap)
		{
			targetFace.transform.Rotate(0, Time.deltaTime*600f, 0f);
			targetPeg.transform.Rotate(0, Time.deltaTime*600f, 0f);
			targetFace.transform.localScale *= 0.9f;
			targetPeg.transform.localScale *= 0.9f;
		}
		
		if(dif != 0)
		{
			if(startScroll)
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-37.29f - (LineWidth - 4.0f*26.8f), AllFaces.transform.position.y, AllFaces.transform.position.z), (Time.time-stTime)/duration);
			}
			if(scrollBack)
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-38.0f, AllFaces.transform.position.y, AllFaces.transform.position.z), ((Time.time-stTime)-timeDif)/duration);
			}
		}
		
		if(Fit)
		{
			add = 1;
			while(add < 12-iFace)
			{
				if(Change)
				{
					if(facePegObj[iFace + add] != null)
					{
						facePegObj[iFace - 1 + add] = facePegObj[iFace + add];
						if(dif == 0)
						{
							ePegs[iFace - 1 + add] = ePegs[iFace + add];
						}
						if(dif == 1)
						{
							mPegs[iFace - 1 + add] = mPegs[iFace + add];
						}
						if(dif == 2)
						{
							hPegs[iFace - 1 + add] = hPegs[iFace + add];
						}
						fPegs[iFace - 1 + add] = fPegs[iFace + add];
					}
					
						facePegObj[iFace + add] = null;
					
				}
				else{
					if(facePegObj[iFace - 1 + add] != null && n-co>3)
					{
						facePegObj[iFace - 1 + add].transform.localPosition = Vector3.Lerp(facePegObj[iFace - 1 + add].transform.localPosition, new Vector3(facePegPos[iFace - 1 + add].x, facePegPos[iFace - 1 + add].y, facePegPos[iFace - 1 + add].z), 3.5f/50f);
						
						//facePegObj[iFace + add].transform.position = facePegPos[iFace + add - 1];
					}
				}
				add += 1;
			}
			Change = false;
		}
		
		if(rotatePeg)
		{
			targetPeg.transform.rotation = Quaternion.Slerp(targetPeg.transform.rotation, Quaternion.Euler(new Vector3(90f, 360f, 0f)), Time.deltaTime * 4f);
		}
		
		if(rotateFace)
		{
			targetFace.transform.rotation = Quaternion.Slerp(targetFace.transform.rotation, Quaternion.Euler(new Vector3(90f, 360f, 0f)), Time.deltaTime * 4f);
		}
		
		if(rotatePegB)
		{
			targetPeg.transform.rotation = Quaternion.Slerp(targetPeg.transform.rotation, Quaternion.Euler(new Vector3(90.0f, 180.0f, 0f)), Time.deltaTime * 4f);
			
		}
		
		if(rotateFaceB)
		{
			targetFace.transform.rotation = Quaternion.Slerp(targetFace.transform.rotation, Quaternion.Euler(new Vector3(90.0f, 180.0f, 0f)), Time.deltaTime * 4f);
		}
		
		if(nullTargets)
		{
			rotatePegB = false;
			rotateFaceB = false;
			targetPeg = null;
			targetFace = null;
			Play = true;
			nullTargets = false;
		}
		
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
		
			if(dif != 0 && n-co>3)
			{
				//ray = Camera.main.ScreenPointToRay(theTouch.position);
				ray= Camera.main.ScreenPointToRay (Input.mousePosition);
				
				if(Physics.Raycast(ray,out hit,1000f,facePegMask))
				{
					//xPos = Camera.main.ScreenToWorldPoint (new Vector3 (theTouch.position.x, theTouch.position.y, 10.0f));
					xPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));
					
					wantedPos.x = xPos.x - OldTPos.x;
						
					tmpPos = AllFaces.transform.position;	
					tmpPos.x = OldFacesPos.x + wantedPos.x;	
					AllFaces.transform.position = tmpPos;
				}
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
					if(targetPeg != null)
					{
						/////
					}
					else
					{
						if(Physics.Raycast(ray,out hit,1000f,pegMask))
						{
							print("targetPeg");
							targetPeg = hit.collider.gameObject;
							rotatePeg = true;
						}
					}
					
					if(targetFace != null)
					{
						/////
					}
					else
					{
						if(Physics.Raycast(ray,out hit,1000f,faceMask))
						{
							print("targetFace");
							targetFace = hit.collider.gameObject;	
							rotateFace = true;				
						}
					}
				}
				
				tt = false;
			}
			
			if(targetPeg != null && targetFace != null)
			{
				////
				i = 0;
				Fit = false;
				
				if(dif == 0)
				{
					while(i<n)
					{
						if(targetPeg.transform.GetChild(0).gameObject == eCards[i])
						{
							iPeg = i;
							i = n;
							print("iPeg: " + iPeg);
						}
						i += 1;
					}
					
					i = 0;
					
					while(i<n)
					{
						if(targetFace.transform.GetChild(0).gameObject == fPegs[i])
						{
							iFace = i;
							i = n;
							print("iFace: " + iFace);
						}
						
						i += 1;
					}
					
					if(rPegs[iPeg] == ePegs[iFace])
					{
						print("yayyy");
						Play = false;
						StartCoroutine(Dst());
					}
					else
					{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						StartCoroutine(RotB());
					}
				}
				
				if(dif == 1)
				{
					while(i<n)
					{
						if(targetPeg.transform.GetChild(0).gameObject == mCards[i])
						{
							iPeg = i;
							i = n;
							print("iPeg: " + iPeg);
						}
						
						i += 1;
					}
					
					i = 0;
					
					while(i<n)
					{
						if(targetFace.transform.GetChild(0).gameObject == fPegs[i])
						{
							iFace = i;
							i = n;
							print("iFace: " + iFace);
						}
						
						i += 1;
					}
					
					if(rPegs[iPeg] == mPegs[iFace])
					{
						print("yayyy");
						Play = false;
						StartCoroutine(Dst());
					}
					else
					{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						StartCoroutine(RotB());
					}
				}
				if(dif == 2)
				{
					while(i<n)
					{
						if(targetPeg.transform.GetChild(0).gameObject == hCards[i])
						{
							iPeg = i;
							i = n;
							print("iPeg: " + iPeg);
						}
						
						i += 1;
					}
					
					i = 0;
					
					while(i<n)
					{
						if(targetFace.transform.GetChild(0).gameObject == fPegs[i])
						{
							iFace = i;
							i = n;
							print("iFace: " + iFace);
						}
						i += 1;
					}
					
					if(rPegs[iPeg] == hPegs[iFace])
					{
						print("yayyy");
						Play = false;
						StartCoroutine(Dst());
					}
					else
					{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						StartCoroutine(RotB());
					}
				}
			}
		}
	}
	
	void LateUpdate()
	{
		Vector3 tmpPos;
		
		if(co == n)
		{
			//Fade
			End.SetActive(true);
			
			tmpPos = Camera.main.transform.position;
			tmpPos.y = 303.86f;
			Camera.main.transform.position = tmpPos;
		}
		if(n-co>3)
		{
			if(First.transform.position.x + 37.29 < - (LineWidth - 4.0*26.0))
			{
				if(First.transform.position.x + 37.29 > - (LineWidth - 4.0*26.0)-0.8)
				{
					tmpPos = AllFaces.transform.position;
					tmpPos.x = 37.29f - (LineWidth - 4.0f*26.0f);
					AllFaces.transform.position = tmpPos;
				}
				else
				{
					AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-37.29f - (LineWidth - 4.0f*26.8f), AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5f/50f);
				
				}
			}
			
			if(First.transform.position.x > -37.29)
			{
	
				
				if(First.transform.position.x < -36.8)
				{
					tmpPos = AllFaces.transform.position;
					tmpPos.x = -37.29f;
					AllFaces.transform.position = tmpPos;
				}
				else
				{
					AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, new Vector3(-38.0f, AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5f/50f);
				}
			}	
		}
	}
}