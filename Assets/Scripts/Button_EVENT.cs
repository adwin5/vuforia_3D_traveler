using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button_EVENT : MonoBehaviour, Vuforia.IVirtualButtonEventHandler {
	
	// Use this for initialization
	void Start () {
		Vuforia.VirtualButtonBehaviour [] btn = transform.GetComponentsInChildren<Vuforia.VirtualButtonBehaviour> ();
		foreach (Vuforia.VirtualButtonBehaviour btns in btn) {
			btns.RegisterEventHandler(this);
		}
	}

	public void OnButtonPressed(Vuforia.VirtualButtonAbstractBehaviour  vb)
	{
		print ("press");
	}
	public void OnButtonReleased(Vuforia.VirtualButtonAbstractBehaviour vb)
	{
		print ("press2");
	}
	
}