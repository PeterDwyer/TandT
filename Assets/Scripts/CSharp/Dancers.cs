using UnityEngine;
using System.Collections;

public class Dancers : MonoBehaviour 
{
	
	public Material[] Materials;
	public int x;
	public int y;
	public int i;
	public float delta;
	public float Speed = 20.0f;
	public bool play;
	public AudioClip[] Sounds;
	public int m;
	
	IEnumerator Start () 
	{
		yield return new WaitForSeconds(1.3f);
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
				i += 1;
				x += 1;
				delta = 0.0f;
				if(x>5)
				{
					y += 1;
					x = 0;
					if(y>3)
					{
						y = 0;
					}
				}
	
				if(i>23)
				{
					i = 0;
				}
				if(m != 4)
				{
					if(i == 17 || i == 5)
					{
						audio.Play();
					}	
				}
				else
				{
					if(i == 17)
					{
						audio.Play();
					}
				}
			}
			renderer.material.SetTextureOffset ("_MainTex", new Vector2((x)*0.1666667f,0.0005f +1-y*0.25f));
		}
	}
	
	void Change( int n )
	{
		if(n == 10)
		{
			play = false;
		}
		else
		{
			m = n;
			renderer.material = Materials[n];
			audio.clip = Sounds[n-1];
			renderer.material.SetTextureOffset ("_MainTex", new Vector2((x)*0.1666667f,0.0005f+1-y*0.25f));
		}
	}
}