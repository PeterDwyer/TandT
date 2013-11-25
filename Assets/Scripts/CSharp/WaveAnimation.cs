using UnityEngine;
using System.Collections;

public class WaveAnimation : MonoBehaviour 
{	
	public Material[] Materials;
	public int x;
	public int y;
	public int i;
	public float delta;
	public float Speed = 20.0f;
	public bool play;
	public int n;
	public float add;
	
	void Start () 
	{
		play = true;
	}
	
	void Update () 
	{
		if(play)
		{
			//renderer.material = Materials[Anim];
			delta += Time.deltaTime;
			if(delta>1.0/Speed)
			{
				if(i == 0)
				{
					if(n == 0)
					{
						n = 1;
					}
					else if(n == 1)
					{
						n = 0;
					}
					Change();
				}
				
				i += 1;
				x += 1;
				delta = 0.0f;
				
				if(y == 0 && x>0)
				{
					y = 1;
					x = 0;
				}
				
				if(x>2)
				{
					y += 1;
					x = 0;
					if(y>5)
					{
						y = 0;
					}
				}
				
				if(i>15)
				{
					i = 0;
				}
				
				if(y == 0)
				{
					add = 0.0015f;
				}
				else
				{
					add = 0f;
				}
			}
			
			renderer.material.SetTextureOffset ("_MainTex", new Vector2((x)*0.332f,-0.0013f -y*0.16642f+add-add*0.0008f*4f));
		}
	}
	
	void Change()
	{
		renderer.material = Materials[n];
		renderer.material.SetTextureOffset ("_MainTex", new Vector2((x)*0.332f,-0.0013f -y*0.16642f+add-add*0.0008f*4f));
	}
}