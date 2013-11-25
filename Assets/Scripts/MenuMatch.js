var easy:GameObject;
var med:GameObject;
var hard:GameObject;
var timeDif:float;
var LineWidth:float;
var n:int;
var D:int;
var menuPlates:GameObject[];
var facePegObj:GameObject[];
var facePegPos:Vector3[];
private var duration:float;
var ePlates:int[];
var mPlates:int[];
var hPlates:int[];
var eObject:GameObject[];
var mObject:GameObject[];
var hObject:GameObject[];
var eCovers:GameObject[];
var mCovers:GameObject[];
var hCovers:GameObject[];
var platesObj:GameObject[];
var rPlates:int[];
var dif:int;
var i:int;
var iPlate:int;
var iFace:int;
var Play:boolean;
var DifScrp:GameObject;
var stTime:float;
var AllFaces:GameObject;
var player:int;
var allFood:Material[];
var allFaces:Material[];
var startScroll:boolean;
var scrollBack:boolean;
var First:GameObject;
var targetPlate:GameObject;
var targetFace:GameObject;
var co:int;
private var disap:boolean;
private var setOld:boolean;
private var OldTPos:Vector3;
private var OldFacesPos:Vector3;
private var ray:Ray;
private var tt:boolean;
private var liftCover:boolean;
private var liftCoverB:boolean;
private var liftMenu:boolean;
private var liftMenuB:boolean;
private var nullTargets:boolean;
var facePegMask:LayerMask;
var plateMask:LayerMask;
var faceMask:LayerMask;
var blackHands:Material;
private var hit:RaycastHit;
var theTouch1 : Touch;
var xPos:Vector3;
var txt:GameObject;
function Start () {
var Dif : Difficulty = DifScrp.GetComponent("Difficulty");
	dif = Dif.dif;
Play = false;
stTime = Time.time+0.5;
AllFaces.SetActive(true);
	if(dif == 0)
	{
		easy.SetActive(true);
		timeDif = 3.25;
		duration = 25;
		LineWidth = 4.0*38.0;
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
		timeDif = 3.75;
		LineWidth = 6.0*38.0;
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
		timeDif = 4.25;
		hard.SetActive(true);
		LineWidth = 8.0*38.0;
		n = 8;
		player = Random.Range(0,8);
	}
	i = 3;
	var p:int;
	i = 0;
	while(i<n)
	{
		p = Random.Range(1,9);

			var ii:int = 0;
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
	while(i<n)
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
		ii = 0;

			while(ii<n)
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
	St();
}
function St()
{
	yield WaitForSeconds(1.0);
	startScroll = true;
	if(dif == 0)
	{
		yield WaitForSeconds(1.75);
		startScroll = false;
		scrollBack = true;
		yield WaitForSeconds(3.0);
		scrollBack = false;
	}
	if(dif == 1)
	{
		yield WaitForSeconds(3.25);
		startScroll = false;
		scrollBack = true;
		yield WaitForSeconds(4.5);
		scrollBack = false;
	}
	if(dif == 2)
	{
		yield WaitForSeconds(4.25);
		startScroll = false;
		scrollBack = true;
		yield WaitForSeconds(5.0);
		scrollBack = false;
	}
	targetFace = null;
	targetPlate = null;
	Play = true;
}
function Update()
{
	if(disap)
	{
		targetPlate.renderer.material.color.a -= Time.deltaTime*3;
		targetPlate.transform.parent.renderer.material.color.a -= Time.deltaTime*3;
		platesObj[iFace].SetActive(true);
	}
	if(liftCover)
	{
		targetPlate.transform.position = Vector3.Lerp(targetPlate.transform.position, Vector3(targetPlate.transform.parent.position.x, targetPlate.transform.parent.position.y + 10, targetPlate.transform.parent.position.z-5), 7.5/50);
	}
	if(liftMenu)
	{
		targetFace.transform.GetChild(0).position = Vector3.Lerp(targetFace.transform.GetChild(0).position, Vector3(targetFace.transform.position.x, targetFace.transform.position.y - 4.5, targetFace.transform.position.z), 7.5/50);
	}
	if(liftCoverB)
	{
		targetPlate.transform.position = Vector3.Lerp(targetPlate.transform.position, Vector3(targetPlate.transform.parent.position.x, targetPlate.transform.parent.position.y , targetPlate.transform.parent.position.z-3), 7.5/50);
		
	}
	if(liftMenuB)
	{
		targetFace.transform.GetChild(0).position = Vector3.Lerp(targetFace.transform.GetChild(0).position, Vector3(targetFace.transform.position.x, targetFace.transform.position.y - 30, targetFace.transform.position.z), 7.5/50);
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
		AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-39.00 - (LineWidth - 3.0*38.0), AllFaces.transform.position.y, AllFaces.transform.position.z), (Time.time-stTime)/duration);
	}
	if(scrollBack)
	{
		AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-39.0, AllFaces.transform.position.y, AllFaces.transform.position.z), ((Time.time-stTime)-timeDif)/duration);
	}
	
	/////// *** Controls ***
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

			ray = Camera.main.ScreenPointToRay(theTouch.position);
			//ray= Camera.main.ScreenPointToRay (Input.mousePosition);
				if(Physics.Raycast(ray,hit,1000,facePegMask))
					{
				xPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
				//xPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
				var wantedPos:Vector3;
				wantedPos.x = xPos.x - OldTPos.x;
				AllFaces.transform.position.x = OldFacesPos.x + wantedPos.x;
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
				if(targetPlate != null)
				{
					/////
				}
				else
				{
					if(Physics.Raycast(ray,hit,1000,plateMask))
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
					if(Physics.Raycast(ray,hit,1000,faceMask))
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
						Dst();
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						LiftB();
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
						Dst();
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						LiftB();
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
						Dst();
					}
					else{
						//targetPeg = null;
						//targetFace = null;
						Play = false;
						LiftB();
					}
				}
			}
		
	}
}
function LiftB()
{
	yield WaitForSeconds(1);
	liftCover = false;
	liftMenu = false;
	liftCoverB = true;
	liftMenuB = true;
	yield WaitForSeconds(1);
	liftCoverB = false;
	liftMenuB = false;
	nullTargets = true;
}
function Dst()
{
	yield WaitForSeconds(1.0);
	liftCover = false;
	liftMenu = false;
	//EnableKidPlate
	disap = true;
	yield WaitForSeconds(1.0);
	liftCoverB = true;
	liftMenuB = true;
	yield WaitForSeconds(1.0);
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
function LateUpdate()
{
	if(co == n)
	{
		//fade
		txt.SetActive(true);
		Camera.main.transform.position.y = 315.8;
	}

		if(First.transform.position.x + 39.0 < - (LineWidth - 3.0*38.0))
		{
			if(First.transform.position.x + 39.0 > - (LineWidth - 3.0*38.0)-0.8)
			{
				AllFaces.transform.position.x = -39.0 - (LineWidth - 3.0*38.0);
			}
			else
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-39.0 - (LineWidth - 3.0*38.0), AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5/50);
			
			}
		}
		if(First.transform.position.x > -39.0)
		{

			
			if(First.transform.position.x < -38.0)
			{
				AllFaces.transform.position.x = -39.0;
			}
			else
			{
				AllFaces.transform.position = Vector3.Lerp(AllFaces.transform.position, Vector3(-39.5, AllFaces.transform.position.y, AllFaces.transform.position.z), 3.5/50);
			}
		}	
}