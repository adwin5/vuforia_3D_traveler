using UnityEngine;
using System.Collections;

public class control_ImageTarget10 :  MonoBehaviour,  Vuforia.IVirtualButtonEventHandler {

	private GameObject Char2;
	private GameObject Char3;
	private GameObject Char4;

	private GameObject Sphere;
	private GameObject Middle;

	private GameObject txt1;
	private GameObject txt2;

	public float speed= 1000.0f ;
	
	private float timer = 0.0f;
	private bool isTimerValid = false;
	
	private float counter = 5.0f;
	public static bool press=false;

	private int a1=0,a2=0,a3=0;
	private int top,sec,tem;
	// Use this for initialization
	void Start () {
		Vuforia.VirtualButtonBehaviour [] btn = transform.GetComponentsInChildren<Vuforia.VirtualButtonBehaviour> ();
		foreach (Vuforia.VirtualButtonBehaviour btns in btn) {
			btns.RegisterEventHandler(this);
		}

		Sphere = transform.FindChild ("Baker_house").gameObject;
		txt1= transform.FindChild ("aaa").gameObject;
		txt2= transform.FindChild ("bbb").gameObject;

	}
	public void Update()
	{
		a1 = 0;a2 = 0;a3 = 0;
		//count
		if (control_ImageTarget3.o_house_3 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_3 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_3 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_4 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_4 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_4 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_5 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_5 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_5 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_6 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_6 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_6 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_7 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_7 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_7 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_8 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_8 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_8 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_9 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_9 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_9 == 3)
			a3++;
		//
		if (control_ImageTarget3.o_house_10 == 1)
			a1++;
		else if (control_ImageTarget3.o_house_10 == 2)
			a2++;
		else if (control_ImageTarget3.o_house_10 == 3)
			a3++;
		//


		if (control_ImageTarget3.countdown != 0) {

			txt1.GetComponent<TextMesh> ().text = "Num: " + control_ImageTarget3.countdown.ToString ();//show num of turn;
			txt2.GetComponent<TextMesh> ().text = "Red_1: " + a1.ToString () +
				" Blue2: " + a2.ToString () + " Yellow3: " + a3.ToString ();//show num of house
		} else {
			txt1.GetComponent<TextMesh> ().text = "End";

			if(a1==a2&&a1==a3 || a1==a2&& a1>a3 ||  a1==a3&& a1>a2 ||  a2==a3&& a2>a1 )//3 same
				txt2.GetComponent<TextMesh> ().text = "no winner";
			else{
				if(a1>a2  &&  a1>a3 )//3 same
					txt2.GetComponent<TextMesh> ().text = "play_red_1_winner";
				if(a2>a1  &&  a2>a3 )//3 same
					txt2.GetComponent<TextMesh> ().text = "play_blue_2_winner";
				if(a3>a1 &&  a3>a2 )//3 same
					txt2.GetComponent<TextMesh> ().text = "play_yellow_3_winner";

			  /*
			 if(a1>=a2)
				top=1;
			 else
				top=2;
			 if(a3>=a1)
				top=3;
			 else
				top=1;

			 if(a3>=a2)
				top=3;
             else
				top=2;

			 if(top==1)
				txt2.GetComponent<TextMesh> ().text = "play_red_1_winner";
			 else if(top==2)
				txt2.GetComponent<TextMesh> ().text = "play_blue_2_winner";
			 else if(top==3)
				txt2.GetComponent<TextMesh> ().text = "play_yellow_3_winner";
				*/
			
			}
		}

		if (isTimerValid)
		{
			timer -= Time.deltaTime;
			
			if (timer <= 0.0f)
			{
				TimeIsUp();
				InvalidateTimer();
			}
		}
	}
	
	public void OnButtonPressed( Vuforia.VirtualButtonAbstractBehaviour vb)
	{


		print ("press");print ("vivian");
		if (vb.name == "VirtualButton1") {

			print ("A");} 
		
		if (vb.name == "VirtualButton2") {

			print ("B");}
		
		print("button pressed, starting timer");
		StartTimer(2.0f);
		
	}
	public void OnButtonReleased( Vuforia.VirtualButtonAbstractBehaviour vb)
	{
		//Sphere.GetComponent<Renderer>().enabled = true;
		print ("pressout");
		if (vb.name == "VirtualButton1") {
			//Sphere.GetComponent<Renderer>().material.color= Color.white;  //change color
			print ("C");}
		if (vb.name == "VirtualButton2") {
			Sphere.GetComponent<Renderer>().material.color= Color.white;    //change color
			print ("D");}
		print("button released, invalidating timer");
		InvalidateTimer();
	}
	
	private void StartTimer(float seconds)
	{
		timer = seconds;
		isTimerValid = true;
	}
	private void InvalidateTimer()
	{
		timer = 0.0f;
		isTimerValid = false;
	}
	private void TimeIsUp()
	{
		// do stuff here!
		print("doing stuff");
		press = true;

	}
}