using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class control_ImageTarget3 : MonoBehaviour,  Vuforia.IVirtualButtonEventHandler {

	public static int turn =3 ;
	public static int char_1_loc =3; //range 3~10
	public static int char_2_loc =3;
	public static int char_3_loc =3;
	public static int countdown =3;

	public static int h_price_3 =3800;
	public static int h_price_4 =1200;
	public static int h_price_5 =3500;
	public static int h_price_6 =4500;
	public static int h_price_7 =4000;
	public static int h_price_8 =700;
	public static int h_price_9 =500;
	public static int h_price_10=1000;

	public static int o_house_3 =0;
	public static int o_house_4 =0;
	public static int o_house_5 =0;
	public static int o_house_6 =0;
	public static int o_house_7 =0;
	public static int o_house_8 =0;
	public static int o_house_9 =0;
	public static int o_house_10=0;
	
	public static int char_1_money=10000;
	public static int char_2_money=9000;
	public static int char_3_money=89000;
	
	private GameObject Char2;
	private GameObject Char3;
	private GameObject Char4;

	private GameObject Cube1;
	private GameObject Cube2;
	private GameObject ball;


	private GameObject t;
	private GameObject p;

	private GameObject Sphere;
	public float speed= 1000.0f ;
	
	private float timer = 0.0f;
	private bool isTimerValid = false;

	private int tem1, tem2, tem3;
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

		Cube1= transform.FindChild ("Cube").gameObject;
		Cube2= transform.FindChild ("Cube2 ").gameObject;

		ball= transform.FindChild ("Sphere").gameObject;
		t= transform.FindChild ("New Text_t ").gameObject;
		p= transform.FindChild ("New Text_p").gameObject;
	}
	public void Update()
	{

		if(char_1_loc ==3)
			Char2.transform.position = new Vector3 (8.0f , 0.0f, 8.0f);
		else
			Char2.transform.position = new Vector3 (8.0f , -5500.0f, 8.0f);

		if(char_2_loc ==3)
			Char3.transform.position = new Vector3 (8.0f , 0.0f, -8.0f);
		else
			Char3.transform.position = new Vector3 (8.0f , -5500.0f, -8.0f);

		if(char_3_loc ==3)
			Char4.transform.position = new Vector3 (-8.0f , 0.0f, -5.0f);
		else
			Char4.transform.position = new Vector3 (-88.0f , -5500.0f, -5.0f);


		p.GetComponent<TextMesh>().text = h_price_3.ToString()+"$";

		if (turn == 1) {
			if(char_1_money<0)//die
				turn= (turn)%3+1;
			else{
     			 Cube1.GetComponent<Renderer> ().material.color = Color.red;
			     Cube2.GetComponent<Renderer> ().material.color = Color.red;//cube change color

			     t.GetComponent<TextMesh>().text = char_1_money.ToString()+"$";
			     t.GetComponent<Renderer> ().material.color = Color.red;
			  }
		} else if (turn == 2) {
			if(char_2_money<0)
				turn= (turn)%3+1;
			else{
			  Cube1.GetComponent<Renderer> ().material.color = Color.blue;
			  Cube2.GetComponent<Renderer> ().material.color = Color.blue;
			  t.GetComponent<TextMesh>().text = char_2_money.ToString()+"$";
			  t.GetComponent<Renderer> ().material.color = Color.blue;
			}

		} else {
			if(char_3_money<0)
				turn= (turn)%3+1;
			else{
			Cube1.GetComponent<Renderer> ().material.color = Color.yellow;
			Cube2.GetComponent<Renderer> ().material.color = Color.yellow;
			t.GetComponent<TextMesh>().text = char_3_money.ToString()+"$";
			t.GetComponent<Renderer> ().material.color = Color.yellow;
			}
		}
		tem1 = char_1_loc - 2;
		tem2 = char_2_loc - 2;
		tem3 = char_3_loc - 2;
		print ("turn is"+turn+"  red_loc:"+ tem1+"  blue_loc:"+ tem2 +"  yellow_loc:"+tem3 );

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
		if (turn == 1 && char_1_loc == 3 || turn == 2 && char_2_loc == 3 || turn == 3 && char_3_loc == 3) {
			
			if (vb.name == "VirtualButton1") { //pay money when end your turn
		
				print ("button pressed, starting timer");
				StartTimer (2.0f);


				print ("A");
			}
		
			if (vb.name == "VirtualButton2") {//buy
				Sphere.GetComponent<MeshRenderer> ().enabled = true;
				Sphere.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);

				if (turn == 1) {
					ball.GetComponent<Renderer> ().material.color = Color.red;
					char_1_money -= h_price_3;
					o_house_3 = 1;
					h_price_3 += 500;//house price increase

				} else if (turn == 2) {
					ball.GetComponent<Renderer> ().material.color = Color.blue;
					char_2_money -= h_price_3;
					o_house_3 = 2;
					h_price_3 += 500;
				} else {
					ball.GetComponent<Renderer> ().material.color = Color.yellow;
					char_3_money -= h_price_3;
					o_house_3 = 3;
					h_price_3 += 500;
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
		// do stuff here!
		print("doing stuff");

		if (turn == 1) {
			if (o_house_3 == 2 || o_house_3 == 3)
				char_1_money -= (int)(h_price_3 / 4);
		} else if (turn == 2) {
			if (o_house_3 == 1 || o_house_3 == 3)
				char_2_money -= (int)(h_price_3 / 4);
		} else {
			if (o_house_3 == 1 || o_house_3 == 2)
				char_3_money -= (int)(h_price_3 / 4);
		}
		if(turn==3)
			countdown=countdown-1;
		turn = (turn) % 3+1;
		
		
		
	}
}
