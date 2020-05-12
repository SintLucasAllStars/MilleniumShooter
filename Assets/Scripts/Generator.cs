using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public static Generator instance;

	public GameObject prefab;
	public float step = 0.01f;
	public float radius = 1;
	public int petals = 4;
	public float petalOffset = 3;
	public Vector3Int offsets;
	Vector3 initialPos;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this);
		}
	}

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C))
		{
			CleanPath();
		}
		else if (Input.GetKeyDown(KeyCode.G))
		{
			GeneratePath();
		}
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
