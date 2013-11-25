using UnityEngine;
using System.Collections;

public class FlurryLogs : MonoBehaviour 
{	
    private static FlurryLogs instance;
	public string Key;
	public string myKey;
	
    public static FlurryLogs GetInstance()
	{
    	return instance;
    }
	
  //  FlurryAgent _FlurryAgent;
	
    void Awake() 
	{
	    if (instance != null && instance != this) {
	    Destroy(this.gameObject);
	    return;
    } 
	else 
	{
		instance = this;
    }
		
    	DontDestroyOnLoad(this.gameObject);
    }
	
	
	void Start () 
		{
		//Key = myKey;
		if(Application.platform != RuntimePlatform.WindowsEditor)
		{
		//	_FlurryAgent = new FlurryAgent();     // need to Initialize the script
	//
	       // _FlurryAgent.onStartSession(Key);  
		}
	}
	
	void Update () 
	{
	
	}
	
	
	void Log( string e )
	{
		Debug.Log( e );
		
		//if(Application.platform != RuntimePlatform.WindowsEditor)
		//{
		//	_FlurryAgent.logEvent( e );
	//	}
	 
	 }
	
	 void End()
	 {
		
		//_FlurryAgent.onEndSession();  
	 }
}