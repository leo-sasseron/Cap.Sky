using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Robozao : MonoBehaviour {
    Animator roboAnim;
    public ControlaCoisasBot CCB;
    public float distanciaPraParar;
    public Transform corpo, cabeça, player;
    Vector3 CorpoSeguePlayer, cabeçaSeguePlayer;

    // Use this for initialization
    void Start () {
        roboAnim = GetComponent<Animator>();

        roboAnim.SetBool("Move",true);
	}
	
	// Update is called once per frame
	void Update () {
        if (CCB.morto)
        {

            roboAnim.SetBool("Move", false);


        }
        
        float distanciaPlayer = Vector3.Distance(corpo.transform.position, player.transform.position);
       // print(distanciaPlayer);
        if (distanciaPlayer <= distanciaPraParar)
        {
            
         

        }

      
     

    }
}
