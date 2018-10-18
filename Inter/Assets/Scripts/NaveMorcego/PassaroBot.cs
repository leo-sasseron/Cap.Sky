using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaroBot : MonoBehaviour {
    public GameObject Desliga1, Desliga2, liga;





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            liga.SetActive(true);
            liga.transform.position = this.transform.position;
            liga.transform.rotation = this.transform.rotation;
            Desliga1.SetActive(false);
            Desliga2.SetActive(false);


        }
    }
}
