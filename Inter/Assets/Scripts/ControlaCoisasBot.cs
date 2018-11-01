using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCoisasBot : MonoBehaviour {


  
    public bool morto = false;
    public bool DesligaAnim;
    public GameObject desligaEssaCaceta;


   public Animator anim;

	// Use this for initialization
	void Start () {
       
       
    }
	
	// Update is called once per frame
	void Update () {

        anim.enabled = DesligaAnim = true;

        if (morto)
        {
            anim = GetComponent<Animator>();
            anim.enabled = false;
            Invoke("vsf", 0.1f);

        }

	}
   
    
    private void vsf()
    {
        desligaEssaCaceta.SetActive(false);
    }
}
