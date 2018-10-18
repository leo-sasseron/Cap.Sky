using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderCode : MonoBehaviour {

int LayerCollider;
    
	// Use this for initialization
	void Start () {
        


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Physics.IgnoreLayerCollision(2, LayerCollider);
        Physics.IgnoreLayerCollision(2, 1);
        Physics.IgnoreLayerCollision(2, 9);
        


    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.layer != 31 && other.gameObject.layer != 1) {
            Debug.Log(other.gameObject.layer);
        LayerCollider = other.gameObject.layer;
            
        }
    }
}
