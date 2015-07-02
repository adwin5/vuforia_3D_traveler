using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VirtualButton_Dice : MonoBehaviour,  Vuforia.IVirtualButtonEventHandler  {

	// Use this for initialization
	public static bool press=false;
	void Start () {
		Vuforia.VirtualButtonBehaviour [] btn = transform.GetComponentsInChildren<Vuforia.VirtualButtonBehaviour> ();
		foreach (Vuforia.VirtualButtonBehaviour btns in btn) {
			btns.RegisterEventHandler(this);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnButtonPressed( Vuforia.VirtualButtonAbstractBehaviour vb)
	{
		print ("pressout");
		press = true;
		
	}
	public void OnButtonReleased( Vuforia.VirtualButtonAbstractBehaviour vb)
	{
	}
}
