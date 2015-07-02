using UnityEngine;
using System.Collections;

public class move_move : MonoBehaviour {
	public float speed= 1000.0f ;
	// Use this for initialization
	void Start () {
		//Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {  
	    if (Input.GetKey (KeyCode.D))
			transform.position += new Vector3 (speed * Time.deltaTime * 10 , 0.0f, 0.0f);
		if (Input.GetKey (KeyCode.A))
			transform.position -= new Vector3 (speed * Time.deltaTime * 10 , 0.0f, 0.0f);

	}
}
