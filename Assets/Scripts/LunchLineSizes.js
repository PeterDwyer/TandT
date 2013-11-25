var kids:GameObject[];
var positions:Transform[];
var randomSeq:int[];
var Highest:GameObject;
var Smallest:GameObject;
var t:int = 0;
var setOld:boolean;
var hit:RaycastHit;
var layerMask:LayerMask;
var target:GameObject;
var Play:boolean;
var Cor:GameObject[];
var Discor:GameObject[];
var part:int;
var disappear:boolean;
var dist:float = 10000.0;
var Text:GameObject[];
var Pos:int;
var centres:float[];
var play:boolean;
var a:boolean = true;
var b:boolean = true;
var st:boolean = true;
function Start () {
Text[2].SetActive(true);
var i:int = 1;
var random = Random.Range(0,6);
randomSeq[0] = random;
	while(i<6)
	{
		random = Random.Range(0,6);
		var ii:int = 0;
		while(ii < 6)
		{
		t += 1;
		if(t>1000)
		{
			print(ii);
			print(i);
			ii = 10;
			i = 10;
		}
			if(randomSeq[ii] == random)
			{
					ii = 0;
					random = Random.Range(0,6);
			}	
			else if(ii == 5)
			{
				randomSeq[i] = random;
				ii += 1;
			}
			else{
			ii += 1;
			}
		}
		i += 1;
	}
	i = 0;
	while(i<6)
	{
		kids[i].transform.position.x = positions[randomSeq[i]].position.x;
		kids[i].name = randomSeq[i].ToString();
		centres[randomSeq[i]] = kids[i].transform.position.y;
		i += 1;
	}
	Play = true;
}

function Update () {
if(disappear)
{
	var i:int = 0;
	while(i<6)
	{
		if(i < 2)
		{
			Cor[i].renderer.material.color.a -= Time.deltaTime*2;
		}
		Discor[i].renderer.material.color.a -= Time.deltaTime*2;
		if(Discor[5].renderer.material.color.a < 0.01)
		{
			disappear = false;
			Disable();
		}
		i += 1;
	}
}
if(part == 0 || part == 1)
{
	if(Input.touchCount > 0)
	//if(Input.GetButton("Fire1"))
		{
			if(Play)
			{
				Play = false;
				var theTouch1 = Input.GetTouch(0);
				var ray1 = Camera.main.ScreenPointToRay(theTouch1.position);
				//var ray1 = Camera.main.ScreenPointToRay (Input.mousePosition);
				
					if(Physics.Raycast(ray1,hit,1000,layerMask))
					{
						target = hit.collider.gameObject;
				
						
					}
			}
		}
		else
		{
			if(target != null)
			{
				Camera.main.audio.Stop();
				if(part == 0)
				{
					if(target == Highest)
					{
						Cor[0].SetActive(true);
						Text[0].SetActive(true);
						Text[1].SetActive(false);
						Text[2].SetActive(false);
						Correct();
					}
					else{
						if(target == Smallest)
						{
							target.transform.GetChild(1).gameObject.SetActive(true);
						}
						else{
						target.transform.GetChild(0).gameObject.SetActive(true);
						}
						Text[1].SetActive(true);
						Text[2 + part].SetActive(false);
					}
				}
				else if(part == 1)
				{
					if(target == Smallest)
					{
						Cor[1].SetActive(true);
						Text[0].SetActive(true);
						Text[1].SetActive(false);
						Text[3].SetActive(false);
				
						Correct();
					}
					else{
						if(target == Highest)
						{
							target.transform.GetChild(1).gameObject.SetActive(true);
						}
						else{
						target.transform.GetChild(0).gameObject.SetActive(true);
						}
						Text[1].SetActive(true);
						Text[2 + part].SetActive(false);
					}
				}
			}
			target = null;
			Play = true;
		}
}
if(part == 2)
	{
		if(Input.touchCount > 0)
		//if(Input.GetButton("Fire1"))
		{
			if(Play)
			{
				var theTouch : Touch = Input.GetTouch(0);
				var ray = Camera.main.ScreenPointToRay(theTouch.position);
				//var ray= Camera.main.ScreenPointToRay (Input.mousePosition);
				
					if(Physics.Raycast(ray,hit,1000,layerMask))
					{
						if(target == null)
						{
							print("hur");
							st = false;
							target = hit.collider.gameObject;
							target.SendMessage("Active");
						}
						if(setOld)
						{
							var OldTPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
							//var OldTPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
							var OldPos = target.transform.position;
							setOld = false;
						}
						var xPos = Camera.main.ScreenToWorldPoint (Vector3 (theTouch.position.x, theTouch.position.y, 10.0));
						//var xPos = Camera.main.ScreenToWorldPoint (Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0));
						
						var wantedPos = xPos - OldTPos;
						target.transform.position = OldPos + wantedPos;
						target.transform.position.z -= 6;
					}
			}
		}
		else
		{
			setOld = true;
			if(target != null)
			{
				target.transform.position.z += 6;
				target.SendMessage("Deactive");
			}
			if(target != null)
			{
				print("target !null");
				i = 0;
				while(i<6)
				{
					if(Vector3.Distance(positions[i].position, target.transform.position)<dist)
					{
						print("LessDistance");
						dist = Vector3.Distance(positions[i].position, target.transform.position);
						Pos = i;
					}
					i+=1;
				}
				if(target.transform.position.x < positions[int.Parse(target.name)].position.x)
				{
					if(positions[Pos].position.x - target.transform.position.x < 0)
					{
						Pos += 1;
					}
					if(positions[Pos].position.x - target.transform.position.x > 0)
					{
						if(positions[Pos].position.x > target.transform.position.x)
						{
							var ii:int = 1;
							while(ii<int.Parse(target.name)+1-Pos)
							{
								var fPos:int = int.Parse(target.name) - ii;
								print(fPos);
								var n = fPos+1;
								gameObject.Find(fPos.ToString()).name = n.ToString();
								ii += 1;
							}
							target.name = Pos.ToString();
						}
					}
				}
				if(target.transform.position.x > positions[int.Parse(target.name)].position.x)
				{
					if(positions[Pos].position.x - target.transform.position.x > 0)
					{
						Pos -= 1;
					}
					if(positions[Pos].position.x - target.transform.position.x < 0)
					{
						if(positions[Pos].position.x < target.transform.position.x)
						{
							ii = 1;
							while(ii<Pos - int.Parse(target.name) + 1)
							{
								fPos = int.Parse(target.name) + ii;
								print(fPos);
								n = fPos-1;
								gameObject.Find(fPos.ToString()).name = n.ToString();
								ii += 1;
							}
							target.name = Pos.ToString();
						};
					}
				}
			}
			dist = 100000;
			target = null;
			
		}
	}
}
function LateUpdate()
{
	var i:int = 0;
	if(Input.GetButton("Fire1"))
	{
	}
	else{
		while(i<6)
		{
			gameObject.Find(i.ToString()).transform.position =  Vector3.Lerp(gameObject.Find(i.ToString()).transform.position, Vector3(positions[i].position.x, gameObject.Find(i.ToString()).transform.position.y, gameObject.Find(i.ToString()).transform.position.z), 8.0/50);
			kids[i].transform.position =  Vector3.Lerp(kids[i].transform.position, Vector3(kids[i].transform.position.x, centres[randomSeq[i]], kids[i].transform.position.z), 8.0/50);
			i +=1;
		}
	}
	if(play)
	{
		if(Highest.name == "0")
		{
			if(!st)
			{
				Text[0].SetActive(false);
				Text[1].SetActive(false);
				Text[2].SetActive(false);
				Text[3].SetActive(false);
				Text[4].SetActive(false);
				Text[6].SetActive(false);
				Text[5].SetActive(true);
			}
		}
		else if(Smallest.name == "5")
		{
			if(!st)
			{
				Text[0].SetActive(false);
				Text[1].SetActive(false);
				Text[2].SetActive(false);
				Text[3].SetActive(false);
				Text[4].SetActive(false);
				Text[5].SetActive(false);
				Text[6].SetActive(true);
			}
		}
		else
		{
			if(!st)
			{
				Text[0].SetActive(false);
				Text[1].SetActive(false);
				Text[2].SetActive(false);
				Text[3].SetActive(false);
				Text[4].SetActive(true);
				Text[6].SetActive(false);
				Text[5].SetActive(false);
			}
		}
	}
	i = 0;
	while(i<6)
	{
		if(kids[i].name == i.ToString())
		{
			i +=1;
			if(i == 6)
			{
				Text[0].SetActive(false);
				Text[1].SetActive(false);
				Text[2].SetActive(false);
				Text[3].SetActive(false);
				Text[4].SetActive(false);
				Text[5].SetActive(false);
				Text[6].SetActive(false);
				Text[7].SetActive(true);
				Play = false;
				TheEnd();
			}
		}
		else{
			i = 6;
		}
		
	}
}
function TheEnd()
{
	yield WaitForSeconds(4.5);
	Text[7].SetActive(false);
	Text[7].audio.enabled = false;
	play = false;
	Camera.main.transform.position.y = 132.84;
}
function Disc()
{
	Text[2 + part].SetActive(false);
	yield WaitForSeconds(2);
	Text[1].SetActive(false);
	if(!Text[0].activeInHierarchy)
	{
		Text[2 + part].SetActive(true);
		Text[6].SetActive(false);
		Text[7].SetActive(false);
	}
}
function Correct()
{
	part += 3;
	yield WaitForSeconds(1);
	disappear = true;
	yield WaitForSeconds(1);
	part -= 3;
	Text[0].SetActive(false);
	part += 1;
	Text[2 + part].SetActive(true);
	Text[6].SetActive(false);
	Text[7].SetActive(false);
	if(Text[4].activeInHierarchy)
	{
		Play = true;
	}
}
function Disable()
{
	var i:int = 0;
	while(i<6)
	{
		if(i < 2)
		{
			Cor[i].renderer.material.color.a = 1;
			Cor[i].SetActive(false);
		}
		Discor[i].renderer.material.color.a = 1;
		Discor[i].SetActive(false);
		i += 1;
	}
}