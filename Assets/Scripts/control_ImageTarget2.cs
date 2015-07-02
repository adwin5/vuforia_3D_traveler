using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class control_ImageTarget2 : MonoBehaviour,  Vuforia.IVirtualButtonEventHandler {
	
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
		Sphere = transform.FindChild ("chou78").gameObject;
		
	}
	public void Update()
	{
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
		if (vb.name == "VirtualButton2_1") {
			Sphere.GetComponent<MeshRenderer>().enabled = false;
			Sphere.transform.position -= new Vector3 (0.0f , 500.0f, 0.0f);
			//Sphere.GetComponent<Renderer>().material.color= Color.red;    //change color to red
			//Sphere.transform.position += new Vector3 (5.0f , 0.0f, 0.0f); //move object
			print ("A");} 
		
		if (vb.name == "VirtualButton2_2") {
			Sphere.GetComponent<MeshRenderer>().enabled = true;
			Sphere.transform.position += new Vector3 (0.0f , 500.0f, 0.0f);
			//Sphere.GetComponent<Renderer>().material.color= Color.blue;    //change color to blue
			//Sphere.transform.position -= new Vector3 (5.0f , 0.0f, 0.0f);  //move object
			print ("B");}
		
		print("button pressed, starting timer");
		StartTimer(2.0f);
		
	}
	public void OnButtonReleased( Vuforia.VirtualButtonAbstractBehaviour vb)
	{
		//Sphere.GetComponent<Renderer>().enabled = true;
		print ("pressout");
		if (vb.name == "VirtualButton2_1") {
			//Sphere.GetComponent<Renderer>().material.color= Color.white;  //change color
			print ("C");}
		if (vb.name == "VirtualButton2_2") {
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
		//Sphere.GetComponent<Renderer>().material.color= Color.yellow;
		float i;
		Sphere.GetComponent<MeshRenderer>().enabled = false;
		Sphere.transform.position -= new Vector3 (5.0f , 0.0f, 0.0f);
		/*
		for (i= counter; i>0.0f; i-= Time.deltaTime) {
			Sphere.transform.position -= new Vector3 ( 0.0f, speed * Time.deltaTime  , 0.0f);
		}
		*/
	}
}
