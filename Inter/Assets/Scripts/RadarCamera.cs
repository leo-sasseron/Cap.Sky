using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class RadarCamera : MonoBehaviour {

	public GameObject Player;

	public GameObject[] TrackedObjects;
	IList<GameObject> radarObjects;
	public GameObject radarPrefab;
	IList<GameObject> borderObjects;
	public float switchDistance;
	public Transform helpTransform;

	// Use this for initialization
	void Start () {

		CreateRadarObjects ();
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Player.transform.position;
		//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Player.transform.rotation.eulerAngles.z);

		for (int i = 0; i < radarObjects.Count; i++) 
		{
			if (Vector3.Distance (radarObjects [i].transform.position, transform.position) > switchDistance) 
			{
				helpTransform.LookAt (radarObjects[i].transform);
				borderObjects [i].transform.position = transform.position + switchDistance * helpTransform.forward;
				borderObjects [i].layer = LayerMask.NameToLayer ("Radar");
				radarObjects [i].layer = LayerMask.NameToLayer ("Invisible");
			} 
			else 
			{
				borderObjects [i].layer = LayerMask.NameToLayer ("Invisible");
				radarObjects [i].layer = LayerMask.NameToLayer ("Radar");
			}
		}
		
	}

	void CreateRadarObjects()
	{

		radarObjects = new List<GameObject> ();
		borderObjects = new List<GameObject> ();
		foreach(GameObject o in TrackedObjects)
		{
			GameObject k = Instantiate (radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
			radarObjects.Add (k);
			GameObject j = Instantiate (radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
			radarObjects.Add (j);
		}
		
	}
}
