using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Touching : MonoBehaviour {

	private Hand hand;
	GameObject lamp;
	Transform other;
	public float distance=100;

	public bool debugMode;
	public GameObject debugSphere;

	// Use this for initialization
	void Start () {
		hand = GetComponent<Hand> ();
		lamp = GameObject.FindGameObjectWithTag ("Lamp");
		other = lamp.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hand != null & hand.controller.GetHairTriggerDown ())
			Debug.Log (distance);
		//Debug.Log (distance);
		if(!debugMode)
			distance = Vector3.Distance (other.position, transform.position);
		else
			distance = Vector3.Distance (other.position, debugSphere.transform.position);
	}
}
