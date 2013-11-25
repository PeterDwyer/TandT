var Intro:GameObject;
var End:GameObject;
var dif:int;
var n:int;
var rPegs:int[];
var easy:GameObject;
var med:GameObject;
var hard:GameObject;
var eCards:GameObject[];
var mCards:GameObject[];
var hCards:GameObject[];
var fPegs:GameObject[];
var facePegObj:GameObject[];
var facePegPos:Vector3[];
var ePegs:int[];
var mPegs:int[];
var hPegs:int[];
var player:int;
var allPegs:Material[];
var allFaces:Material[];
var targetPeg:GameObject;
var targetFace:GameObject;
private var hit:RaycastHit;
var rotatePeg:boolean;
var rotateFace:boolean;
var rotatePegB:boolean;
var rotateFaceB:boolean;
var nullTargets:boolean;
var pegMask:LayerMask;
var faceMask:LayerMask;
var facePegMask:LayerMask;
var iPeg:int;
var iFace:int;
private var D:int;
var i:int;
var Play:boolean = true;
var add:int;
var Fit:boolean;
var Change:boolean;
var co:int;
var LineWidth:float;
var First:GameObject;
var AllFaces:GameObject;
var OldFacesPos:Vector3;
var OldTPos:Vector3;
var setOld:boolean;
var wantedPos:Vector3;
var xPos:Vector3;
var spin:boolean;
var startScroll:boolean = false;
var scrollBack:boolean = false;
var timeDif:float;
var disap:boolean;
var duration:float;
var stTime:float;
var DifScrp:GameObject;
var tt:boolean;
var theTouch1 : Touch;
var ray : Ray;
var Sticker:GameObject;
var stickerNum:int;
var stickersMat:Material[];
var cor:AudioClip;
var dis:AudioClip;
function Start () {
Intro.SetActive(false);
player = PlayerPrefs.GetInt("playerSticker");
stickerNum = PlayerPrefs.GetInt("stickerNum");
Sticker.renderer.material = stickersMat[stickerNum];
var Dif : Difficulty = DifScrp.GetComponent("Difficulty");
	dif = Dif.dif;
Play = false;
St();
stTime = Time.time;
AllFaces.SetActive(true);
	if(dif == 0)
	{
		easy.SetActive(true);
		timeDif = 1.0;
		LineWidth = 4.0*26.0;
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
		timeDif = 3.0;
		LineWidth = 8.0*26.0;
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
		timeDif = 4.0;
		hard.SetActive(true);
		LineWidth = 12.0*26.0;
		n = 12;
	}
	i = 3;
	var p:int;
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
		var ii:int = 0;
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
		ii = 0;
		while(ii<n)
		{
			if(dif == 0)
			{
				if(ePegs[p] == rPegs[ii])
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
function St()
{
	yield WaitForSeconds(0.25);
	startScroll = true;
	if(dif == 0)
	{
		yield WaitForSeconds(1.0);
		yield WaitForSeconds(2.0);
		facePegObj[0].transform.rotation = Quaternion.Euler(90.0, 180.0, 0);
	}
	if(dif == 1)
	{
		yield WaitForSeconds(2.0);
		startScroll = false;
		scrollBack = true;
		yield WaitForSeconds(3.0);
		scrollBack = false;
	}
	if(dif == 2)
	{
		yield WaitForSeconds(3.0);
		startScroll = false;
		scrollBack = true;
		yield WaitForSeconds(4.0);
		scrollBack = false;
	}
	Play = true;
}
function RotB()
{
	yield WaitForSeconds(2);
	audio.clip = dis;
	audio.Play();
	rotatePeg = false;
	rotateFace = false;
	rotatePegB = true;
	rotateFaceB = true;
	yield WaitForSeconds(1.0);
	nullTargets = true;
}
function Dst()
{
	yield WaitForSeconds(1.0);
	audio.clip = cor;
	audio.Play();
	rotatePeg = false;
	rotateFace = false;
	disap = true;
	yield WaitForSeconds(0.8);
	disap = false;
	Destroy(targetPeg);
	Destroy(targetFace);
	targetFace = null;
	targetPeg = null;
	co += 1;
	Fit = true;
	Play = true;
	LineWidth -= 26.0;
	Change = true;
	
}
function Update () {
if(disap)
{
	targetFace.transform.Rotate(0, Time.deltaTime*600, 0);
	targetPeg.transform.Rotate(0, Time.deltaTime*600, 0);
	targetFace.transform.localScale *= 0.9;
	targetPeg.transform.localScale *= 0.9;
}
if(dif != 0)
{
	if(startScroll)
	{
		AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-37.29 - (LineWidth - 4.0*26.8), AllFaces.transform.position.y, AllFaces.transform.position.z), (Time.time-stTime)/duration);
	}
	if(scrollBack)
	{
		AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-38.0, AllFaces.transform.position.y, AllFaces.transform.position.z), ((Time.time-stTime)-timeDif)/duration);
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
					facePegObj[iFace - 1 + add].transform.localPosition = Vector3.Lerp(facePegObj[iFace - 1 + add].transform.localPosition, Vector3(facePegPos[iFace - 1 + add].x, facePegPos[iFace - 1 + add].y, facePegPos[iFace - 1 + add].z), 3.5/50);
					
					//facePegObj[iFace + add].transform.position = facePegPos[iFace + add - 1];
				}
			}
			add += 1;
		}
		Change = false;
	}
	if(rotatePeg)
	{
		targetPeg.transform.rotation = Quaternion.Slerp(targetPeg.transform.rotation, Quaternion.Euler(new Vector3(90, 360, 0)), Time.deltaTime * 4);
	}
	if(rotateFace)
	{
		targetFace.transform.rotation = Quaternion.Slerp(targetFace.transform.rotation, Quaternion.Euler(new Vector3(90, 360, 0)), Time.deltaTime * 4);
	}
	if(rotatePegB)
	{
		targetPeg.transform.rotation = Quaternion.Slerp(targetPeg.transform.rotation, Quaternion.Euler(new Vector3(90.0, 180.0, 0)), Time.deltaTime * 4);
		
	}
	if(rotateFaceB)
	{
		targetFace.transform.rotation = Quaternion.Slerp(targetFace.transform.rotation, Quaternion.Euler(new Vector3(90.0, 180.0, 0)), Time.deltaTime * 4);
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
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			var theTouch : Touch = Input.GetTouch(0);
			tt = true;
			if(setOld)
			{
				OldTPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
				//OldTPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
				OldFacesPos = AllFaces.transform.position;
				setOld = false;
			}
			if(dif != 0 && n-co>3)
			{
			ray = Camera.main.ScreenPointToRay(theTouch.position);
			//ray= Camera.main.ScreenPointToRay (Input.mousePosition);
				if(Physics.Raycast(ray,hit,1000,facePegMask))
					{
				xPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
				//xPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
				
				wantedPos.x = xPos.x - OldTPos.x;
				AllFaces.transform.position.x = OldFacesPos.x + wantedPos.x;
				}
			}
		}
		else
		{
			setOld = true;
		}
	if(Play)
	{
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			tt = true;
			theTouch1 = Input.GetTouch(0);
			ray = Camera.main.ScreenPointToRay(theTouch1.position);
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
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
					if(Physics.Raycast(ray,hit,1000,pegMask))
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
					if(Physics.Raycast(ray,hit,1000,faceMask))
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
						Dst();
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						RotB();
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
						Dst();
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						RotB();
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
						Dst();
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						RotB();
					}
				}
			}
		
	}
}
function LateUpdate()
{
	if(co == n)
	{
		//Fade
		End.SetActive(true);
		Camera.main.transform.position.y = 303.86;
	}
	if(n-co>3)
	{
		if(First.transform.position.x + 37.29 < - (LineWidth - 4.0*26.0))
		{
			if(First.transform.position.x + 37.29 > - (LineWidth - 4.0*26.0)-0.8)
			{
				AllFaces.transform.position.x = -37.29 - (LineWidth - 4.0*26.0);
			}
			else
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-37.29 - (LineWidth - 4.0*26.8), AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5/50);
			
			}
		}
		if(First.transform.position.x > -37.29)
		{

			
			if(First.transform.position.x < -36.8)
			{
				AllFaces.transform.position.x = -37.29;
			}
			else
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-38.0, AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5/50);
			}
		}	
	}
}