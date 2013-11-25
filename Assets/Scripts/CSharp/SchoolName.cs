using UnityEngine;
using System.Collections;

public class SchoolName : MonoBehaviour 
{	
	public string Name;
	public string Name1;
	public Vector2 Pos;
	public float btnAmplifier;
	public GUISkin skin;
	public bool Enter;
	public bool st;
	public LayerMask Mask;
	public bool tt;
	public Ray ray;
	public Touch theTouch1;
	public RaycastHit hit;
	public GameObject target;
	public GameObject Next;
	public GameObject Back;
	public GameObject Text;
	public GameObject txt;
	public bool arrive;
	public GameObject Keyb;
	
	void Start () 
	{
	
			Pos.x = Screen.width/2f;
			Pos.y = Screen.height / 2f ;
			btnAmplifier = Screen.height/10.0f;
			Name = "";
		
			if(Text != null)
			{
				Text.guiText.text = PlayerPrefs.GetString("Name");
			}
	}
	
	void Update () 
	{
			
			Pos.x = Screen.width/2f - (7.5f*btnAmplifier)/2f;
			Pos.y = Screen.height / 2f - btnAmplifier*0.95f;
			btnAmplifier = Screen.height/10.0f;
		
			if(Name != "")
			{
				Next.SetActive(true);
			}
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		
		if(Enter)
		{
			
		//	Name = GUI.TextField (new Rect( Pos.x, Pos.y, 7.5f*btnAmplifier, btnAmplifier), Name, 20);
			txt.GetComponent<TextMesh>().text = Name;
			PlayerPrefs.SetString("Name", Name);
			PlayerPrefs.SetString("Name1", Name1);

			PlayerPrefs.Save();

			Debug.Log( "Saved " + PlayerPrefs.GetString("Name") + " as name");
		}
		//if(Input.touchCount > 0)
			if(Input.GetButton("Fire1"))
			{
				tt = true;
				//theTouch1 = Input.GetTouch(0);
				//ray = Camera.main.ScreenPointToRay(theTouch1.position);
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
				if( Physics.Raycast(ray,out hit,1000f,Mask) )
						{
							target = hit.collider.gameObject;
						}
			}
			else if(tt)
			{
	
					if(target != null)
					{
						//target.SetActive(false);
						txt.GetComponent<TextMesh>().text = Name;
						target = null;
						Keyb.SetActive(true);
						Back.SetActive(false);
						Next.SetActive(false);
					}
			}
		
			if(arrive)
			{
				
			}
	}
	
	void AddLetter(string letter)
	{	
		if(letter == "Done")
		{
			Back.SetActive(true);
			Next.SetActive(true);
			Keyb.SetActive(false);

			txt.GetComponent<TextMesh>().text = Name;
			PlayerPrefs.SetString("Name", Name);
			PlayerPrefs.SetString("Name1", Name1);
			
			PlayerPrefs.Save();
			
			Debug.Log( "Saved " + PlayerPrefs.GetString("Name") + " as name");
		}
		else if(letter == "Backspace")
		{
			if(Name.Length >0)
			{
				Name = Name.Substring(0, Name.Length - 1);
			}
		}
		else
		{
			if(Name.Length<20)
			{
				Name += letter;
			}
		}
		txt.GetComponent<TextMesh>().text = Name;
	}
}