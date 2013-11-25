using UnityEngine;
using System.Collections;

public class IntroAnim : MonoBehaviour 
{
	public GameObject Topsy;
	public GameObject Tim;
	public GameObject TnTtxt;
	public GameObject StartSchoolTxt;
	public GameObject LadybirdIco;
	public GameObject Faces;
	
	public Vector3 TopsyFinPos;
	public Vector3 TimFinPos;
	public Vector3 TnTtxtFinPos;
	public Vector3 StartSchoolTxtFinPos;
	public Vector3 LadybirdIcoFinPos;
	public Vector3 FacesFinPos;
	
	public Vector3 TopsyFinScale;
	public Vector3 TimFinScale;
	public Vector3 TnTtxtFinScale;
	public Vector3 StartSchoolTxtFinScale;
	public Vector3 LadybirdIcoFinScale;
	public Vector3 FacesFinScale;
	
	public Vector3 TopsyTempScale;
	public Vector3 TimTempScale;
	public Vector3 TnTtxtTempScale;
	public Vector3 StartSchoolTxtTempScale;
	public Vector3 LadybirdIcoTempScale;
	public Vector3 FacesTempScale;
	
	public Vector3 TopsyTempPos;
	public Vector3 TimTempPos;
	public Vector3 TnTtxtTempPos;
	public Vector3 StartSchoolTxtTempPos;
	public Vector3 LadybirdIcoTempPos;
	public Vector3 FacesTempPos;
	
	public bool TempPos = true;
	
	public GameObject Buttons;
	public GameObject face0;
	public float timeDif;
	public GameObject faces;
	
	public bool Static;
	
	IEnumerator Start () 
	{
		if( PlayerPrefs.GetInt("Gender") == 0)
		{
			PlayerPrefs.SetInt("Gender", 0);
			PlayerPrefs.SetInt("hairType", 0);
			PlayerPrefs.SetInt("hairMat", 0);
			PlayerPrefs.SetInt("Colour", 0);
			PlayerPrefs.SetInt("mouthType", 0);
			PlayerPrefs.SetInt("noseType", 0);
			PlayerPrefs.SetInt("glassesA", 0);
			PlayerPrefs.SetInt("eyeColor", 0);
		}
		
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
				yield return new WaitForSeconds(4);
				TempPos = false;
				yield return new WaitForSeconds(1);
				Buttons.SetActive(true);
				face0.SetActive(false);
				faces.SetActive(true);
				PlayerPrefs.SetInt("Init", 0);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			if(PlayerPrefs.GetInt("Init") == 1)
			{
				Destroy(this.gameObject);
			}
		}
	}
	
	void Update () 
	{
		if(!Static)
		{
			if(TempPos)
			{
				Topsy.transform.position = Vector3.Lerp(Topsy.transform.position, TopsyTempPos, (Time.time-timeDif)/8.0f);
				Tim.transform.position = Vector3.Lerp(Tim.transform.position, TimTempPos, (Time.time-timeDif)/12.0f);
				TnTtxt.transform.position = Vector3.Lerp(TnTtxt.transform.position, TnTtxtTempPos, (Time.time-timeDif)/5.0f);
				StartSchoolTxt.transform.position = Vector3.Lerp(StartSchoolTxt.transform.position, StartSchoolTxtTempPos, (Time.time-timeDif)/13.0f);
				LadybirdIco.transform.position = Vector3.Lerp(LadybirdIco.transform.position, LadybirdIcoTempPos, (Time.time-timeDif)/9.0f);
				Faces.transform.position = Vector3.Lerp(Faces.transform.position, FacesTempPos, (Time.time+2.0f-timeDif)/40.0f);
			}
			else
			{
				Topsy.transform.position = Vector3.Lerp(Topsy.transform.position, TopsyFinPos, (Time.time-timeDif-4f)/2.0f);
				Tim.transform.position = Vector3.Lerp(Tim.transform.position, TimFinPos, (Time.time-timeDif-4f)/2.0f);
				TnTtxt.transform.position = Vector3.Lerp(TnTtxt.transform.position, TnTtxtFinPos, (Time.time-timeDif-4f)/2.0f);
				StartSchoolTxt.transform.position = Vector3.Lerp(StartSchoolTxt.transform.position, StartSchoolTxtFinPos, (Time.time-timeDif-4f)/2.0f);
				LadybirdIco.transform.position = Vector3.Lerp(LadybirdIco.transform.position, LadybirdIcoFinPos, (Time.time-timeDif-4f)/2.0f);
				Faces.transform.position = Vector3.Lerp(Faces.transform.position, FacesFinPos, (Time.time-timeDif-4f)/2.0f);
				
				Topsy.transform.localScale = Vector3.Lerp(Topsy.transform.localScale, TopsyFinScale, (Time.time-timeDif-4f)/2.0f);
				Tim.transform.localScale = Vector3.Lerp(Tim.transform.localScale, TimFinScale, (Time.time-timeDif-4f)/2.0f);
				TnTtxt.transform.localScale = Vector3.Lerp(TnTtxt.transform.localScale, TnTtxtFinScale, (Time.time-timeDif-4f)/2.0f);
				StartSchoolTxt.transform.localScale = Vector3.Lerp(StartSchoolTxt.transform.localScale, StartSchoolTxtFinScale, (Time.time-timeDif-4f)/2.0f);
				LadybirdIco.transform.localScale = Vector3.Lerp(LadybirdIco.transform.localScale, LadybirdIcoFinScale, (Time.time-timeDif-4f)/2.0f);
				Faces.transform.localScale = Vector3.Lerp(Faces.transform.localScale, FacesFinScale, (Time.time-timeDif-4f)/1.0f);
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
}