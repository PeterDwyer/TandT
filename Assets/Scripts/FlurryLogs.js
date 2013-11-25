#pragma strict
    private static var instance:FlurryLogs;
	var Key:String;
	var myKey:String;
    public static function GetInstance() : FlurryLogs {
    return instance;
    }
    // var _FlurryAgent : FlurryAgent;
    function Awake() {
    if (instance != null && instance != this) {
    Destroy(this.gameObject);
    return;
    } else {
		instance = this;
    }
    DontDestroyOnLoad(this.gameObject);
    }
function Start () {
	//Key = myKey;
	if(Application.platform != RuntimePlatform.WindowsEditor)
	{
		//_FlurryAgent = new FlurryAgent();     // need to Initialize the script

       // _FlurryAgent.onStartSession(Key);  
	}
}

function Update () {

}


function Log(event:String){
	Debug.Log(event);
	if(Application.platform != RuntimePlatform.WindowsEditor)
	{
		//_FlurryAgent.logEvent(event);
	}
 
 }
 function End()
 {
	
	//_FlurryAgent.onEndSession();  
 }