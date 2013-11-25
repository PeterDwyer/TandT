#pragma strict
var TTM:GameObject[];
var Walkers:GameObject[];
var Cars:GameObject[];
var TnT:GameObject;
var res:GameObject;
var We:GameObject;
var i:float;
var InSchool:boolean;
var end:boolean;

function Start() {
yield WaitForSeconds(10.0);
	if(end)
	{
	Destroy(gameObject.Find("SingletOn"));
	//Destroy(TnT);
	//Destroy(this);
	 //We.SetActive(true);
	 Application.LoadLevel("StartScreen");
	 }
}

function Update () {
	if(end)
	{
		Cars[2].transform.position.x -= Time.deltaTime*50;
		Cars[2].transform.position.y = Mathf.Sin(i*1.7)*0.3-4.37;
		Cars[1].transform.position.x += Time.deltaTime*30;
		i += Time.deltaTime*10;
	}	
	else if(!InSchool)
	{
		TTM[0].transform.position.x += Time.deltaTime*32;
		TTM[1].transform.position.x += Time.deltaTime*32;
		TTM[2].transform.position.x += Time.deltaTime*32;
		Cars[0].transform.position.x += Time.deltaTime*50;
		Cars[1].transform.position.x -= Time.deltaTime*20;
		Walkers[0].transform.position.x += Time.deltaTime*8;
		Walkers[1].transform.position.x += Time.deltaTime*10;
		Walkers[2].transform.position.x += Time.deltaTime*10;
		Camera.main.transform.position.x += Time.deltaTime*27;
		i += Time.deltaTime*10;
		TTM[0].transform.position.y = Mathf.Sin(i)*0.5-29.0;
		TTM[1].transform.position.y = Mathf.Sin(i)*0.8-29.0;
		TTM[2].transform.position.y = Mathf.Sin(i)*1.1-29.0;
		Walkers[0].transform.position.y = Mathf.Sin(i)*0.25-29.0;
		Walkers[1].transform.position.y = Mathf.Sin(i)*0.4-29.0;
		Walkers[2].transform.position.y = Mathf.Sin(i)*0.3-29.0;
		Cars[0].transform.position.y = Mathf.Sin(i*1.7)*0.3-4.37;
		if(TTM[0].transform.position.x>550.0)
		{
			gameObject.Find("SingletOn").SendMessage("dKe", 1);
			Application.LoadLevel("EnterSchool");
			
		}
	}
	else{
		i += Time.deltaTime*10;
		TnT.transform.position.y = Mathf.Sin(i*0.8)*0.7-18.43;
	}
}