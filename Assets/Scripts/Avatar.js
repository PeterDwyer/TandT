#pragma strict
var Gender:int;
var GirlPrefab:GameObject;
var BoyPrefab:GameObject;
var GirlHairType:GameObject[];
var GirlHairWhite:Material[];
var GirlHairWhiteSecondary:Material[];
var GirlHairBlack:Material[];
var GirlHairBlackSecondary:Material[];
var Glasses:GameObject;
var EyesColor:Material[];
var Nose:GameObject[];
var NoseColoured:GameObject[];
var eye1:GameObject;
var eye2:GameObject;
var Mouth:GameObject[];
var MouthColoured:GameObject[];
var Neck1:GameObject;
var Neck2:GameObject;
var Head:GameObject;
var Cheek1:GameObject;
var Cheek2:GameObject;
var WhiteHead:Material;
var WhiteHeadEyes:Material[];
var BlackHead:Material;
var BlackHeadEyes:Material[];
var ray:Ray;
var theTouch1 : Touch;
var tt:boolean;
var hit:RaycastHit;
var target:GameObject;
var Mask:LayerMask;
var Eyes1target:GameObject;
var Eyes2target:GameObject;
var NoseTarget:GameObject;
var MouthTarget:GameObject;
var FaceTarget:GameObject;
var Cloth:GameObject;
var ClothColoured:GameObject;
var hairMat:int;
var hairType:int;
var lastHairType:int;
var mouthType:int;
var noseType:int;
var eyeColor:int;
var glassesA:int;
var Colour:int;
var Game:boolean;
var Pegs:boolean;
function Start () {
print (PlayerPrefs.GetInt("hairType"));
	PlayerPrefs.GetInt("Gender", Gender);
	hairType = PlayerPrefs.GetInt("hairType");
	hairMat = PlayerPrefs.GetInt("hairMat");
	Colour = PlayerPrefs.GetInt("Colour");
	mouthType = PlayerPrefs.GetInt("mouthType");
	noseType = PlayerPrefs.GetInt("noseType");
	glassesA = PlayerPrefs.GetInt("glassesA");
	eyeColor = PlayerPrefs.GetInt("eyeColor");
	eye1.renderer.material = EyesColor[eyeColor];
	eye2.renderer.material = EyesColor[eyeColor];
	if(glassesA == 1)
	{
		Glasses.SetActive(true);
	}
	else if(glassesA == 0)
	{
		Glasses.SetActive(false);
	}
	if(Colour == 0)
	{
		
			Cloth.SetActive(true);
		
		Nose[noseType].SetActive(true);
		Cheek1.SetActive(true);
		Cheek2.SetActive(true);
		Neck2.SetActive(false);
		Neck1.SetActive(true);
		Mouth[mouthType].SetActive(true);
		GirlHairType[hairType].SetActive(true);
		GirlHairType[hairType].renderer.material = GirlHairWhite[hairMat];
		Head.renderer.material = WhiteHead;	
		if(Pegs)
		{
			Head.renderer.material = WhiteHeadEyes[eyeColor];	
		}
		if(GirlHairType[hairType].transform.childCount > 1)
		{
			GirlHairType[hairType].transform.GetChild(0).gameObject.renderer.material = GirlHairWhiteSecondary[hairMat];
		}	
	}
	if(Colour == 1)
	{
		
			ClothColoured.SetActive(true);
		
		NoseColoured[noseType].SetActive(true);
		Cheek1.SetActive(false);
		Cheek2.SetActive(false);
		Neck2.SetActive(true);
		Neck1.SetActive(false);
		MouthColoured[mouthType].SetActive(true);
		GirlHairType[hairType].SetActive(true);
		GirlHairType[hairType].renderer.material = GirlHairBlack[hairMat];
		Head.renderer.material = BlackHead;	
		if(Pegs)
		{
			Head.renderer.material = BlackHeadEyes[eyeColor];	
		}
		if(GirlHairType[hairType].transform.childCount > 1)
		{
			GirlHairType[hairType].transform.GetChild(0).gameObject.renderer.material = GirlHairBlackSecondary[hairMat];
		}
	}
}

function Update () {
	if(!Game)
	{
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			tt = true;
			theTouch1 = Input.GetTouch(0);
			ray = Camera.main.ScreenPointToRay(theTouch1.position);
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,hit,1000,Mask))
					{
						target = hit.collider.gameObject;
					}
		}
		else if(tt)
		{


				if(target != null)
				{
					if(target == Eyes1target || target == Eyes2target)
					{
						print("eyes");
						if(Glasses.activeInHierarchy)
						{
							glassesA = 0;
							Glasses.SetActive(false);
							eyeColor += 1;
							if(eyeColor>1)
							{
								eyeColor = 0;
							}
						}
						else
						{
							glassesA = 1;
							Glasses.SetActive(true);
						}
					}
					else if(target == NoseTarget)
					{
						print("Nose");
						Nose[noseType].SetActive(false);
						NoseColoured[noseType].SetActive(false);
						noseType += 1;
						if(noseType>1)
						{
							noseType = 0;
						}
					}
					else if(target == MouthTarget)
					{
						print("Mouth");
						Mouth[mouthType].SetActive(false);
						MouthColoured[mouthType].SetActive(false);
						mouthType += 1;
						if(mouthType > 4)
						{
							mouthType = 0;
						}
					}
					else if(target == FaceTarget)
					{
						print("Face");
						NoseColoured[noseType].SetActive(false);
						Nose[noseType].SetActive(false);
						Mouth[mouthType].SetActive(false);
						MouthColoured[mouthType].SetActive(false);
						if(Colour == 0)
						{
							Colour = 1;
						}
						else if(Colour == 1)
						{
							Colour = 0;
						}
					}
					else{
						print("hair");
						GirlHairType[hairType].SetActive(false);
						lastHairType = hairType;
						hairMat += 1;
						if(hairMat > 29)
						{
							hairMat = 0;
							hairType = 0;
						}
						if(hairMat >= (5*(hairType+1)))
						{
							if(hairType < 5)
							{
								hairType += 1;
							}
							else
							{
								hairType = 0;
							}
						}
					}
				}
					GirlHairType[lastHairType].SetActive(false);
					GirlHairType[hairType].SetActive(true);
					eye1.renderer.material = EyesColor[eyeColor];
					eye2.renderer.material = EyesColor[eyeColor];
					PlayerPrefs.SetInt("Gender", Gender);
					PlayerPrefs.SetInt("hairType", hairType);
					PlayerPrefs.SetInt("hairMat", hairMat);
					PlayerPrefs.SetInt("Colour", Colour);
					PlayerPrefs.SetInt("mouthType", mouthType);
					PlayerPrefs.SetInt("noseType", noseType);
					PlayerPrefs.SetInt("glassesA", glassesA);
					PlayerPrefs.SetInt("eyeColor", eyeColor);
					PlayerPrefs.Save();
					if(glassesA == 1)
					{
						Glasses.SetActive(true);
					}
					else if(glassesA == 0)
					{
						Glasses.SetActive(false);
					}
					if(Colour == 0)
					{
						if(Game)
						{
							Cloth.SetActive(true);
						}
						Nose[noseType].SetActive(true);
						Cheek1.SetActive(true);
						Cheek2.SetActive(true);
						Head.renderer.material = WhiteHead;
						Neck2.SetActive(false);
						Neck1.SetActive(true);
						Mouth[mouthType].SetActive(true);
						GirlHairType[hairType].renderer.material = GirlHairWhite[hairMat];
						if(GirlHairType[hairType].transform.childCount > 1)
						{
							GirlHairType[hairType].transform.GetChild(0).gameObject.renderer.material = GirlHairWhiteSecondary[hairMat];
						}
					}
					if(Colour == 1)
					{
						if(Game)
						{
							ClothColoured.SetActive(true);
						}
						NoseColoured[noseType].SetActive(true);
						Cheek1.SetActive(false);
						Cheek2.SetActive(false);
						Neck2.SetActive(true);
						Neck1.SetActive(false);
						MouthColoured[mouthType].SetActive(true);
						Head.renderer.material = BlackHead;
						GirlHairType[hairType].renderer.material = GirlHairBlack[hairMat];
						if(GirlHairType[hairType].transform.childCount > 1)
						{
							GirlHairType[hairType].transform.GetChild(0).gameObject.renderer.material = GirlHairBlackSecondary[hairMat];
						}
					}
					tt = false;
					target = null;
		}
	}
}