using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStatus : MonoBehaviour {
	public bool isTouching = false;
	public bool isNear = false;
	public float touchDist;
	public float nearDist;
	public GameObject hand0;
	public GameObject hand1;
	Touching hand0t;
	Touching hand1t;
	// Use this for initialization
	void Start () {
		hand0t = hand0.GetComponent<Touching>();
		hand1t = hand1.GetComponent<Touching>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hand0t.distance < hand1t.distance) {
			if (hand0t.distance < touchDist) 
			{
				isNear = false;
				isTouching = true;
			}
			if (hand0t.distance > touchDist && hand0t.distance < nearDist) 
			{
				isTouching = false;
				isNear = true;
			}
			if (hand0t.distance > nearDist) 
			{
				isNear = false;
				isTouching = false;
			}
		} 
		else 
		{
			//Debug.Log ("yo");
			if (hand1t.distance < touchDist) 
			{
				isNear = false;
				isTouching = true;
			}
			if (hand1t.distance > touchDist && hand1t.distance < nearDist) 
			{
				//Debug.Log ("Hi");
				isTouching = false;
				isNear = true;
			}
			if (hand1t.distance > nearDist) 
			{
				isNear = false;
				isTouching = false;
			}
		}
	}
}
