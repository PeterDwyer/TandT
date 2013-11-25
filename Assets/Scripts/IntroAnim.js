#pragma strict
var Topsy:GameObject;
var Tim:GameObject;
var TnTtxt:GameObject;
var StartSchoolTxt:GameObject;
var LadybirdIco:GameObject;
var Faces:GameObject;

var TopsyFinPos:Vector3;
var TimFinPos:Vector3;
var TnTtxtFinPos:Vector3;
var StartSchoolTxtFinPos:Vector3;
var LadybirdIcoFinPos:Vector3;
var FacesFinPos:Vector3;

var TopsyFinScale:Vector3;
var TimFinScale:Vector3;
var TnTtxtFinScale:Vector3;
var StartSchoolTxtFinScale:Vector3;
var LadybirdIcoFinScale:Vector3;
var FacesFinScale:Vector3;

var TopsyTempScale:Vector3;
var TimTempScale:Vector3;
var TnTtxtTempScale:Vector3;
var StartSchoolTxtTempScale:Vector3;
var LadybirdIcoTempScale:Vector3;
var FacesTempScale:Vector3;

var TopsyTempPos:Vector3;
var TimTempPos:Vector3;
var TnTtxtTempPos:Vector3;
var StartSchoolTxtTempPos:Vector3;
var LadybirdIcoTempPos:Vector3;
var FacesTempPos:Vector3;

var TempPos:boolean = true;

var Buttons:GameObject;
var face0:GameObject;
var timeDif:float;
var faces:GameObject;

var Static:boolean;

function Start () {
PlayerPrefs.SetInt("Story", 0);
	if(!Static)
	{
		if(PlayerPrefs.GetInt("Init") == 1)
		{
			timeDif = Time.time;
			PlayerPrefs.SetInt("Story", 0);
			Topsy.transform.localScale = TopsyTempScale;
			Tim.transform.localScale = TimTempScale;
			TnTtxt.transform.localScale = TnTtxtTempScale;
			StartSchoolTxt.transform.localScale = StartSchoolTxtTempScale;
			LadybirdIco.transform.localScale = LadybirdIcoTempScale;
			Faces.transform.localScale = FacesTempScale;
			
			TempPos = true;
			yield WaitForSeconds(4);
			TempPos = false;
			yield WaitForSeconds(1);
			Buttons.SetActive(true);
			face0.SetActive(false);
			faces.SetActive(true);
			PlayerPrefs.SetInt("Init", 0);
		}
		else{
			Destroy(this.gameObject);
		}
	}
	else{
		if(PlayerPrefs.GetInt("Init") == 1)
		{
			Destroy(this.gameObject);
		}
	}

}

function Update () {
	if(!Static)
	{
		if(TempPos)
		{
			Topsy.transform.position = Vector3.Lerp(Topsy.transform.position, TopsyTempPos, (Time.time-timeDif)/8.0);
			Tim.transform.position = Vector3.Lerp(Tim.transform.position, TimTempPos, (Time.time-timeDif)/12.0);
			TnTtxt.transform.position = Vector3.Lerp(TnTtxt.transform.position, TnTtxtTempPos, (Time.time-timeDif)/5.0);
			StartSchoolTxt.transform.position = Vector3.Lerp(StartSchoolTxt.transform.position, StartSchoolTxtTempPos, (Time.time-timeDif)/13.0);
			LadybirdIco.transform.position = Vector3.Lerp(LadybirdIco.transform.position, LadybirdIcoTempPos, (Time.time-timeDif)/9.0);
			Faces.transform.position = Vector3.Lerp(Faces.transform.position, FacesTempPos, (Time.time+2.0-timeDif)/40.0);
		}
		else
		{
			Topsy.transform.position = Vector3.Lerp(Topsy.transform.position, TopsyFinPos, (Time.time-timeDif-4)/2.0);
			Tim.transform.position = Vector3.Lerp(Tim.transform.position, TimFinPos, (Time.time-timeDif-4)/2.0);
			TnTtxt.transform.position = Vector3.Lerp(TnTtxt.transform.position, TnTtxtFinPos, (Time.time-timeDif-4)/2.0);
			StartSchoolTxt.transform.position = Vector3.Lerp(StartSchoolTxt.transform.position, StartSchoolTxtFinPos, (Time.time-timeDif-4)/2.0);
			LadybirdIco.transform.position = Vector3.Lerp(LadybirdIco.transform.position, LadybirdIcoFinPos, (Time.time-timeDif-4)/2.0);
			Faces.transform.position = Vector3.Lerp(Faces.transform.position, FacesFinPos, (Time.time-timeDif-4)/2.0);
			
			Topsy.transform.localScale = Vector3.Lerp(Topsy.transform.localScale, TopsyFinScale, (Time.time-timeDif-4)/2.0);
			Tim.transform.localScale = Vector3.Lerp(Tim.transform.localScale, TimFinScale, (Time.time-timeDif-4)/2.0);
			TnTtxt.transform.localScale = Vector3.Lerp(TnTtxt.transform.localScale, TnTtxtFinScale, (Time.time-timeDif-4)/2.0);
			StartSchoolTxt.transform.localScale = Vector3.Lerp(StartSchoolTxt.transform.localScale, StartSchoolTxtFinScale, (Time.time-timeDif-4)/2.0);
			LadybirdIco.transform.localScale = Vector3.Lerp(LadybirdIco.transform.localScale, LadybirdIcoFinScale, (Time.time-timeDif-4)/2.0);
			Faces.transform.localScale = Vector3.Lerp(Faces.transform.localScale, FacesFinScale, (Time.time-timeDif-4)/1.0);
		}
	}
	else
	{
			Topsy.transform.position = TopsyFinPos;
			Tim.transform.position = TimFinPos;
			TnTtxt.transform.position = TnTtxtFinPos;
			StartSchoolTxt.transform.position = StartSchoolTxtFinPos;
			LadybirdIco.transform.position = LadybirdIcoFinPos;
			Faces.transform.position = FacesFinPos;
			
			Topsy.transform.localScale = TopsyFinScale;
			Tim.transform.localScale = TimFinScale;
			TnTtxt.transform.localScale = TnTtxtFinScale;
			StartSchoolTxt.transform.localScale = StartSchoolTxtFinScale;
			LadybirdIco.transform.localScale = LadybirdIcoFinScale;
			Faces.transform.localScale = FacesFinScale;
			Buttons.SetActive(true);
			face0.SetActive(false);
			faces.SetActive(true);
	}
}