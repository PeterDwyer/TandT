using UnityEngine;
using System.Collections;

public class WordWrap : MonoBehaviour 
{	
	public GameObject textObject;
	public int wrapPoint = 0;
	public string currentText;
	public bool hyphen = true;
	public bool pinText;
	 
	
	void Awake ()
	{
		currentText = PlayerPrefs.GetString("Name");
	    currentText = " " + currentText;

		Debug.Log("Name is " + currentText );

	    string finalString ="";
	    int currentWrap = wrapPoint;
	    int count = 0;
	    int startPoint = 0;
	    int lastBlankSpace = 0;
	    int currentLength = 0;
	    string appendText = "";
	
	    while( count <= currentText.Length  )
	    {
	        count++;
			
	        if( count   >= currentText.Length)
	        {
	                int finalLength = currentText.Length - startPoint;
	
	                finalString +=  currentText.Substring( startPoint+1 , finalLength-1 );
	                break;
			}
	
	        if( currentText[count] == ' ' )
	        {
	            lastBlankSpace = count;
	        }
	
	        if( currentText[count] == ' ' && count >= currentWrap )
			{
	            currentLength = count - startPoint;
	            appendText = currentText.Substring( startPoint+1 , currentLength ) + "\n" ;
	            finalString += appendText;
	            currentWrap = count + wrapPoint;
	            startPoint = count;
	        }
	
	        if( currentText[count] != ' ' && count >= currentWrap )
	        {
				for(int i = count; i > startPoint;i--)
	            {

	                if( currentText[i] == ' ' )
					{
	                	Debug.Log(currentText[i]);
	                    currentLength = i - startPoint;
	                    appendText = currentText.Substring( startPoint+1 , currentLength ) + "\n" ;
	                    finalString += appendText;
	                    currentWrap = i + wrapPoint;
	                    startPoint = i;
	                }
	            }
	        }
	
	        if(hyphen)
	        {
	            int worldLength = (count - lastBlankSpace);
	            if(  worldLength  >    wrapPoint )
				{ string fred = "" ;
					int what = fred.Length;
	                currentLength = count - startPoint;
	                appendText = currentText.Substring( startPoint+1 , currentLength ) + "\n" ;
	                finalString += appendText;
	                currentWrap = count + wrapPoint;
	                startPoint = count; 
	                lastBlankSpace = count; 
	            }
	        }
	    }
	
		textObject.GetComponent<TextMesh>().text = finalString;
	}
	
	void Start()
	{
		Vector3 tmpPos;
		
		if(!pinText)
		{
			if((Screen.width*1.0)/(Screen.height*1.0)<1.7)
			{
				tmpPos = transform.position;
				tmpPos.x -= 7;
				transform.position = tmpPos;
			}
			if((Screen.width*1.0)/(Screen.height*1.0)<1.5)
			{
				tmpPos = transform.position;
				tmpPos.x -= 6;
				transform.position = tmpPos;
			}
		}
	}
}