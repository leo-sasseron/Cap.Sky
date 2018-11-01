using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spineRobo : MonoBehaviour {
    public ControlaCoisasBot CCB;
    Rigidbody rb;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
		if (CCB.morto)
        {

           
            rb.useGravity = true;
            rb.isKinematic = false;
            print("asdasdasd");
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).SetParent(null);

            }

        }
	}
}
