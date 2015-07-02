using UnityEngine;
using System.Collections;

public class control_ImageTarget10_new:  MonoBehaviour,  Vuforia.IVirtualButtonEventHandler {
	
	private GameObject Char2;
	private GameObject Char3;
	private GameObject Char4;

	private GameObject ball;
	//***
	private GameObject Cube1;
	private GameObject Cube2;

	//**
	private GameObject t;
	private GameObject p;

	private GameObject Sphere;
	public float speed= 1000.0f ;
	
	private float timer = 0.0f;
	private bool isTimerValid = false;
	
	private float counter = 5.0f;
	// Use this for initialization
	void Start () {
		Vuforia.VirtualButtonBehaviour [] btn = transform.GetComponentsInChildren<Vuforia.VirtualButtonBehaviour> ();
		foreach (Vuforia.VirtualButtonBehaviour btns in btn) {
			btns.RegisterEventHandler(this);
		}
		Sphere = transform.FindChild ("Baker_house").gameObject;
		Char2= transform.FindChild ("Char_2").gameObject;
		Char3= transform.FindChild ("Char_3").gameObject;
		Char4= transform.FindChild ("Char_4").gameObject;

		//***
		Cube1= transform.FindChild ("Cube").gameObject;
		Cube2= transform.FindChild ("Cube1").gameObject;
		ball= transform.FindChild ("Sphere1").gameObject;
		//**
		t= transform.FindChild ("New Text_t").gameObject;
		p= transform.FindChild ("New Text_p").gameObject;
	}
	public void Update()
	{
		if(control_ImageTarget3.char_1_loc ==10)
			Char2.transform.position = new Vector3 (-584.0f +8.0f , 0.0f, 8.0f);
		else
			Char2.transform.position = new Vector3 (8.0f , -500.0f, 8.0f);
		
		if(control_ImageTarget3.char_2_loc ==10)
			Char3.transform.position = new Vector3 (-584.0f +8.0f , 0.0f, -8.0f);
		else
			Char3.transform.position = new Vector3 (8.0f , -500.0f, -8.0f);
		
		if(control_ImageTarget3.char_3_loc ==10)
			Char4.transform.position = new Vector3 (-584.0f -8.0f , 0.0f, -5.0f);
		else
			Char4.transform.position = new Vector3 (-88.0f , -500.0f, -5.0f);

		p.GetComponent<TextMesh>().text = control_ImageTarget3.h_price_10.ToString()+"$";
		//cube follows turn
		if (control_ImageTarget3.turn == 1) {
			if(control_ImageTarget3.char_1_money<0)         //jump over
				control_ImageTarget3.turn= (control_ImageTarget3.turn)%3+1;
			else{
				Cube1.GetComponent<Renderer> ().material.color = Color.red;
				Cube2.GetComponent<Renderer> ().material.color = Color.red;//cube change color
				
				t.GetComponent<TextMesh>().text = control_ImageTarget3.char_1_money.ToString()+"$";
				t.GetComponent<Renderer> ().material.color = Color.red;
			}
		} else if (control_ImageTarget3.turn == 2) {
			if(control_ImageTarget3.char_2_money<0)
				control_ImageTarget3.turn= (control_ImageTarget3.turn)%3+1;
			else{
				Cube1.GetComponent<Renderer> ().material.color = Color.blue;
				Cube2.GetComponent<Renderer> ().material.color = Color.blue;
				t.GetComponent<TextMesh>().text = control_ImageTarget3.char_2_money.ToString()+"$";
				t.GetComponent<Renderer> ().material.color = Color.blue;
			}
			
		} else {
			if(control_ImageTarget3.char_3_money<0)
				control_ImageTarget3.turn= (control_ImageTarget3.turn)%3+1;
			else{
				Cube1.GetComponent<Renderer> ().material.color = Color.yellow;
				Cube2.GetComponent<Renderer> ().material.color = Color.yellow;
				t.GetComponent<TextMesh>().text = control_ImageTarget3.char_3_money.ToString()+"$";
				t.GetComponent<Renderer> ().material.color = Color.yellow;
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
		
		if (control_ImageTarget3.turn == 1 && control_ImageTarget3.char_1_loc == 10 
			|| control_ImageTarget3.turn == 2 && control_ImageTarget3.char_2_loc == 10
			|| control_ImageTarget3.turn == 3 && control_ImageTarget3.char_3_loc == 10) {

			if (vb.name == "VirtualButton1") {


				print ("button pressed, starting timer");
				StartTimer (2.0f);
				print ("A");
			} 
		
			if (vb.name == "VirtualButton2") {
				Sphere.GetComponent<MeshRenderer> ().enabled = true;
				Sphere.transform.position = new Vector3 (-584.0f, 0.0f, 0.0f);

				if (control_ImageTarget3.turn == 1) {
					ball.GetComponent<Renderer> ().material.color = Color.red;
					control_ImageTarget3.char_1_money -= control_ImageTarget3.h_price_10;
					control_ImageTarget3.o_house_10 = 1;
					control_ImageTarget3.h_price_10 += 500;//house price increase
				} else if (control_ImageTarget3.turn == 2) {
					ball.GetComponent<Renderer> ().material.color = Color.blue;
					control_ImageTarget3.char_2_money -= control_ImageTarget3.h_price_10;
					control_ImageTarget3.o_house_10 = 2;
					control_ImageTarget3.h_price_10 += 500;//house price increase
				} else {
				
					ball.GetComponent<Renderer> ().material.color = Color.yellow;
					control_ImageTarget3.char_3_money -= control_ImageTarget3.h_price_10;
					control_ImageTarget3.o_house_10 = 3;
					control_ImageTarget3.h_price_10 += 500;//house price increase
				
				}


				print ("B");
			}
		

		}
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
		if (control_ImageTarget3.turn == 1) {
			if (control_ImageTarget3.o_house_10 == 2 || control_ImageTarget3.o_house_10 == 3)
				control_ImageTarget3.char_1_money -= (int)(control_ImageTarget3.h_price_10 / 4);
		} else if (control_ImageTarget3.turn == 2) {
			if (control_ImageTarget3.o_house_10 == 1 || control_ImageTarget3.o_house_10 == 3)
				control_ImageTarget3.char_2_money -= (int)(control_ImageTarget3.h_price_10 / 4);
		} else {
			if (control_ImageTarget3.o_house_10 == 1 || control_ImageTarget3.o_house_10 == 2)
				control_ImageTarget3.char_3_money -= (int)(control_ImageTarget3.h_price_10 / 4);//**
		}

		if(control_ImageTarget3.turn==3)
			control_ImageTarget3.countdown = control_ImageTarget3.countdown-1;
		control_ImageTarget3.turn = (control_ImageTarget3.turn) % 3 + 1;

	}
}