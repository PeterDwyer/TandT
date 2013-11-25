    private static var instance:MyUnitySingleton;
    public static function GetInstance() : MyUnitySingleton {
    return instance;
    }
     var music:AudioClip[];
    function Awake() {
		audio.loop = true;
		if (instance != null && instance != this) {
		Destroy(this.gameObject);
		return;
		} else {
		instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
    }

	function dKe(i:int)
	{
		audio.Stop();
		audio.clip = music[i];
		audio.Play();
	}