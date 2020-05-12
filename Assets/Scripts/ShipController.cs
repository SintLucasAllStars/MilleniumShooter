using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public GameObject explosion;
	public float thrust = 0.01f;
	float angle;
	int hp = 100;

	public float step = 0.01f;
	public float radius = 1;
	public int petals = 4;
	public float petalOffset = 3;
	public Vector3Int offsets;
	Vector3 initialPos;

	// Use this for initialization
	void Start () {
		GeneratePath();
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GetPositionAtAngle(angle);
		transform.LookAt(GetPositionAtAngle(angle + thrust*Time.deltaTime));
		angle += thrust*Time.deltaTime;
		if(2*Mathf.PI - angle < 0.01f)
		{
			CleanPath();
			GeneratePath();
			angle = 0;
		}
	}

	void OnCollisionEnter(Collision other){
		Destroy(other.gameObject);
		
		if(hp < 0)
		{
			Destroy(gameObject);
		}
		else
		{
			hp--;
		}
		Instantiate(explosion, other.contacts[0].point, Quaternion.identity);
	}

	public void GeneratePath()
	{
		radius = Random.Range(8f, 15f);
		petals = Random.Range(0, 9);
		petalOffset = Random.Range(10f, 40f);
		// for(float a=0; a<2*Mathf.PI; a=a+step)
		// {
		// 	Instantiate(prefab, GetPositionAtAngle(a), Quaternion.identity);
		// }
	}

	public void CleanPath()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Part"))
		{
			Destroy(go);
		}
	}

	public Vector3 GetPositionAtAngle(float angle)
	{
		float petalAdd = Mathf.Cos(angle * petals) * petalOffset;

		float x = Mathf.Cos(angle*offsets.x) * (radius + petalAdd) + initialPos.x;
		float y = Mathf.Sin(angle*offsets.y) * (radius + petalAdd) + initialPos.y;
		float z = Mathf.Cos(angle*offsets.z) * (radius + petalAdd) + initialPos.z;

		return new Vector3(x,y,z);
	}
}
