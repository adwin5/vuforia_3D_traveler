using UnityEngine;
using System.Collections;



public class rolld :MonoBehaviour {

	// Use this for initialization

	//public int result;
	double tim=0;
	float fric=0f;
	//public int diceside;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*tim = tim + Time.deltaTime;
		if (tim < 3) {
			//transform.Translate (new Vector3 (-60, 0, -60) * Time.deltaTime*(1-fric));
			transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime * 15*(1-fric));
			fric=fric+Time.deltaTime/3;


		}
		diceside=value;
		*/

	}
	/*
	override protected Vector3 HitVector(int side)
	{
		switch (side)
		{
		case 1:
			result=1;
			return new Vector3(0F, 0F, 1F);
		case 2:
			result=2;
			return new Vector3(0F, -1F, 0F);
			
		case 3:
			result=3;
			return new Vector3(-1F, 0F, 0F);
		case 4:
			result=4;
			return new Vector3(1F, 0F, 0F);
		case 5: 
			result=5;
			return new Vector3(0F, 1F, 0F);
		case 6:
			result=6;
			return new Vector3(0F, 0F, -1F);
		}
		return Vector3.zero;
	}*/
	/*
	class myside:Die
	{
		//public int result;	
		override protected Vector3 HitVector(int side)
		{
			switch (side)
			{
			case 1:
				result=1;
				return new Vector3(0F, 0F, 1F);
			case 2:
				result=2;
				return new Vector3(0F, -1F, 0F);
				
			case 3:
				result=3;
				return new Vector3(-1F, 0F, 0F);
			case 4:
				result=4;
				return new Vector3(1F, 0F, 0F);
			case 5: 
				result=5;
				return new Vector3(0F, 1F, 0F);
			case 6:
				result=6;
				return new Vector3(0F, 0F, -1F);
			}
			return Vector3.zero;
		}
	}*/

}
