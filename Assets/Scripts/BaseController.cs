using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {

	public GameObject laser;
	public Transform emitter1;
	public Transform emitter2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1"))
		{
			Instantiate(laser, emitter1.position, Camera.main.transform.rotation);
			Instantiate(laser, emitter2.position, Camera.main.transform.rotation);
		}
	}
}
