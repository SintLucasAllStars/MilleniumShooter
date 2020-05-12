using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeScript : MonoBehaviour {

	public float speed = 1;
	public float radius = 10;
	public GameObject prefab;
	public int petals = 4;
	public float petalOffset = 3;


	// Use this for initialization
	void Start () {
			}
	
	// Update is called once per frame
	void Update () {
		float petalAdd = Mathf.Cos(Time.realtimeSinceStartup * speed * petals) * petalOffset;
		Vector3 pos = new Vector3(Mathf.Cos(Time.realtimeSinceStartup * speed) * (radius+petalAdd), 0, Mathf.Sin(Time.realtimeSinceStartup * speed)* (radius+petalAdd));
		GameObject go = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
		transform.position = pos;
		Destroy(go, 2);
	}
}
